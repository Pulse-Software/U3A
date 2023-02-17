using Eway.Rapid.Abstractions.Response;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using U3A.Database;
using U3A.Model;
using U3A.Services;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task<List<Class>> SelectableClassesAsync(U3ADbContext dbc, int Year) {
            return await dbc.Class.AsNoTracking()
                            .Include(x => x.OnDay)
                            .Include(x => x.Course)
                            .Include(x => x.Leader)
                            .Include(x => x.Leader2)
                            .Include(x => x.Leader3)
                            .Include(x => x.Occurrence)
                            .Include(x => x.Venue)
                            .Where(x => x.Course.Year == Year)
                            .OrderBy(x => x.Course.Name).ThenBy(x => x.StartTime).ToListAsync();
        }
        public static async Task<List<Class>> SelectableClassesWithCourseEnrolmentsAsync(U3ADbContext dbc, Term term) {
            var classes = await dbc.Class.AsNoTracking()
                            .Include(x => x.OnDay)
                            .Include(x => x.Course).ThenInclude(x => x.Enrolments)
                            .Include(x => x.Leader)
                            .Include(x => x.Occurrence)
                            .Include(x => x.Venue)
                            .Where(x => x.Course.Year == term.Year)
                            .OrderBy(x => x.OnDayID).ThenBy(x => x.StartTime).ToListAsync();
            return classes;
        }

        public static List<Class> GetClassDetailsWhereNotLeader(U3ADbContext dbc, Term term, Person person) {
            var classes = dbc.Class.AsNoTracking()
                            .Include(x => x.OnDay)
                            .Include(x => x.Course).ThenInclude(x => x.Enrolments.Where(x => x.TermID == term.ID))
                            .Include(x => x.Leader)
                            .Include(x => x.Occurrence)
                            .Include(x => x.Venue)
                            .Where(x => x.Course.Year == term.Year)
                            .OrderBy(x => x.OnDayID).ThenBy(x => x.StartTime).ToList();
            foreach (var c in classes) {
                BusinessRule.SetCourseParticipationDetails(c.Course, term);
            }
            return classes;
        }

        /// <summary>
        /// Get available classes for the current year
        /// </summary>
        /// <param name="dbc"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public static List<Class> GetClassDetails(U3ADbContext dbc, Term term) {
            var terms = dbc.Term.Where(x => x.Year == term.Year &&
                            x.TermNumber >= term.TermNumber);
            var classes = dbc.Class.AsNoTracking()
                            .Include(x => x.OnDay)
                            .Include(x => x.Course)
                                .ThenInclude(x => x.Enrolments.Where(x => terms.Contains(x.Term)))
                            .Include(x => x.Leader)
                            .Include(x => x.Occurrence)
                            .Include(x => x.Venue)
                            .Where(x => x.Course.Year == term.Year)
                            .OrderBy(x => x.OnDayID).ThenBy(x => x.StartTime)
                            .ToList().Where(x => IsClassInYear(dbc, x, term));
            foreach (var c in classes) {
                BusinessRule.SetCourseParticipationDetails(c.Course, term);
            }
            return classes.ToList();
        }

        public static List<Class> GetClassDetailsForStudent(IEnumerable<Class> Classes, Person Student, Term term) {
            List<Class> result;
            result = Classes.Where(c => c.Course.Enrolments
                                .Any(e => e.PersonID == Student.ID &&
                                    (e.ClassID == null || e.ClassID == c.ID))).ToList();
            return result;
        }
        public static bool IsCourseInTerm(Course course, Term term) {
            bool result = false;
            foreach (var c in course.Classes) {
                if (IsClassInTerm(c, term.TermNumber)) { result = true; break; }
            }
            return result;
        }

        public static async Task<List<Person>> GetPersonsInClassAsync(U3ADbContext dbc, Guid ClassID) {
            List<Person> result = new List<Person>();
            var course = dbc.Class.Include(x => x.Course).Where(x => x.ID == ClassID).Select(x => x.Course).FirstOrDefault();
            if (course != null) {
                if (course.CourseParticipationTypeID == (int?)ParticipationType.SameParticipantsInAllClasses) {
                    result = await dbc.Enrolment
                                    .Include(x => x.Person)
                                    .Where(x => x.CourseID == course.ID && !x.IsWaitlisted)
                                    .Select(x => x.Person).ToListAsync();
                }
                else {
                    result = await dbc.Enrolment
                                    .Include(x => x.Person)
                                    .Where(x => x.CourseID == course.ID && x.ClassID == ClassID && !x.IsWaitlisted)
                                    .Select(x => x.Person).ToListAsync();
                }
            }
            return result;
        }

        public static bool IsClassInTerm(Class Class, int TermNumber) {
            bool result = false;
            switch (TermNumber) {
                case 1:
                    result = Class.OfferedTerm1;
                    break;
                case 2:
                    result = Class.OfferedTerm2;
                    break;
                case 3:
                    result = Class.OfferedTerm3;
                    break;
                case 4:
                    result = Class.OfferedTerm4;
                    break;
            }
            return result;
        }
        public static bool IsClassInYear(U3ADbContext dbc, Class Class, Term term) {
            bool result = false;
            switch (term.TermNumber) {
                case 1:
                    result = (Class.OfferedTerm1 || Class.OfferedTerm2 || Class.OfferedTerm3 || Class.OfferedTerm4);
                    break;
                case 2:
                    result = Class.OfferedTerm2 || Class.OfferedTerm3 || Class.OfferedTerm4;
                    break;
                case 3:
                    result = Class.OfferedTerm3 || Class.OfferedTerm4;
                    break;
                case 4:
                    result = Class.OfferedTerm4;
                    break;
            }
            DateTime? endDate = GetClassEndDate(dbc, Class, term);
            if (endDate == null || endDate <= DateTime.Today) result = false ;
            return result;
        }

        public static async Task DeleteLeadershipRole(U3ADbContext dbc, Guid PersonID) {
            foreach (var c in await dbc.Class.Where(x => x.LeaderID == PersonID).ToListAsync()) {
                c.LeaderID = null;
                c.Leader = null;
            }
        }
    }
}
