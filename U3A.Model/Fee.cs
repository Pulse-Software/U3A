using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace U3A.Model
{
    [Index(nameof(ProcessingYear))]
    [Index(nameof(Date), nameof(Description))]
    public class Fee : BaseEntity
    {
        public Guid ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int ProcessingYear { get; set; }
        [Required]
        [Precision(precision: 18, 2)]
        public decimal Amount { get; set; }
        [Required]
        public string Description { get; set; }
        public Guid PersonID { get; set; }
        [Required]
        public Person Person { get; set; }
        [Comment("If true, will be included in the calculation of member Financial To")]
        public bool IsMembershipFee { get; set; }
    }
}
