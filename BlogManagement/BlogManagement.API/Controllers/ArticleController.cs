﻿using System;
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
        //private readonly BlogManagement.Data.Repositories.ArticleRepository _articleRepository;

        private readonly Data.Repositories.RepoWrappers.IRepoWrapper _repoWrappers;

        public ArticleController(BlogManagement.Data.Repositories.RepoWrappers.IRepoWrapper repoWrapper)
        {
            _repoWrappers = repoWrapper;
        }

        [Route("[action]")]
        public IEnumerable<Data.Models.ArticleEntity> GetArticles()
        {
            var articles = _repoWrappers.Article.GetAll();

            var articleWithComments = _repoWrappers.Article.GetAllWithComments();

            return articleWithComments.ToList();
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
