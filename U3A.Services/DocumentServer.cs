using System.Diagnostics;
using System.Text;
using U3A.Model;
using DevExpress.XtraRichEdit;
using U3A.Database;
using U3A.BusinessRules;
using U3A.Services;
using Microsoft.EntityFrameworkCore;
using DevExpress.XtraRichEdit.API.Native;

namespace U3A.Services
{

    public class DocumentServer
    {
        public event EventHandler<DocumentSentEventArgs> DocumentSentEvent;

        public int SuccessTransmissionAttempts { get; set; } = 0;
        public int FailureTransmissionAttempts { get; set; } = 0;
        public int BatchCount { get; set; } = 0;
        public int BatchSuccessCount { get; set; } = 0;
        public int BatchFailureCount { get; set; } = 0;
        public int BulkRecipientCount { get; set; } = 0;
        DateTime sendTime;
        public TimeSpan ElapsedTime { get; set; }

        void ClearCounters() {
            SuccessTransmissionAttempts= 0;
            FailureTransmissionAttempts= 0;
            BatchCount= 0;
            BatchSuccessCount= 0;
            BatchFailureCount= 0;
            BulkRecipientCount= 0;
            sendTime= DateTime.Now;
        }

        Dictionary<string, int> Result;

        public string GetHTMLResult() {
            var sb = new StringBuilder();
            var elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                    ElapsedTime.Hours, ElapsedTime.Minutes, ElapsedTime.Seconds);
            sb.AppendLine($"Batch Sent: {sendTime.ToShortDateString()} {sendTime.ToLongTimeString()}");
            sb.AppendLine($"<br/>{SuccessTransmissionAttempts + FailureTransmissionAttempts} transmission attempts - elapsed time: {elapsedTime}.");
            if (BulkRecipientCount > 0) {
                sb.AppendLine($"<p>{BatchSuccessCount} items(s) were successfully sent in {BatchCount} batches(s). There was {BatchFailureCount} failure(s).</p>");
            }
            else sb.AppendLine($"<p>{SuccessTransmissionAttempts} items(s) were successfully sent and there were {FailureTransmissionAttempts} failures.</p>");
            if (FailureTransmissionAttempts > 0) {
                sb.AppendLine("<table class='table'>");
                sb.AppendLine("<thead><tr>");
                sb.AppendLine("<th scope='col'>Status</th>");
                sb.AppendLine("<th scope='col'>Count</th>");
                sb.AppendLine("</tr></thead>");
                sb.AppendLine("<tbody>");
                foreach (var item in Result) {
                  if (item.Value != 0)  sb.AppendLine($"<tr><td>{item.Key}</td><td>{item.Value}</td></tr>");
                }
                sb.AppendLine("</tbody></table>");
                sb.AppendLine("<p>Consult the Event Log and / or your Service Provider logs for further details.</p>");
            }
            return sb.ToString();
        }

        struct DocumentText
        {
            public string HtmlText;
            public string PlainText;
        }

        RichEditDocumentServer server;
        RichEditDocumentServer resultServer;
        IEmailService IEmailSender;
        ISMSSender ISMSSender;
        U3ADbContext dbc;

        public DocumentServer(U3ADbContext dbc) {
            this.dbc = dbc;
            DevExpress.Utils.AzureCompatibility.Enable = true;
            server = new RichEditDocumentServer();
            resultServer = new RichEditDocumentServer();
            resultServer.Document.CalculateDocumentVariable += Document_CalculateDocumentVariable;
            IEmailSender = EmailFactory.GetEmailSender(dbc);
            IEmailSender.BatchEmailSentEvent += IEmailSender_BatchEmailSentEvent;
        }

        public async Task ConvertDocx2Html(DocumentTemplate DocumentTemplate) {
            await Task.Run(() => {
                server.DocmBytes = DocumentTemplate.Content;
                DocumentTemplate.HTML = server.HtmlText;
            });
        }

