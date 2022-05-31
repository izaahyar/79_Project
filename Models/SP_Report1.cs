using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _79_Project.Models
{
    public class SP_Report1
    {
        [Key]
        public string Name { get; set; }
        public decimal TotalPoin { get; set; }
    }
}
