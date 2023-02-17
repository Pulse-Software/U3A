using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    public class EnrolmentDetail : OrganisationPersonDetail
    {
        public int CourseLegacyID { get; set; }
        public string CourseName { get; set; }
        public string? CourseDescription { get; set; }
        public string CourseParticipationType { get; set; }
        public decimal CourseFeePerYear { get; set; }
        public string? CourseFeePerYearDescription { get; set; }
        public decimal CourseFeePerTerm { get; set; }
        public string? CourseFeePerTermDescription { get; set; }
        public decimal CourseDuration { get; set; }
        public int CourseRequiredStudents { get; set; }
        public int CourseMaximumStudents { get; set; }
        public int CourseTotalActiveStudents { get; set; }
        public int CourseTotalWaitlistedStudents { get; set; }
        public double CourseParticipationRate { get; set; }
        public string CourseType { get; set; }
        public Boolean ClassOfferedTerm1 { get; set; } 
        public Boolean ClassOfferedTerm2 { get; set; } 
        public Boolean ClassOfferedTerm3 { get; set; } 
        public Boolean ClassOfferedTerm4 { get; set; } 
        public string ClassOfferedSummary { get; set; }
        public DateTime? ClassStartDate { get; set; }
        public string ClassOnDay { get; set; }
        public DateTime ClassStartTime { get; set; }
        public string ClassOccurrence { get; set; }
        public DateTime? ClassEndTime { get; set; }
        public string ClassStrEndTime { get; set; }
        public string ClassSummary { get; set; }
        public string ClassDetail { get; set; }
        public string ClassDetailWithoutVenue { get; set; }
        public string ClassVenue { get; set; }
        public string ClassVenueAddress { get; set; }
        public string ClassLeader { get; set; }
        public string ClassLeaderFirstName { get; set; }
        public string LeaderSummary { get; set; }
        public DateTime EnrolmentDateReceived { get; set; }
        public DateTime? EnrolmentDateEnrolled { get; set; }
        public bool EnrolmentIsWaitlisted { get; set; }

        }
    }
