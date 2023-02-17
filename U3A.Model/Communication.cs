using System.ComponentModel.DataAnnotations.Schema;

namespace U3A.Model
{
    [NotMapped]
    public class Communication : List<string>
    {
        public Communication() {
            base.Add("Email");
            base.Add("Post");
        }
    }
}