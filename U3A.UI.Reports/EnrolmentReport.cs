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
    public partial class EnrolmentReport : DevExpress.XtraReports.UI.XtraReport, IXtraReportWithDbContext
    {
        public EnrolmentReport() {
            InitializeComponent();
        }

        public U3ADbContext DbContext { get; set; }

        List<Course> Courses;
        private void CourseList_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {
            Guid id = (Guid)paramCourseYear.Value;
            var term = DbContext.Term.Find(id);
            if (term != null) {
                Courses= BusinessRule.SelectableCourses(DbContext,term);
                var data = BusinessRule.SelectableEnrolments(DbContext, term);
                switch ((int)prmEnrolmentStatus.Value) {
                    case 1:
                        objectDataSource1.DataSource = data.Where(x => !x.IsWaitlisted).ToList();
                        paramReportTitle.Value = "Active Student Enrolment Report";
                        break;
                    case 2:
                        objectDataSource1.DataSource = data.Where(x => x.IsWaitlisted).ToList();
                        paramReportTitle.Value = "Waitlisted Student Enrolment Report";
                        break;
                    default:
                        objectDataSource1.DataSource = data;
                        paramReportTitle.Value = "Student Enrolment Report";
                        break;
                }
            }
            paramTermSummary.Value = term?.TermSummary;
            paramCourseYear.Value = term?.ID;
        }

        private void CourseList_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {
            var terms = BusinessRule.SelectableTerms(DbContext);
            objectDataSource2.DataSource = terms;
            var term = BusinessRule.CurrentTerm(DbContext);
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
