using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    public class AttendClassStatus
    {
        public int ID { get; set; }
        public string Status { get; set; }
    }

    public enum AttendClassStatusType
    {
        Present,
        AbsentFromClassWithoutApology,
        AbsentFromClassWithApology
    }

}
