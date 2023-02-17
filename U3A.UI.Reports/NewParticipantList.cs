using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace U3A.UI.Reports
{
    public partial class NewParticipantList : DevExpress.XtraReports.UI.XtraReport
    {
        public NewParticipantList() {
            InitializeComponent();
            StartDate.Value = DateTime.Today.AddDays(DateTime.Today.Day * -1).AddDays(1);
        }
    }
}
