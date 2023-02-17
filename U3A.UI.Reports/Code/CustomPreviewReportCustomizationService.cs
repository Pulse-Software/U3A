using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports.Native.Data;
using DevExpress.XtraReports.Services;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
using DevExpress.XtraReports.Web.ReportDesigner.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using U3A.Database;

namespace U3A.UI.Reports
{
    public class CustomPreviewReportCustomizationService : PreviewReportCustomizationService
    {
        readonly IObjectDataSourceInjector objectDataSourceInjector;
        public CustomPreviewReportCustomizationService(IObjectDataSourceInjector objectDataSourceInjector) {
            this.objectDataSourceInjector = objectDataSourceInjector;

        }
        public override void CustomizeReport(XtraReport report) {
            objectDataSourceInjector.Process(report);
        }
    }

}