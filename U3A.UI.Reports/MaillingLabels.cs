using DevExpress.Web.Internal;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using U3A.BusinessRules;
using U3A.Database;

namespace U3A.UI.Reports
{
    public partial class MaillingLabels : DevExpress.XtraReports.UI.XtraReport, IXtraReportWithDbContext
    {

        public U3ADbContext DbContext { get; set; }

        public MaillingLabels() {
            InitializeComponent();
            DataSourceDemanded += MaillingLabels_DataSourceDemanded;
        }

        private void MaillingLabels_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {

        }

        private void MaillingLabels_BeforePrint(object sender, CancelEventArgs e) {
            var settings = DbContext.SystemSettings.FirstOrDefault();
            var gap = Detail.MultiColumn.ColumnSpacing;
            if (settings != null) {
                BeginUpdate();
                SuspendLayout();
                Detail.MultiColumn.ColumnSpacing = 0;
                panel1.HeightF = (float)settings.MailLabelHeight * 10;
                panel1.WidthF = (float)settings.MailLabelWidth * 10;
                Detail.MultiColumn.ColumnWidth = (int)settings.MailLabelWidth * 10;
                TopMargin.HeightF = (float)(settings.MailLabelTopMargin * 10.0);
                BottomMargin.HeightF = (float)(settings.MailLabelBottomMargin * 10.0);
                var LeftMargin = (int)(settings.MailLabelLeftMargin * 10.0);
                var RightMargin = (int)(settings.MailLabelRightMargin * 10.0);
                Margins = new System.Drawing.Printing.Margins(LeftMargin, RightMargin,
                                                (int)TopMargin.HeightF, (int)TopMargin.HeightF);
                ResumeLayout();
                EndUpdate();
            }
        }

        private void MaillingLabels_DataSourceDemanded(object sender, EventArgs e) {
            var term = BusinessRule.CurrentTerm(DbContext);

            var includeUnfinancial = (bool)prmIncludeUnfinancial.Value;
            DataSource = BusinessRule.GetPostalPersons(DbContext,term, includeUnfinancial);
        }
    }
}
