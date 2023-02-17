using Microsoft.EntityFrameworkCore;
using Twilio.TwiML.Fax;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static List<EnrolmentDetail> GetEnrolmentSample(U3ADbContext dbc) {
            // Grab a random Enrolment
            return GetEnrolmentDetail(dbc,
                dbc.Enrolment.OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefault());
        }

        public static List<EnrolmentDetail> GetEnrolmentDetail(U3ADbContext dbc, Enrolment enrolment) {
            var result = new List<EnrolmentDetail>();
            EnrolmentDetail ed;
            var p = BusinessRule.SelectPerson(dbc, enrolment.PersonID) ?? throw new ArgumentNullException(nameof(Person));
            var t = dbc.Term.Find(enrolment.TermID) ?? throw new ArgumentNullException(nameof(Term));
            var cr = dbc.Course.Where(x => x.ID == enrolment.CourseID).Include(x => x.Enrolments).FirstOrDefault(); 
            var pt = dbc.CourseParticpationType.Find(cr.CourseParticipationTypeID);
            var ct = dbc.CourseType.Find(cr.CourseTypeID);
            SetCourseParticipationDetails(cr, t);
            var classes = new List<Class>();
            if (enrolment.ClassID != null) {
                classes.Add(dbc.Class
                                .Include(x => x.Occurrence)
                                .Where(x => x.ID == enrolment.ClassID).FirstOrDefault());
            }
            else {
                classes.AddRange(dbc.Class
                                    .Include(x => x.Occurrence)
                                    .Where(x => x.CourseID == cr.ID).ToList());
            }
            foreach (var c in classes) {
                var od = dbc.WeekDay.Find(c.OnDayID);
                var v = dbc.Venue.Find(c.VenueID);
                var l = dbc.Person.Find(c.LeaderID);
                ed = new EnrolmentDetail() {
                    // Course
                    CourseLegacyID = cr.ConversionID,
                    CourseName = cr.Name,
                    CourseDescription = cr.Description ?? String.Empty,
                    CourseParticipationType = pt.Name,
                    CourseFeePerYear = cr.CourseFeePerYear,
                    CourseFeePerYearDescription = cr.CourseFeePerYearDescription ?? String.Empty,
                    CourseFeePerTerm = cr.CourseFeePerTerm,
                    CourseFeePerTermDescription = cr.CourseFeePerTermDescription ?? String.Empty,
                    CourseDuration = cr.Duration,
                    CourseRequiredStudents = cr.RequiredStudents,
                    CourseMaximumStudents = cr.MaximumStudents,
                    CourseTotalActiveStudents = cr.TotalActiveStudents,
                    CourseTotalWaitlistedStudents = cr.TotalWaitlistedStudents,
                    CourseParticipationRate = cr.ParticipationRate,
                    CourseType = ct.Name,
                    // Class
                    ClassOfferedTerm1 = c.OfferedTerm1,
                    ClassOfferedTerm2 = c.OfferedTerm2,
                    ClassOfferedTerm3 = c.OfferedTerm3,
                    ClassOfferedTerm4 = c.OfferedTerm4,
                    ClassOfferedSummary = c.OfferedSummary,
                    ClassStartDate = c.StartDate,
                    ClassOnDay = od.Day,
                    ClassStartTime = c.StartTime,
                    ClassOccurrence = c.OccurrenceText,
                    ClassEndTime = c.EndTime,
                    ClassStrEndTime = c.StrEndTime,
                    ClassSummary = c.ClassSummary,
                    ClassDetail = c.ClassDetail,
                    ClassDetailWithoutVenue = c.ClassDetailWithoutVenue,
                    ClassVenue = v.Name,
                    ClassVenueAddress = v.Address,
                    // Enrolment
                    EnrolmentDateReceived = enrolment.Created,
                    EnrolmentDateEnrolled = enrolment.DateEnrolled,
                    EnrolmentIsWaitlisted = enrolment.IsWaitlisted,
                };
                if (l != null) {
                    ed.ClassLeader = l.FullName;
                    ed.ClassLeaderFirstName = l.FirstName;
                    ed.LeaderSummary = l.PersonSummary;
                } else { ed.ClassLeader = "The Group"; }
                GetOrganisationPersonDetail(dbc, ed, t, p);
                result.Add(ed);
            }
            return result;
        }

    }
}