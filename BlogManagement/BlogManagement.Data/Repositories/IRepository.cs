using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BlogManagement.Data.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        public void AddRange(IEnumerable<T> entities);
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        public T Get(int id);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entities);
    }
}
