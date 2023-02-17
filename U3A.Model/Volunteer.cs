using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace U3A.Model
{
    [Index(nameof(Activity), nameof(PersonID), IsUnique = true)]
    public class Volunteer
    {
        public Guid ID { get; set; }

        [Required]
        public string Activity { get; set; }
        public Guid PersonID { get; set; }
        [Required]
        public Person Person { get; set; }
        public string? Comment { get; set; }
    }
}
