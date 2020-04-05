using System;
using System.Collections.Generic;

namespace BlogManagement.Data.Models
{
    public class ArticleEntity : BaseEntity
    {
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public virtual AuthorEntity Author { get; set; }
        public virtual ICollection<CommentEntity> Comments{get;set;}
    }
}
