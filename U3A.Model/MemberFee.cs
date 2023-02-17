using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    [NotMapped]
    public class MemberFee
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
