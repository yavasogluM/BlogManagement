using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Data.Repositories
{
    public class AuthorRepository : BaseRepository<Models.AuthorEntity>
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Models.AuthorEntity> GetByCredentials(string UserName, string Pass)
        {
            return await Context.AuthorEntities.FirstOrDefaultAsync(x => x.AuthorName == UserName && x.Password == Pass);
        }

        public async Task<Models.AuthorEntity> GetArticlesByAuthor(string AuthorName)
        {
            return await Context.AuthorEntities.Include(x => x.Article).FirstOrDefaultAsync(x => x.AuthorName == AuthorName);
        }

    }
}
