using System.ComponentModel.DataAnnotations.Schema;

namespace U3A.Model
{
    [NotMapped]
    public class VenueConflict
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public List<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>();
    }
}
