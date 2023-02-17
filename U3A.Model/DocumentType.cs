using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    public class DocumentType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsEmail { get; set; }
        public bool IsSMS { get; set; }
        public bool IsPostal { get; set; }
        public bool IsEnrolmentSubDocument { get; set; }
        public bool IsREceiptSubDocument { get; set; }

    }
}
