using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _79_Project.Models
{
    public class SP_Report2
    {
        [Key]
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public decimal Amount { get; set; }
    }
}
