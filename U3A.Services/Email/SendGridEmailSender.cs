using System.Net;
using Eway.Rapid.Abstractions.Response;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using U3A.Model;
using System.Text;

namespace U3A.Services
{
    internal class SendGridEmailSender : IEmailService
    {
        public event EventHandler<BatchEmailSentEventArgs> BatchEmailSentEvent;
        private string APIKey { get; }
        private bool UseSandbox { get; }

        private SystemSettings settings { get; }    

        public string Service => "SendGrid";

        public bool WasTransmissionSuccessful { get; set; }


        public SendGridEmailSender(string APIKey, bool UseSandbox, SystemSettings settings) {
            this.APIKey = APIKey;
            this.UseSandbox = UseSandbox;
            this.settings = settings;
        }
        public async Task<string> SendEmailAsync( 
                                        EmailType EmailType,
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
            var client = new SendGridClient(APIKey);
            var from = new EmailAddress(FromAddress.Trim(), FromDisplayName);
            var to = new EmailAddress(ToAddress.Trim(), ToDisplayName);
            var plainTextContent = PlainTextMessage;
            var htmlContent = HtmlMessage;
            var msg = MailHelper.CreateSingleEmail(from, to, Subject, plainTextContent, htmlContent);
            if (PDFFileAttachments != null) {
                for (var i = 0; i < PDFFileAttachments.Count(); i++) {
                    var bytes = File.ReadAllBytes(PDFFileAttachments.ElementAt(i));
                    var file = Convert.ToBase64String(bytes);
                    msg.AddAttachment(PDFFileAttachmentNames.ElementAt(i), file);
                }
            }
            msg.SetSandBoxMode(UseSandbox);
            try {
                var response = await client.SendEmailAsync(msg);
                if (response != null) result = $"{response.StatusCode}";
                else result = "Response not received";
                var status = response.StatusCode;
                if (status == HttpStatusCode.OK ||
                    status == HttpStatusCode.Created ||
                    status == HttpStatusCode.Accepted) { WasTransmissionSuccessful = true; }
                else { WasTransmissionSuccessful = false; }

            }
            catch (Exception e) {
                result = e.Message.Replace(", see inner exception.", String.Empty);
                WasTransmissionSuccessful = false;
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
            var to = new List<EmailAddress>();
            for (var i = 0; i < ToAddress.Count; i++) {
                    to.Add(new EmailAddress(ToAddress[i].Trim(), ToDisplayName[i]));
                }
            var client = new SendGridClient(APIKey);
            var from = new EmailAddress(FromAddress.Trim(), FromDisplayName);
            var plainTextContent = PlainTextMessage;
            var htmlContent = HtmlMessage;
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, Subject, plainTextContent, htmlContent);
            msg.SetSandBoxMode(UseSandbox);
            try {
                var response = await client.SendEmailAsync(msg);
                if (response != null) result = $"{response.StatusCode}";
                else result = "Response not received";
                var status = response.StatusCode;
                if (status == HttpStatusCode.OK ||
                    status == HttpStatusCode.Created ||
                    status == HttpStatusCode.Accepted) { WasTransmissionSuccessful = true; }
                else { WasTransmissionSuccessful = false; }
            }
            catch (Exception e) {
                result = e.Message.Replace(", see inner exception.", String.Empty);
                WasTransmissionSuccessful = false;
            }
            return result;
        }
        //Not wired up
        protected virtual void OnBatchEmailSent(BatchEmailSentEventArgs e) {
            EventHandler<BatchEmailSentEventArgs> handler = BatchEmailSentEvent;
            handler?.Invoke(this, e);
        }
    }
}
