using DevExpress.Blazor;
using DevExpress.XtraRichEdit.Import.Rtf;
using EllipticCurve;
using Microsoft.EntityFrameworkCore;
using System.Text;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task<List<Enrolment>> EditableEnrolmentsAsync(U3ADbContext dbc, Term SelectedTerm,
                              Course SelectedCourse, Class SelectedClass) {
            if (SelectedClass == null || SelectedCourse.CourseParticipationTypeID == (int?)ParticipationType.SameParticipantsInAllClasses) {
                return await dbc.Enrolment
                                    .Include(x => x.Term)
                                    .Include(x => x.Course)
                                    .Include(x => x.Person)
                                    .Where(x => x.CourseID == SelectedCourse.ID
                                                        && x.TermID == SelectedTerm.ID
                                                        && x.Person.DateCeased == null)
                                    .OrderBy(x => x.IsWaitlisted)
                                                .ThenBy(x => x.Person.LastName)
                                                .ThenBy(x => x.Person.FirstName)
                                    .ToListAsync();
            }
            else {
                return await dbc.Enrolment
                                    .Include(x => x.Term)
                                    .Include(x => x.Course)
                                    .Include(x => x.Person)
                                    .Where(x => x.ClassID == SelectedClass.ID
                                                    && x.TermID == SelectedTerm.ID
                                                    && x.Person.DateCeased == null)
                                    .OrderBy(x => x.IsWaitlisted)
                                                .ThenBy(x => x.Person.LastName)
                                                .ThenBy(x => x.Person.FirstName)
                                    .ToListAsync();
            }
        }

        public static async Task<List<Dropout>> EditableDropoutsAsync(U3ADbContext dbc, Term SelectedTerm) {
            return await dbc.Dropout
                                .Include(x => x.Term)
                                .Include(x => x.Course)
                                .Include(x => x.Person)
                                .Where(x => x.TermID == SelectedTerm.ID
                                                    && x.Person.DateCeased == null)
                                .OrderBy(x => x.IsWaitlisted)
                                            .ThenBy(x => x.Person.LastName)
                                            .ThenBy(x => x.Person.FirstName)
                                .ToListAsync();
        }

        public static bool SetWaitlistStatus(Term selectedTerm, Term currentTerm) {
            bool result = false;
            if (selectedTerm.Comparer > currentTerm.Comparer) {
                // Any future enrolments must be waitlisted.
                result = true;
            }
            else {
                // set Enrolled if class allocation finalised
                // otherwise, set waitlisted.
                result = !currentTerm.IsClassAllocationFinalised;
            }
            return result;
        }
        public static async Task<bool> AnyEnrolmentsInYear(U3ADbContext dbc, Course course, int Year) {
            bool result = await dbc.Enrolment.AsNoTracking()
                                .Include(x => x.Course)
                                .Include(x => x.Term)
                                .AnyAsync(x => x.CourseID == course.ID && x.Term.Year == Year);
            return result;
        }
        public static async Task<int> ActiveEnrolmentCount(U3ADbContext dbc, Person person, Term SelectedTerm) {
            return await dbc.Enrolment
                .Where(x => x.PersonID == person.ID && x.TermID == SelectedTerm.ID && !x.IsWaitlisted)
                        .CountAsync();
        }
        public static async Task<int> WaitlistedEnrolmentCount(U3ADbContext dbc, Person person, Term SelectedTerm) {
            return await dbc.Enrolment
                .Where(x => x.PersonID == person.ID && x.TermID == SelectedTerm.ID && x.IsWaitlisted)
                        .CountAsync();
        }
        public static List<Enrolment> SelectableEnrolments(U3ADbContext dbc, Term SelectedTerm) {
            var enrolments = dbc.Enrolment
                                .Include(x => x.Term)
                                .Include(x => x.Course)
                                .Include(x => x.Class).ThenInclude(x => x.OnDay)
                                .Include(x => x.Person)
                                .Where(x => x.TermID == SelectedTerm.ID
                                                    && x.Person.DateCeased == null)
                                .OrderBy(x => x.IsWaitlisted)
                                            .ThenBy(x => x.Person.LastName)
                                            .ThenBy(x => x.Person.FirstName)
                                .ToList();
            foreach (var e in enrolments) {
                SetCourseParticipationDetails(e.Course, SelectedTerm);
            }
            return enrolments;
        }

        public static List<Enrolment> SelectableEnrolmentsByClass(U3ADbContext dbc, Class SelectedClass, Term SelectedTerm,
                              Course SelectedCourse) {
            if (SelectedClass == null || SelectedCourse.CourseParticipationTypeID == (int?)ParticipationType.SameParticipantsInAllClasses) {
                return dbc.Enrolment
                                    .Include(x => x.Term)
                                    .Include(x => x.Course)
                                    .Include(x => x.Person)
                                    .Where(x => x.CourseID == SelectedCourse.ID
                                                        && x.TermID == SelectedTerm.ID
                                                        && x.Person.DateCeased == null)
                                    .OrderBy(x => x.IsWaitlisted)
                                                .ThenBy(x => x.Person.LastName)
                                                .ThenBy(x => x.Person.FirstName)
                                    .ToList();
            }
            else {
                return dbc.Enrolment
                                    .Include(x => x.Term)
                                    .Include(x => x.Course)
                                    .Include(x => x.Person)
                                    .Where(x => x.ClassID == SelectedClass.ID
                                                    && x.TermID == SelectedTerm.ID
                                                    && x.Person.DateCeased == null)
                                    .OrderBy(x => x.IsWaitlisted)
                                                .ThenBy(x => x.Person.LastName)
                                                .ThenBy(x => x.Person.FirstName)
                                    .ToList();
            }
        }

        public static List<EnrolmentExportData> GetEnrolmentExportDataByPersonAsync(U3ADbContext dbc, Guid PersonID) {
            var result = new List<EnrolmentExportData>();
            Term? term = dbc.Term.AsNoTracking().Where(x => x.IsDefaultTerm).FirstOrDefault();
            if (term == null) throw new Exception("The current/default Term has not been set");
            var enrolments = dbc.Enrolment
                                .Include(x => x.Term)
                                .Include(x => x.Course).ThenInclude(x => x.CourseType)
                                .Include(x => x.Course).ThenInclude(x => x.Classes).ThenInclude(x => x.Leader)
                                .Include(x => x.Course).ThenInclude(x => x.Classes).ThenInclude(x => x.Occurrence)
                                .Include(x => x.Course).ThenInclude(x => x.Classes).ThenInclude(x => x.OnDay)
                                .Include(x => x.Course).ThenInclude(x => x.Classes).ThenInclude(x => x.Venue)
                                .Include(x => x.Person)
                                .Include(x => x.Class)
                                .Where(x => x.PersonID == PersonID
                                                && x.Person.DateCeased == null
                                                && x.Person.FinancialTo >= term.Year
                                                && x.TermID == term.ID && x.Class == null)
                                .ToList();
            enrolments.AddRange(dbc.Enrolment
                                .Include(x => x.Term)
                                .Include(x => x.Person)
                                .Include(x => x.Class)
                                .Include(x => x.Class).ThenInclude(x => x.Leader)
                                .Include(x => x.Class).ThenInclude(x => x.Occurrence)
                                .Include(x => x.Class).ThenInclude(x => x.OnDay)
                                .Include(x => x.Class).ThenInclude(x => x.Venue)
                                .Where(x => x.PersonID == PersonID
                                                    && x.Person.DateCeased == null
                                                    && x.Person.FinancialTo >= term.Year
                                                    && x.TermID == term.ID && x.Class != null)
                                .ToList());
            foreach (var e in enrolments) {
                if (e.Course.CourseParticipationTypeID == (int?)ParticipationType.SameParticipantsInAllClasses) {
                    foreach (var c in e.Course.Classes) {
                        result.Add(new EnrolmentExportData() {
                            CourseType = e.Course.CourseType.Name,
                            CourseName = e.Course.Name,
                            CourseDescription = e.Course.Description,
                            CourseParticipationType = "Enrolled in all classes",
                            CourseFeePerYear = e.Course.CourseFeePerYear.ToString("c2"),
                            CourseFeePerYearDescription = e.Course.CourseFeePerYearDescription,
                            CourseFeePerTerm = e.Course.CourseFeePerTerm.ToString("c2"),
                            CourseFeePerTermDescription = e.Course.CourseFeePerTermDescription,
                            ClassHeld = c.ClassSummary,
                            Leader = c.LeaderSummary,
                            Venue = c.Venue.Name,
                            VenueLocation = c.Venue.Address,
                            EnrolmentStatus = (e.IsWaitlisted) ? "Waitlisted" : "Enrolled"
                        });
                    }
                }
                else {
                    result.Add(new EnrolmentExportData() {
                        CourseType = e.Course.CourseType.Name,
                        CourseName = e.Course.Name,
                        CourseDescription = e.Course.Description,
                        CourseParticipationType = "Enrolled in all classes",
                        CourseFeePerYear = e.Course.CourseFeePerYear.ToString("c2"),
                        CourseFeePerYearDescription = e.Course.CourseFeePerYearDescription,
                        CourseFeePerTerm = e.Course.CourseFeePerTerm.ToString("c2"),
                        CourseFeePerTermDescription = e.Course.CourseFeePerTermDescription,
                        ClassHeld = e.Class?.ClassSummary,
                        Leader = e.Class?.LeaderSummary,
                        Venue = e.Class?.Venue.Name,
                        VenueLocation = e.Class?.Venue.Address,
                        EnrolmentStatus = (e.IsWaitlisted) ? "Waitlisted" : "Enrolled"
                    });
                }
            }
            return result;
        }

        public static string GetEnrolmentStatus(Course course, List<Enrolment> enrolments) {
            string result = "N/A";
            if (course != null && enrolments != null) {
                int EnrolledParticipants = enrolments.Where(x => !x.IsWaitlisted).Count();
                int WaitlistedParticipants = enrolments.Where(x => x.IsWaitlisted).Count();
                if (EnrolledParticipants < course.RequiredStudents) {
                    result = "Undersubscribed";
                }
                if (EnrolledParticipants >= course.RequiredStudents
                        && EnrolledParticipants <= course.MaximumStudents) {
                    result = "Good To Go";
                }
                if (EnrolledParticipants > course.MaximumStudents) {
                    result = "Oversubscribed";
                }
                if (EnrolledParticipants < course.MaximumStudents
                        && WaitlistedParticipants > 0) {
                    result = "Places Available - Assign Waitlisted";
                }
            }
            return result;
        }
        public static ButtonRenderStyle GetEnrolmentButtonRenderStyle(Course course, List<Enrolment> enrolments) {
            ButtonRenderStyle result = ButtonRenderStyle.Light;
            if (course != null && enrolments != null) {
                int EnrolledParticipants = enrolments.Where(x => !x.IsWaitlisted).Count();
                int WaitlistedParticipants = enrolments.Where(x => x.IsWaitlisted).Count();
                if (EnrolledParticipants < course.RequiredStudents) {
                    result = ButtonRenderStyle.Warning;
                }
                if (EnrolledParticipants >= course.RequiredStudents
                        && EnrolledParticipants <= course.MaximumStudents) {
                    result = ButtonRenderStyle.Success;
                }
                if (EnrolledParticipants > course.MaximumStudents) {
                    result = ButtonRenderStyle.Danger;
                }
                if (EnrolledParticipants < course.MaximumStudents
                        && WaitlistedParticipants > 0) {
                    result = ButtonRenderStyle.Info;
                }
            }
            return result;
        }

        public static async Task<string> DuplicateMarkUpAsync(U3ADbContext dbc,
                                            Enrolment enrolment, Term selectedTerm,
                                            Course selectedCourse, Class selectedClass) {
            StringBuilder result = new StringBuilder();
            Enrolment? duplicate = await DuplicateEnrolment(dbc, enrolment, selectedTerm, selectedCourse, selectedClass);
            if (duplicate != null) {
                result.AppendLine($"<p>{duplicate.Person.FullName} is already enrolled in this course.<br/>");
                if (duplicate.IsWaitlisted) { result.AppendLine("They are registered as <strong>Waitlisted</strong>.<br/>"); }
                if (duplicate.Course.CourseParticipationTypeID == (int?)ParticipationType.DifferentParticipantsInEachClass &&
                   duplicate.Class != null) {
                    result.AppendLine($"They are registered in class <strong>{duplicate.Class.ClassSummary}</strong>.<br/>");
                }
                result.AppendLine("</p>");
            }
            return result.ToString();
        }
        static async Task<Enrolment?> DuplicateEnrolment(U3ADbContext dbc,
                                        Enrolment enrolment, Term selectedTerm,
                                        Course selectedCourse, Class selectedClass) {
            if (selectedCourse.CourseParticipationTypeID == (int?)ParticipationType.DifferentParticipantsInEachClass &&
                selectedClass != null) {
                return await dbc.Enrolment.AsNoTracking()
                            .Include(x => x.Course)
                            .Include(x => x.Class)
                            .Include(x => x.Term)
                            .Include(x => x.Person)
                            .Where(x => x.ID != enrolment.ID &&
                                        x.PersonID == enrolment.Person.ID &&
                                        x.TermID == selectedTerm.ID &&
                                        x.CourseID == selectedCourse.ID &&
                                        x.ClassID == selectedClass.ID).FirstOrDefaultAsync();
            }
            else {
                return await dbc.Enrolment.AsNoTracking()
                            .Include(x => x.Course)
                            .Include(x => x.Term)
                            .Include(x => x.Person)
                            .Where(x => x.ID != enrolment.ID &&
                                        x.PersonID == enrolment.Person.ID &&
                                        x.TermID == selectedTerm.ID &&
                                        x.CourseID == selectedCourse.ID).FirstOrDefaultAsync();
            }
        }
        public static async Task<Enrolment?> DuplicateEnrolment(U3ADbContext dbc,
                                        Person selectedPerson, Term selectedTerm,
                                        Course? selectedCourse, Class selectedClass) {
            if (selectedCourse.CourseParticipationTypeID == (int?)ParticipationType.DifferentParticipantsInEachClass &&
                selectedClass != null) {
                return await dbc.Enrolment
                            .Include(x => x.Course)
                            .Include(x => x.Class)
                            .Include(x => x.Term)
                            .Include(x => x.Person)
                            .Where(x => x.PersonID == selectedPerson.ID &&
                                        x.TermID == selectedTerm.ID &&
                                        x.CourseID == selectedCourse.ID &&
                                        x.ClassID == selectedClass.ID).FirstOrDefaultAsync();
            }
            else {
                return await dbc.Enrolment
                            .Include(x => x.Course)
                            .Include(x => x.Term)
                            .Include(x => x.Person)
                            .Where(x => x.PersonID == selectedPerson.ID &&
                                        x.TermID == selectedTerm.ID &&
                                        x.CourseID == selectedCourse.ID).FirstOrDefaultAsync();
            }
        }

        public static async Task DeleteEnrolmentByClassID(U3ADbContext dbc, Guid ClassID) {
            var query = await dbc.Enrolment
                        .Include(x => x.Class)
                        .Where(x => x.ClassID == ClassID).ToArrayAsync();
            dbc.RemoveRange(query);
        }

        /// <summary>
        /// Delete enrolements no longer required by a member.
        /// </summary>
        /// <param name="dbc"></param>
        /// <param name="person"></param>
        /// <param name="term"></param>
        public static int DeleteEnrolmentsRescinded(U3ADbContext dbc,
                                            IEnumerable<Class> RequestedClasses,
                                            Person person,
                                            Term term) {
            int result = 0;
            var reqID = new List<Guid>();
            var terms = dbc.Term.Where(x => x.Year == term.Year && x.TermNumber >= term.TermNumber);
            foreach (var Class in RequestedClasses) { reqID.Add(Class.ID); }
            foreach (var e in dbc.Enrolment.Include(e => e.Course).ThenInclude(e => e.Classes)
                                           .Include(e => e.Class)
                                           .Where(e =>
                                                e.PersonID == person.ID &&
                                                terms.Contains(e.Term))) {
                if ((ParticipationType)e.Course.CourseParticipationTypeID == ParticipationType.SameParticipantsInAllClasses) {
                    foreach (var c in e.Course.Classes) {
                        if (!reqID.Contains(c.ID)) {
                            dbc.Remove(e);
                            result++;
                            break;
                        }
                    }
                }
                else {
                    if (e.ClassID != null && !reqID.Contains(e.ClassID.Value)) {
                        dbc.Remove(e);
                        result++;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Add enrolments requested by a member
        /// </summary>
        /// <param name="dbc"></param>
        /// <param name="RequestedClasses"></param>
        /// <param name="person"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public static async Task<List<Enrolment>> AddEnrolmentRequests(U3ADbContext dbc,
                                            IEnumerable<Class> RequestedClasses,
                                            Person person,
                                            Term term) {
            var result = new List<Enrolment>();
            foreach (var c in RequestedClasses) {
                var termNumber = GetFirstTermNumber(term, c);
                var course = await dbc.Course.FindAsync(c.CourseID);
                if ((ParticipationType)c.Course.CourseParticipationTypeID == ParticipationType.SameParticipantsInAllClasses) {
                    if (!await dbc.Enrolment.AnyAsync(x =>
                                        x.PersonID == person.ID &&
                                        x.Term.Year == term.Year && x.Term.TermNumber == termNumber &&
                                        x.CourseID == c.CourseID)) {
                        var e = new Enrolment() {
                            Created = DateTime.Now,
                            IsWaitlisted = await BusinessRule.SetWaitlistStatusAsync(dbc, course.ID, term, person)
                        };
                        e.Person = await dbc.Person.FindAsync(person.ID);
                        e.Term = await dbc.Term.FirstOrDefaultAsync(x => x.Year == term.Year && x.TermNumber == termNumber);
                        e.Course = await dbc.Course.FindAsync(c.Course.ID);
                        if (c.Course.CourseParticipationTypeID == 1) {
                            e.Class = await dbc.Class.FindAsync(c.ID);
                        }
                        result.Add(e);
                        await dbc.AddAsync<Enrolment>(e);
                    }
                }
                else {
                    if (!await dbc.Enrolment.AnyAsync(x =>
                                        x.PersonID == person.ID &&
                                        x.Term.Year == term.Year && x.Term.TermNumber == termNumber &&
                                        x.CourseID == c.CourseID &&
                                        x.ClassID == c.ID)) {
                        var e = new Enrolment() {
                            Created = DateTime.Now,
                            IsWaitlisted = await BusinessRule.SetWaitlistStatusAsync(dbc, course.ID, term, person)
                        };
                        e.Person = await dbc.Person.FindAsync(person.ID);
                        e.Term = await dbc.Term.FirstOrDefaultAsync(x => x.Year == term.Year && x.TermNumber == termNumber);
                        e.Course = await dbc.Course.FindAsync(c.Course.ID);
                        e.Class = await dbc.Class.FindAsync(c.ID);
                        result.Add(e);
                        await dbc.AddAsync<Enrolment>(e);
                    }
                }
            }
            return result;
        }

        public static async Task<bool> SetWaitlistStatusAsync(U3ADbContext dbc,
                                    Guid CourseID,
                                    Term CurrentTerm,
                                    Person person) {
            bool result = false;
            if (person.FinancialTo < CurrentTerm.Year) return true;
            if (!CurrentTerm.IsClassAllocationFinalised) result = true;
            else {
                var course = await dbc.Course.FindAsync(CourseID);
                int enrolments = await dbc.Enrolment
                                    .Where(x => x.CourseID == CourseID && x.TermID == CurrentTerm.ID).CountAsync();
                result = (enrolments >= course.MaximumStudents);
            }
            return result;
        }


        static int GetFirstTermNumber(Term currentTerm, Class requestedClass) {
            var termNumber = currentTerm.TermNumber;
            var numbers = new List<int>();
            if (requestedClass.OfferedTerm1 && termNumber == 1) numbers.Add(1);
            if (requestedClass.OfferedTerm2 && termNumber <= 2) numbers.Add(2);
            if (requestedClass.OfferedTerm3 && termNumber <= 3) numbers.Add(3);
            if (requestedClass.OfferedTerm4 && termNumber <= 4) numbers.Add(4);
            return numbers.Min();
        }

        public static async Task<string> GetEnrolmentStatusMarkup(U3ADbContext dbc, IEnumerable<Enrolment> enrolments, int deletions) {
            var result = new StringBuilder();
            if (enrolments.Count() > 0) {
                result.AppendLine("<table class='table'>");
                result.AppendLine("<thead><tr>");
                result.AppendLine("<th scope='col'>Course</th>");
                result.AppendLine("<th scope='col'>Status</th>");
                result.AppendLine("</tr></thead>");
                result.AppendLine("<tbody>");
                foreach (var e in enrolments) {
                    var status = (e.IsWaitlisted) ? "Waitlisted" : "Enrolled";
                    result.AppendLine($"<tr><td>{e.Course.Name}</td><td>{status}</td></tr>");
                }
                result.AppendLine("</tbody></table>");
            }
            if (deletions > 0) { result.AppendLine($"<p>{deletions} enrolment(s) have been removed.</p>"); }
            return result.ToString();
        }

    }
}
