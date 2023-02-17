using Finbuckle.MultiTenant;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using U3A.Database;
using U3A.Model;

namespace U3A.Services
{
    public interface ISMSSender
    {
        public string Service { get; }
        public string SendSMS(string From,
                                        string To,
                                        string Message);
        public bool WasTransmissionSuccessful { get; set; }
    }

    public static class SMSFactory
    {
        public static ISMSSender? GetSMSSender(U3ADbContext dbc) {
            ISMSSender? result = null;
            TenantInfoEx tenantInfo = (TenantInfoEx)dbc.TenantInfo;
            if (tenantInfo.TwilioAccountSID != null && tenantInfo.TwilioAuthToken != null) {
                result = new TwilioSMS(tenantInfo.TwilioAccountSID,
                                tenantInfo.TwilioAuthToken,
                                tenantInfo.TwilioPhoneNo,
                                tenantInfo.UseSMSTestEnviroment);
            }
            return result;
        }
    }

    public class TwilioSMS : ISMSSender
    {
        string accountSID;
        string authToken;
        string FromPhoneNumber;
        bool UseSandbox { get; }


        public TwilioSMS(string accountSID, string authToken, string FromPhoneNumber, bool UseSandbox) {
            this.accountSID = accountSID;
            this.authToken = authToken;
            this.FromPhoneNumber = FromPhoneNumber;
            this.UseSandbox = UseSandbox;
            TwilioClient.Init(accountSID, authToken);
        }

        public string Service => "TwilioSMS";

        public bool WasTransmissionSuccessful { get; set; }

        public string SendSMS(string From, string To, string Message) {
            string result;
            var from = (string.IsNullOrWhiteSpace(From)) ? FromPhoneNumber : From;
            var to = To.Trim();
            if (to.StartsWith("0")) { to = $"+61{to.Substring(1)}"; }
            if (UseSandbox) {
                WasTransmissionSuccessful = true;
                result = "Success - Test Environment";
            }
            else {
                try {
                    var msg = MessageResource.Create(
                        body: Message,
                        from: new Twilio.Types.PhoneNumber(from),
                        to: new Twilio.Types.PhoneNumber(to)
                    );
                    WasTransmissionSuccessful = true;
                    result = msg.Status.ToString();
                }
                catch (Exception ex) {
                    result = ex.Message;
                    WasTransmissionSuccessful = false;
                }
            }
            return result;
        }
    }
}
