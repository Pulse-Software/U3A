using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace U3A.Model
{
    public class Class : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DateTime mStartTime { get; set; }

        [NotMapped]
        public int SotrOrder { get; set; }

        [Key]
        public Guid ID { get; set; }

        [Comment("Is the course offered in term 1?")]
        [DefaultValue(true)]
        public Boolean OfferedTerm1 { get; set; } = true;

        [Comment("Is the course offered in term 2?")]
        [DefaultValue(true)]
        public Boolean OfferedTerm2 { get; set; } = true;

        [Comment("Is the course offered in term 3?")]
        [DefaultValue(true)]
        public Boolean OfferedTerm3 { get; set; } = true;

        [Comment("Is the course offered in term 4?")]
        [DefaultValue(true)]
        public Boolean OfferedTerm4 { get; set; } = true;

        [NotMapped]
        public string OfferedSummary {
            get {
                string result = string.Empty;
                if (OfferedTerm1) { result = $"{result} T1"; }
                if (OfferedTerm2) { result = $"{result} T2"; }
                if (OfferedTerm3) { result = $"{result} T3"; }
                if (OfferedTerm4) { result = $"{result} T4"; }
                return result.Trim();
            }
        }

        [Description("Optional Start Date. Only set when Start Date is not the start of term")]
        public DateTime? StartDate { get; set; }

        [DefaultValue(2)]
        public int? OccurrenceID { get; set; }
        public Occurrence Occurrence { get; set; }

        [Description("Optional. Number of recurrancies. Only set when not the end of term")]
        public int? Recurrence { get; set; }

        public int OnDayID { get; set; }
        [Required]
        public WeekDay OnDay { get; set; }

        [Required]
        public DateTime StartTime {
            get { return mStartTime; }
            set {
                if (value != this.mStartTime) {
                    this.mStartTime = new DateTime(1, 1, 1, value.Hour, value.Minute, 0);
                    NotifyPropertyChanged();
                }
            }
        }

        [NotMapped]
        public string OccurrenceText { 
            get {
                string result = string.Empty;
                switch ((OccurrenceType) Occurrence.ID) {
                    case OccurrenceType.OnceOnly:
                        result += (StartDate.HasValue) ? StartDate.Value.ToString("ddd dd-MMM-yy") : "Term Start";
                        break;
                    case OccurrenceType.Daily:
                        result = "Daily: Mon - Fri";
                        result = $"{result} {GetDateRange()}";
                        break;
                    case OccurrenceType.Weekly:
                        result = $"{OnDay.Day}, Weekly";
                        result = $"{result} {GetDateRange()}";
                        break;
                    case OccurrenceType.Fortnightly:
                        result = $"{OnDay.Day}, Fornightly";
                        result = $"{result} {GetDateRange()}";
                        break;
                    case OccurrenceType.FirstWeekOfMonth:
                        result = $"{OnDay.Day}, 1st Week of Month";
                        result = $"{result} {GetDateRange()}";
                        break;
                    case OccurrenceType.SecondWeekOfMonth:
                        result = $"{OnDay.Day}, 2nd Week of Month";
                        result = $"{result} {GetDateRange()}";
                        break;
                    case OccurrenceType.ThirdWeekOfMonth:
                        result = $"{OnDay.Day}, 3rd Week of Month";
                        result = $"{result} {GetDateRange()}";
                        break;
                    case OccurrenceType.FourthWeekOfMonth:
                        result = $"{OnDay.Day}, 4th Week of Month";
                        result = $"{result} {GetDateRange()}";
                        break;
                    case OccurrenceType.LastWeekOfMonth:
                        result = $" {OnDay.Day}, Last Week of Month";
                        result = $"{result} {GetDateRange()}";
                        break;
                    case OccurrenceType.Every5Weeks:
                        result = $" {OnDay.Day}, Every 5 Weeks";
                        result = $"{result} {GetDateRange()}";
                        break;
                    case OccurrenceType.Every6Weeks:
                        result = $" {OnDay.Day}, Every 6 Weeks";
                        result = $"{result} {GetDateRange()}";
                        break;
                }
                return result;
            }
        }

        string GetDateRange() {
            string result = string.Empty;
            if (StartDate.HasValue && Recurrence.HasValue) { 
                result = $": From {StartDate.Value.ToString("d")} & repeats {Recurrence} times."; }
            if (!StartDate.HasValue && !Recurrence.HasValue) { result = ": For full term."; }
            if (StartDate.HasValue && !Recurrence.HasValue) { result = $": From {StartDate.Value.ToString("d")} till End of Term."; }
            if (!StartDate.HasValue && Recurrence.HasValue) { result = $": From Start of Term & repeats {Recurrence} times."; }
            return result;
        }


        [NotMapped]
        public DateTime? EndTime {
            get {
                DateTime? result = null;
                if (Course != null) { result = StartTime.AddHours((double)Course.Duration); }
                return result;
            }
        }
        [NotMapped]
        public string StrEndTime {
            get {
                string result = String.Empty;
                if (Course != null) { result = StartTime.AddHours((double)Course.Duration).ToString("t").Trim(); }
                return result;
            }
        }

        [NotMapped]
        public string CourseSummary {
            get {
                var s = $"{Course.Name} {OccurrenceText} From: {StartTime.ToString("t")} To: {StrEndTime}";
                if (Venue != null) { s = $"{s} {Venue.Name}"; }
                return s;
            }
        }
        [NotMapped]
        public string ClassSummary {
            get {
                var s = $"{OccurrenceText} From: {StartTime.ToString("t")} To: {StrEndTime}";
                if (Venue != null) { s = $"{s} {Venue.Name}"; }
                return s;
            }
        }
        [NotMapped]
        public string ClassDetail {
            get {
                var s = $"{OccurrenceText} {StartTime.ToString("t").Trim()} to {StrEndTime}";
                if (Venue != null) { s = $"{s} {Venue.Name}"; }
                return s;
            }
        }
        [NotMapped]
        public string ClassDetailWithoutVenue {
            get {
                var s = $"{OccurrenceText} {StartTime.ToString("t").Trim()} to {StrEndTime}";
                return s;
            }
        }

        public Course Course { get; set; }
        public Guid CourseID { get; set; }

        [Required]
        public Venue Venue { get; set; }
        public Guid? VenueID { get; set; }

        public Guid? LeaderID { get; set; }

        [ForeignKey("LeaderID")]
        public Person? Leader { get; set; }
        
        public Guid? Leader2ID { get; set; }

        [ForeignKey("Leader2ID")]
        public Person? Leader2 { get; set; }
        
        public Guid? Leader3ID { get; set; }

        [ForeignKey("Leader3ID")]
        public Person? Leader3 { get; set; }

        public List<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
        public List<CancelClass> CancelledClasses { get; set; } = new List<CancelClass>();

        [NotMapped]
        public string LeaderSummary {
            get {
                var result = "The Group";
                if (Leader != null) { result = Leader.PersonSummary; }
                return result.Trim();
            }
        }

    }
}
