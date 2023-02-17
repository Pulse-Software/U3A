using System.ComponentModel.DataAnnotations.Schema;

namespace U3A.Model
{
    [NotMapped]
    public class ClassDate
    {
        public DateTime Date { get; set; }
        public string DateName { get {
                return Date.ToString("ddd, dd MMM yyyy"); 
            }
        }
    }
}
