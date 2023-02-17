using Microsoft.EntityFrameworkCore;

namespace U3A.Model
{
    public class EmailHistory
    {
        public Guid ID { get; set; }
        public string Service { get; set; }
        public DateTime Sent { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
    }
}
