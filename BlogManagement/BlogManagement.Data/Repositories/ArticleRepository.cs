using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Data.Repositories
{
    public class ArticleRepository : BaseRepository<Models.ArticleEntity>
    {
        public ArticleRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Arama sonuçlarını listeliyoruz
        /// </summary>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public async Task<List<Models.ArticleEntity>> GetArticlesBySearchText(string SearchText)
        {
            return await Context.ArticleEntities.Where(x => x.IsDeleted == false && x.ArticleContent.Contains(SearchText)).ToListAsync();
        }

        /// <summary>
        /// Makalenin detay bilgisini ve yorumlarını getiriyoruz.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Models.ArticleEntity> GetArticleDetailById(int Id)
        {
           return await Context.ArticleEntities.Include(x => x.Comments.Where(c => c.IsDeleted == false)).Include(x => x.Author).FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
        }

        /// <summary>
        /// Makalenin detay bilgisini alıyoruz
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Models.ArticleEntity> GetArticleDetailByIdWithAuthor(int Id)
        {
            return await Context.ArticleEntities.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id == Id);
        }

        /// <summary>
        /// Tüm makaleleri yorumlarıyla listeliyoruz.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Models.ArticleEntity>> GetAllWithComments()
        {
            return await Context.ArticleEntities.Include(x => x.Comments).ToListAsync();
        }
    }
}
