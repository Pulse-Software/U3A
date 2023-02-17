using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U3A.Database;

namespace U3A.UI.Reports
{
    public interface IXtraReportWithDbContextFactory
    {
        public IDbContextFactory<U3ADbContext> U3Adbfactory { get; set; }

    }
}
