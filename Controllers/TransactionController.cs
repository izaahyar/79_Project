using _79_Project.Provider;
using _79_Project.ViewModel;
using _79_Project.ViewModel.Transaction;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _79_Project.Controllers
{
    public class TransactionController : Controller
    {
        TransactionProvider tp = new TransactionProvider();

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult List([DataSourceRequest] DataSourceRequest request)
        {
            return Json(tp.GetListTransaction().ToDataSourceResult(request));
        }
        
        #region dropdown
        public ActionResult GetDescription()
        {
            return Json(tp.GetDescription());
        }
        public ActionResult GetStatus()
        {
            return Json(tp.GetStatus());
        }
        #endregion

        public ActionResult Edit(string ID)
        {
            CreateEditViewModel model = tp.GetCreateEdit(ID);
            return View("CreateEdit", model);
        }

        public ActionResult Add()
        {
            CreateEditViewModel model = tp.GetCreateEdit(string.Empty);
            return View("CreateEdit", model);
        }

        [HttpPost]
        public AjaxViewModel Save(CreateEditViewModel model)
        {
            var result = tp.Create(model);
            return result;
        }

        [HttpPost]
        public AjaxViewModel Update(CreateEditViewModel model)
        {
            var result = tp.Edit(model);
            return result;
        }

    }
}