        public async Task MailMerge(U3ADbContext dbc,
                            DocumentTemplate documentTemplate,
                            List<ExportData> ExportTo,
                            bool OverrideCommunicationPreference) {
            ClearCounters();
            var s = new Stopwatch();
            s.Start();
            Result = new Dictionary<string, int>();
            if (documentTemplate.DocumentType.IsSMS || HasMergeCodes(documentTemplate.Content)) {
                await SendSingleItemToSingleRecipient(documentTemplate, ExportTo, OverrideCommunicationPreference);
            }
            else {
                var normalExports = new List<ExportData>();
                foreach (var item in ExportTo) {
                    normalExports.Add(item);
                }
                await SendSingleItemToMultipleRecipients(documentTemplate, normalExports, OverrideCommunicationPreference);
            };
            s.Stop();
            ElapsedTime = s.Elapsed;
        }

        private bool HasMergeCodes(byte[] content) {
            var server = new RichEditDocumentServer();
            server.RtfText = System.Text.Encoding.UTF8.GetString(content);
            return (server.Document.Fields.Count - server.Document.Hyperlinks.Count) > 0;
        }

        async Task SendSingleItemToMultipleRecipients(DocumentTemplate documentTemplate,
                                    List<ExportData> ExportTo,
                                    bool OverrideCommunicationPreference) {
            var toAddressList = new List<string>();
            var toDisplayNameList = new List<string>();
            var toMobile = new List<string>();
            foreach (var mergeItem in FilterPreference(documentTemplate,
                                            ExportTo,
                                            OverrideCommunicationPreference)) {
                toAddressList.Add(mergeItem.P_Email);
                toDisplayNameList.Add(mergeItem.P_FullName);
                toMobile.Add(mergeItem.P_Mobile);
            }
            BulkRecipientCount = toAddressList.Count;
            server.RtfText = System.Text.Encoding.UTF8.GetString(documentTemplate.Content);
            var bodyText = new DocumentText() { HtmlText = server.HtmlText, PlainText = server.Text };
            await SendEmailToMultipleRecipients(documentTemplate, toAddressList, toDisplayNameList, bodyText);
            await dbc.SaveChangesAsync();
        }
        async Task SendEmailToMultipleRecipients(DocumentTemplate documentTemplate,
                                                List<string> ToAddressList,
                                                List<string> ToDisplayNameList,
                                                DocumentText bodyText) {
            if (!documentTemplate.DocumentType.IsEmail) return;
            var response = await IEmailSender.SendEmailToMultipleRecipientsAsync(
                                        EmailType.Broadcast,
                                        documentTemplate.FromEmailAddress,
                                        documentTemplate.FromDisplayName,
                                        ToAddressList,
                                        ToDisplayNameList,
                                        documentTemplate.Subject,
                                        bodyText.HtmlText,
                                        bodyText.PlainText);
        }
        private void IEmailSender_BatchEmailSentEvent(object? sender, BatchEmailSentEventArgs e) {
            var to = (e.FailedEmailAddress == null)
                        ? $"Bulk email batch {e.BatchNumber}: {e.EmailSent + e.EmailFailed} email addresses."
                        : e.FailedEmailAddress;
            EmailHistory history = new EmailHistory() {
                Sent = sendTime,
                From = e.FromEmailAddress,
                To = to,
                Subject = e.Subject,
                Service = IEmailSender.Service,
                Status = $"{e.Response}: Sent: {e.EmailSent} Fail: {e.EmailFailed}"
            };
            if (e.EmailSent > 0) SuccessTransmissionAttempts++;
            if (e.EmailFailed > 0) FailureTransmissionAttempts++;
            BatchCount++;
            BatchSuccessCount += e.EmailSent;
            BatchFailureCount += e.EmailFailed;
            if (!Result.ContainsKey(e.Response)) { Result.Add(e.Response, 0); }
            Result[e.Response] += e.EmailSent + e.EmailFailed;
            dbc.EmailHistory.Add(history);
            OnDocumentSent(new DocumentSentEventArgs() { DocumentsSent = e.EmailSent + e.EmailFailed });
        }

