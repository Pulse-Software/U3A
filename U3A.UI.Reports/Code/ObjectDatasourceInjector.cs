using System;
using System.ComponentModel.Design;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports;
using DevExpress.XtraReports.Native.Data;
using DevExpress.XtraReports.Services;
using DevExpress.XtraReports.UI;
using Microsoft.Extensions.DependencyInjection;

namespace U3A.UI.Reports
{
    public interface IObjectDataSourceInjector
    {
        public void Process(XtraReport report);
    }

    public class ObjectDataSourceInjector : IObjectDataSourceInjector
    {
        IServiceProvider ServiceProvider { get; }

        public ObjectDataSourceInjector(IServiceProvider serviceProvider) {
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public void Process(XtraReport report) {
            foreach (var ods in DataSourceManager.GetDataSources<ObjectDataSource>(report, includeSubReports: true)) {
                if (ods.DataSource is Type dataSourceType) {
                    ods.DataSource = ServiceProvider.GetRequiredService(dataSourceType);
                }
            }
        }
    }
}