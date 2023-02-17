using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace U3A.Model
{
    [Index(nameof(Name), IsUnique = true)]
    public class CourseType
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Boolean Discontinued { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Comment { get; set; } = string.Empty;

        public string NameWithStatus {
            get {
                if (!Discontinued) return Name; else return $"{Name} (Discontinued)";
            }
        }

        public List<Course> Courses { get; set; } = new List<Course>();

    }
}