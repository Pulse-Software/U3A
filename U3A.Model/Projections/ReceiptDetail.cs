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
    public class ReceiptDetail : OrganisationPersonDetail
    {
        public DateTime ReceiptDate { get; set; }
        public int ReceiptProcessingYear { get; set; }
        public decimal ReceiptAmount { get; set; }
        public string ReceiptDescription { get; set; }
        public string? ReceiptIdentifier { get; set; }
        public int? ReceiptPreviousFinancialTo { get; set; }
        public DateTime? ReceiptPreviousDateJoined { get; set; }

    }
}
