using DevExpress.Blazor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task MaintainAttendanceHistoryAsync(U3ADbContext dbc) {
            AttendanceHistory? history;
            var changes = dbc.ChangeTracker.Entries<AttendClass>()
                                .Where(x => x.State != EntityState.Unchanged && x.State != EntityState.Detached)
                                .ToList();
            foreach (var change in changes) {
                history = null;
                switch (change.State) {
                    case EntityState.Modified:
                        history = await dbc.AttendanceHistory.Where(x => x.AttendClassID == change.Entity.ID).FirstOrDefaultAsync();
                        if (history == null) {
                            history = new AttendanceHistory();
                            PopulateHistory(ref history, change.Entity);
                            await dbc.AddAsync(history);
                        }
                        else { PopulateHistory(ref history, change.Entity); }
                        break;
                    case EntityState.Added:
                        history = new AttendanceHistory();
                        PopulateHistory(ref history, change.Entity);
                        await dbc.AddAsync(history);
                        break;
                    case EntityState.Deleted:
                        await DeleteAttendanceHistoryAsync(dbc, change.Entity.ID);
                        break;
                    default: break;
                }
            }
        }

        private static void PopulateHistory(ref AttendanceHistory history, AttendClass attendance) {
            history.AttendClassID = attendance.ID;
            history.AttendanceStatus = attendance.AttendClassStatus.Status;
            history.Course = attendance.Class.Course.Name;
            history.CourseType = attendance.Class.Course.CourseType.Name;
            history.Date = attendance.Date;
            history.IsAdHoc = attendance.IsAdHoc;
            if (attendance.Class.Leader != null) {
                history.LeaderFirstName = attendance.Class.Leader.FirstName;
                history.LeaderLastName = attendance.Class.Leader.LastName;
            }
            else {
                history.LeaderFirstName = String.Empty;
                history.LeaderLastName = String.Empty;
            }
            history.Venue = attendance.Class.Venue.Name;
            history.ParticipantFirstName = attendance.Person.FirstName;
            history.ParticipantLastName = attendance.Person.LastName;
            history.Term = attendance.Term.TermNumber;
            history.year = attendance.Term.Year;
        }

        public static async Task DeleteAttendanceHistoryAsync(U3ADbContext dbc, Guid AttendClassID) {
            var history = await dbc.AttendanceHistory.Where(x => x.AttendClassID == AttendClassID).FirstOrDefaultAsync();
            if (history != null) {
                dbc.AttendanceHistory.Remove(history);
            }
        }
    }
}
