using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    public class Dropout
    {
        public Dropout() { DropoutDate = DateTime.Now; }

        [Key]
        public Guid ID { get; set; }

        public Guid TermID { get; set; }
        public Term Term { get; set; }

        public Guid CourseID { get; set; }
        public Course Course { get; set; }

        public Guid? ClassID { get; set; }
        public Class? Class { get; set; }

        public Guid PersonID { get; set; }
        [Required]
        public Person Person { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime DropoutDate { get; set; }

        public bool IsWaitlisted { get; set; }

        public string? DeletedBy { get; set; }
        public DateTime? DateEnrolled { get; set; }
    }
}
