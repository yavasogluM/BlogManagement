using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace BlogManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Models.ApiVersionEntity> ApiVersionEntities { get; set; }
        public DbSet<Models.ArticleEntity> ArticleEntities { get; set; }
        public DbSet<Models.CommentEntity> CommentEntities { get; set; }
        public DbSet<Models.AuthorEntity> AuthorEntities { get; set; }
        public DbSet<Models.LogEntity> LogEntities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.ArticleEntity>()
            .HasMany(c => c.Comments)
            .WithOne(e => e.Article);

            modelBuilder.Entity<Models.ArticleEntity>()
                .HasOne(a => a.Author)
                .WithMany(ar => ar.Article);

        }

    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {

            string rootPath = $"{Directory.GetCurrentDirectory()}";
            string jsonFilePath = $"{rootPath}/../BlogManagement.API/appsettings.json";

            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(rootPath).AddJsonFile(jsonFilePath).Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
