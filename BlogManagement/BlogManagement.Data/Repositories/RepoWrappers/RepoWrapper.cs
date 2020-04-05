using System;
namespace BlogManagement.Data.Repositories.RepoWrappers
{
    public class RepoWrapper : IRepoWrapper
    {
        private ApplicationDbContext _applicationDbContext;
        public RepoWrapper(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        private ArticleRepository _articleRepository;
        public ArticleRepository Article
        {
            get
            {
                if (_articleRepository == null)
                {
                    _articleRepository = new ArticleRepository(_applicationDbContext);
                }
                return _articleRepository;
            }
        }

        private CommentRepository _commentRepository;
        public CommentRepository Comment
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_applicationDbContext);
                }
                return _commentRepository;
            }
        }

        private ApiVersionRepository _apiVersionRepository;
        public ApiVersionRepository ApiVersion
        {
            get
            {
                if (_apiVersionRepository == null)
                {
                    _apiVersionRepository = new ApiVersionRepository(_applicationDbContext);
                }
                return _apiVersionRepository;
            }
        }

        private AuthorRepository _authorRepository;
        public AuthorRepository Author
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_applicationDbContext);
                }
                return _authorRepository;
            }
        }

        private LogRepository _logRepository;
        public LogRepository Log
        {
            get
            {
                if (_logRepository == null)
                {
                    _logRepository = new LogRepository(_applicationDbContext);
                }
                return _logRepository;
            }
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
