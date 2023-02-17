using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using U3A.BusinessRules;
using U3A.Database;
using U3A.Model;

namespace U3A.UI.Reports
{
    public partial class VenueConflictList : DevExpress.XtraReports.UI.XtraReport, IXtraReportWithDbContext
    {
        public VenueConflictList() {
            InitializeComponent();
        }

        public U3ADbContext DbContext { get; set; }

        private void VenueConflictList_DataSourceDemanded(object sender, EventArgs e) {
            Term term = new Term() {
                Duration = (int)WeeksReqd.Value,
                StartDate = (DateTime)StartDate.Value,
                TermNumber = 1,
                Year = 9999
            };
            DataSource = BusinessRule.ReportableVenueConflicts(DbContext, term);
        }

        private void VenueConflictList_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {
            StartDate.Value = DateTime.Today;
        }
    }
}
