using _79_Project.Provider;
using _79_Project.ViewModel.Customer;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _79_Project.Controllers
{
    public class CustomerController : Controller
    {
        CustomerProvider cp = new CustomerProvider();

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult List([DataSourceRequest] DataSourceRequest request)
        {
            return Json(cp.GetListCustomer().ToDataSourceResult(request));
        }
        [AcceptVerbs("Post")]
        public ActionResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, CreateEditViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                cp.Create(model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, CreateEditViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                cp.Edit(model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public ActionResult EditingPopup_Destroy([DataSourceRequest] DataSourceRequest request, CreateEditViewModel model)
        {
            if (model != null)
            {
                cp.Destroy(model);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}
