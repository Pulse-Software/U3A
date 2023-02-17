using DevExpress.XtraRichEdit.Commands.Internal;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using U3A.Database;
using U3A.Model;
using DevExpress.Blazor.Internal;
using System.Runtime.CompilerServices;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task<List<Receipt>> EditableReceiptsForYearAsync(U3ADbContext dbc, int PtocessingYear) {
            return await dbc.Receipt
                            .Include(x => x.Person)
                            .OrderBy(x => x.Person.LastName)
                            .ThenBy(x => x.Person.FirstName)
                            .ThenBy(x => x.Date)
                            .Where(x => x.Amount != 0)
                            .ToListAsync();
        }
        public static async Task<List<Fee>> EditableFeesForYearAsync(U3ADbContext dbc, int PtocessingYear) {
            return await dbc.Fee
                            .Include(x => x.Person)
                            .OrderBy(x => x.Person.LastName)
                            .ThenBy(x => x.Person.FirstName)
                            .ThenBy(x => x.Date)
                            .ToListAsync();
        }

        public static async Task ResetPersonDetailsForDeletedReceipt(U3ADbContext dbc, Receipt ReceiptToDelete) {
            // Safest way is to use the previous receipt
            var prevReceipt = await dbc.Receipt
                                .Where(x => x.ID != ReceiptToDelete.ID
                                        && x.PersonID == ReceiptToDelete.Person.ID)
                                .OrderByDescending(x => x.ProcessingYear)
                                .ThenByDescending(x => x.UpdatedOn).FirstOrDefaultAsync();
            var person = ReceiptToDelete.Person;
            if (prevReceipt != null) {
                person.FinancialTo = prevReceipt.FinancialTo;
                person.DateJoined = prevReceipt.DateJoined;
            }
            // No previous receipt? Use the previous fields on the person record
            else {
                person.FinancialTo = (person.PreviousFinancialTo.HasValue)
                                        ? person.PreviousFinancialTo.Value : person.FinancialTo - 1;
                person.DateJoined = (person.PreviousDateJoined.HasValue)
                                        ? person.PreviousDateJoined : person.DateJoined;
            }
            dbc.Update(person);
        }

        public static async Task SetPersonDetailsForNewReceipt(U3ADbContext dbc, Receipt ReceiptToCreate) {
            var person = ReceiptToCreate.Person;
            if (person.FinancialTo < ReceiptToCreate.ProcessingYear) {
                person.PreviousFinancialTo = person.FinancialTo;
                person.FinancialTo = ReceiptToCreate.ProcessingYear;
            }
            if (person.DateJoined == null) person.DateJoined = DateTime.Today;
            if (person.FinancialTo - person.PreviousFinancialTo > 1) {
                person.PreviousDateJoined = person.DateJoined;
                person.DateJoined = DateTime.Today;
            }
            ReceiptToCreate.FinancialTo = person.FinancialTo;
            ReceiptToCreate.DateJoined = person.DateJoined.Value;
            dbc.Update(person);
        }

        public static async Task SetPersonDetailsForEditedReceipt(U3ADbContext dbc, Receipt OriginalReceipt, Receipt EditedReceipt) {
            if (OriginalReceipt.Person.ID != EditedReceipt.Person.ID) {
                await ResetPersonDetailsForDeletedReceipt(dbc, OriginalReceipt);
                await SetPersonDetailsForNewReceipt(dbc, EditedReceipt);
            }
        }
    }
}