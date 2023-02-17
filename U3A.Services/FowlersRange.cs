using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static U3A.Services.Helpers;

namespace U3A.Services
{

    public interface IFowlersRange<T>
    {
        T Start { get; }
        T End { get; }
        bool Includes(T value);
        bool Includes(IFowlersRange<T?> range);
    }

    public class DateRange : IFowlersRange<DateTime>
    {
        public DateRange(DateTime? start, DateTime? end) {
            Start = start.GetValueOrDefault();
            End = end.GetValueOrDefault();
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public bool Includes(DateTime value) {
            return (value >= Start && value < End);
        }

        public bool Includes(IFowlersRange<DateTime> range) {
            return range.Start >= Start && End < range.End;
        }
    }
}
