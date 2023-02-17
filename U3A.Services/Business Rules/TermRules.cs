using DevExpress.Blazor.Internal;
using DevExpress.XtraRichEdit.Model;
using Microsoft.EntityFrameworkCore;
using Twilio.Rest.Trunking.V1;
using Twilio.TwiML.Messaging;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task<List<Term>> EditableTermsAsync(U3ADbContext dbc) {
            return await dbc.Term
                            .OrderByDescending(x => x.Year)
                            .ThenByDescending(x => x.TermNumber).ToListAsync();
        }
        public static List<Term> SelectableTerms(U3ADbContext dbc) {
            return dbc.Term
                            .OrderByDescending(x => x.Year)
                            .ThenByDescending(x => x.TermNumber).ToList();
        }

        public static async Task<Term?> CurrentTermAsync(U3ADbContext dbc) {
            return await dbc.Term.Where(x => x.IsDefaultTerm).FirstOrDefaultAsync();
        }
        public static Term? CurrentTerm(U3ADbContext dbc) {
            return dbc.Term.Where(x => x.IsDefaultTerm).FirstOrDefault();
        }
        public static Term? CurrentEnrolmentTerm(U3ADbContext dbc) {
            var today = DateTime.Today;
            return dbc.Term
                        .OrderByDescending(x => x.Year).ThenByDescending(x => x.TermNumber).AsEnumerable()
                        .Where(x => today >= x.EnrolmentStartDate && today <= x.EnrolmentEndDate)
                        .FirstOrDefault();
        }

        public static async Task<Term?> FirstTermNextYearAsync(U3ADbContext dbc, int CurrentYear) {
            return await dbc.Term
                            .Where(x => x.Year == CurrentYear + 1 && x.TermNumber == 1).FirstOrDefaultAsync();
        }
        public static async Task<int> MaxTermYearAsync(U3ADbContext dbc) {
            var term = await dbc.Term.OrderByDescending(x => x.Year).FirstOrDefaultAsync();
            return term.Year;
        }

        /// <summary>
        /// Returns all term records greater than or equal to the current term minus one year.
        /// </summary>
        /// <param name="dbc"></param>
        /// <returns></returns>
        public static async Task<List<Term>> SelectableRelaxedTermsAsync(U3ADbContext dbc) {
            var currentTerm = await CurrentTermAsync(dbc);
            var terms = new List<Term>();
            if (currentTerm != null) {
                terms = await dbc.Term.AsNoTracking()
                            .Where(x => x.Year >= currentTerm.Year-1)
                            .OrderByDescending(x => x.Year).ThenByDescending(x => x.TermNumber).ToListAsync();
            }
            return terms;
        }

        public static async Task<List<Term>> SelectableTermsInCurrentYearAsync(U3ADbContext dbc, Term CurrentTerm) {
            return await dbc.Term.AsNoTracking()
                .Where(x => x.Year == CurrentTerm.Year && x.TermNumber >= CurrentTerm.TermNumber)
                .OrderBy(x => x.Year).ThenBy(x => x.TermNumber)
                .ToListAsync();
        }

        /// <summary>
        /// Returns all term records Today's date is later than the enrolment start date 
        /// and earlier than the enrolement end date.
        /// </summary>
        /// <param name="dbc"></param>
        /// <returns></returns>
        public static async Task<List<Term>> SelectableStrictTermsAsync(U3ADbContext dbc) {
            var terms = await dbc.Term.AsNoTracking().ToListAsync();
            // The Where clause must be executed on the client because it is a calculated field.
            return terms.Where(x => (x.EnrolmentStartDate >= DateTime.Today && 
                                                DateTime.Today <= x.EnrolmentEndDate))
                           .OrderBy(x => x.Year).ThenBy(x => x.TermNumber).ToList();
        }

        /// <summary>
        /// Returns the term record with the highest Year / Term number.
        /// </summary>
        /// <param name="dbc"></param>
        /// <returns></returns>
        public static async Task<Term?> GetLastTermAsync(U3ADbContext dbc) {
            return await dbc.Term.OrderByDescending(x => x.Year)
                            .ThenByDescending(x => x.TermNumber).FirstOrDefaultAsync();
        }
        public static async Task<Term?> GetSameTermLastYearAsync(U3ADbContext dbc, int Year, int TermNumber) {
            return await dbc.Term.Where(x => x.Year == Year-1 && x.TermNumber == TermNumber ).FirstOrDefaultAsync();
        }
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek firstDayOfWeek) {
            int diff = (7 + (dt.DayOfWeek - firstDayOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
