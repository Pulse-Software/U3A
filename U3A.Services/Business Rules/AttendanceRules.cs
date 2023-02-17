using DevExpress.Blazor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task<List<ClassDate>> SelectableAttendanceDatesAsync(U3ADbContext dbc,
                    Term selectedTerm, Class selectedClass, DateTime Now) {
            List<ClassDate> result;
            var storage = await GetCourseScheduleDataStorageAsync(dbc, selectedTerm);
            DateTime start = selectedTerm.StartDate;
            DateTime end = Now.AddDays(7);
            end = (end > start && end < selectedTerm.EndDate) ? end : selectedTerm.EndDate;
            DxSchedulerDateTimeRange range = new DxSchedulerDateTimeRange(start, end);
            result = (from a in storage.GetAppointments(range)
                      where (a.CustomFields["Source"] != null
                                && (int)a.LabelId != 9    // Cancelled/Postponed
                                && selectedClass.ID == (a.CustomFields["Source"] as Class).ID)
                      select new ClassDate() { Date = a.Start }).ToList();
            return result;
        }

        public static async Task<List<AttendClass>> EditableAttendanceAsync(U3ADbContext dbc,
                                    Term SelectedTerm, Course SelectedCourse, Class SelectedClass, ClassDate ClassDate) {
            List<AttendClass> attendance = await GetAttendanceAsync(dbc, SelectedTerm, SelectedClass, ClassDate);
            var enrolments = await BusinessRule.EditableEnrolmentsAsync(dbc, SelectedTerm, SelectedCourse, SelectedClass);
            AttendClass? a;
            foreach (var e in enrolments.Where(x => !x.IsWaitlisted)) {
                if (SelectedCourse.CourseParticipationTypeID == (int?)ParticipationType.SameParticipantsInAllClasses) {
                    a = attendance.Where(a => a.TermID == e.TermID
                                            && e.CourseID == SelectedCourse.ID
                                            && a.Date == ClassDate.Date
                                            && a.PersonID == e.PersonID).FirstOrDefault();
                }
                else {
                    a = attendance.Where(a => a.TermID == e.TermID
                                            && a.ClassID == e.ClassID
                                            && a.Date == ClassDate.Date
                                            && a.PersonID == e.PersonID).FirstOrDefault();
                }
                if (a == null) {
                    a = new AttendClass() {
                        TermID = SelectedTerm.ID,
                        Term = await dbc.Term.FindAsync(SelectedTerm.ID),
                        ClassID = SelectedClass.ID,
                        Class = await dbc.Class.FindAsync(SelectedClass.ID),
                        Date = ClassDate.Date,
                        Person = await dbc.Person.FindAsync(e.PersonID),
                        PersonID = e.PersonID,
                        AttendClassStatus = await dbc.AttendClassStatus.FindAsync((int)AttendClassStatusType.AbsentFromClassWithoutApology),
                        AttendClassStatusID = (int)AttendClassStatusType.AbsentFromClassWithoutApology,
                        Comment = String.Empty
                    };
                    a.Class.Venue = await dbc.Venue.FindAsync(a.Class.VenueID);
                    a.Class.Leader = await dbc.Person.FindAsync(a.Class.LeaderID);
                    a.Class.OnDay = await dbc.WeekDay.FindAsync(a.Class.OnDayID);
                    a.Class.Occurrence = await dbc.Occurrence.FindAsync(a.Class.OccurrenceID);
                    a.Class.Course = await dbc.Course.FindAsync(a.Class.CourseID);
                    a.Class.Course.CourseType = await dbc.CourseType.FindAsync(a.Class.Course.CourseTypeID);
                    a.Class.Course.CourseParticipationType = await dbc.CourseParticpationType.FindAsync(a.Class.Course.CourseParticipationTypeID);
                    attendance.Add(a);
                    await dbc.AttendClass.AddAsync(a);
                }
            }
            await BusinessRule.MaintainAttendanceHistoryAsync(dbc);
            await dbc.SaveChangesAsync();
            return await GetAttendanceAsync(dbc, SelectedTerm, SelectedClass, ClassDate);
        }

        private static async Task<List<AttendClass>> GetAttendanceAsync(U3ADbContext dbc,
                                    Term SelectedTerm, Class SelectedClass, ClassDate ClassDate) {
            return await dbc.AttendClass
                            .Include(x => x.Term)
                            .Include(x => x.Class)
                            .Include(x => x.Class).ThenInclude(x => x.Venue)
                            .Include(x => x.Class).ThenInclude(x => x.Leader)
                            .Include(x => x.Class).ThenInclude(x => x.OnDay)
                            .Include(x => x.Class).ThenInclude(x => x.Occurrence)
                            .Include(x => x.Class).ThenInclude(x => x.Course).ThenInclude(x => x.CourseType)
                            .Include(x => x.Class).ThenInclude(x => x.Course).ThenInclude(x => x.CourseParticipationType)
                            .Include(x => x.Person)
                            .Include(x => x.AttendClassStatus)
                            .Where(x => x.TermID == SelectedTerm.ID
                                            && x.ClassID == SelectedClass.ID
                                            && x.Date == ClassDate.Date)
                            .OrderBy(x => x.Person.LastName)
                                        .ThenBy(x => x.Person.FirstName)
                            .ToListAsync();
        }
    }
}