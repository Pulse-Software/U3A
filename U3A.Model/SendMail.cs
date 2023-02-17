using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    public class SendMail : BaseEntity
    {
        public Guid ID { get; set; }
        public string DocumentName { get; set; }
        public Guid PersonID { get; set; }
        public Person Person { get; set; }
        public Guid RecordKey { get; set; }
        public Guid? TermID { get; set; }
        public string Status { get; set; } = String.Empty;
    }
}
