using System.Net;
using Microsoft.Extensions.Logging;
using Postmark;
using U3A.Model;
using System.Text;
using PostmarkDotNet;
using System.Reactive.Subjects;

namespace U3A.Services
{
    internal class PostmarkEmailSender : IEmailService
    {
        public event EventHandler<BatchEmailSentEventArgs> BatchEmailSentEvent;

        private const int MAX_EMAILS = 50;
        private string APIKey { get; }
        private bool UseSandbox { get; }

        private SystemSettings settings { get; }

        public string Service => "Postmark";

        public bool WasTransmissionSuccessful { get; set; }

        public PostmarkEmailSender(string APIKey, bool UseSandbox, SystemSettings settings) {
            this.APIKey = APIKey;
            this.UseSandbox = UseSandbox;
            this.settings = settings;
        }
        public async Task<string> SendEmailAsync(EmailType EmailType, 
                                        string FromAddress,
                                        string FromDisplayName,
                                        string ToAddress,
                                        string ToDisplayName,
                                        string Subject,
                                        string HtmlMessage,
                                        string PlainTextMessage) {
            return await SendEmailAsync(EmailType, 
                                           FromAddress,
                                           FromDisplayName,
                                           ToAddress,
                                           ToDisplayName,
                                           Subject,
                                           HtmlMessage,
                                           PlainTextMessage,
                                           null, null);
        }

        public async Task<string> SendEmailAsync(EmailType EmailType, 
                                            string FromAddress,
                                            string FromDisplayName,
                                            string ToAddress,
                                            string ToDisplayName,
                                            string Subject,
                                            string HtmlMessage,
                                            string PlainTextMessage,
                        IEnumerable<string>? PDFFileAttachments,
                        IEnumerable<string>? PDFFileAttachmentNames) {
            var result = string.Empty;
            var client = new PostmarkClient(APIKey);
            var batchNumber = 1;
            var emailSent = 0;
            var emailFailed = 0;
            var message = new PostmarkMessage {
                To = (!string.IsNullOrWhiteSpace(ToDisplayName))
                            ? $"\"{ToDisplayName}\" <{ToAddress}>" : ToAddress,                
                From = (!string.IsNullOrWhiteSpace(FromDisplayName)) 
                            ? $"\"{FromDisplayName}\" <{FromAddress}>" : FromAddress,
                TrackOpens = true,
                TrackLinks = LinkTrackingOptions.HtmlAndText,
                Subject = Subject,
                TextBody = PlainTextMessage,
                HtmlBody = HtmlMessage,
                MessageStream = (EmailType == EmailType.Broadcast) ? "broadcast" : "outbound",
            };
            if (PDFFileAttachments != null) {
                for (var i = 0; i < PDFFileAttachments.Count(); i++) {
                    var content = File.ReadAllBytes(PDFFileAttachments.ElementAt(i));
                    var file = Convert.ToBase64String(content);
                    message.AddAttachment(content, PDFFileAttachmentNames.ElementAt(i));
                }
            }
            try {
                var response = await client.SendMessageAsync(message);
                if (response != null) result = response.Status.ToString();
                else result = "Response not received";
                var status = response.Status;
                if (status == PostmarkStatus.Success) {
                    WasTransmissionSuccessful = true; emailSent = 1;
                }
                else { WasTransmissionSuccessful = false; emailFailed = 1; }

            }
            catch (Exception e) {
                result = e.Message;
                emailFailed = 1;
                WasTransmissionSuccessful = false;
            }
            finally {
                if (result == "Success") result = "Accepted";
                OnBatchEmailSent(message?.From,
                                    message?.To,
                                    Subject = Subject,
                                    batchNumber,
                                    emailSent,
                                    emailFailed,
                                    result);
            }
            return result;
        }

        public async Task<string> SendEmailToMultipleRecipientsAsync(
                                        EmailType EmailType,    
                                        string FromAddress, 
                                        string FromDisplayName, 
                                        List<string> ToAddress, 
                                        List<string> ToDisplayName, 
                                        string Subject, 
                                        string HtmlMessage, 
                                        string PlainTextMessage) {
            var result = string.Empty;
            var client = new PostmarkClient(APIKey);
            var to = string.Empty;
            var skip = 0;
            var batchNumber = 0;
            var emailSent = 0;
            var emailFailed = 0;
            var isFailedBatch = false;
            string[] sendAddresses;
            PostmarkResponse? response = null;
            PostmarkMessage? message = null;
            while (skip < ToAddress.Count) {
                emailSent= 0; emailFailed= 0;isFailedBatch= false;
                sendAddresses= ToAddress.OrderBy(x => x).Skip(skip).Take(MAX_EMAILS).ToArray();
                to = string.Join(",", sendAddresses);
                skip += MAX_EMAILS;
                message = new PostmarkMessage {
                    Bcc = to,
                    From = (!string.IsNullOrWhiteSpace(FromDisplayName))
                            ? $"\"{FromDisplayName}\" <{FromAddress}>" : FromAddress,
                    TrackOpens = true,
                    TrackLinks = LinkTrackingOptions.HtmlAndText,
                    Subject = Subject,
                    TextBody = PlainTextMessage,
                    HtmlBody = HtmlMessage,
                    MessageStream = (EmailType == EmailType.Broadcast) ? "broadcast" : "outbound",
                };
                try {
                    response = await client.SendMessageAsync(message);
                    if (response != null) result = response.Status.ToString();
                    else result = "Response not received";
                    var status = response.Status;
                    batchNumber++;
                    if (status == PostmarkStatus.Success) {
                        emailSent = sendAddresses.Length;
                        WasTransmissionSuccessful = true;
                    }
                    else {
                        emailFailed = sendAddresses.Length;
                        WasTransmissionSuccessful = false;
                    }
                }
                catch (Exception e) {
                    isFailedBatch = true;
                    result = e.Message;
                    //emailFailed= sendAddresses.Length;
                    //WasTransmissionSuccessful = false;
                }
                finally {
                    if (result == "Success") result = "Accepted";
                    OnBatchEmailSent(message?.From,
                                        (isFailedBatch) ? $"Batch failed, attemtping individual send" : null,
                                        Subject = Subject,
                                        batchNumber,
                                        emailSent,
                                        emailFailed,
                                        result); ;
                }
                if (isFailedBatch) {
                    foreach (var email in sendAddresses) {
                       result = await SendEmailAsync(EmailType, 
                                FromAddress,
                                FromDisplayName,
                                email,string.Empty,
                                Subject,
                                HtmlMessage,
                                PlainTextMessage);
                    }
                }
            }
            return result;
        }

        protected virtual void OnBatchEmailSent(string From, 
                string? FailedEmailAddress,
                string Subject,
                int BatchNumber,
                int EmailSent,
                int EmailFailed,
                string Response) {
            var e = new BatchEmailSentEventArgs() {
                FromEmailAddress = From,
                FailedEmailAddress = FailedEmailAddress,
                Subject = Subject,
                BatchNumber = BatchNumber,
                EmailSent = EmailSent,
                EmailFailed = EmailFailed,
                Response = Response
            };
            EventHandler<BatchEmailSentEventArgs> handler = BatchEmailSentEvent;
            handler?.Invoke(this, e);
        }

    }
}
