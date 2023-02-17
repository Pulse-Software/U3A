using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    public class Term : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Guid mID { get; set; }
        private int mYear { get; set; }
        private int mTermNumber { get; set; }
        private DateTime mStartDate { get; set; }
        private int mDuration { get; set; }
        private int mEnrolmentEnds { get; set; }
        private int mEnrolmentStarts { get; set; }
        private bool mIsDefaultTerm { get; set; }
        private bool mIsClassAllocationFinalised { get; set; } = false;



        [Key]
        public Guid ID {
            get { return mID; }
            set {
                if (value != this.mID) {
                    this.mID = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [Required]
        public int Year {
            get { return mYear; }
            set {
                if (value != this.mYear) {
                    this.mYear = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [Required]
        public int TermNumber {
            get { return mTermNumber; }
            set {
                if (value != this.mTermNumber) {
                    this.mTermNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [Required]
        public DateTime StartDate {
            get { return mStartDate; }
            set {
                if (value != this.mStartDate) {
                    this.mStartDate = new DateTime( value.Year, value.Month,value.Day);
                    NotifyPropertyChanged();
                }
            }
        }

        [Required]
        [Comment("The number of weeks a Term will last")]
        public int Duration {
            get { return mDuration; }
            set {
                if (value != this.mDuration) {
                    this.mDuration = value;
                    this.mEnrolmentEnds = -mDuration;
                    NotifyPropertyChanged();
                }
            }
        }

        [Required]
        [Comment("The number of weeks prior to StartDate that enrolment begins")]
        public int EnrolmentStarts {
            get { return mEnrolmentStarts; }
            set {
                if (value != this.mEnrolmentStarts) {
                    this.mEnrolmentStarts = value;
                    NotifyPropertyChanged();
                }
            }
        }
        [Required]
        [Comment("The number of weeks before/after to StartDate that enrolment ends")]
        public int EnrolmentEnds {
            get { return mEnrolmentEnds; }
            set {
                if (value != this.mEnrolmentEnds) {
                    this.mEnrolmentEnds = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [Required]
        [Comment("The number of weeks prior to StartDate that enrolment ends")]
        public bool IsDefaultTerm {
            get { return mIsDefaultTerm; }
            set {
                if (value != this.mIsDefaultTerm) {
                    this.mIsDefaultTerm = value;
                    NotifyPropertyChanged();
                }
            }
        }
        [Required]
        [Comment("True if class enrolment allocation is finished")]
        [DefaultValue(false)]
        public bool IsClassAllocationFinalised {
            get { return mIsClassAllocationFinalised; }
            set {
                if (value != this.mIsClassAllocationFinalised) {
                    this.mIsClassAllocationFinalised = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [NotMapped]
        public int Comparer {
            get {
                return Year * 10 + TermNumber;
            }
        }

        [NotMapped]
        public string Name {
            get {
                return $"{Year} Term-{TermNumber}";
            }
        }
        [NotMapped]
        public string TermSummary {
            get {
                return $"Term-{TermNumber}: {StartDate.ToString(constants.STD_DATE_MONTH_ONLY_FORMAT)} to {EndDate.ToString(constants.STD_DATE_FORMAT)}";
            }
        }
        [NotMapped]
        public DateTime EndDate {
            get {
                return StartDate.AddDays(Duration * 7).AddMilliseconds(-1);
            }
        }
        [NotMapped]
        public DateTime EnrolmentStartDate {
            get {
                if (StartDate == new DateTime()) {
                    return StartDate;
                }
                return StartDate.AddDays(EnrolmentStarts * 7);
            }
        }
        [NotMapped]
        public DateTime EnrolmentEndDate {
            get {
                if (StartDate == new DateTime()) {
                    return StartDate;
                }
                return StartDate.AddDays(EnrolmentEnds * 7).AddMilliseconds(-1);
            }
        }

        [NotMapped]
        public string DurationSummary {
            get {
                return $"{EndDate.ToString(constants.STD_DATE_FORMAT)} ({Duration} wks)";
            }
        }
        [NotMapped]
        public string EnrolStartSummary {
            get {
                return $"{EnrolmentStartDate.ToString(constants.STD_DATE_FORMAT)} ({EnrolmentStarts} wks)";
            }
        }
        [NotMapped]
        public string EnrolEndSummary {
            get {
                return $"{EnrolmentEndDate.ToString(constants.STD_DATE_FORMAT)} ({EnrolmentEnds} wks)";
            }
        }

        public List<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
    }
}
