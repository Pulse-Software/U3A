using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace U3A.Model
{
    [Index(new string[] { nameof(TermID), nameof(ClassID), nameof(Date) },IsUnique = false )]
    public class AttendClass
    {

        [Key]
        public Guid ID { get; set; }

        public bool IsAdHoc { get; set; }
        public Guid TermID { get; set; }
        public Term Term { get; set; }

        public Guid? ClassID { get; set; }
        public Class? Class { get; set; }

        public DateTime Date { get; set; }

        public Guid PersonID { get; set; }
        public Person Person { get; set; }

        [Required]
        public AttendClassStatus AttendClassStatus { get; set; }

        public int AttendClassStatusID { get; set; }

        public string Comment { get; set; }

        public DateTime? DateProcessed { get; set; }

    }
}
