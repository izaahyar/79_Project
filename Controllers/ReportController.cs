using _79_Project.Provider;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _79_Project.Controllers
{
    public class ReportController : Controller
    {
        ReportProvider rp = new ReportProvider();
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult List([DataSourceRequest] DataSourceRequest request)
        {
            return Json(rp.GetListSP_Report1().ToDataSourceResult(request));
        }
        public JsonResult List2([DataSourceRequest] DataSourceRequest request, int accountId, DateTime startDate, DateTime endDate)
        {
            return Json(rp.GetListSP_Report2(accountId, startDate, endDate).ToDataSourceResult(request));
        }
    }
}
