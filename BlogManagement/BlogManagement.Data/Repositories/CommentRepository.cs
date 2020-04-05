using System;
namespace BlogManagement.Data.Repositories
{
    public class CommentRepository : BaseRepository<Models.CommentEntity>
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
