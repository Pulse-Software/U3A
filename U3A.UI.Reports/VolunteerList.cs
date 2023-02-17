using DevExpress.XtraReports.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using U3A.Database;
using U3A.Model;

namespace U3A.UI.Reports
{

    public partial class VolunteerList : DevExpress.XtraReports.UI.XtraReport, IXtraReportWithDbContext
    {
        public VolunteerList() {
            InitializeComponent();
        }

        public U3ADbContext DbContext { get; set; }
        private void CeasedParticipantList_DataSourceDemanded(object sender, EventArgs e) {
            DataSource = DbContext.Volunteer.Include(x => x.Person).Where(x => x.Person.DateCeased == null).ToList();
        }
    }
}

