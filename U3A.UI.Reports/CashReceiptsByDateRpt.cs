using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using U3A.BusinessRules;
using U3A.Database;

namespace U3A.UI.Reports
{
    public partial class CashReceiptsByDateRpt : DevExpress.XtraReports.UI.XtraReport, IXtraReportWithDbContext
    {
        public CashReceiptsByDateRpt() {
            InitializeComponent();
            FromDate.Value = DateTime.Today.AddDays(DateTime.Today.Day * -1 + 1);
            ToDate.Value = DateTime.Today.AddMonths(1).AddDays(DateTime.Today.Day * -1);
        }

        public U3ADbContext DbContext { get; set; }

        private void CashReceiptsByDate_DataSourceDemanded(object sender, EventArgs e) {
            var fromDate = (DateTime)FromDate.Value;
            var toDate = ((DateTime)ToDate.Value).AddDays(1);
            DataSource = BusinessRule.GetCashReceiptsByDate(DbContext, fromDate, toDate);
        }
    }
}
