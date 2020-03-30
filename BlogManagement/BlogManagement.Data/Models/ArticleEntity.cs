using System;
namespace BlogManagement.Data.Models
{
    public class ArticleEntity : BaseEntity
    {
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public string AuthorName { get; set; }
    }
}
