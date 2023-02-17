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
        public static async Task<int> CountOfTermEnrolments(U3ADbContext dbc, Term? targetTerm) {
            return await dbc.Enrolment.Include(x => x.Person)
                                .Where(enrolment => enrolment.Term == targetTerm &&
                                                        enrolment.Person.DateCeased == null).CountAsync();
        }
        public static async Task<Term?> GetNextTargetTerm(U3ADbContext dbc, Term? sourceTerm) {
            return await dbc.Term
                            .Where(x => x.Year == sourceTerm.Year && x.TermNumber == sourceTerm.TermNumber + 1).FirstOrDefaultAsync();
        }

        public static async Task BringForwardEnrolmentsAsync(U3ADbContext dbc,
                    Term? sourceTerm, Term? targetTerm, bool SetCurrentTerm) {

            var enrolments = await dbc.Enrolment
                                .Include(x => x.Class)
                                .Include(x => x.Course)
                                .Include(x => x.Person)
                                .Where(enrolment => enrolment.Term == sourceTerm
                                                        && enrolment.Person.DateCeased == null)
                                .ToListAsync();
            foreach (var e in enrolments) {
                if (IsClassInTerm(targetTerm, e.Class)) { await CreateEnrolment(dbc, e, targetTerm); }
                else {
                    foreach (var course in dbc.Course
                                        .Include(x => x.Classes)
                                        .Where(x => x.ID == e.Course.ID).ToList()) {
                        foreach (var clss in course.Classes) {
                            if (IsClassInTerm(targetTerm, clss)) {
                                await CreateEnrolment(dbc, e, targetTerm);
                                break;  // we only need one new enrolment
                            }
                        }
                    }
                }
            }

            if (SetCurrentTerm) {
                foreach (var t in dbc.Term.Where(x => x.IsDefaultTerm)) {
                    t.IsDefaultTerm = false;
                }
                var trm = await dbc.Term.FindAsync(targetTerm.ID);
                trm.IsDefaultTerm = true;
            }

            await dbc.SaveChangesAsync();
        }

        static async Task CreateEnrolment(U3ADbContext dbc, Enrolment currentEnrolment, Term? targetTerm) {
            var newEnrolment = new Enrolment();
            currentEnrolment.CopyTo(newEnrolment);
            newEnrolment.Term = await dbc.Term.FindAsync(targetTerm.ID);
            newEnrolment.Course = await dbc.Course.FindAsync(currentEnrolment.CourseID);
            newEnrolment.Person = await dbc.Person.FindAsync(currentEnrolment.PersonID);
            if (currentEnrolment.Class != null) {
                newEnrolment.Class = await dbc.Class.FindAsync(currentEnrolment.ClassID);
            }
            newEnrolment.ID = Guid.Empty;
            await dbc.Enrolment.AddAsync(newEnrolment);
        }

        static bool IsClassInTerm(Term? targetTerm, Class? c) {
            bool result = false;
            if (c != null && c.StartDate == null) {
                if (targetTerm.TermNumber == 1 && c.OfferedTerm1) { result = true; }
                if (targetTerm.TermNumber == 2 && c.OfferedTerm2) { result = true; }
                if (targetTerm.TermNumber == 3 && c.OfferedTerm3) { result = true; }
                if (targetTerm.TermNumber == 4 && c.OfferedTerm4) { result = true; }
            }
            return result;
        }
    }
}
