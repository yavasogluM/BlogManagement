using System;
using BlogManagement.Data;
namespace BlogManagement.API.Models.ResultModels
{
    public class LoginResultModel
    {
        public Data.Models.AuthorEntity Author { get; set; }
        public string Token { get; set; }
    }
}
