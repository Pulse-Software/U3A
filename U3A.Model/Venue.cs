using DevExpress.Data.Linq.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    public class Venue
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Boolean Discontinued { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DefaultValue(0)]
        public int MaxNumber { get; set; }

        public string Address { get; set; } = string.Empty;

        public string? Equipment { get; set; }
        public string? Coordinator { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? AccessDetail { get; set; }
        public string? KeyCode { get; set; }

        public List<Class> Classes { get; set; } = new List<Class>();

        public string Comment { get; set; } = string.Empty;
    }
}
