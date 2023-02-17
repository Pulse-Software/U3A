using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace U3A.Model
{
    [Index(nameof(Name), IsUnique = true)]
    public class DocumentTemplate
    {
        [Key]
        public Guid ID { get; set; }

        public int? DocumentTypeID { get; set; }
        public DocumentType DocumentType { get; set; }

        public string DocumentTypeName {
            get {
                string result = string.Empty;
                if (DocumentType != null) result= DocumentType.Name;
                return result; 
            }
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        [RequiredIfEmailDocumentType("DocumentType", ErrorMessage = "An email document type requires a Subject.")]
        public String? Subject { get; set; }

        [MaxLength(50)]
        [RequiredIfEmailDocumentType("DocumentType", ErrorMessage = "An email document type requires a From Email Address.")]
        public String? FromEmailAddress { get; set; }

        [MaxLength(50)]
        [RequiredIfEmailDocumentType("DocumentType", ErrorMessage = "An email document type requires a Display Name.")]
        [RequiredIfSMSDocumentType("DocumentType", ErrorMessage = "An SMS document type requires a Display Name, 11 charcters or less.")]
        public String? FromDisplayName { get; set; }

        public byte[] Content { get; set; }
        public string HTML { get; set; }

    }

    public class RequiredIfEmailDocumentTypeAttribute : ValidationAttribute
    {
        private readonly string _fieldData;

        public RequiredIfEmailDocumentTypeAttribute(string FieldData) {
            _fieldData = FieldData;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            ErrorMessage = ErrorMessageString;
            var fieldToTest = (string?)value;

            var property = validationContext.ObjectType.GetProperty(_fieldData);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var documentType = (DocumentType?)property.GetValue(validationContext.ObjectInstance);

            if (documentType != null && documentType.IsEmail && string.IsNullOrWhiteSpace(fieldToTest))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
    public class RequiredIfSMSDocumentTypeAttribute : ValidationAttribute
    {
        private readonly string _fieldData;

        public RequiredIfSMSDocumentTypeAttribute(string FieldData) {
            _fieldData = FieldData;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            ErrorMessage = ErrorMessageString;
            var fieldToTest = (string?)value;

            var property = validationContext.ObjectType.GetProperty(_fieldData);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var documentType = (DocumentType?)property.GetValue(validationContext.ObjectInstance);

            if (documentType != null && documentType.IsSMS &&
                    (string.IsNullOrWhiteSpace(fieldToTest) || fieldToTest.Length > 11))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }

}