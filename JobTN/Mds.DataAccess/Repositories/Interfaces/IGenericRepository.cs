using System;
using System.Collections.Generic;
using System.Text;

namespace Mds.DataAccess.Repositories.Interfaces
{
  public interface IGenericRepository<TEntity> where TEntity : class
  {
    IEnumerable<TEntity> GetAll();

    IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

    void Insert(TEntity entity);

    void Remove(TEntity entity);

    void Update(TEntity entity);
  }
}
