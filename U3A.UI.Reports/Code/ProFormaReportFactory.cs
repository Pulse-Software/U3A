using DevExpress.DataAccess.Json;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.DataAccess.Sql;
using DevExpress.ReportServer.ServiceModel.DataContracts;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using U3A.BusinessRules;
using U3A.Database;
using U3A.Model;
using U3A.Services;
using U3A.UI.Reports;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace U3A.UI.Reports
{
    public class ProFormaReportFactory : IDisposable
    {

        public List<string> PostalReports { get; set; }

        IDbContextFactory<U3ADbContext> U3AdbFactory;
        U3ADbContext? dbc;
        CustomReportStorageWebExtension storage;
        XtraReport cashReceiptProForma;
        XtraReport participantEnrolmentProForma;
        XtraReport leaderReportProForma;
        XtraReport leaderAttendanceList;
        XtraReport leaderClassList;
        XtraReport leaderICEList;

        IEmailService emailSender;
        PdfExportOptions options;
        bool isPreview;
        string sendEmailAddress;
        string sendEmailDisplayName;

        public ProFormaReportFactory(IWebHostEnvironment env, IDbContextFactory<U3ADbContext> U3AdbFactory, bool IsPreview) {
            this.U3AdbFactory = U3AdbFactory ?? throw new ArgumentNullException(nameof(U3AdbFactory));
            storage = new CustomReportStorageWebExtension(env, this.U3AdbFactory);
            isPreview = IsPreview;
            dbc = this.U3AdbFactory.CreateDbContext();
            var settings = dbc.SystemSettings.FirstOrDefault() ?? throw new ArgumentNullException(nameof(SystemSettings));
            if (settings != null) {
                sendEmailAddress = settings.SendEmailAddesss;
                sendEmailDisplayName = settings.SendEmailDisplayName;
            }
            emailSender = EmailFactory.GetEmailSender(dbc);
            options = new PdfExportOptions() {
                ImageQuality = PdfJpegImageQuality.Lowest,
            };
            PostalReports = new List<string>();
        }

        public async Task<string> CreateCashReceiptProForma(Receipt receipt) {
            if (cashReceiptProForma == null) {
                cashReceiptProForma = CreateReport("CashReceipt");
            }
            var detail = BusinessRule.GetReceiptDetail(dbc, receipt);
            var person = await dbc.Person.FindAsync(receipt.PersonID);
            var list = new List<ReceiptDetail>();
            list.Add(detail);
            cashReceiptProForma.DataSource = list;
            cashReceiptProForma.CreateDocument();
            string pdfFilename = GetTempPdfFile();
            cashReceiptProForma.ExportToPdf(pdfFilename, options);
            if (!isPreview && person.Communication.ToLower() == "email") {
                return await emailSender.SendEmailAsync(EmailType.Transactional,
                                sendEmailAddress,
                                sendEmailDisplayName,
                                person.Email,
                                person.FullName,
                                $"U3A Cash Receipt: {person.FullName}",
                                $"<p>Hello {person.FirstName},</p>" +
                                $"<p>Please find your U3A cash receipt attached.</p>" +
                                $"<p><p>Thank you<br/>" +
                                $"{sendEmailDisplayName}</p>",
                                string.Empty,
                                new List<string>() { pdfFilename },
                                new List<string>() { "Cash Receipt.pdf" }
                                );
            }
            else {
                PostalReports.Add(pdfFilename);
                return (isPreview) ? String.Empty : "Accepted";
            }
        }
        public async Task<Dictionary<Guid, string>> CreateEnrolmentProForma(Dictionary<Guid, List<Enrolment>> Enrolments) {
            if (participantEnrolmentProForma == null) {
                participantEnrolmentProForma = CreateReport("ParticipantEnrolment");
            }
            var result = new Dictionary<Guid, string>();
            foreach (var kvp in Enrolments) {
                var person = await dbc.Person.FindAsync(kvp.Key);
                var personsFiles = new List<string>();
                foreach (var enrolment in kvp.Value) {
                    var detail = BusinessRule.GetEnrolmentDetail(dbc, enrolment);
                    participantEnrolmentProForma.DataSource = detail;
                    participantEnrolmentProForma.CreateDocument();
                    string pdf = GetTempPdfFile();
                    participantEnrolmentProForma.ExportToPdf(pdf, options);
                    personsFiles.Add(pdf);
                }
                var pdfFilename = CreateMergedPDF(personsFiles);
                if (!isPreview && person.Communication.ToLower() == "email") {
                    result.Add(kvp.Key, await emailSender.SendEmailAsync(
                                   EmailType.Transactional,
                                   sendEmailAddress,
                                   sendEmailDisplayName,
                                   person.Email,
                                   person.FullName,
                                   $"U3A Enrolment: {person.FullName}",
                                   $"<p>Hello {person.FirstName},</p>" +
                                   $"<p>Please find your U3A enrolment details attached.</p>" +
                                   $"<p><p>Thank you<br/>" +
                                   $"{sendEmailDisplayName}</p>",
                                   string.Empty,
                                   new List<string>() { pdfFilename },
                                   new List<string>() { "Your Enrolment Details.pdf" }
                                   ));
                }
                else {
                    PostalReports.Add(pdfFilename);
                    result.Add(kvp.Key, (isPreview) ? String.Empty : "Accepted");
                }
            }
            return result;
        }

        public async Task<string> CreateLeaderReports(
                                        bool DoLeaderReport,
                                        bool DoLeaderAttendanceList,
                                        bool DoLeaderClassList,
                                        bool DoLeaderICEList,
                                        bool DoLeaderCSVFile,
                                        Person Leader, Enrolment[] Enrolments) {
            var result = string.Empty;
            var createdFilenames = new List<string>();
            var reportNames = new List<string>();
            if (DoLeaderReport) {
                if (leaderReportProForma == null) leaderReportProForma = CreateReport("LeaderReport");
                createdFilenames.Add(await CreateLeaderReportAsync(leaderReportProForma, Leader, Enrolments));
                reportNames.Add("Leader's Report.pdf");
            }
            if (DoLeaderAttendanceList) {
                if (leaderAttendanceList == null) leaderAttendanceList = new LeaderAttendanceList();
                createdFilenames.Add(await CreateLeaderReportAsync(leaderAttendanceList, 
                                        Leader, Enrolments.Where(x => !x.IsWaitlisted).ToArray()));
                reportNames.Add("Student Attendance Record.pdf");
            }
            if (DoLeaderClassList) {
                if (leaderClassList == null) leaderClassList = new LeaderClassList();
                createdFilenames.Add(await CreateLeaderReportAsync(leaderClassList, 
                                        Leader, Enrolments.Where(x => !x.IsWaitlisted).ToArray()));
                reportNames.Add("Class Contact Listing.pdf");
            }
            if (DoLeaderICEList) {
                if (leaderICEList == null) leaderICEList = new LeaderICEList();
                createdFilenames.Add(await CreateLeaderReportAsync(leaderICEList, 
                                        Leader, Enrolments.Where(x => !x.IsWaitlisted).ToArray()));
                reportNames.Add("Class ICE Listing.pdf");
            }
            if (DoLeaderCSVFile && !isPreview) {
                createdFilenames.Add(CreateCSVFile(Enrolments.Where(x => !x.IsWaitlisted).ToArray()));
                reportNames.Add("Class List.csv");
            }
            return await ProcessLeaderReport(Leader, createdFilenames.ToArray(), reportNames.ToArray());
        }

        string CreateCSVFile(Enrolment[] Enrolments) {
            var sb = new StringBuilder();
            sb.AppendLine("\"WaitListed?\",\"LastName\",\"FirstName\",\"Email\",\"Mobile\",\"Home\",\"Address\",\"City\",\"State\"");
            foreach (var e in Enrolments) {
                    var p = e.Person; if (p != null) {
                    sb.AppendLine($"\"{e.IsWaitlisted}\",\"{p.LastName}\",\"{p.FirstName}\",\"{p.Email}\",\"{p.HomePhone}\",\"{p.Mobile}\",\"{p.Address}\",\"{p.City}\",\"{p.State}\"");
                }
            }
            var outputFilename = GetTempCSVFile();
            using (var sw = new StreamWriter(outputFilename)) {
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
            }
            return outputFilename;
        }
        public async Task<string> CreateLeaderReportProForma(Person Leader, Enrolment[] Enrolments) {
            if (leaderReportProForma == null) {
                leaderReportProForma = CreateReport("LeaderReport");
            }
            var report = await CreateLeaderReportAsync(leaderReportProForma, Leader, Enrolments);
            return await ProcessLeaderReport(Leader, new string[] { report }, new string[] { "Leader Report.pdf" });
        }
        async Task<string> CreateLeaderReportAsync(XtraReport report,
                Person Leader,
                Enrolment[] Enrolments) {
            var term = dbc.Term.Find(Enrolments[0].TermID);
            var leaderDetail = BusinessRule.GetLeaderDetail(dbc, Leader, term);
            var enrolmentDetails = new List<EnrolmentDetail>();
            foreach (var enrolment in Enrolments) {
                enrolmentDetails.AddRange(BusinessRule.GetEnrolmentDetail(dbc, enrolment));
            }
            var dataSources = DataSourceManager.GetDataSources<ObjectDataSource>(
                report: report,
                includeSubReports: true
            );
            foreach (var ds in dataSources) {
                ds.DataMember = String.Empty;
                if (ds.Name == "objectDataSource1")
                    ds.DataSource = leaderDetail;
                else
                    ds.DataSource = enrolmentDetails;
            }
            report.CreateDocument();
            string pdfFilename = GetTempPdfFile();
            report.ExportToPdf(pdfFilename, options);
            return pdfFilename;
        }

        async Task<string> ProcessLeaderReport(Person Leader, string[] CreatedFilenames, string[] ReportsNames) {
            if (!isPreview && Leader.Communication.ToLower() == "email") {
                return await emailSender.SendEmailAsync(
                                EmailType.Transactional,
                                sendEmailAddress,
                                sendEmailDisplayName,
                                Leader.Email,
                                Leader.FullName,
                                $"U3A Leader Report(s): {Leader.FullName}",
                                $"<p>Hello {Leader.FirstName},</p>" +
                                $"<p>Please find your U3A Leader report(s) attached.</p>" +
                                $"<p><p>Thank you<br/>" +
                                $"{sendEmailDisplayName}</p>",
                                string.Empty,
                                CreatedFilenames, ReportsNames
                                );
            }
            else {
                PostalReports.AddRange(CreatedFilenames);
                return (isPreview) ? String.Empty : "Accepted";
            }
        }

        public string? CreatePostalPDF() {
            return Path.GetFileName(CreateMergedPDF(PostalReports));
        }
        public string? CreateMergedPDF(List<string> pdfFilenames) {
            if (pdfFilenames.Count > 0) {
                PdfDocument outputDocument = new PdfDocument();
                foreach (string file in pdfFilenames) {
                    PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);
                    int count = inputDocument.PageCount;
                    for (int idx = 0; idx < count; idx++) {
                        PdfPage page = inputDocument.Pages[idx];
                        outputDocument.AddPage(page);
                    }
                }
                outputDocument.Close();
                // Save the document...
                var outputFile = GetTempPdfFile();
                outputDocument.Save(outputFile);
                return outputFile;
            }
            else return null;
        }

        private string GetTempPdfFile() {
            return Path.Combine(storage.TempDirectory, Guid.NewGuid() + ".pdf");
        }
        private string GetTempCSVFile() {
            return Path.Combine(storage.TempDirectory, Guid.NewGuid() + ".csv");
        }
        private string GetFullPath(string fileName) {
            return Path.Combine(storage.TempDirectory, fileName);
        }
        private XtraReport CreateReport(string name) {
            MemoryStream stream = new MemoryStream(storage.GetData(name));
            XtraReport report = new XtraReport();
            report.LoadLayout(stream);
            return report;
        }

        public void Dispose() {
            dbc?.Dispose();
        }
    }
}
