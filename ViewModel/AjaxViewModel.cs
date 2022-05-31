using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _79_Project.ViewModel
{
    public class AjaxViewModel
    {
        public AjaxViewModel()
        {
        }

        public AjaxViewModel(bool isSuccess, object data, string message)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
        }

        public void SetValues(bool isSuccess, object data, string message)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
        }

        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
