using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace U3A.Model
{
    [NotMapped]
    public class OrganisationPersonDetail
    {
        // U3A Group
        public string U3AGroup { get; set; }
        public string? U3AOfficeLocation { get; set; }
        public string U3APostalAddress { get; set; }
        public string U3AStreetAddress { get; set; }
        public string U3AABN { get; set; }
        public string? U3AEmail { get; set; }
        public string? U3AWebsite { get; set; }
        public string? U3APhone { get; set; }
        public decimal U3AMembershipFee { get; set; }
        public decimal U3AMailSurcharge { get; set; }

        // Person
        public int PersonLegacyID { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string PersonAddress { get; set; }
        public string PersonCity { get; set; }
        public string PersonState { get; set; }
        public int PersonPostcode { get; set; }
        public string PersonGender { get; set; }
        public DateTime? PersonBirthDate { get; set; }
        public DateTime? PersonDateJoined { get; set; }
        public int? PersonMembershipYears { get; set; }
        public DateTime? PersonDateCeased { get; set; }
        public int PersonFinancialTo { get; set; }
        public string? PersonEmail { get; set; }
        public string? PersonHomePhone { get; set; }
        public string? PersonMobile { get; set; }
        public bool PersonSMSOptOut { get; set; }
        public string? PersonICEContact { get; set; }
        public string? PersonICEPhone { get; set; }
        public bool PersonVaxCertificateViewed { get; set; }
        public string? PersonOccupation { get; set; }
        public string PersonCommunication { get; set; }
        public Boolean PersonIsLifeMember { get; set; }
        public string PersonFullName { get; set; }
        public string PersonIdentity { get; set; }
        public Boolean PersonIsCourseLeader { get; set; }
        public Boolean PersonIsCommitteeMember { get; set; }
        public Boolean PersonIsVolunteer { get; set; }

        //Current Term
        public int CurrentTermYear { get; set; }
        public int CurrentTermNumber { get; set; }
        public DateTime CurrentTermStartDate { get; set; }
        public int CurrentTermDuration { get; set; }
        public string CurrentTermName { get; set; }
        public string CurrentTermSummary { get; set; }
        public DateTime CurrentTermEndDate { get; set; }
        public DateTime CurrentTermEnrolmentStartDate { get; set; }
        public DateTime CurrentTermEnrolmentEndDate { get; set; }
        public string CurrentTermDurationSummary { get; set; }
        public string CurrentTermEnrolStartSummary { get; set; }
        public string CurrentTermEnrolEndSummary { get; set; }
    }
}
