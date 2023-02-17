using DevExpress.Web;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reactive.Threading.Tasks;
using U3A.BusinessRules;
using U3A.Database;

namespace U3A.UI.Reports
{
    public partial class CourseList : DevExpress.XtraReports.UI.XtraReport, IXtraReportWithDbContext
    {
        public CourseList() {
            InitializeComponent();
        }

        public U3ADbContext DbContext { get; set; }

        private void CourseList_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {
            Guid id = (Guid)paramCourseYear.Value;
            var term = DbContext.Term.Find(id);
            if (term != null) {
                DataSource = BusinessRule.SelectableCourses(DbContext, term);
            }
            paramTermSummary.Value = term?.TermSummary;
            string reportStyle;
            string reportSort = string.Empty;
            int SortBy = (int)paramSortBy.Value;
            ReportGroup.GroupFields.Clear();
            switch (SortBy) {
                case 0: // Name
                    ReportGroup.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("Name", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
                    break;
                case 1: // Popularity
                    ReportGroup.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("calculatedField1", DevExpress.XtraReports.UI.XRColumnSortOrder.Descending)});
                    reportSort = "By Popularity";
                    break;
                case 2: // Participation Rate
                    ReportGroup.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("ParticipationRate", DevExpress.XtraReports.UI.XRColumnSortOrder.Descending)});
                    reportSort = "By Participation Rate";
                    break;
            }
            int style = (int)paramReportStyle.Value;
            switch (style) {
                case 1: // Summary
                    ClassSubReport.Visible = true;
                    rowDescription.Visible = false;
                    rowDetail.BackColor = Color.White;
                    reportStyle = "Summary";
                    break;
                case 2: // Abbreviated
                    ClassSubReport.Visible = false;
                    rowDescription.Visible = false;
                    rowDetail.BackColor = Color.White;
                    reportStyle = "Abbreviated";
                    break;
                default: // Detail
                    ClassSubReport.Visible = true;
                    rowDescription.Visible = true;
                    rowDetail.BackColor = Color.WhiteSmoke;
                    reportStyle = "Detail";
                    break;
            }
            paramReportTitle.Value = $"{reportStyle} Course Listing {reportSort}".Trim();
        }

        private void CourseList_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {
            var terms = BusinessRule.SelectableTerms(DbContext);
            objectDataSource2.DataSource = terms;
            var term = BusinessRule.CurrentTerm(DbContext);
            paramTermSummary.Value = term?.TermSummary;
            paramCourseYear.Value = term?.ID;
        }
    }
}
