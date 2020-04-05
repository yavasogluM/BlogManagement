using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogManagement.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        /// <summary>
        /// Token ile istek yapan kişinin bilgisini alıyoruz
        /// </summary>
        private Data.Models.AuthorEntity GetCurrentAuthor
        {
            get
            {
                var _claims = HttpContext.User.Claims;
                int _id = Convert.ToInt32(_claims.FirstOrDefault(x => x.Type == "authorid").Value);
                string _authorName = _claims.FirstOrDefault(x => x.Type == "authorname").Value;
                return _repoWrapper.Author.Get(_id);
            }
        }


        private readonly Data.Repositories.RepoWrappers.IRepoWrapper _repoWrapper;
        private readonly Services.IUserService _userService;
        private readonly Services.ILogService _logService;

        public AuthorController(BlogManagement.Data.Repositories.RepoWrappers.IRepoWrapper repoWrapper, Services.IUserService userService, Services.ILogService logService)
        {
            _repoWrapper = repoWrapper;
            _userService = userService;
            _logService = logService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<Models.ResultModels.LoginResultModel> GetAuthor([FromBody]Models.PostModels.AuthorLoginModel authorLoginModel)
        {
            var result = await _userService.Authenticate(authorLoginModel.UserName, authorLoginModel.Password);
            return result;
        }


        #region Article Methods

        /// <summary>
        /// Soft delete işlemi uygulandı.
        /// Tamamen veritabanında silinmedi. IsDeleted değeri true olarak düzenlendi.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<Models.ResultModels.BaseResultModel<object>> DeleteArticle([FromBody]Models.PostModels.ArticlePostModel model)
        {
            try
            {
                var _currentArticle = await _repoWrapper.Article.GetArticleDetailByIdWithAuthor(model.Id);

                var _author = GetCurrentAuthor;
                if (_currentArticle.Author.Id != _author.Id)
                {
                    return new Models.ResultModels.BaseResultModel<object>
                    {
                        ErrorText = "Bu başkasına ait bir makale",
                        Result = false
                    };
                }

                _currentArticle.IsDeleted = true;

                _repoWrapper.Article.Update(_currentArticle);
                _repoWrapper.Save();
                return new Models.ResultModels.BaseResultModel<object>
                {
                    Result = true
                };
            }
            catch (Exception ex)
            {
                _logService.SaveToDB(ex.ToString(), "DeleteArticle Metodunda Hata");
                return new Models.ResultModels.BaseResultModel<object>
                {
                    ErrorText = "Bir hata oluştu",
                    Result = false
                };
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<Models.ResultModels.BaseResultModel<object>> UpdateArticle([FromBody]Models.PostModels.ArticlePostModel model)
        {
            try
            {
                var _currentArticle = await _repoWrapper.Article.GetArticleDetailByIdWithAuthor(model.Id);


                var _author = GetCurrentAuthor;
                if (_currentArticle.Author.Id != _author.Id)
                {
                    return new Models.ResultModels.BaseResultModel<object>
                    {
                        ErrorText = "Bu başkasına ait bir makale",
                        Result = false
                    };
                }

                _currentArticle.ArticleTitle = model.ArticleTitle;
                _currentArticle.ArticleContent = model.ArticleContent;

                _repoWrapper.Article.Update(_currentArticle);
                _repoWrapper.Save();
                return new Models.ResultModels.BaseResultModel<object>
                {
                    Result = true
                };
            }
            catch (Exception ex)
            {
                _logService.SaveToDB(ex.ToString(), "UpdateArticle Metodunda Hata");
                return new Models.ResultModels.BaseResultModel<object>
                {
                    ErrorText = "Bir hata oluştu",
                    Result = false
                };
            }
        }


        [HttpPost]
        [Route("[action]")]
        public bool CreateArticle([FromBody]Models.PostModels.ArticlePostModel model)
        {
            bool result = false;
            try
            {
                var _author = GetCurrentAuthor;

                Data.Models.ArticleEntity articleEntity = new Data.Models.ArticleEntity();
                articleEntity.ArticleTitle = model.ArticleTitle;
                articleEntity.ArticleContent = model.ArticleContent;
                articleEntity.Author = _author;
                articleEntity.IsDeleted = false;
                articleEntity.CreateDate = DateTime.Now;

                _repoWrapper.Article.Add(articleEntity);
                _repoWrapper.Save();
                result = true;
            }
            catch (Exception ex)
            {

                _logService.SaveToDB(ex.ToString(), "CreateArticle Metodunda Hata");
                result = false;
            }
            return result;
        }

        #endregion


        #region Comment Methods

        [HttpGet]
        [Route("[action]")]
        public Models.ResultModels.BaseResultModel<object> DeleteComment(int CommentId)
        {
            try
            {
                var _comment = _repoWrapper.Comment.Get(CommentId);
                _comment.IsDeleted = true;
                _repoWrapper.Comment.Update(_comment);
                _repoWrapper.Save();
                return new Models.ResultModels.BaseResultModel<object>
                {
                    Result = true
                };
            }
            catch (Exception ex)
            {
                _logService.SaveToDB(Detail: ex.ToString(), Title: "DeleteComment Metodunda Hata");
                return new Models.ResultModels.BaseResultModel<object>
                {
                    ErrorText = "Bir hata oluştu",
                    Result = false
                };
            }
        }

        [HttpPost]
        [Route("[action]")]
        public Models.ResultModels.BaseResultModel<object> UpdateComment([FromBody]Models.PostModels.CommentModel model)
        {
            try
            {
                var _comment = _repoWrapper.Comment.Get(model.Id);

                _comment.CommentContent = model.CommentContent;
                _comment.CommentatorName = model.CommentatorName;
                _repoWrapper.Comment.Update(_comment);
                _repoWrapper.Save();
                return new Models.ResultModels.BaseResultModel<object>
                {
                    Result = true
                };
            }
            catch (Exception ex)
            {
                _logService.SaveToDB(Detail: ex.ToString(), Title: "DeleteComment Metodunda Hata");
                return new Models.ResultModels.BaseResultModel<object>
                {
                    ErrorText = "Bir hata oluştu",
                    Result = false
                };
            }
        }

        #endregion
    }
}
