using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace U3A.Model
{
    public class SystemSettings
    {
        [Key]
        public Guid ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string U3AGroup { get; set; }
        [MaxLength(50)]
        public string? OfficeLocation { get; set; }
        [MaxLength(256)]
        [Required]
        public string PostalAddress { get; set; }
        [MaxLength(256)]
        [Required]
        public string StreetAddress { get; set; }

        [MaxLength(15)]
        public string ABN { get; set; }
        [MaxLength(256)]
        [EmailAddress]
        public string? Email { get; set; }
        [MaxLength(256)]
        public string? Website { get; set; }
        [MaxLength(16)]
        public string? Phone { get; set; }

        [EmailAddress]
        [Comment("Pro-forma reports are sent from here")]
        public string SendEmailAddesss { get; set; }

        [MaxLength(256)]
        public string SendEmailDisplayName { get; set; } = "U3A Membership Office";

        [Required]
        [Precision(precision: 18, 2)]
        [DefaultValue(0.00)]
        [Range(0.00,double.MaxValue)]
        [Comment("Full Year Membership Fee")]
        public decimal MembershipFee { get; set; }
        [Required]
        [Precision(precision: 18, 2)]
        [DefaultValue(0.00)]
        [Comment("Term 2 Membership Fee")]
        [Range(0.00, double.MaxValue)]
        public decimal MembershipFeeTerm2 { get; set; }
        [Required]
        [Precision(precision: 18, 2)]
        [DefaultValue(0.00)]
        [Comment("Term 3 Year Membership Fee")]
        [Range(0.00, double.MaxValue)]
        public decimal MembershipFeeTerm3 { get; set; }
        [Required]
        [Precision(precision: 18, 2)]
        [DefaultValue(0.00)]
        [Comment("Term 4 Year Membership Fee")]
        [Range(0.00, double.MaxValue)]
        public decimal MembershipFeeTerm4 { get; set; }


        [Precision(precision: 18, 2)]
        [DefaultValue(0.00)]
        [Comment("Yearly surcharge if requiring mail correspondence")]
        public decimal MailSurcharge { get; set; }

        public bool RequireVaxCertificate { get; set; }

        public Guid? CurrentTermID { get; set; }

        [Precision(18, 2)]
        [Range(0, 100, ErrorMessage = "Enter a percentage between {1} and {2}.")]
        public decimal AutoEnrolNewParticipantPercent { get; set; }

        [DefaultValue("Random")]
        [Required]
        public string AutoEnrolRemainderMethod { get; set; }

        [Required]
        public string CommitteePositions { get; set; }
        public string? VolunteerActivities { get; set; }

        [Required]
        public DateTime? LastCashReceiptDate { get; set; } = DateTime.Today;

        public double MailLabelTopMargin { get; set; }
        public double MailLabelBottomMargin { get; set; }
        public double MailLabelLeftMargin { get; set; }
        public double MailLabelRightMargin { get; set; }
        public double MailLabelWidth { get; set; }
        public double MailLabelHeight { get; set; }

        public string BankBSB { get; set; }
        public string BankAccountNo { get; set; }

        [Required]
        [Range(-12,12)]
        [DefaultValue(10)]
        public int UTCOffset { get; set; }

        [DefaultValue(true)]
        public bool IncludeMembershipFeeInComplimentary { get; set; }
        [DefaultValue(true)]
        public bool IncludeMailSurchargeInComplimentary { get; set; }
        [DefaultValue(true)]
        public bool IncludeCourseFeePerYearInComplimentary { get; set; }
        [DefaultValue(true)]
        public bool IncludeCourseFeePerTermInComplimentary { get; set; }

        [DefaultValue(0)]
        public int LeaderMaxComplimentaryCourses { get; set; }
    }
}
