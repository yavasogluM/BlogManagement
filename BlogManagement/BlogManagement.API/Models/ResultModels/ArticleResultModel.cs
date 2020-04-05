using System;
namespace BlogManagement.API.Models.ResultModels
{
    public class ArticleResultModel
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
    }
}
