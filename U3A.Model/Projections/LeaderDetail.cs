using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    [NotMapped]
    public class LeaderDetail : OrganisationPersonDetail
    {
        public Guid CourseID { get; set; }
        public Guid? ClassID { get; set; }

    }
}
