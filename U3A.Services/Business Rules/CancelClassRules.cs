using Microsoft.EntityFrameworkCore;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task<List<CancelClass>> EditableCancelClassAsync(U3ADbContext dbc, Term selectedTerm, Class selectedClass) {
            var Cancellations = (await dbc.CancelClass
                        .Where(x => x.ClassID == selectedClass.ID)
                        .Include(x => x.Class).ThenInclude(c => c.Course)
                        .Include(x => x.Class).ThenInclude(c => c.OnDay)
                        .Include(x => x.Class).ThenInclude(c => c.Venue)
                        .Include(x => x.Class).ThenInclude(c => c.Occurrence)
                        .OrderBy(x => x.StartDate)
                        .ToListAsync()).Where(x => DoDatesOverlap(x.StartDate, x.EndDate, selectedTerm.StartDate, selectedTerm.EndDate));
            return Cancellations.ToList();
        }
        public static async Task<List<CancelClass>> AllCancelledClassesAsync(U3ADbContext dbc) {
            return await dbc.CancelClass.AsNoTracking()
                        .Include(x => x.Class).ThenInclude(c => c.Course)
                        .Include(x => x.Class).ThenInclude(c => c.OnDay)
                        .Include(x => x.Class).ThenInclude(c => c.Venue)
                        .Include(x => x.Class).ThenInclude(c => c.Occurrence)
                        .OrderBy(x => x.StartDate)
                        .ToListAsync();
        }

        public static async Task<List<CancelClass>> CancelledClassForTermAsync(U3ADbContext dbc, Term selectedTerm) {
            var Cancellations = (await dbc.CancelClass.AsNoTracking()
                        .Include(x => x.Class).ThenInclude(c => c.Course)
                        .Include(x => x.Class).ThenInclude(c => c.OnDay)
                        .Include(x => x.Class).ThenInclude(c => c.Venue)
                        .Include(x => x.Class).ThenInclude(c => c.Occurrence)
                        .OrderBy(x => x.Class.Course.Name).ThenBy(x => x.StartDate)
                        .ToListAsync()).Where(x => DoDatesOverlap(x.StartDate, x.EndDate, selectedTerm.StartDate, selectedTerm.EndDate));
            return Cancellations.ToList();
        }

        static bool DoDatesOverlap(DateTime xStart, DateTime xEnd, DateTime yStart, DateTime yEnd) {
            return xStart < yEnd.AddDays(1) && xEnd.AddDays(1) > yStart;
        }
    }
}
