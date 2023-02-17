using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U3A.Database;
using U3A.Model;

namespace U3A.Services
{
    public interface IEmailService
    {
        public string Service { get; }

        public event EventHandler<BatchEmailSentEventArgs> BatchEmailSentEvent;
        public Task<string> SendEmailAsync(EmailType EmailType,
                                        string FromAddress,
                                        string FromDisplayName,
                                        string ToAddress,
                                        string ToDisplayName,
                                        string Subject,
                                        string HtmlMessage,
                                        string PlainTextMessage);
        public Task<string> SendEmailAsync(EmailType EmailType, 
                                        string FromAddress,
                                        string FromDisplayName,
                                        string ToAddress,
                                        string ToDisplayName,
                                        string Subject,
                                        string HtmlMessage,
                                        string PlainTextMessage,
                                        IEnumerable<String>? PDFFileAttachments,
                                        IEnumerable<String>? PDFFileAttachmentFinalNames);

        public Task<string> SendEmailToMultipleRecipientsAsync(EmailType EmailType,
                                        string FromAddress,
                                        string FromDisplayName,
                                        List<string> ToAddress,
                                        List<string> ToDisplayName,
                                        string Subject,
                                        string HtmlMessage,
                                        string PlainTextMessage);
        public bool WasTransmissionSuccessful { get; set; }
    }

    public class BatchEmailSentEventArgs : EventArgs {
        public string FromEmailAddress { get; set; }
        public string? FailedEmailAddress { get; set; }
        public string Subject { get; set; }
        public int BatchNumber { get; set; }
        public int EmailSent { get; set; }
        public int EmailFailed { get; set; }
        public string Response { get; set; }
    }

    public enum EmailType {
        Transactional,
        Broadcast
    }

    public static class EmailFactory
    {
        public static IEmailService? GetEmailSender(U3ADbContext dbc) {
            IEmailService? result = null;
            SystemSettings settings = dbc.SystemSettings.FirstOrDefault();
            TenantInfoEx tenantInfo = (TenantInfoEx)dbc.TenantInfo;
            if (tenantInfo.PostmarkAPIKey != null && !tenantInfo.UsePostmarkTestEnviroment) {
                result = new PostmarkEmailSender(tenantInfo.PostmarkAPIKey,
                                tenantInfo.UsePostmarkTestEnviroment, settings);
            }
            if (result == null && tenantInfo.PostmarkSandboxAPIKey != null && tenantInfo.UsePostmarkTestEnviroment) {
                result = new PostmarkEmailSender(tenantInfo.PostmarkSandboxAPIKey,
                                tenantInfo.UsePostmarkTestEnviroment, settings);
            }
            if (result == null && tenantInfo.SendGridAPIKey != null) {
                result = new SendGridEmailSender(tenantInfo.SendGridAPIKey,
                                tenantInfo.UseEmailTestEnviroment, settings);
            }
            return result;
        }

        private const string U3ADMIN_API_KEY = "c5009448-2219-46a7-9fb6-b3481c998e44";
        public static IEmailService? GetIdentityEmailSender(U3ADbContext dbc) {
            IEmailService? result = null;
            SystemSettings settings = dbc.SystemSettings.FirstOrDefault();
            TenantInfoEx tenantInfo = (TenantInfoEx)dbc.TenantInfo;
            if (tenantInfo.PostmarkAPIKey != null && !tenantInfo.UsePostmarkTestEnviroment) {
                result = new PostmarkEmailSender(U3ADMIN_API_KEY,
                                false, settings);
            }
            if (result == null && tenantInfo.PostmarkSandboxAPIKey != null && tenantInfo.UsePostmarkTestEnviroment) {
                result = new PostmarkEmailSender(U3ADMIN_API_KEY,
                                false, settings);
            }
            if (result == null && tenantInfo.SendGridAPIKey != null) {
                result = new SendGridEmailSender(tenantInfo.SendGridAPIKey,
                                tenantInfo.UseEmailTestEnviroment, settings);
            }
            return result;
        }
    }


}
