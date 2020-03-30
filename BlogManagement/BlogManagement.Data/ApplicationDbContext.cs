using System;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Models.ArticleEntity> ArticleEntities { get; set; }
        public DbSet<Models.CommentEntity> CommentEntities { get; set; }
    }
}
