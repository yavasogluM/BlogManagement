using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogManagement.Data.Models
{
    public class CommentEntity : BaseEntity
    {
        public string CommentContent { get; set; }
        public string CommentatorName { get; set; }
        public ArticleEntity Article { get; set; }

        /*[ForeignKey("ArticleEntity")]
        public int ArticleId { get; set; }
        public virtual ArticleEntity ArticleEntity { get; set; }*/
    }
}
