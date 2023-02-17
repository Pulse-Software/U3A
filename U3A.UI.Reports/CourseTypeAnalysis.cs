using DevExpress.Web;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reactive.Threading.Tasks;
using U3A.BusinessRules;
using U3A.Database;
using U3A.Model;

namespace U3A.UI.Reports
{
    public partial class CourseTypeAnalysis : DevExpress.XtraReports.UI.XtraReport, IXtraReportWithDbContext
    {
        public CourseTypeAnalysis() {
            InitializeComponent();
        }

        public U3ADbContext DbContext { get; set; }
        List<Course> Courses;

        private void CourseList_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {
            Guid id = (Guid)paramCourseYear.Value;
            var term = DbContext.Term.Find(id);
            if (term != null) {
                Courses = BusinessRule.SelectableCourses(DbContext, term);
                DataSource = Courses;
            }
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
                    groupHeaderBand1.Visible = false;
                    Detail.Visible = false;
                    foreach (XRControl row in xrTable2.Rows) {
                        foreach (XRControl cell in row.Controls) {
                            cell.BackColor = Color.Transparent;
                            cell.BorderColor = Color.Silver;
                        }
                    }
                    reportStyle = "Summary";
                    break;
                default: // Detail
                    groupHeaderBand1.Visible = true;
                    Detail.Visible = true;
                    foreach (XRControl row in xrTable2.Rows) {
                        foreach (XRControl cell in row.Controls) {
                            cell.BackColor = Color.WhiteSmoke;
                            cell.BorderColor = Color.Silver;
                        }
                    }
                    reportStyle = "Detail";
                    break;
            }
            paramReportTitle.Value = $"{reportStyle} Course Type Analysis {reportSort}".Trim();
            paramTermSummary.Value = term?.TermSummary;
        }

        private void CourseList_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {
            var terms = BusinessRule.SelectableTerms(DbContext);
            objectDataSource2.DataSource = terms;
            var term = BusinessRule.CurrentTerm(DbContext);
            paramTermSummary.Value = term?.TermSummary;
            paramCourseYear.Value = term?.ID;
        }

        private void xrReportTotalMax_BeforePrint(object sender, CancelEventArgs e) {
            xrReportTotalMax.Text = Courses.Sum(x => x.MaximumStudents).ToString("n0");
        }

        private void xrReportTotalMin_BeforePrint(object sender, CancelEventArgs e) {
            xrReportTotalMin.Text = Courses.Sum(x => x.RequiredStudents).ToString("n0");
        }
    }
}
