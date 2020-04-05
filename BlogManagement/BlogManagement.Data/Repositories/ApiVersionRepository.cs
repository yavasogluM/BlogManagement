using System;
using System.Collections.Generic;
using System.Linq;
namespace BlogManagement.Data.Repositories
{
    public class ApiVersionRepository : BaseRepository<Models.ApiVersionEntity>
    {
        public ApiVersionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Models.ApiVersionEntity GetUptoDateVersion()
        {
            return Context.ApiVersionEntities.OrderByDescending(x => x.CreateDate).FirstOrDefault(x => x.IsDeleted == false);
        }
    }
}
