using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace U3A.Model
{
    [NotMapped]
    public class EnrolmentExportData
    {
        public string CourseType { get; set; }
        public string CourseName { get; set; }
        public string? CourseDescription { get; set; }
        public string CourseParticipationType { get; set; }
        public string CourseFeePerYear { get; set; }
        public string CourseFeePerYearDescription { get; set; }
        public string CourseFeePerTerm { get; set; }
        public string CourseFeePerTermDescription { get; set; }
        public string ClassHeld { get; set; }
        public string Leader { get; set; }
        public string Venue { get; set; }
        public string VenueLocation { get; set; }
        public string EnrolmentStatus { get; set; }

    }
}
