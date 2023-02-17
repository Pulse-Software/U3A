using Microsoft.EntityFrameworkCore;
using System.Text;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task<List<CourseType>> EditableCourseTypesAsync(U3ADbContext dbc) {
            return await dbc.CourseType
                            .OrderBy(x => x.Discontinued)
                            .ThenBy(x => x.Name).ToListAsync();
        }
        public static async Task<List<CourseType>> SelectableCourseTypesAsync(U3ADbContext dbc) {
            return await dbc.CourseType.AsNoTracking()
                .Where(x => !x.Discontinued)
                .Select(c => new CourseType {
                    ID = c.ID,
                    Name = c.Name
                })
                .OrderBy(x => x.Name).ToListAsync();
        }

        public static async Task<string> DuplicateMarkUpAsync(U3ADbContext dbc, CourseType courseType) {
            StringBuilder result = new StringBuilder();
            CourseType? duplicate = await DuplicateCourseType(dbc, courseType);
            if (duplicate != null) {
                result.AppendLine($"<p>The course type [{duplicate.Name.Trim()}] is already on file.<br/>");
                if (duplicate.Discontinued) {
                    result.AppendLine("It has been <strong>Discontinued</strong>. It may be reactivated by unchecking its Discontinued status.");
                } 
                result.AppendLine("</p>");
            }
            return result.ToString();
        }

        static async Task<CourseType?> DuplicateCourseType(U3ADbContext dbc, CourseType courseType) {
            return await dbc.CourseType.AsNoTracking()
                            .Where(x => x.ID != courseType.ID &&
                                        x.Name.Trim().ToUpper() == courseType.Name.Trim().ToUpper()).FirstOrDefaultAsync();
        }
    }
}
