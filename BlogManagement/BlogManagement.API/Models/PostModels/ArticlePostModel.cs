using System;
namespace BlogManagement.API.Models.PostModels
{
    public class ArticlePostModel : BasePostModel
    {
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
    }
}
