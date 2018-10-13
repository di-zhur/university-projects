using System;
using System.Collections.Generic;

namespace Delta.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetWhere(Func<TEntity, bool> predicate);
        TEntity Insert(TEntity item);
        IEnumerable<TEntity> InsertRange(IEnumerable<TEntity> items);
        void Remove(TEntity item);
        void RemoveRange(IEnumerable<TEntity> items);
        bool Update(TEntity item);
    }
}
