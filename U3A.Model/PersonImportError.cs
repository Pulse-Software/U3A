using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace U3A.Model
{
    public class PersonImportError {
        public Guid ID { get; set; }
        public string Filename { get; set; }
        public DateTime ImportDate { get; set; }
        public int LineNumber { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Course { get; set; }
        public string? Error { get; set; }
    }

}
