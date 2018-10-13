using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.DataAccess.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetWhere(Func<TEntity, bool> predicate);
        void Insert(TEntity item);
        void InserRange(IEnumerable<TEntity> items);
        void Remove(TEntity item);
        void RemoveRange(IEnumerable<TEntity> items);
        void Update(TEntity item);
    }
}
