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
        public static async Task<List<Venue>> EditableVenuesAsync(U3ADbContext dbc) {
            return await dbc.Venue
                            .OrderBy(x => x.Discontinued)
                            .ThenBy(x => x.Name).ToListAsync();
        }
        public static async Task<List<Venue>> SelectableVenuesAsync(U3ADbContext dbc) {
            return await dbc.Venue.AsNoTracking()
                .Where(x => !x.Discontinued)
                .OrderBy(x => x.Name).ToListAsync();
        }
        public static List<Venue> SelectableVenues(U3ADbContext dbc, Guid TermID) {
            var term = dbc.Term.Find(TermID);
            if (term == null) { return new List<Venue> { }; }
            var venues = dbc.Venue.AsNoTracking().ToList();
            foreach (var venue in venues) {
                venue.Classes = dbc.Class
                            .Include(x => x.Course).ThenInclude(x => x.CourseParticipationType)
                            .Include(x => x.OnDay)
                            .Include(x => x.Leader)
                            .Include(x => x.Occurrence)
                            .Where(x => x.VenueID == venue.ID && 
                                            x.Course.Year == term.Year)
                                            .AsEnumerable()
                                            .Where(x => IsClassInTerm(x, term.TermNumber)).ToList(); 
            }
            return venues.Where(x => x.Classes.Any()).ToList();
        }

        public static async Task<string> DuplicateMarkUpAsync(U3ADbContext dbc, Venue venue) {
            StringBuilder result = new StringBuilder();
            Venue? duplicate = await DuplicateVenue(dbc, venue);
            if (duplicate != null) {
                result.AppendLine($"<p>The venue [{duplicate.Name.Trim()}] is already on file.<br/>");
                if (duplicate.Discontinued) {
                    result.AppendLine("It has been <strong>Discontinued</strong>. It may be reactivated by unchecking its Discontinued status.");
                }
                result.AppendLine("</p>");
            }
            return result.ToString();
        }
        static async Task<Venue?> DuplicateVenue(U3ADbContext dbc, Venue venue) {
            return await dbc.Venue.AsNoTracking()
                            .Where(x => x.ID != venue.ID &&
                                        x.Name.Trim().ToUpper() == venue.Name.Trim().ToUpper()).FirstOrDefaultAsync();
        }

    }
}
