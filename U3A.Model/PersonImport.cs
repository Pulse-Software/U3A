using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Pdf.Native.BouncyCastle.Asn1.Ocsp;

namespace U3A.Model
{
    [Index(new string[] { nameof(LastName), nameof(FirstName), nameof(IsNewPerson) }, IsUnique = false)]
    [Index(nameof(Timestamp))]
    public class PersonImport
    {
        [Key]
        public Guid ID { get; set; }

        public string Timestamp { get; set; }
        public string? CurrentStudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Postcode { get; set; }

        public string Gender { get; set; }

        public DateTime? BirthDate { get; set; }
        public string? Email { get; set; }
        public string? HomePhone { get; set; }
        public string? Mobile { get; set; }
        public bool SMSOptOut { get; set; }
        public string? ICEContact { get; set; }
        public string? ICEPhone { get; set; }

        public bool VaxCertificateViewed { get; set; }

        public string? Occupation { get; set; }

        public string Communication { get; set; } = "Email";

        public bool IsNewPerson { get; set; }
        public int CourseChoice01 { get; set; }
        public int CourseChoice02 { get; set; }
        public int CourseChoice03 { get; set; }
        public int CourseChoice04 { get; set; }
        public int CourseChoice05 { get; set; }
        public int CourseChoice06 { get; set; }
        public string Filename { get; set; }
        public int Linenumber { get; set; }

        [NotMapped]
        public string Status { get; set; } = "Ok";

        [NotMapped]
        public string CourseRequests {
            get {
                return $"{CourseChoice01.ToString("#")} {CourseChoice02.ToString("#")} {CourseChoice03.ToString("#")} {CourseChoice04.ToString("#")} {CourseChoice05.ToString("#")} {CourseChoice06.ToString("#")}".Trim();
            }
        }

        [NotMapped]
        public string Issues { get; set; }

    }
}