        async Task SendSingleItemToSingleRecipient(DocumentTemplate documentTemplate,
                                    List<ExportData> ExportTo,
                                    bool OverrideCommunicationPreference) {
            foreach (var mergeItem in FilterPreference(documentTemplate,
                                            ExportTo,
                                            OverrideCommunicationPreference)) {
                DocumentText bodyText = MergeDocument(documentTemplate, mergeItem);
                await SendSingleEmail(documentTemplate, mergeItem, bodyText);
                await SendSingleSMS(documentTemplate, mergeItem, bodyText);
                await dbc.SaveChangesAsync();
                OnDocumentSent(new DocumentSentEventArgs() { DocumentsSent = 1});
            }
        }

        async Task SendSingleEmail(DocumentTemplate documentTemplate, ExportData mergeItem, DocumentText bodyText) {
            if (!documentTemplate.DocumentType.IsEmail) return;
            var response = await IEmailSender.SendEmailAsync(EmailType.Broadcast,
                                        documentTemplate.FromEmailAddress,
                                        documentTemplate.FromDisplayName,
                                        mergeItem.P_Email,
                                        mergeItem.P_FullName,
                                        documentTemplate.Subject,
                                        bodyText.HtmlText,
                                        bodyText.PlainText);
            EmailHistory history = new EmailHistory() {
                Sent = sendTime,
                From = documentTemplate.FromEmailAddress,
                To = $"{mergeItem.P_FullName} <{mergeItem.P_Email}>",
                Subject = documentTemplate.Subject,
                Service = IEmailSender.Service,
                Status = response
            };
        }
        async Task SendSingleSMS(DocumentTemplate documentTemplate, ExportData mergeItem, DocumentText bodyText) {
            if (!documentTemplate.DocumentType.IsSMS) return;
            if (ISMSSender == null) ISMSSender = SMSFactory.GetSMSSender(dbc);
            var response = ISMSSender.SendSMS(documentTemplate.FromDisplayName,
                                        mergeItem.P_Mobile,
                                        bodyText.PlainText);
            EmailHistory history = new EmailHistory() {
                Sent = sendTime,
                From = documentTemplate.FromDisplayName,
                To = $"{mergeItem.P_Mobile} ({mergeItem.P_FullName}",
                Subject = String.Empty,
                Service = ISMSSender.Service,
                Status = response
            };
            if (ISMSSender.WasTransmissionSuccessful) { SuccessTransmissionAttempts += 1; } else { FailureTransmissionAttempts += 1; }
            if (!Result.ContainsKey(response)) { Result.Add(response, 0); }
            Result[response] += 1;
            await dbc.EmailHistory.AddAsync(history);
        }
        protected virtual void OnDocumentSent(DocumentSentEventArgs e) {
            EventHandler< DocumentSentEventArgs> handler = DocumentSentEvent;
            handler?.Invoke(this, e);
        }

        private DocumentText MergeDocument(DocumentTemplate DocumentTemplate, ExportData mergeItem) {
            DocumentText result = new DocumentText();
            server.RtfText = System.Text.Encoding.UTF8.GetString(DocumentTemplate.Content);
            server.Options.MailMerge.ViewMergedData = true;
            server.Options.Export.Html.EmbedImages = true;
            var l = new List<ExportData>() { mergeItem };
            server.Options.MailMerge.DataSource = l;
            server.MailMerge(resultServer.Document);
            result.PlainText = resultServer.Text;
            result.HtmlText = resultServer.HtmlText;
            return result;
        }
        public string MergeDocumentAsPdf(DocumentTemplate DocumentTemplate, List<ExportData> mergeData,
                                        bool OverrideCommunicationPreference) {
            string result = "data:application/pdf;base64,";
            server.RtfText = System.Text.Encoding.UTF8.GetString(DocumentTemplate.Content);
            server.Options.Export.Html.EmbedImages = true;
            resultServer.Options.MailMerge.ViewMergedData = true;
            server.Options.MailMerge.DataSource = FilterPreference(DocumentTemplate, mergeData, OverrideCommunicationPreference);
            var opt = resultServer.CreateMailMergeOptions();
            opt.MergeMode = MergeMode.NewSection;
            opt.FirstRecordIndex = 0;
            server.MailMerge(opt, resultServer.Document);
            using (var ms = new MemoryStream()) {
                resultServer.ExportToPdf(ms);
                ms.Position = 0;
                result += System.Convert.ToBase64String(ms.ToArray());
            }
            return result;
        }

