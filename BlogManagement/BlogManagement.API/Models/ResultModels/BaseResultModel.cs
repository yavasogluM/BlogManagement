using System;
namespace BlogManagement.API.Models.ResultModels
{
    public class BaseResultModel<T>
    {
        public T ResultObject { get; set; }
        public bool Result { get; set; }
        public string ErrorText { get; set; }
    }
}
