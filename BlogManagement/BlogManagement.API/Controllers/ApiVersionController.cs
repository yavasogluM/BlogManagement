using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BlogManagement.Data;
using Microsoft.Extensions.Caching.Memory;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class ApiVersionController : Controller
    {
        const string memoryCacheKey = "apiCacheKey";


        private readonly Data.Repositories.RepoWrappers.IRepoWrapper _repoWrapper;
        private readonly IMemoryCache _memoryCache;

        public ApiVersionController(Data.Repositories.RepoWrappers.IRepoWrapper repoWrapper, IMemoryCache memoryCache)
        {
            _repoWrapper = repoWrapper;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Cache mekanizması güncel api versiyonu tutmak için kullanılıyor.
        /// Örnek olması için yapıldı.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public Models.ResultModels.BaseResultModel<Models.ResultModels.ApiResultModel> GetCurrentVersion()
        {
            
            try
            {
                Models.ResultModels.BaseResultModel<Models.ResultModels.ApiResultModel> apiVersion = new Models.ResultModels.BaseResultModel<Models.ResultModels.ApiResultModel>();

                if (!_memoryCache.TryGetValue(memoryCacheKey, out apiVersion))
                {
                    var result = _repoWrapper.ApiVersion.GetUptoDateVersion();
                    apiVersion = new Models.ResultModels.BaseResultModel<Models.ResultModels.ApiResultModel>
                    {
                        Result = true,
                        ResultObject = new Models.ResultModels.ApiResultModel
                        {

                            VersionName = result.VersionName,
                            VersionDetail = result.VersionDetail
                        }
                    };

                    var cacheExpirationOpts = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(1),
                        Priority = CacheItemPriority.Normal
                    };
                    _memoryCache.Set(memoryCacheKey, apiVersion, cacheExpirationOpts);
                }

                return apiVersion;

            }
            catch (Exception ex)
            {
                _repoWrapper.Log.Add(new Data.Models.LogEntity
                {
                    CreateDate = DateTime.Now,
                    IsDeleted = false,
                    LogText = ex.ToString(),
                    LogTitle = "GetCurrentVersion Metodunda Hata"
                });
                _repoWrapper.Save();
                return new Models.ResultModels.BaseResultModel<Models.ResultModels.ApiResultModel>
                {
                    Result = false,
                    ErrorText = "Bir hata oluştu, daha sonra tekrar deneyiniz"
                };
            }
        }
    }
}