        private List<ExportData> FilterPreference(DocumentTemplate documentTemplate,
                            List<ExportData> mergeData, bool OverrideCommunicationPreference) {
            var result = new List<ExportData>();
            if (OverrideCommunicationPreference) {
                if (documentTemplate.DocumentType.IsEmail) {
                    result = mergeData.Where(x => !string.IsNullOrWhiteSpace(x.P_Email)).ToList();
                }
                else {
                    if (documentTemplate.DocumentType.IsSMS) {
                        result = mergeData.Where(x => !string.IsNullOrWhiteSpace(x.P_Mobile)).ToList();
                    }
                    else result = mergeData.ToList();
                }
            }
            else {
                if (documentTemplate.DocumentType.IsEmail) {
                    result = mergeData.Where(x => x.P_Communication == "Email" &&
                                                    !string.IsNullOrWhiteSpace(x.P_Email)).ToList();
                }
                if (documentTemplate.DocumentType.IsPostal) {
                    result = mergeData.Where(x => x.P_Communication == "Post").ToList();
                }
                if (documentTemplate.DocumentType.IsSMS) {
                    result = mergeData.Where(x => (x.P_SMSOptOut == false) && string.IsNullOrWhiteSpace(x.P_Mobile) == false).ToList();
                }
            }
            return result;
        }
        public void Document_CalculateDocumentVariable(object sender, CalculateDocumentVariableEventArgs e) {
            var dstServer = new RichEditDocumentServer();
            Guid ParticipantID;
            if (e.Arguments.Count > 0 && Guid.TryParse(e.Arguments[0].Value, out ParticipantID)) {
                var subDocTemplate = dbc.DocumentTemplate
                                        .Include(x => x.DocumentType)
                                        .Where(x => x.Name == e.VariableName).FirstOrDefault();
                if (subDocTemplate != null) {
                    if (subDocTemplate.DocumentType.Name == "EnrolmentSubdoc") {
                        GetEnrolmentDetails(subDocTemplate, dstServer, ParticipantID);
                    }
                }
                else { dstServer.Text = $"***** [{e.VariableName}] not found in document templates *****"; }
            }
            else {
                dstServer.Text = $"***** Participnat key is not first argument to DOCVARIABLE in [{e.VariableName}] *****";
            }
            e.Value = dstServer;
            e.Handled = true;
        }

        public void GetEnrolmentDetails(DocumentTemplate subDocTemplate,
                    RichEditDocumentServer dstServer, Guid ParticipantID) {
            var mergeItems = BusinessRule.GetEnrolmentExportDataByPersonAsync(dbc, ParticipantID).ToList();
            if (mergeItems.Count > 0) {
                var src = new RichEditDocumentServer();
                src.RtfText = System.Text.Encoding.UTF8.GetString(subDocTemplate.Content);
                src.Options.MailMerge.KeepLastParagraph = false;
                src.Options.MailMerge.ViewMergedData = true;
                src.Options.Export.Html.EmbedImages = true;
                src.Options.MailMerge.DataSource = mergeItems;
                src.MailMerge(dstServer.Document);
            }
            else dstServer.Text = "*** You have no enrolments in the current Term ***";
        }
    }

    public class DocumentSentEventArgs //: EventArgs
    {
        public int DocumentsSent { get; set; }
    }
}

