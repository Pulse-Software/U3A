using Microsoft.EntityFrameworkCore;
using System.Linq;
using U3A.BusinessRules;
using U3A.Database;
using U3A.Model;

namespace U3A.UI.Reports
{
    public partial class ComplimentaryMembershipRpt : DevExpress.XtraReports.UI.XtraReport , IXtraReportWithDbContext
    {
        public ComplimentaryMembershipRpt() {
            InitializeComponent();
            FromDate.Value = DateTime.Today.AddDays(DateTime.Today.Day*-1 + 1);
            ToDate.Value = DateTime.Today.AddMonths(1).AddDays(DateTime.Today.Day * -1);
        }

        public U3ADbContext DbContext { get; set; }

        private void MemberPaymentsReport_DataSourceDemanded(object sender, EventArgs e) {
            var fromDate = (DateTime)FromDate.Value;
            var toDate = ((DateTime)ToDate.Value).AddDays(1);
            DataSource = BusinessRule.GetCashReceiptsByDate(DbContext,fromDate,toDate);
        }
    }
}
