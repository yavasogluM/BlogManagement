using System;
namespace BlogManagement.Data.Repositories
{
    public class LogRepository : BaseRepository<Models.LogEntity>
    {
        public LogRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
