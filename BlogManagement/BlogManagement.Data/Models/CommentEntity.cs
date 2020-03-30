using System;
namespace BlogManagement.Data.Models
{
    public class CommentEntity : BaseEntity
    {
        public string CommentContent { get; set; }
        public string CommentatorName { get; set; }
    }
}
