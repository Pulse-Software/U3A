using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    [NotMapped]
    public class AUState : List<string>
    {
        public AUState() {
            base.Add("NSW");
            base.Add("ACT");
            base.Add("VIC");
            base.Add("QLD");
            base.Add("SA");
            base.Add("WA");
            base.Add("TAS");
            base.Add("NT");
        }
    }
}