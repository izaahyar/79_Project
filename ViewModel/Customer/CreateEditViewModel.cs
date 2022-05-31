using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _79_Project.ViewModel.Customer
{
    public class CreateEditViewModel
    {
        [ScaffoldColumn(false)]
        public string ID
        {
            get;
            set;
        }
        public string Name { get; set; }
    }
}
