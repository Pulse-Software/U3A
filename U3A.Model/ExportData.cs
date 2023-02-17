using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace U3A.Model
{
    [NotMapped]
    public class ExportData
    {
        public Guid P_Key { get; set; }
        //Participant data
        public string P_ID { get; set; }
        public int P_ConversionID { get; set; }
        public string P_FirstName { get; set; }
        public string P_LastName { get; set; }
        public string P_Address { get; set; }
        public string P_City { get; set; }
        public string P_State { get; set; }
        public int P_Postcode { get; set; }
        public string P_Gender { get; set; }
        public string? P_BirthDate { get; set; }
        public string? P_DateJoined { get; set; }
        public string? P_Email { get; set; }
        public string? P_HomePhone { get; set; }
        public string? P_Mobile { get; set; }
        public bool P_SMSOptOut { get; set; }
        public string? P_ICEContact { get; set; }
        public string? P_ICEPhone { get; set; }
        public bool P_VaxCertificateViewed { get; set; }
        public string? P_Occupation { get; set; }
        public string P_Communication { get; set; }
        public Boolean P_IsLifeMember { get; set; }
        public string P_FullName { get; set; }
        public Boolean P_IsCourseLeader { get; set; }

        // System Settings data

        public string S_U3AGroup { get; set; }
        public string? S_OfficeLocation { get; set; }
        public string S_PostalAddress { get; set; }
        public string S_StreetAddress { get; set; }
        public string S_ABN { get; set; }
        public string? S_Email { get; set; }
        public string? S_Website { get; set; }
        public string? S_Phone { get; set; }
        public decimal S_MembershipFee { get; set; }
        public decimal S_MailSurcharge { get; set; }
        public string S_fmtMembershipFee { get; set; }
        public string S_fmtMailSurcharge { get; set; }

    }
}
