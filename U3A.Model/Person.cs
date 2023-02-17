using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace U3A.Model
{
    [Index(nameof(DataImportTimestamp))]
    [Index(nameof(ConversionID))]
    [Index(nameof(PersonID))]
    [Index(nameof(LastName), nameof(FirstName), nameof(Email))]
    public class Person : BaseEntity
    {
        [Key]
        public Guid ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }

        public int ConversionID { get; set; }

        public string? DataImportTimestamp { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(3)]
        public string State { get; set; }

        [Range(1, 9999)]
        public int Postcode { get; set; }

        [Required]
        [DefaultValue("Male")]
        public string Gender { get; set; }

        public DateTime? BirthDate { get; set; }
        public DateTime? DateJoined { get; set; }
        public DateTime? PreviousDateJoined { get; set; }

        public int? MembershipYears {
            get {
                return Age.Calculate(DateCeased, DateJoined);
            }
        }
        public DateTime? DateCeased { get; set; }

        [Range(constants.START_OF_TIME, 9999)]
        [DefaultValue(constants.START_OF_TIME)]
        public int FinancialTo { get; set; } = constants.START_OF_TIME;

        public int? PreviousFinancialTo { get; set; }


        [MaxLength(256)]
        [EmailAddressAlowNull]
        public string? Email { get; set; }

        public string Domain {
            get {
                var result = string.Empty;
                if (!string.IsNullOrWhiteSpace(Email)) {
                    var splits = Email.Split("@");
                    if (splits.Length > 0) result = splits[1].ToLower();
                }
                return result;
            }
        }
        [MaxLength(20)]
        public string? HomePhone { get; set; }
        public string? AdjustedHomePhone {
            get {
                string? result = null;
                if (HomePhone != null) {
                    result = HomePhone.Replace(" ","").Replace("+61","0");
                }
                return result;
            }
        }
        [MaxLength(20)]
        public string? Mobile { get; set; }
        [DefaultValue(false)]
        public string? AdjustedMobile {
            get {
                string? result = null;
                if (Mobile != null) {
                    result = Mobile.Replace(" ", "").Replace("+61", "0");
                }
                return result;
            }
        }

        [MaxLength(20)]
        public string? SilentNumber { get; set; }

        public bool SMSOptOut { get; set; }
        [Required]
        [MaxLength(50)]
        public string ICEContact { get; set; }
        [Required]
        [MaxLength(50)]
        public string ICEPhone { get; set; }

        public bool VaxCertificateViewed { get; set; }

        public string? Occupation { get; set; }

        [Required]
        [EmailCommunicationRequiresEmailAddress("Email", ErrorMessage = "Email communication method requires an email address")]
        public string Communication { get; set; } = "Email";

        [DefaultValue(false)]
        public Boolean IsLifeMember { get; set; }

        [NotMapped]
        public string FullName {
            get {
                return $"{FirstName.Trim()} {LastName.Trim()}";
            }
        }

        [NotMapped]
        public string FullNameAlpha {
            get {
                return $"{LastName.Trim()}, {FirstName.Trim()}";
            }
        }
        [NotMapped]
        public string AlphaGroup {
            get {
                return LastName.Substring(0, 1).ToUpper();
            }
        }
        [NotMapped]
        public string PersonSummary {
            get {
                var s = $"{FullName} ";
                if (!string.IsNullOrWhiteSpace(Mobile)) { s = $"{s} Mob: {Mobile}"; }
                else if (!string.IsNullOrWhiteSpace(HomePhone)) { s = $"{s} Ph: {HomePhone}"; }
                if (!string.IsNullOrWhiteSpace(Email)) { s = $"{s} Email: {Email}"; }
                return s;
            }
        }

        [NotMapped]
        public string PersonIdentity {
            get {
                if (FirstName != null && LastName != null) {
                    return $"{FirstName.Substring(0, 1).ToLower()}{LastName.Substring(0, 1).ToLower()}{PersonID.ToString("0000")}";
                }
                else {
                    return "To be calculated";
                }
            }
        }

        [NotMapped]
        [DefaultValue(false)]
        [Comment("Set in business rule")]
        public Boolean IsCourseLeader { get; set; }

        [NotMapped]
        [DefaultValue(false)]
        [Comment("Set in business rule")]
        public Boolean IsCommitteeMember { get; set; }

        [NotMapped]
        [DefaultValue(false)]
        [Comment("Set in business rule")]
        public Boolean IsVolunteer { get; set; }

        [InverseProperty("Leader")]
        public List<Class> LeaderOf { get; set; } = new List<Class>();
        [InverseProperty("Leader2")]
        public List<Class> Leader2Of { get; set; } = new List<Class>();
        [InverseProperty("Leader3")]
        public List<Class> Leader3Of { get; set; } = new List<Class>();

        /// <summary>
        /// Populated in BusinessRule. Use when printing enrolled classes for a student.
        /// </summary>
        [NotMapped]
        public List<Class> EnrolledClasses { get; set; } = new List<Class>();

        public List<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
        public List<Receipt> Receipts { get; set; } = new List<Receipt>();
        public List<Fee> Fees { get; set; } = new List<Fee>();
        public List<ReceiptDataImport> ReceiptDataImports { get; set; } = new List<ReceiptDataImport>();

    }
    public class PersonList : BindingList<Person> { }

    public class EmailCommunicationRequiresEmailAddressAttribute : ValidationAttribute
    {
        private readonly string _emailAddress;

        public EmailCommunicationRequiresEmailAddressAttribute(string EmailAddress) {
            _emailAddress = EmailAddress;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            ErrorMessage = ErrorMessageString;
            var CommunicationMethod = (string?)value;

            var property = validationContext.ObjectType.GetProperty(_emailAddress);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var emailAddress = (string?)property.GetValue(validationContext.ObjectInstance);

            if (CommunicationMethod.ToLower() == "email" && string.IsNullOrWhiteSpace(emailAddress))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}

public class EmailAddressAlowNullAttribute : ValidationAttribute
{

    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        ErrorMessage = ErrorMessageString;
        var emailAddress = (string)value;

        if (string.IsNullOrWhiteSpace(emailAddress)) return ValidationResult.Success;

        var a = new EmailAddressAttribute();
        return a.GetValidationResult(value, validationContext);
    }
}

