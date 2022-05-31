using System;
using System.Collections.Generic;

namespace _79_Project.Models
{
    public partial class TblMNasabah
    {
        public TblMNasabah()
        {
            TblTPembayaran = new HashSet<TblTPembayaran>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DelBy { get; set; }
        public DateTime? DelDate { get; set; }

        public virtual ICollection<TblTPembayaran> TblTPembayaran { get; set; }
    }
}
