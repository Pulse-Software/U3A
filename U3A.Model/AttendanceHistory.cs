using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace U3A.Model
{
    [Index("AttendClassID")]
    public class AttendanceHistory
    {

        [Key]
        public int ID { get; set; }

        public Guid AttendClassID { get; set; }
        public bool IsAdHoc { get; set; }
        public int year { get; set; }
        public int Term { get; set; }
        public string CourseType { get; set; }
        public string Course { get; set; }
        public string Venue { get; set; }
        public string LeaderLastName { get; set; }
        public string LeaderFirstName { get; set; }
        public DateTime Date { get; set; }
        public string ParticipantFirstName { get; set; }
        public string ParticipantLastName { get; set; }
        public string AttendanceStatus { get; set; }

        [NotMapped]
        public string Leader {
            get {
                string result;
                if (string.IsNullOrWhiteSpace(LeaderFirstName) && string.IsNullOrWhiteSpace(LeaderLastName) ){
                    result = "The Group";
                }
                else {
                    result = $"{LeaderLastName}, {LeaderFirstName}";
                }
                return result;
            }
        }

        [NotMapped]
        public string Person {
            get {
                return $"{ParticipantLastName}, {ParticipantFirstName}";
            }
        }

    }
}
