using System;
using BlogManagement.Data;
using BlogManagement.Data.Models;
using BlogManagement.Data.Repositories.RepoWrappers;

namespace BlogManagement.API.Services
{
    public interface ILogService
    {
        void SaveToDB(string Detail, string Title);

    }


    public class LogService : ILogService
    {
        private readonly Data.Repositories.RepoWrappers.IRepoWrapper _repoWrapper;

        public LogService(Data.Repositories.RepoWrappers.IRepoWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public void SaveToDB(string Detail, string Title)
        {
            _repoWrapper.Log.Add(new LogEntity
            {
                CreateDate = DateTime.Now,
                IsDeleted = false,
                LogText = Detail,
                LogTitle = Title
            });
            _repoWrapper.Save();
        }
    }
}
