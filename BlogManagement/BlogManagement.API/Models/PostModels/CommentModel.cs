using System;
namespace BlogManagement.API.Models.PostModels
{
    public class CommentModel : BasePostModel
    {
        public string CommentContent { get; set; }
        public string CommentatorName { get; set; }
        public int ArticleId { get; set; }
    }
}
