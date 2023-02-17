using DevExpress.XtraRichEdit.Commands.Internal;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task<bool> HasUnporcessedOnlinePayment(U3ADbContext dbc, Person person) {
            if (person == null) { return false; }
            return await dbc.OnlinePaymentStatus.AnyAsync(x => x.PersonID == person.ID &&
                                                                x.AccessCode != string.Empty &&
                                                                x.Status == String.Empty);
        }
        public static async Task<bool> HasUnporcessedOnlinePayment(U3ADbContext dbc, string AdminEmail) {
            return await dbc.OnlinePaymentStatus.AnyAsync(x => x.AdminEmail == AdminEmail &&
                                                                x.AccessCode != string.Empty &&
                                                                x.Status == String.Empty);
        }
        public static async Task<OnlinePaymentStatus> GetUnporcessedOnlinePayment(U3ADbContext dbc, Person person) {
            return await dbc.OnlinePaymentStatus
                .FirstOrDefaultAsync(x => x.PersonID == person.ID &&
                                            x.AccessCode != string.Empty &&
                                            x.Status == String.Empty);
        }
        public static async Task<OnlinePaymentStatus> GetUnporcessedOnlinePayment(U3ADbContext dbc, string AdminEmail) {
            return await dbc.OnlinePaymentStatus
                .FirstOrDefaultAsync(x => x.AdminEmail == AdminEmail &&
                                            x.AccessCode != string.Empty &&
                                            x.Status == String.Empty);
        }
    }

}