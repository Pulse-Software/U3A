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

    public partial class SkillsList : DevExpress.XtraReports.UI.XtraReport, IXtraReportWithDbContext
    {
        public SkillsList() {
            InitializeComponent();
        }

        public U3ADbContext DbContext { get; set; }
        private void CeasedParticipantList_DataSourceDemanded(object sender, EventArgs e) {
            DataSource = DbContext.Person.Where(x => x.DateCeased == null 
                                     && !string.IsNullOrWhiteSpace(x.Occupation)).ToList();
        }

    }
}

