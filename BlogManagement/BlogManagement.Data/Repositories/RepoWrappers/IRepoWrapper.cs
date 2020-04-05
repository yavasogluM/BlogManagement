using System;
namespace BlogManagement.Data.Repositories.RepoWrappers
{
    public interface IRepoWrapper
    {
        Repositories.ArticleRepository Article { get; }
        Repositories.CommentRepository Comment { get; }
        Repositories.ApiVersionRepository ApiVersion { get; }
        Repositories.AuthorRepository Author { get; }
        Repositories.LogRepository Log { get; }
        void Save();
    }
}
