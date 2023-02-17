using DevExpress.Blazor;
using Microsoft.EntityFrameworkCore;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task<DxSchedulerDataStorage> GetCourseScheduleDataStorageAsync(U3ADbContext dbc, Term selectedTerm) {
            return await GetCourseScheduleDataStorageAsync(dbc, selectedTerm, new List<Venue>());
        }
        public static async Task<DxSchedulerDataStorage> GetCourseScheduleDataStorageAsync(U3ADbContext dbc,
                    Term selectedTerm, IEnumerable<Venue> VenuesToFilter) {
            DxSchedulerDataStorage dataStorage = new DxSchedulerDataStorage() {
                AppointmentsSource = await GetScheduleAsync(dbc, selectedTerm, VenuesToFilter),
                AppointmentMappings = new DxSchedulerAppointmentMappings() {
                    Type = "AppointmentType",
                    Start = "StartDate",
                    End = "EndDate",
                    Subject = "Caption",
                    AllDay = "AllDay",
                    Location = "Location",
                    Description = "Description",
                    LabelId = "Label",
                    RecurrenceInfo = "Recurrence",
                    CustomFieldMappings = new List<DxSchedulerCustomFieldMapping> {
                        new DxSchedulerCustomFieldMapping { Name = "Source", Mapping = "Class" }
                    }
                },
                AppointmentLabelsSource = new List<LabelObject>() {
            new LabelObject() {
                Id = 0,
                LabelCaption = "Undersubscribed",
                BackgroundCssClass = "bg-warning",
                TextCssClass = "text-white"
            },
            new LabelObject() {
                Id = 1,
                LabelCaption = "Good To Go",
                BackgroundCssClass = "bg-success",
                TextCssClass = "text-white"
            },
            new LabelObject() {
                Id = 2,
                LabelCaption = "Oversubscribed",
                BackgroundCssClass = "bg-danger",
                TextCssClass = "text-white"
            },
            new LabelObject() {
                Id = 3,
                LabelCaption = "Places Avalable - Assign Waitlisted",
                BackgroundCssClass = "bg-info",
                TextCssClass = "text-white"
            },
            new LabelObject() {
                Id = 9,
                LabelCaption = "Cancelled/Postponed",
                BackgroundCssClass = "bg-light",
                TextCssClass = "text-white"
            },
        },
                AppointmentLabelMappings = new DxSchedulerAppointmentLabelMappings() {
                    Id = "Id",
                    Caption = "LabelCaption",
                    BackgroundCssClass = "BackgroundCssClass",
                    TextCssClass = "TextCssClass"
                }
            };
            // Set any class on a public holiday to LabelID = 9 (Xancellation)
            foreach (var ph in dbc.PublicHoliday.AsNoTracking().ToArray()) {
                DxSchedulerDateTimeRange range = new DxSchedulerDateTimeRange(ph.Date,
                            ph.Date.AddDays(1));
                var appointments = dataStorage?.GetAppointments(range);
                if (appointments != null) {
                    foreach (var a in appointments) {
                        a.LabelId = 9;
                    }
                }
            }
            // Set any class cancelled to LabelID = 9 (Cancellation)
            foreach (var cancelled in await BusinessRule.AllCancelledClassesAsync(dbc)) {
                DxSchedulerDateTimeRange range = new DxSchedulerDateTimeRange(cancelled.StartDate,
                            cancelled.EndDate.AddDays(1));
                foreach (var a in dataStorage?.GetAppointments(range)) {
                    Class c = (Class)a.CustomFields["Source"];
                    if (c != null && c.ID == cancelled.ClassID) {
                        a.LabelId = 9;
                    }
                }
            }

            return dataStorage;
        }
        static async Task<List<ClassSchedule>> GetScheduleAsync(U3ADbContext dbc,
                        Term selectedTerm, IEnumerable<Venue> VenuesToFilter) {
            List<ClassSchedule> list = new List<ClassSchedule>();
            ClassSchedule schedule;
            var classes = await BusinessRule.SelectableClassesWithCourseEnrolmentsAsync(dbc, selectedTerm);
            foreach (Class c in classes) {
                if (VenuesToFilter.Count() <= 0 || VenuesToFilter.Where(x => x.ID == c.VenueID).Any()) {
                    if (isOfferedInTerm(selectedTerm, c)) {
                        schedule = new ClassSchedule();
                        if (c.StartDate.HasValue) {
                            schedule.StartDate = GetDateTime(c.StartDate.Value, c.StartTime);
                        }
                        else {
                            schedule.StartDate = GetDateTime(selectedTerm.StartDate, c.StartTime);
                        }
                        schedule.EndDate = GetDateTime(schedule.StartDate, c.Course.Duration);

                        if ((OccurrenceType?)c.OccurrenceID != OccurrenceType.OnceOnly) {
                            schedule.AppointmentType = 1;
                        }
                        else {
                            schedule.AppointmentType = 0;
                        }
                        schedule.Caption = c.Course.Name;
                        schedule.Description = (c.Leader != null) ? c.Leader.FullName : "The Group";
                        schedule.Location = c.Venue.Name;
                        schedule.Label = GetLabelStatus(c, selectedTerm);
                        schedule.AllDay = false;
                        schedule.Recurrence = GetRecurrence(c, selectedTerm);
                        schedule.Class = c;
                        list.Add(schedule);
                    }
                }
            }
            // Public Holidays

            foreach (var ph in dbc.PublicHoliday.AsNoTracking().ToArray()) {
                // Add the holiday as an all-day event
                list.Add(new ClassSchedule() {
                    StartDate = ph.Date,
                    EndDate = ph.Date,
                    AllDay = true,
                    Caption = ph.Name
                });
            }
            return list;
        }

        public static DateTime? GetClassEndDate(U3ADbContext dbc, Class c, Term selectedTerm) {
            DateTime? result = null;
            List<ClassSchedule> list = new List<ClassSchedule>();
            var schedule = new ClassSchedule();
            if (c.StartDate.HasValue) {
                schedule.StartDate = GetDateTime(c.StartDate.Value, c.StartTime);
            }
            else {
                schedule.StartDate = GetDateTime(selectedTerm.StartDate, c.StartTime);
            }
            schedule.EndDate = GetDateTime(schedule.StartDate, c.Course.Duration);

            if ((OccurrenceType?)c.OccurrenceID != OccurrenceType.OnceOnly) {
                schedule.AppointmentType = 1;
            }
            else {
                schedule.AppointmentType = 0;
            }
            schedule.Recurrence = GetRecurrence(c, selectedTerm);
            list.Add(schedule);
            DxSchedulerDataStorage dataStorage = new DxSchedulerDataStorage() {
                AppointmentsSource = list,
                AppointmentMappings = new DxSchedulerAppointmentMappings() {
                    Type = "AppointmentType",
                    Start = "StartDate",
                    End = "EndDate",
                    Subject = "Caption",
                    AllDay = "AllDay",
                    Location = "Location",
                    Description = "Description",
                    LabelId = "Label",
                    RecurrenceInfo = "Recurrence",
                    CustomFieldMappings = new List<DxSchedulerCustomFieldMapping> {
                            new DxSchedulerCustomFieldMapping { Name = "Source", Mapping = "Class" }
                        }
                },
                AppointmentLabelsSource = new List<LabelObject>()
            };
            var range = new DxSchedulerDateTimeRange(selectedTerm.StartDate,
                            new DateTime(selectedTerm.Year, 12, 31));
            var a = dataStorage.GetAppointments(range)
                        .OrderByDescending(x => x.End).FirstOrDefault();
            if (a != null) result = a.End;
            return result;
        }

        static int GetLabelStatus(Class c, Term term) {
            int result = 0;
            var enrolments = (from e in c.Course.Enrolments
                              where e.TermID == term.ID
                              select e).ToList();
            string ClassStatus = BusinessRule.GetEnrolmentStatus(c.Course, enrolments);
            if (ClassStatus.ToLower() == "udersubscribed") { result = 0; }
            if (ClassStatus.ToLower() == "good to go") { result = 1; }
            if (ClassStatus.ToLower() == "oversubscribed") { result = 2; }
            if (ClassStatus.ToLower() == "places available - assign waitlisted") { result = 3; }
            return result;
        }
        static string GetRecurrence(Class c, Term term) {
            DxSchedulerRecurrenceInfo info = new DxSchedulerRecurrenceInfo() { Id = Guid.NewGuid() };
            switch ((OccurrenceType)c.OccurrenceID) {
                case OccurrenceType.OnceOnly: {
                        break;
                    }
                case OccurrenceType.Daily: {
                        info.Type = SchedulerRecurrenceType.Daily;
                        info.WeekDays = SchedulerWeekDays.WorkDays;
                        SetupDates(ref info, c, term);
                        break;
                    }
                case OccurrenceType.Weekly: {
                        info.Type = SchedulerRecurrenceType.Weekly;
                        switch (c.OnDay.ID) {
                            case 0: { info.WeekDays = SchedulerWeekDays.Sunday; break; }
                            case 1: { info.WeekDays = SchedulerWeekDays.Monday; break; }
                            case 2: { info.WeekDays = SchedulerWeekDays.Tuesday; break; }
                            case 3: { info.WeekDays = SchedulerWeekDays.Wednesday; break; }
                            case 4: { info.WeekDays = SchedulerWeekDays.Thursday; break; }
                            case 5: { info.WeekDays = SchedulerWeekDays.Friday; break; }
                            case 6: { info.WeekDays = SchedulerWeekDays.Saturday; break; }
                        }
                        SetupDates(ref info, c, term);
                        break;
                    }
                case OccurrenceType.Fortnightly: {
                        info.Type = SchedulerRecurrenceType.Weekly;
                        switch (c.OnDay.ID) {
                            case 0: { info.WeekDays = SchedulerWeekDays.Sunday; break; }
                            case 1: { info.WeekDays = SchedulerWeekDays.Monday; break; }
                            case 2: { info.WeekDays = SchedulerWeekDays.Tuesday; break; }
                            case 3: { info.WeekDays = SchedulerWeekDays.Wednesday; break; }
                            case 4: { info.WeekDays = SchedulerWeekDays.Thursday; break; }
                            case 5: { info.WeekDays = SchedulerWeekDays.Friday; break; }
                            case 6: { info.WeekDays = SchedulerWeekDays.Saturday; break; }
                        }
                        SetupDates(ref info, c, term);
                        info.Frequency = 2;
                        break;
                    }
                case OccurrenceType.FirstWeekOfMonth: {
                        info.Type = SchedulerRecurrenceType.Monthly;
                        switch (c.OnDay.ID) {
                            case 0: { info.WeekDays = SchedulerWeekDays.Sunday; break; }
                            case 1: { info.WeekDays = SchedulerWeekDays.Monday; break; }
                            case 2: { info.WeekDays = SchedulerWeekDays.Tuesday; break; }
                            case 3: { info.WeekDays = SchedulerWeekDays.Wednesday; break; }
                            case 4: { info.WeekDays = SchedulerWeekDays.Thursday; break; }
                            case 5: { info.WeekDays = SchedulerWeekDays.Friday; break; }
                            case 6: { info.WeekDays = SchedulerWeekDays.Saturday; break; }
                        }
                        SetupDates(ref info, c, term);
                        info.WeekOfMonth = SchedulerWeekOfMonth.First;
                        break;
                    }
                case OccurrenceType.SecondWeekOfMonth: {
                        info.Type = SchedulerRecurrenceType.Monthly;
                        switch (c.OnDay.ID) {
                            case 0: { info.WeekDays = SchedulerWeekDays.Sunday; break; }
                            case 1: { info.WeekDays = SchedulerWeekDays.Monday; break; }
                            case 2: { info.WeekDays = SchedulerWeekDays.Tuesday; break; }
                            case 3: { info.WeekDays = SchedulerWeekDays.Wednesday; break; }
                            case 4: { info.WeekDays = SchedulerWeekDays.Thursday; break; }
                            case 5: { info.WeekDays = SchedulerWeekDays.Friday; break; }
                            case 6: { info.WeekDays = SchedulerWeekDays.Saturday; break; }
                        }
                        SetupDates(ref info, c, term);
                        info.WeekOfMonth = SchedulerWeekOfMonth.Second;
                        break;
                    }
                case OccurrenceType.ThirdWeekOfMonth: {
                        info.Type = SchedulerRecurrenceType.Monthly;
                        switch (c.OnDay.ID) {
                            case 0: { info.WeekDays = SchedulerWeekDays.Sunday; break; }
                            case 1: { info.WeekDays = SchedulerWeekDays.Monday; break; }
                            case 2: { info.WeekDays = SchedulerWeekDays.Tuesday; break; }
                            case 3: { info.WeekDays = SchedulerWeekDays.Wednesday; break; }
                            case 4: { info.WeekDays = SchedulerWeekDays.Thursday; break; }
                            case 5: { info.WeekDays = SchedulerWeekDays.Friday; break; }
                            case 6: { info.WeekDays = SchedulerWeekDays.Saturday; break; }
                        }
                        SetupDates(ref info, c, term);
                        info.WeekOfMonth = SchedulerWeekOfMonth.Third;
                        break;
                    }
                case OccurrenceType.FourthWeekOfMonth: {
                        info.Type = SchedulerRecurrenceType.Monthly;
                        switch (c.OnDay.ID) {
                            case 0: { info.WeekDays = SchedulerWeekDays.Sunday; break; }
                            case 1: { info.WeekDays = SchedulerWeekDays.Monday; break; }
                            case 2: { info.WeekDays = SchedulerWeekDays.Tuesday; break; }
                            case 3: { info.WeekDays = SchedulerWeekDays.Wednesday; break; }
                            case 4: { info.WeekDays = SchedulerWeekDays.Thursday; break; }
                            case 5: { info.WeekDays = SchedulerWeekDays.Friday; break; }
                            case 6: { info.WeekDays = SchedulerWeekDays.Saturday; break; }
                        }
                        SetupDates(ref info, c, term);
                        info.WeekOfMonth = SchedulerWeekOfMonth.Fourth;
                        break;
                    }
                case OccurrenceType.LastWeekOfMonth: {
                        info.Type = SchedulerRecurrenceType.Monthly;
                        switch (c.OnDay.ID) {
                            case 0: { info.WeekDays = SchedulerWeekDays.Sunday; break; }
                            case 1: { info.WeekDays = SchedulerWeekDays.Monday; break; }
                            case 2: { info.WeekDays = SchedulerWeekDays.Tuesday; break; }
                            case 3: { info.WeekDays = SchedulerWeekDays.Wednesday; break; }
                            case 4: { info.WeekDays = SchedulerWeekDays.Thursday; break; }
                            case 5: { info.WeekDays = SchedulerWeekDays.Friday; break; }
                            case 6: { info.WeekDays = SchedulerWeekDays.Saturday; break; }
                        }
                        SetupDates(ref info, c, term);
                        info.WeekOfMonth = SchedulerWeekOfMonth.Last;
                        break;
                    }
                case OccurrenceType.Every5Weeks: {
                        info.Type = SchedulerRecurrenceType.Weekly;
                        switch (c.OnDay.ID) {
                            case 0: { info.WeekDays = SchedulerWeekDays.Sunday; break; }
                            case 1: { info.WeekDays = SchedulerWeekDays.Monday; break; }
                            case 2: { info.WeekDays = SchedulerWeekDays.Tuesday; break; }
                            case 3: { info.WeekDays = SchedulerWeekDays.Wednesday; break; }
                            case 4: { info.WeekDays = SchedulerWeekDays.Thursday; break; }
                            case 5: { info.WeekDays = SchedulerWeekDays.Friday; break; }
                            case 6: { info.WeekDays = SchedulerWeekDays.Saturday; break; }
                        }
                        SetupDates(ref info, c, term);
                        info.Frequency = 5;
                        break;
                    }
                case OccurrenceType.Every6Weeks: {
                        info.Type = SchedulerRecurrenceType.Weekly;
                        switch (c.OnDay.ID) {
                            case 0: { info.WeekDays = SchedulerWeekDays.Sunday; break; }
                            case 1: { info.WeekDays = SchedulerWeekDays.Monday; break; }
                            case 2: { info.WeekDays = SchedulerWeekDays.Tuesday; break; }
                            case 3: { info.WeekDays = SchedulerWeekDays.Wednesday; break; }
                            case 4: { info.WeekDays = SchedulerWeekDays.Thursday; break; }
                            case 5: { info.WeekDays = SchedulerWeekDays.Friday; break; }
                            case 6: { info.WeekDays = SchedulerWeekDays.Saturday; break; }
                        }
                        SetupDates(ref info, c, term);
                        info.Frequency = 6;
                        break;
                    }
            }
            return info?.ToXml();
        }

        static void SetupDates(ref DxSchedulerRecurrenceInfo info, Class c, Term term) {
            if (c.StartDate.HasValue) {
                info.Start = GetDateTime(c.StartDate.Value, c.StartTime);
            }
            else {
                info.Start = GetDateTime(term.StartDate, c.StartTime);
            }
            if (c.Recurrence.HasValue) {
                info.OccurrenceCount = c.Recurrence.Value;
                info.Range = SchedulerRecurrenceRange.OccurrenceCount;
            }
            else {
                info.End = term.EndDate;
                info.Range = SchedulerRecurrenceRange.EndByDate;
            }
        }

        static DateTime GetDateTime(DateTime DatePart, DateTime TimePart) {
            return new DateTime(DatePart.Year, DatePart.Month, DatePart.Day,
                                TimePart.Hour, TimePart.Minute, 0);
        }
        static DateTime GetDateTime(DateTime DatePart, decimal Duration) {
            return DatePart.AddHours((double)Duration);
        }
        static bool isOfferedInTerm(Term selectedTerm, Class c) {
            bool result = false;
            if (c.StartDate.HasValue && c.Recurrence.HasValue && c.Recurrence > 0) result = true;
            if (OccurrenceType.OnceOnly == (OccurrenceType)c.OccurrenceID) result = true;
            if (c.OfferedTerm1 && selectedTerm.TermNumber == 1) { result = true; }
            if (c.OfferedTerm2 && selectedTerm.TermNumber == 2) { result = true; }
            if (c.OfferedTerm3 && selectedTerm.TermNumber == 3) { result = true; }
            if (c.OfferedTerm4 && selectedTerm.TermNumber == 4) { result = true; }
            return result;
        }

    }

}
