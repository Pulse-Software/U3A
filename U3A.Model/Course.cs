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
    [Index(nameof(Year),nameof(Name))]
    public class Course
    {
        [Key]
        public Guid ID { get; set; }

        public int ConversionID { get; set; }

        [Required]
        [DefaultValue(2022)]
        public int Year { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DefaultValue(" ")]
        public string? Description { get; set; }

        [DefaultValue(0)]
        public int? CourseParticipationTypeID { get; set; }
        public CourseParticipationType CourseParticipationType { get; set; }

        [Required]
        [Precision(precision: 18, 2)]
        [DefaultValue(0.00)]
        [Comment("Optional once-only course enrolment fee")]
        public decimal CourseFeePerYear { get; set; }

        [DefaultValue(" ")]
        public string? CourseFeePerYearDescription { get; set; }

        [Comment("Overrides the System Settings complimentary status for year fees")]
        public bool OverrideComplimentaryPerYearFee { get; set; }

        [Required]
        [Precision(precision: 18, 2)]
        [DefaultValue(0.00)]
        [Comment("Optional fee per term)")]
        public decimal CourseFeePerTerm { get; set; }

        [DefaultValue(" ")]
        public string? CourseFeePerTermDescription { get; set; }
        [Comment("Overrides the System Settings complimentary status for term fees")]
        public bool OverrideComplimentaryPerTermFee { get; set; }

        [Required]
        [Comment("The time in hours each class is expeted to take")]
        [Precision(precision: 18, 2)]
        [DefaultValue(2.00)]
        public decimal Duration { get; set; }

        [Required]
        [Comment("The required number of students per class")]
        [DefaultValue(6)]
        public int RequiredStudents { get; set; }

        [Required]
        [Comment("The maximum number of students per class")]
        [DefaultValue(28)]
        public int MaximumStudents { get; set; }
        [Required]
        public bool ExcludeFromLeaderComplimentaryCount { get; set; }

        [NotMapped]
        [Comment("Set By Business Rule")]
        public int TotalActiveStudents { get; set; }
        [NotMapped]
        [Comment("Set By Business Rule")]
        public int TotalWaitlistedStudents { get; set; }

        [NotMapped]
        [Comment("Set By Business Rule")]
        public double ParticipationRate { get; set; }

        public CourseType CourseType { get; set; }
        public Guid? CourseTypeID { get; set; }

        public List<Class> Classes { get; set; } = new List<Class>();

        public List<Enrolment> Enrolments { get; set; } = new List<Enrolment>();

    }

}
