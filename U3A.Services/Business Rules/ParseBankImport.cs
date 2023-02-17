using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Twilio.TwiML.Fax;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static Person? ParseBankDescription(U3ADbContext dbc, string BankDescription) {
            var info = dbc.TenantInfo;
            // removing the identifier stop matches against the group name (eastlakes, maitland etc)
            var bankDescription = strip(BankDescription);
            bankDescription = bankDescription.Replace(info.Identifier.ToUpper(), String.Empty);
            Person? person;
            person = dbc.Person.AsEnumerable().FirstOrDefault(x => bankDescription.Contains(strip(x.FirstName + x.LastName))) ??
                     dbc.Person.AsEnumerable().FirstOrDefault(x => bankDescription.Contains(strip(x.LastName + x.FirstName))) ??
                     dbc.Person.AsEnumerable().FirstOrDefault(x => bankDescription.Contains(strip(x.FirstName.Substring(0, 1) + x.LastName))) ??
                     dbc.Person.AsEnumerable().FirstOrDefault(x => bankDescription.Contains(strip(x.LastName) + x.FirstName.Substring(0, 1))) ??
                     dbc.Person.AsEnumerable().FirstOrDefault(x => bankDescription.Contains(x.ConversionID + strip(x.LastName))) ??
                     dbc.Person.AsEnumerable().FirstOrDefault(x => bankDescription.Contains(x.PersonIdentity + strip(x.LastName))) ??
                     dbc.Person.AsEnumerable().FirstOrDefault(x => bankDescription.Contains(strip(x.LastName) + x.ConversionID)) ??
                     dbc.Person.AsEnumerable().FirstOrDefault(x => bankDescription.Contains(strip(x.LastName) + x.PersonIdentity)); 
            if (person != null) return person;
            var people = dbc.Person.AsEnumerable().Where(x => bankDescription.Contains(strip(x.LastName)));
            if (people.Count() == 1) return people.First(); else return null;
        }

        public static async Task<bool> IsReceiptOnFileAsync(U3ADbContext dbc, 
                                        DateTime Date, String Description, DateTime StartTime) {
            return dbc.Receipt.Any(x => x.Date == Date && 
                                        x.Description == Description &&
                                        x.CreatedOn < StartTime);
        }
        public static async Task<Receipt?> GetReceiptOnFileAsync(U3ADbContext dbc, 
                                        DateTime Date, String Description, DateTime StartTime) {
            return await dbc.Receipt.FirstOrDefaultAsync(x => x.Date == Date && 
                                        x.Description == Description &&
                                        x.CreatedOn < StartTime);
        }
        public static async Task DeleteReceiptOnFileAsync(U3ADbContext dbc, 
                                            DateTime Date, String Description, DateTime StartTime) {
            dbc.RemoveRange(await dbc.Receipt.Where(x => x.Date == Date && 
                                        x.Description == Description &&
                                        x.CreatedOn < StartTime).ToArrayAsync());
        }
        public static decimal GetPreviouslyPaidAsync(U3ADbContext dbc, 
                                                    Guid? PersonID,
                                                    int ProcessingYear,
                                                    DateTime StartTime) {
            return dbc.Receipt.Where(x => x.PersonID == PersonID && 
                                            x.ProcessingYear == ProcessingYear &&
                                            x.CreatedOn < StartTime)
                                            .Sum(x => x.Amount);
        }
    }
}