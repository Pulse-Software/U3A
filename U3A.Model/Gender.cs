using System.ComponentModel.DataAnnotations.Schema;

namespace U3A.Model
{
    [NotMapped]
    public class Gender : List<string>
    {
        public Gender() {
            base.Add("Male");
            base.Add("Female");
            base.Add("Other");
        }
    }
}