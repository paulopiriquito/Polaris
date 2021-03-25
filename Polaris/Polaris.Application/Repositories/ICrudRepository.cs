using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Polaris.Application.Repositories
{
    public interface ICrudRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public IEnumerable<T> Where(Predicate<T> expression);
        public T FirstOrDefault(Predicate<T> expression);
        public T FindByGuid(Guid id);
        public void Add(T input);
        public T Update(Guid id, T updatedData);
        public void Delete(T input);
        public void Delete(Guid id);
        public bool TryCommitChanges();
        public bool TryRollbackChanges();
    }
}