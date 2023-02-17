using Finbuckle.MultiTenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    public class TenantInfoEx : TenantInfo, ITenantInfo {
        public string Website { get; set; }
        public string State { get; set; }
        public string? SendGridAPIKey { get; set; }
        public bool UseEmailTestEnviroment { get; set; }
        public string? PostmarkAPIKey { get; set; }
        public string? PostmarkSandboxAPIKey { get; set; }
        public bool UsePostmarkTestEnviroment { get; set; }
        public string? TwilioAccountSID { get; set; }
        public string? TwilioAuthToken { get; set; }
        public string? TwilioPhoneNo { get; set; }
        public bool UseSMSTestEnviroment { get; set; }
        public string? EwayAPIKey { get; set; }
        public string? EwayPassword { get; set; }
        public bool UseEwayTestEnviroment { get; set; }
    }
}
