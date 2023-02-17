using System.ComponentModel.DataAnnotations.Schema;

namespace U3A.Model
{
    [NotMapped]
    public class DuplicatePerson
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public List<Person> Persons { get; set; } = new List<Person>();
    }
}
