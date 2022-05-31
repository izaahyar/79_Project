using _79_Project.Models;
using _79_Project.ViewModel.Transaction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace _79_Project.Provider
{
    public class ReportProvider
    {
        DB_79Context context = new DB_79Context();

        public IQueryable<DropDownListViewModel> GetCustomer()
        {
            var query = from entity in context.TblMNasabah.Where(e=>!e.DelDate.HasValue)
                        select new DropDownListViewModel
                        {
                            Value = entity.Id.ToString(),
                            Text = entity.Name
                        };
            return query.OrderBy(x => x.Text);
        }

        public IQueryable<SP_Report1> GetListSP_Report1()
        {
            IQueryable<SP_Report1> ccc = context.SP_Report1.FromSql("EXECUTE SP_Report1");
            return ccc;
        }
        public IQueryable<SP_Report2> GetListSP_Report2(int accountId, DateTime startDate, DateTime endDate)
        {
            var accountIdP = new SqlParameter("param1", accountId);
            var startDateP = new SqlParameter("param2", startDate);
            var endDateP = new SqlParameter("param3", endDate);
            IQueryable<SP_Report2> ccc = context.SP_Report2.FromSql("EXECUTE SP_Report2 @param1, @param2, @param3", accountIdP, startDateP, endDateP);
            return ccc;
        }
    }
}
