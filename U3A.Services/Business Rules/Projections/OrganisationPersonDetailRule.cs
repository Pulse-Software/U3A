using Microsoft.EntityFrameworkCore;
using System;
using Twilio.TwiML.Fax;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static List<LeaderDetail> GetLeaderDetailSample(U3ADbContext dbc, out List<EnrolmentDetail> EnrolmentDetails) {
            var eDetails = new List<EnrolmentDetail>();
            LeaderDetail leader = new LeaderDetail();
            Person? leaderPerson;
            Term? term = BusinessRule.CurrentTerm(dbc);
            if (term != null) {
                var e = dbc.Enrolment
                    .Include(x => x.Course)
                    .Where(x => x.TermID == term.ID)
                    .OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefault();
                if (e != null) {
                    var c = dbc.Class
                        .Include(x => x.Leader)
                        .Where(x => x.CourseID == e.CourseID).FirstOrDefault();
                    if (c != null) {
                        leaderPerson = c.Leader;
                        if (leaderPerson == null) { leaderPerson = new Person() { LastName = "The Group" }; }
                        GetOrganisationPersonDetail(dbc, leader, term, c.Leader);
                        leader.CourseID = e.CourseID;
                        leader.ClassID = e.ClassID;
                        var enrolments = new List<Enrolment>();
                        if (e.ClassID != null) {
                            enrolments = dbc.Enrolment.Where(x => x.ClassID == e.ClassID
                                                                && x.TermID == term.ID).ToList();
                        }
                        else {
                            enrolments = dbc.Enrolment.Where(x => x.CourseID == e.CourseID
                                                                && x.TermID == term.ID).ToList();
                        }
                        foreach (var enrolment in enrolments) {
                            eDetails.AddRange(BusinessRule.GetEnrolmentDetail(dbc, enrolment));
                        }
                    }
                }
            }
            EnrolmentDetails = eDetails.OrderBy(x => x.PersonFullName).ToList();
            return new List<LeaderDetail>() { leader };
        }

        public static List<LeaderDetail> GetLeaderDetail(U3ADbContext dbc, Person person, Term term) {
            var leader = new LeaderDetail();
            GetOrganisationPersonDetail(dbc,leader,term,person);
            return new List<LeaderDetail>() { leader };
        }

        private static void GetOrganisationPersonDetail(U3ADbContext dbc,
                    OrganisationPersonDetail opd,
                    Term t,
                    Person person) {
            var settings = dbc.SystemSettings.FirstOrDefault() ?? throw new ArgumentNullException(nameof(Person));
            opd.U3AGroup = settings.U3AGroup;
            opd.U3AOfficeLocation = settings.OfficeLocation;
            opd.U3APostalAddress = settings.PostalAddress;
            opd.U3AStreetAddress = settings.StreetAddress;
            opd.U3AABN = settings.ABN;
            opd.U3AEmail = settings.Email;
            opd.U3AWebsite = settings.Website;
            opd.U3APhone = settings.Phone;
            opd.U3AMembershipFee = settings.MembershipFee;
            opd.U3AMailSurcharge = settings.MailSurcharge;

            // Person
            opd.PersonLegacyID = person.ConversionID;
            opd.PersonFirstName = person.FirstName;
            opd.PersonLastName = person.LastName;
            opd.PersonAddress = person.Address;
            opd.PersonCity = person.City;
            opd.PersonState = person.State;
            opd.PersonPostcode = person.Postcode;
            opd.PersonGender = person.Gender;
            opd.PersonBirthDate = person.BirthDate;
            opd.PersonDateJoined = person.DateJoined;
            opd.PersonMembershipYears = person.MembershipYears;
            opd.PersonDateCeased = person.DateCeased;
            opd.PersonFinancialTo = person.FinancialTo;
            opd.PersonEmail = person.Email;
            opd.PersonHomePhone = person.HomePhone;
            opd.PersonMobile = person.Mobile;
            opd.PersonSMSOptOut = person.SMSOptOut;
            opd.PersonICEContact = person.ICEContact;
            opd.PersonICEPhone = person.ICEPhone;
            opd.PersonVaxCertificateViewed = person.VaxCertificateViewed;
            opd.PersonOccupation = person.Occupation;
            opd.PersonCommunication = person.Communication;
            opd.PersonIsLifeMember = person.IsLifeMember;
            opd.PersonFullName = person.FullNameAlpha;
            opd.PersonIdentity = person.PersonIdentity;
            opd.PersonIsCourseLeader = person.IsCourseLeader;
            opd.PersonIsCommitteeMember = person.IsCommitteeMember;
            opd.PersonIsVolunteer = person.IsVolunteer;

            opd.CurrentTermYear = t.Year;
            opd.CurrentTermNumber = t.TermNumber;
            opd.CurrentTermStartDate = t.StartDate;
            opd.CurrentTermDuration = t.Duration;
            opd.CurrentTermName = t.Name;
            opd.CurrentTermSummary = t.TermSummary;
            opd.CurrentTermEndDate = t.EndDate;
            opd.CurrentTermEnrolmentStartDate = t.EnrolmentStartDate;
            opd.CurrentTermEnrolmentEndDate = t.EnrolmentEndDate;
            opd.CurrentTermDurationSummary = t.DurationSummary;
            opd.CurrentTermEnrolStartSummary = t.EnrolStartSummary;
            opd.CurrentTermEnrolEndSummary = t.EnrolStartSummary;


        }
    }
}