using DevExpress.Data.Linq.Helpers;
using DevExpress.XtraRichEdit.Commands.Internal;
using Microsoft.EntityFrameworkCore;
using System.Text;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task<bool> IsImportCourseOnFileAsync(U3ADbContext dbc, Guid PersonID, int Year, int ConversionID) {
            bool result = false;
            var enrolments = await dbc.Enrolment
                                .Include(x => x.Course)
                                .Where(x => x.PersonID == PersonID).ToListAsync();
            result = (from e in enrolments
                      where e.Course.ConversionID == ConversionID && e.Course.Year == Year
                      select e).Any();
            return result;
        }
    }
}