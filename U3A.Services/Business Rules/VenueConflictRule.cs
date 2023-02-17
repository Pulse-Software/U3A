using DevExpress.Blazor;
using Microsoft.EntityFrameworkCore;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static List<ClassSchedule> ReportableVenueConflicts(U3ADbContext dbc, Term selectedTerm) {
            var conflicts = new List<ClassSchedule>();
            List<VenueConflict> potentialConflicts = new List<VenueConflict>();
            Task<DxSchedulerDataStorage> syncTask = Task.Run(async () => {
                return await GetCourseScheduleDataStorageAsync(dbc, selectedTerm);
            });
            syncTask.Wait();
            var scheduleStorage = syncTask.Result;

            DxSchedulerDateTimeRange range = new DxSchedulerDateTimeRange(selectedTerm.StartDate,
                        selectedTerm.EndDate.AddDays(1));
            var appointments = scheduleStorage.GetAppointments(range);
            foreach (var a in scheduleStorage.GetAppointments(range)) {
                if ((int)a.LabelId != 9) {
                    Class c = (Class)a.CustomFields["Source"];
                    if (c != null) {
                        var p = potentialConflicts.Where(x => x.ID == c.VenueID &&
                                    DoTimesOverlap(x.StartDateTime, x.EndDateTime, a.Start, a.End)).FirstOrDefault();
                        if (p == null) {
                            p = new VenueConflict() {
                                ID = c.VenueID.Value,
                                Name = a.Location,
                                StartDateTime = a.Start,
                                EndDateTime = a.End
                            };
                            potentialConflicts.Add(p);
                        }
                        var cs = new ClassSchedule() {
                            AllDay = a.AllDay,
                            Caption = a.Subject,
                            Location = a.Location,
                            StartDate = a.QueryStart,
                            EndDate = a.QueryEnd,
                        };
                        p.ClassSchedules.Add(cs);
                    }
                }
            }
            foreach (var cs in potentialConflicts.Where(x => x.ClassSchedules.Count > 1)) {
                foreach (var p in cs.ClassSchedules) {
                    conflicts.Add(p);
                }
            }
            return conflicts;
        }
        static bool DoTimesOverlap(DateTime xStart, DateTime xEnd, DateTime yStart, DateTime yEnd) {
            return xStart < yEnd && xEnd > yStart;
        }
    }
}