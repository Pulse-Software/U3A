using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    public static class Age
    {
        public static int? Calculate(DateTime? FromDate) {
            return Calculate(null, FromDate);
        }
        public static int? Calculate(DateTime? Now, DateTime? FromDate) {
            int? result = 0;
            if (FromDate == null) return result;
            var now = (Now == null) ? DateTime.Today : Now;
            TimeSpan span = (TimeSpan)(now - FromDate);
            if (span >= TimeSpan.Zero) {
                DateTime age = DateTime.MinValue + span;
                // note: MinValue is 1/1/1 so we have to subtract a year here. 
                result = age.Year - 1;
            }
            return result;
        }
    }
}
