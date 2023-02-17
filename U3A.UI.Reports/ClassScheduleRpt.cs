using DevExpress.DataAccess.ObjectBinding;
using DevExpress.ReportServer.ServiceModel.DataContracts;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using U3A.BusinessRules;
using U3A.Database;

namespace U3A.UI.Reports
{
    public partial class ClassScheduleRpt : DevExpress.XtraReports.UI.XtraReport, IXtraReportWithDbContext
    {
        public ClassScheduleRpt() {
            InitializeComponent();
        }

        public U3ADbContext DbContext { get; set; }

        private void ClassSchedule_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {
            var terms = BusinessRule.SelectableTerms(DbContext);
            objectDataSource2.DataSource = terms;
            var term = BusinessRule.CurrentTerm(DbContext);
            prmTerm.Value = term?.ID;
        }

        private void ClassSchedule_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {
            CreateReport();
        }

        public void CreateReport() {
            Guid id = (Guid)prmTerm.Value;
            var settings = DbContext.SystemSettings.FirstOrDefault();
            prmU3AGroup.Value = settings.U3AGroup;
            prmABN.Value = settings.ABN;
            var term = DbContext.Term.Find(id);
            if (term != null) {
                DataSource = BusinessRule.GetClassDetails(DbContext, term);
            }
            prmTermSummary.Value = term?.TermSummary;
            rowLeaderDetail.Visible = ((int)prmIntendedUse.Value == 0) ? false : true;
            var fieldValue = string.Empty;
            switch ((int)prmIntendedUse.Value) {
                case 1: // member view
                    fieldValue = "[Leader].[FirstName] + ' ' + Iif(IsNullOrEmpty([Leader].[Mobile]),[Leader].[HomePhone] ,[Leader].[Mobile] )";
                    break;
                case 2: // internal view
                    fieldValue = "[Leader].[FullName] + ' ' + [Leader].[Email] + ' ' + Iif(IsNullOrEmpty([Leader].[Mobile]),[Leader].[HomePhone] ,[Leader].[Mobile] )";
                    break;
                default:
                    break;
            }
            lblLeaderDetail.ExpressionBindings.Clear();
            lblLeaderDetail.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", fieldValue)});
            lblWatermark.Text = (string)prmWatermark.Value;
            lblTitleWatermark.Text = (string)prmWatermark.Value;
        }

    }


}

