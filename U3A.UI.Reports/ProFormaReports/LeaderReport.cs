using DevExpress.XtraReports.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using U3A.Database;
using U3A.BusinessRules;
using DevExpress.DataAccess.Json;
using DevExpress.XtraReports;
using DevExpress.DataAccess.ObjectBinding;

namespace U3A.UI.Reports
{
    public partial class LeaderReport : DevExpress.XtraReports.UI.XtraReport
    {
        public LeaderReport() {
            InitializeComponent();
        }

    }
}
