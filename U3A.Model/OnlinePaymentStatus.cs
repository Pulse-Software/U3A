using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Model
{
    [Index(nameof(PersonID), nameof(CreatedOn))]
    [Index(nameof(AdminEmail), nameof(CreatedOn))]
    public class OnlinePaymentStatus : BaseEntity
    {
        public Guid ID { get; set; }
        public string? AdminEmail { get; set; }
        public Guid PersonID { get; set; }
        public string AccessCode { get; set; }
        public string Status { get; set; }
    }

}

