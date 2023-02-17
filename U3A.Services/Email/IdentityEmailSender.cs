using System.Net;
using System.Linq;
using Finbuckle.MultiTenant;
using SendGrid;
using SendGrid.Helpers.Mail;
using U3A.Database;
using U3A.Model;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using Twilio.Http;
using System.Reactive.Subjects;
using DevExpress.Pdf;

namespace U3A.Services
{
    public class IdentityEmailSender : IEmailSender
    {

        IDbContextFactory<U3ADbContext> dbFactory;
        public IdentityEmailSender(IDbContextFactory<U3ADbContext> contextFactory) {
            dbFactory = contextFactory;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage) {
            using (var dbc = dbFactory.CreateDbContext()) {
                var settings = dbc.SystemSettings.FirstOrDefault() ?? throw new ArgumentNullException(nameof(SystemSettings));
                var sender = EmailFactory.GetIdentityEmailSender(dbc);
                var result = await sender.SendEmailAsync(EmailType.Transactional,
                                                       settings.SendEmailAddesss,
                                                       settings.SendEmailDisplayName,
                                                       email, email, subject, GetEmailText(settings,htmlMessage), 
                                                       htmlMessage);
                EmailHistory history = new EmailHistory() {
                    Sent = DateTime.Now,
                    From = settings.SendEmailAddesss,
                    To = email,
                    Subject = subject,
                    Service = sender.Service,
                    Status = result
                };
                await dbc.EmailHistory.AddAsync(history);
                await dbc.SaveChangesAsync();
            }
        }

        private string GetEmailText(SystemSettings settings, string HtmLMessgae) {
            string result = $"<h3>{settings.U3AGroup}</h3><p>ABN: {settings.ABN}<br/>" +
                                $"{settings.OfficeLocation}<br/>Phone: {settings.Phone}</p>" +
                                $"<p>{HtmLMessgae}</p>";
            return result;
        }

    }

}
