using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using U3A.Database;
using U3A.Model;
using DevExpress.Blazor.Internal;
using Eway.Rapid.Abstractions.Response;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task<List<Course>> EditableCoursesAsync(U3ADbContext dbc, int Year) {
            var Courses = await dbc.Course
                        .Include(x => x.CourseType)
                        .Include(x => x.CourseParticipationType)
                        .Include(x => x.Classes).ThenInclude(x => x.Venue)
                        .Include(x => x.Classes).ThenInclude(x => x.OnDay)
                        .Include(x => x.Classes).ThenInclude(x => x.Leader)
                        .Include(x => x.Classes).ThenInclude(x => x.Leader2)
                        .Include(x => x.Classes).ThenInclude(x => x.Leader3)
                        .Include(x => x.Classes).ThenInclude(x => x.Occurrence)
                        .Where(x => x.Year == Year)
                        .OrderBy(x => x.Name)
                        .ToListAsync();
            foreach (var course in Courses) {
                course.Classes = course.Classes.OrderBy(x => x.OnDayID).ThenBy(x => x.StartTime).ToList();
            }
            return Courses;
        }

        public static async Task<List<Course>> SelectableCoursesAsync(U3ADbContext dbc, int Year) {
            var Courses = await dbc.Course
                        .Include(x => x.CourseType)
                        .Include(x => x.CourseParticipationType)
                        .Include(x => x.Classes).ThenInclude(x => x.Venue)
                        .Include(x => x.Classes).ThenInclude(x => x.OnDay)
                        .Include(x => x.Classes).ThenInclude(x => x.Leader)
                        .Include(x => x.Classes).ThenInclude(x => x.Leader2)
                        .Include(x => x.Classes).ThenInclude(x => x.Leader3)
                        .Include(x => x.Classes).ThenInclude(x => x.Occurrence)
                        .Where(x => x.Year == Year)
                        .OrderBy(x => x.Name)
                        .ToListAsync();
            foreach (var course in Courses) {
                course.Classes = course.Classes.OrderBy(x => x.OnDayID).ThenBy(x => x.StartTime).ToList();
            }
            return Courses;
        }
        public static List<Course> SelectableCourses(U3ADbContext dbc, Term term) {
            var courses = dbc.Course.AsNoTracking()
                        .Include(x => x.CourseType)
                        .Include(x => x.Enrolments).ThenInclude(x => x.Person)
                        .Include(x => x.CourseParticipationType)
                        .Include(x => x.Classes).ThenInclude(x => x.Venue)
                        .Include(x => x.Classes).ThenInclude(x => x.OnDay)
                        .Include(x => x.Classes).ThenInclude(x => x.Leader)
                        .Include(x => x.Classes).ThenInclude(x => x.Leader2)
                        .Include(x => x.Classes).ThenInclude(x => x.Leader3)
                        .Include(x => x.Classes).ThenInclude(x => x.Occurrence)
                        .Where(x => x.Year == term.Year & x.Classes.Any())
                        .OrderBy(x => x.Name)
                        .ToList();
            foreach (var c in courses) {
                SetCourseParticipationDetails(c, term);
            }
            return courses;
        }

        public static async Task<List<Course>> SelectableCoursesForLeader(U3ADbContext dbc, 
                                            Term term, Person Leader) {
            var allCourses = await SelectableCoursesByTermAsync(dbc, term.Year, term.TermNumber);
            var courses = new List<Course>();
            bool isCourseLeader;
            foreach (var course in allCourses) {
                foreach (var c in course.Classes) {
                    isCourseLeader = false;
                    if (c.Leader != null &&  Leader.ID == c.LeaderID) {
                        isCourseLeader = true;
                    }
                    if (c.Leader != null && Leader.ID == c.Leader2ID) {
                        isCourseLeader = true;
                    }
                    if (c.Leader != null && Leader.ID == c.Leader3ID) {
                        isCourseLeader = true;
                    }
                    if (isCourseLeader) { courses.Add(course); }
                }
            }
            return courses;
        }

        public static List<Person> SelectableCourseLeaders(Course SelectedCourse, Class? SelectedClass) {
            List<Person> result = new List<Person>();
            List<Class> classes = new List<Class>();
            if (SelectedClass != null) {
                classes.Add(SelectedClass);
            }
            else {
                classes.AddRange(SelectedCourse.Classes);
            }
            foreach (var c in classes) {
                if (c.Leader != null && !result.Any(x => x.ID == c.LeaderID)) {
                    result.Add(c.Leader);
                }
                if (c.Leader2 != null && !result.Any(x => x.ID == c.Leader2ID)) {
                    result.Add(c.Leader2);
                }
                if (c.Leader3 != null && !result.Any(x => x.ID == c.Leader3ID)) {
                    result.Add(c.Leader3);
                }
            }
            return result;
        }

        public static void SetCourseParticipationDetails(Course course, Term term) {
            course.TotalActiveStudents = course.Enrolments.Where(x => !x.IsWaitlisted && x.TermID == term.ID).Count();
            course.TotalWaitlistedStudents = course.Enrolments.Where(x => x.IsWaitlisted && x.TermID == term.ID).Count();
            course.ParticipationRate = 0;
            double count = 0;
            if (course.CourseParticipationTypeID == (int?)ParticipationType.SameParticipantsInAllClasses) {
                count = course.MaximumStudents;
            }
            else {
                count = (course.MaximumStudents * course.Classes.Count());
            }
            if (count != 0) course.ParticipationRate = (double)((course.TotalActiveStudents + course.TotalWaitlistedStudents) / count);
        }

        public static async Task<List<Course>> SelectableCoursesByTermAsync(U3ADbContext dbc, int Year, int TermNumber) {
            var courses = await SelectableCoursesAsync(dbc, Year);
            switch (TermNumber) {
                case 1:
                    courses = (from p in courses
                               where p.Classes.Any(c => c.OfferedTerm1 == true)
                               select p).ToList();
                    break;
                case 2:
                    courses = (from p in courses
                               where p.Classes.Any(c => c.OfferedTerm2 == true)
                               select p).ToList();
                    break;
                case 3:
                    courses = (from p in courses
                               where p.Classes.Any(c => c.OfferedTerm3 == true)
                               select p).ToList();
                    break;
                case 4:
                    courses = (from p in courses
                               where p.Classes.Any(c => c.OfferedTerm4 == true)
                               select p).ToList();
                    break;
            }
            return courses;
        }

        public static async Task<List<CourseParticipationType>> SelectableCourseParticipationTypesAsync(U3ADbContext dbc) {
            return await dbc.CourseParticpationType.AsNoTracking().ToListAsync();
        }
        public static async Task<string> DuplicateMarkUpAsync(U3ADbContext dbc, Course course) {
            string result = String.Empty;
            Course? duplicate = await DuplicateCourse(dbc, course);
            if (duplicate != null) {
                result = $"<p>The course [{duplicate.Name.Trim()}] is already on file.</p>";
            }
            return result;
        }

        public static async Task<bool> IsCourseNumberUnique(U3ADbContext dbc,Course course, int Year) {
            var result = await dbc.Course.Where(x =>
                            x.ConversionID == course.ConversionID && x.Year == Year &&
                            x.ID != course.ID).ToListAsync();
            return !await dbc.Course.Where(x => 
                            x.ConversionID == course.ConversionID && x.Year == Year &&
                            x.ID != course.ID).AnyAsync();
        }
        static async Task<Course?> DuplicateCourse(U3ADbContext dbc, Course course) {
            return await dbc.Course.AsNoTracking()
                            .Where(x => x.ID != course.ID &&
                                        (x.Year == course.Year &&
                                            x.Name.Trim().ToUpper() == course.Name.Trim().ToUpper())).FirstOrDefaultAsync();
        }
    }
}