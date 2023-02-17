using Microsoft.EntityFrameworkCore;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task<List<WeekDay>> SelectableWeekdaysAsync(U3ADbContext dbc) {
            return await dbc.WeekDay.AsNoTracking()
                                .OrderBy(x => x.ID).ToListAsync();
        }
    }
}
