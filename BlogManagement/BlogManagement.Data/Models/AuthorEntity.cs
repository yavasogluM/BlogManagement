using System;
using System.Collections.Generic;

namespace BlogManagement.Data.Models
{
    /// <summary>
    /// Yazar listesi
    /// </summary>
    public class AuthorEntity : BaseEntity
    {
        public string AuthorName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<ArticleEntity> Article { get; set; }
    }
}
