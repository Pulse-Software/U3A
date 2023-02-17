using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Import.Doc;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using U3A.Database;
using U3A.Model;

namespace U3A.UI.Reports
{
    public partial class SummaryParticipantList : DevExpress.XtraReports.UI.XtraReport, IXtraReportWithDbContext
    {
        public SummaryParticipantList() {
            InitializeComponent();
        }

        public U3ADbContext DbContext {get; set; }
        FinancialStatusCollection list = new FinancialStatusCollection();

        private void SummaryParticipantList_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {
                list.BuildList(DbContext);
                objectDataSource2.DataSource = list;
            foreach (ParameterInfo info in e.ParametersInformation) {
                if (info.Parameter.Name == "paramFinStatus") {
                    info.Parameter.Value = list.FirstOrDefault().Key;
                }
            }
        }

        private void SummaryParticipantList_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {
            Term? term = DbContext.Term.Where(x => x.IsDefaultTerm).FirstOrDefault();
            if (term != null) {
                int key = (int)paramFinStatus.Value;
                var persons = DbContext.Person.Where(x => x.DateCeased == null).ToList();
                switch (key) {
                    case int.MaxValue-1:
                        persons = persons.Where(x => x.FinancialTo < term.Year).ToList();
                        break;
                    case int.MaxValue: // Ignore Financial Status
                        break;
                    default:
                        persons = persons.Where(x => x.FinancialTo == key).ToList();
                        break;
                }
                DataSource = persons;
                lblSubTitle.Text = list[key];
            }
        }
    }
}
