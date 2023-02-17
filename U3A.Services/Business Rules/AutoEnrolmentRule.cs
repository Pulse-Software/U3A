using DevExpress.Blazor;
using DevExpress.Utils.Serializing;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task AutoEnrolParticipantsAsync(U3ADbContext dbc, Term SelectedTerm,
                              bool DoFullEnrolment, 
                              bool IsClassAllocationDone,
                              bool ForceEmailQueue) {
            List<Enrolment> enrolmentsToProcess;
            List<Person> CourseLeaders;
            foreach (var course in await dbc.Course
                                            .Include(x => x.Classes)
                                            .Where(x => x.Year== SelectedTerm.Year)
                                            .ToListAsync()) {
                CourseLeaders = new List<Person>();
                foreach (var c in course.Classes) {
                    if (c.Leader != null && !CourseLeaders.Contains(c.Leader)) { CourseLeaders.Add(c.Leader); }
                    if (c.Leader2 != null && !CourseLeaders.Contains(c.Leader2)) { CourseLeaders.Add(c.Leader2); }
                    if (c.Leader3 != null && !CourseLeaders.Contains(c.Leader3)) { CourseLeaders.Add(c.Leader3); }
                }
                if (course.CourseParticipationTypeID == (int?)ParticipationType.SameParticipantsInAllClasses) {
                    enrolmentsToProcess = dbc.Enrolment
                                                .Include(x => x.Person).ThenInclude(x => x.Enrolments)
                                                .AsEnumerable()
                                                .Where(x => x.TermID == SelectedTerm.ID 
                                                                && x.CourseID == course.ID
                                                                && x.Person.DateCeased == null 
                                                                && !CourseLeaders.Contains(x.Person)
                                                                && x.Person.FinancialTo >= SelectedTerm.Year)
                                                .ToList();
                    await ProcessEnrolments(dbc, course, enrolmentsToProcess,DoFullEnrolment,ForceEmailQueue);
                }
                else {
                    foreach (var courseClass in course.Classes) {
                        enrolmentsToProcess = await dbc.Enrolment
                                                    .Include(x => x.Person).ThenInclude(x => x.Enrolments)
                                                    .Where(x => x.TermID == SelectedTerm.ID 
                                                                    && x.ClassID == courseClass.ID
                                                                    && x.Person.DateCeased == null
                                                                    && x.Person.FinancialTo >= SelectedTerm.Year)
                                                    .ToListAsync();
                        await ProcessEnrolments(dbc, course, enrolmentsToProcess, DoFullEnrolment,ForceEmailQueue);
                    }
                }
            }
            await BusinessRule.CreateEnrolmentSendMailAsync(dbc);
            var term = await dbc.Term.FindAsync(SelectedTerm.ID);
            term.IsClassAllocationFinalised = IsClassAllocationDone;
            dbc.Update(term);
            await dbc.SaveChangesAsync();
        }
        private static async Task ProcessEnrolments(U3ADbContext dbc, Course course,
                                    List<Enrolment> enrolments, bool DoFullEnrolment, bool ForceEmailQueue) {
            var settings = await dbc.SystemSettings.FirstAsync();
            if (string.IsNullOrWhiteSpace(settings.AutoEnrolRemainderMethod)) settings.AutoEnrolRemainderMethod = "Random";
            // Set everyone to waitlisted if we are doing Full Enrolment
            if (DoFullEnrolment) foreach (var e in enrolments) { e.IsWaitlisted = true; }
            int enrolled = enrolments.Where(x => !x.IsWaitlisted).Count();
            int waitlisted = enrolments.Where(x => x.IsWaitlisted).Count();
            // If available places is less than waitlisted then enrol everyone.
            if (waitlisted <= course.MaximumStudents - enrolled) {
                foreach (var e in enrolments.Where(x => x.IsWaitlisted)) { e.IsWaitlisted = false; }
            }
            else {
                // Enrol new participants first
                int places = 0;
                decimal percent = settings.AutoEnrolNewParticipantPercent;
                if (percent > 0) { places = (int)(enrolments.Count * percent / 100); }
                if (places > 0 && places <= course.MaximumStudents - enrolled) {
                    foreach (var e in enrolments
                                        .OrderBy(x => x.Random)
                                        .Where(x => x.IsWaitlisted && !x.Person.Enrolments.Any())
                                        .Take(places)) { e.IsWaitlisted = false; }
                }
                // apply the remainder
                enrolled = enrolments.Where(x => !x.IsWaitlisted).Count();
                places = course.MaximumStudents - enrolled;
                if (places > 0) {
                    if (settings.AutoEnrolRemainderMethod.ToLower() == "random") {
                        foreach (var e in enrolments
                                            .OrderBy(x => x.Random)
                                            .Where(x => x.IsWaitlisted)
                                            .Take(places)) { e.IsWaitlisted = false; }
                    }
                    else {
                        foreach (var e in enrolments
                                            .OrderBy(x => x.Created)
                                            .Where(x => x.IsWaitlisted)
                                            .Take(places)) { e.IsWaitlisted = false; }
                    }
                }
            }
            if (ForceEmailQueue) {
                foreach (var e in enrolments) {
                    if (dbc.Entry(e).State == EntityState.Unchanged) { dbc.Entry(e).State = EntityState.Modified; }
                }
            }
        }
    }
}