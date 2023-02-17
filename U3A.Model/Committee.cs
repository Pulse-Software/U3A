using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace U3A.Model
{
    [Index(nameof(Position),nameof(PersonID), IsUnique = true)]
    public class Committee
    {
        public Guid ID { get; set; }

        [Required]
        public string Position { get; set; }
        public Guid? PersonID { get; set; }
        
        public Person? Person { get; set; }
    }
}
