using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _79_Project.ViewModel.Transaction
{
    public class CreateEditViewModel
    {
        public string ID { get; set; }
        public int AccountId { get; set; }

        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }
        public decimal Amount { get; set; }
    }

    public class DropDownListViewModel
    {
        [JsonProperty(PropertyName = "Value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }
    }
}
