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
            prmMembershipYear.Value = DateTime.Now.Year;
        }

        public U3ADbContext DbContext { get; set; }

        private void MemberPaymentsReport_DataSourceDemanded(object sender, EventArgs e) {
            DataSource = BusinessRule.GetComplimentaryReceipts(DbContext,(int)prmMembershipYear.Value);
        }
    }
}
