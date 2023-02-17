using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    [NotMapped]
    public class PersonFinancialStatus
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? HomePhone { get; set; }
        public Boolean IsLifeMember { get; set; } = false;
        public Boolean IsCourseLeader { get; set; } = false;
        public Boolean IsComplimentary { get; set; } = false;
        public int Waitlisted { get; set; } = 0;
        public int Enrolments { get; set; } = 0;
        public decimal MembershipFees { get; set; } = decimal.Zero;
        public decimal MailSurcharge { get; set; } = decimal.Zero;
        public decimal CourseFeesPerYear { get; set; } = decimal.Zero;
        public decimal CourseFeesPerTerm { get; set; } = decimal.Zero;
        public decimal AmountReceived { get; set; } = decimal.Zero;
        public decimal TotalFees { get {
                return MembershipFees+MailSurcharge+CourseFeesPerYear+CourseFeesPerYear-AmountReceived;
            }
        }
        public DateTime? DateJoined { get; set; }
        public int FinancialTo { get; set; } = constants.START_OF_TIME;
        public DateTime? LastReceipt { get; set; }

    }
}
