using System;
using System.Collections.Generic;

namespace _79_Project.Models
{
    public partial class TblTPembayaran
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal? Amount { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DelBy { get; set; }
        public DateTime? DelDate { get; set; }

        public virtual TblMNasabah Account { get; set; }
    }
}
