using Microsoft.EntityFrameworkCore;
using Twilio.TwiML.Fax;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static List<Receipt> GetCashReceiptsByDate(U3ADbContext dbc, DateTime FromDate, DateTime ToDate) {
            return dbc.Receipt
                .Include(x => x.Person)
                .Where(x => x.Date >= FromDate && x.Date < ToDate && x.Amount != 0)
                .OrderBy(x => x.Date).ThenBy(x => x.Person.LastName).ThenBy(x => x.Person.FirstName)
                .ToList();

        }
        public static List<Receipt> GetComplimentaryReceipts(U3ADbContext dbc, int year) {
            return dbc.Receipt
                .Include(x => x.Person)
                .Where(x => x.FinancialTo >= year && x.Amount == 0)
                .OrderBy(x => x.Person.LastName).ThenBy(x => x.Person.FirstName)
                .ToList();

        }

    }
}