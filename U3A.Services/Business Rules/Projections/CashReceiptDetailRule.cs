using Microsoft.EntityFrameworkCore;
using Twilio.TwiML.Fax;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static ReceiptDetail GetCashReceiptsSample(U3ADbContext dbc) {
            // Grab a random receipt
            return GetReceiptDetail(dbc,
                dbc.Receipt.OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefault());
        }

        public static ReceiptDetail GetReceiptDetail(U3ADbContext dbc, Receipt receipt) {
            var p = BusinessRule.SelectPerson(dbc, receipt.PersonID) ?? throw new ArgumentNullException(nameof(Person));
            var t = BusinessRule.CurrentTerm(dbc) ?? throw new ArgumentNullException(nameof(Person));
            var rd = new ReceiptDetail() {

                //Cash Receipt
                ReceiptDate = receipt.Date,
                ReceiptProcessingYear = receipt.ProcessingYear,
                ReceiptAmount = receipt.Amount,
                ReceiptDescription = receipt.Description,
                ReceiptIdentifier = receipt.Identifier,

            };
            GetOrganisationPersonDetail(dbc, rd, t, p);
            return rd;
        }

    }
}