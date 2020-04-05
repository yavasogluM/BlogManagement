using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private readonly Data.Repositories.RepoWrappers.IRepoWrapper _repoWrapper;
        private readonly Services.ILogService _logService;

        public ArticleController(BlogManagement.Data.Repositories.RepoWrappers.IRepoWrapper repoWrapper, Services.ILogService logService)
        {
            _repoWrapper = repoWrapper;
            _logService = logService;
        }
        
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Models.ResultModels.ArticleResultModel> SearchByContent(string SearchText)
        {
            return _repoWrapper.Article.GetArticlesBySearchText(SearchText).Result.Select(x => new Models.ResultModels.ArticleResultModel {
                 ArticleId = x.Id,
                  ArticleContent = x.ArticleContent,
                   ArticleTitle = x.ArticleTitle
            }).ToList();
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<Data.Models.ArticleEntity> GetArticleById(int Id)
        {
            var result = _repoWrapper.Article.GetArticleDetailById(Id);
            return await result;
        }


        [HttpPost]
        [Route("[action]")]
        public Models.ResultModels.BaseResultModel<object> CreateComment([FromBody]Models.PostModels.CommentModel model)
        {
            try
            {

                var _article = _repoWrapper.Article.Get(model.ArticleId);
                if (_article == null)
                {
                    return new Models.ResultModels.BaseResultModel<object>
                    {
                         Result = false,
                          ErrorText = "Article bulunamadı"
                    };
                }
                
                Data.Models.CommentEntity commentEntity = new Data.Models.CommentEntity();
                commentEntity.IsDeleted = false;
                commentEntity.CreateDate = DateTime.Now;
                commentEntity.CommentatorName = model.CommentatorName;
                commentEntity.CommentContent = model.CommentContent;


                commentEntity.Article = _article;

                _repoWrapper.Comment.Add(commentEntity);
                _repoWrapper.Save();

                return new Models.ResultModels.BaseResultModel<object>
                {
                    Result = true
                };
            }
            catch (Exception ex)
            {
                _logService.SaveToDB(ex.ToString(), "CreateComment Metodunda Hata");
                return new Models.ResultModels.BaseResultModel<object>
                {
                    Result = false,
                    ErrorText = "Bir hata oluştu, daha sonra tekrar deneyiniz"
                };
            }
        }
    }
}
