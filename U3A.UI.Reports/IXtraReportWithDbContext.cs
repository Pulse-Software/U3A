using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U3A.Database;

namespace U3A.UI.Reports
{
    public interface IXtraReportWithDbContext
    {
        public U3ADbContext DbContext { get; set; }
    }
}
