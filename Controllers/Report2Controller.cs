using _79_Project.Provider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _79_Project.Controllers
{
    public class Report2Controller : Controller
    {
        ReportProvider rp = new ReportProvider();

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetCustomer()
        {
            return Json(rp.GetCustomer());
        }
    }
}
