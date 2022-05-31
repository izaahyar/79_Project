using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _79_Project.ViewModel.Transaction
{
    public class ListTransactionViewModel
    {
        public string ID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
    }
}
