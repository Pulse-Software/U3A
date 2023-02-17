using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace U3A.UI.Reports
{
    public partial class PublicHolidayList : DevExpress.XtraReports.UI.XtraReport
    {
        public PublicHolidayList() {
            InitializeComponent();
        }

        private void PublicHolidayList_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {
            StartDate.Value = new DateTime(DateTime.Today.Year, 1, 1, 0, 0, 0);
            EndDate.Value = new DateTime(DateTime.Today.Year, 12, 31, 0, 0, 0);
        }
    }
}
