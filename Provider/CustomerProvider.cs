using _79_Project.Models;
using _79_Project.ViewModel;
using _79_Project.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _79_Project.Provider
{
    public class CustomerProvider
    {
        DB_79Context context = new DB_79Context();

        public AjaxViewModel Create(CreateEditViewModel model)
        {
            var result = new AjaxViewModel();
            try
            {
                TblMNasabah tp = new TblMNasabah();
                tp.Name = model.Name;
                tp.CreatedBy = 100;
                tp.CreatedDate = DateTime.Now;
                context.Add(tp);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.SetValues(false, null, ex.InnerException.Message);
                return result;
            }
            result.SetValues(true, null, "Save Success");
            return result;
        }

        public AjaxViewModel Edit(CreateEditViewModel model)
        {
            var result = new AjaxViewModel();
            try
            {
                TblMNasabah tp = context.TblMNasabah.Where(e => e.Id == Convert.ToInt32(model.ID)).FirstOrDefault();
                tp.Name = tp.Name;
                tp.CreatedBy = 100;
                tp.CreatedDate = DateTime.Now;
                context.TblMNasabah.Update(tp);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.SetValues(false, null, ex.InnerException.Message);
                return result;
            }
            result.SetValues(true, null, "Save Success");
            return result;
        }

        public AjaxViewModel Destroy(CreateEditViewModel model)
        {
            var result = new AjaxViewModel();
            try
            {
                TblMNasabah tp = context.TblMNasabah.Where(e => e.Id == Convert.ToInt32(model.ID)).FirstOrDefault();
                tp.DelBy = 100;
                tp.DelDate = DateTime.Now;
                context.TblMNasabah.Update(tp);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.SetValues(false, null, ex.InnerException.Message);
                return result;
            }
            result.SetValues(true, null, "Delete Success");
            return result;
        }

        public CreateEditViewModel GetCreateEdit(string ID)
        {
            CreateEditViewModel model = new CreateEditViewModel();
            if (!string.IsNullOrEmpty(ID))
            {
                TblMNasabah tp = context.TblMNasabah.Where(e => e.Id == Convert.ToInt32(model.ID)).FirstOrDefault();
                model.Name = tp.Name;
            }
            else
            {
                model.Name = string.Empty;
            }
            return model;
        }

        public IQueryable<ListCustomerViewModel> GetListCustomer()
        {
            var query = from a in context.TblMNasabah.Where(e => !e.DelDate.HasValue)
                        select new ListCustomerViewModel
                        {
                            ID = a.Id.ToString(),
                            Name = a.Name
                        };

            return query;
        }
    }
}
