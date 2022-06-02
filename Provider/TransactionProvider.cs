
using _79_Project.Models;
using _79_Project.ViewModel;
using _79_Project.ViewModel.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _79_Project.Provider
{
    public class TransactionProvider
    {
        DB_79Context context = new DB_79Context();
        public IQueryable<DropDownListViewModel> GetDescription()
        {
            var query = from entity in context.TblMAdditional.Where(x => x.Group == "DescriptionColumn")
                        select new DropDownListViewModel
                        {
                            Value = entity.FieldName,
                            Text = entity.Value
                        };
            return query.OrderBy(x => x.Text);
        }
        public IQueryable<DropDownListViewModel> GetStatus()
        {
            var query = from entity in context.TblMAdditional.Where(x => x.Group == "StatusColumn")
                        select new DropDownListViewModel
                        {
                            Value = entity.FieldName,
                            Text = entity.Value
                        };
            return query.OrderBy(x => x.Text);
        }

        public AjaxViewModel Create(CreateEditViewModel model)
        {
            var result = new AjaxViewModel();
            try
            {
                TblTPembayaran tp = new TblTPembayaran();
                tp.AccountId = model.AccountId;
                tp.TransactionDate = model.TransactionDate;
                tp.Description = model.Description;
                tp.Status = model.Status;
                tp.Amount = model.Amount;
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
                TblTPembayaran tp = context.TblTPembayaran.Where(e => e.Id == Convert.ToInt32(model.ID)).FirstOrDefault();
                tp.AccountId = tp.AccountId;
                tp.TransactionDate = model.TransactionDate;
                tp.Description = model.Description;
                tp.Status = model.Status;
                tp.Amount = model.Amount;
                tp.UpdateBy = 100;
                tp.UpdateDate = DateTime.Now;
                context.TblTPembayaran.Update(tp);
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
                TblTPembayaran tp = context.TblTPembayaran.Where(e => e.Id == Convert.ToInt32(model.ID)).FirstOrDefault();
                tp.DelBy = 100;
                tp.DelDate = DateTime.Now;
                context.TblTPembayaran.Update(tp);
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
                TblTPembayaran tp = context.TblTPembayaran.Where(e => e.Id == Convert.ToInt32(ID)).FirstOrDefault();
                model.ID = ID;
                model.AccountId = tp.AccountId;
                model.TransactionDate = (DateTime)tp.TransactionDate;
                model.Description = tp.Description;
                model.Status = tp.Status;
                model.Amount = (decimal)tp.Amount;
            }
            else
            {
                model.TransactionDate = DateTime.Now;
                model.Amount = 0;
            }
            return model;
        }

        public IQueryable<ListTransactionViewModel> GetListTransaction()
        {
            var query = from a in context.TblTPembayaran
                        join b in context.TblMAdditional.Where(x => x.Group == "DescriptionColumn") on a.Description equals b.FieldName
                        join c in context.TblMAdditional.Where(x => x.Group == "StatusColumn") on a.Status equals c.FieldName
                        select new ListTransactionViewModel
                        {
                            ID = a.Id.ToString(),
                            TransactionDate = (DateTime)a.TransactionDate,
                            Description = b.Value,
                            Status = c.Value,
                            Amount = (decimal)a.Amount
                        };

            return query;
        }
    }
}
