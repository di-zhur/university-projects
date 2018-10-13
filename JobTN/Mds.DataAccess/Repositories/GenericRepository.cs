using Mds.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mds.DataAccess.Repositories
{
  public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
  {
    private ModelDbContext _dbContext;
    private DbSet<TEntity> _dbSet;

    public GenericRepository(ModelDbContext dbContext)
    {
      _dbContext = dbContext;
      _dbSet = _dbContext.Set<TEntity>();
    }

    public IEnumerable<TEntity> GetAll()
    {
      return _dbSet;
    }

    public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
    {
      return _dbSet.AsQueryable().Where(predicate);
    }

    public void Remove(TEntity item)
    {
      _dbSet.Remove(item);
      _dbContext.SaveChanges();
    }

    public void Update(TEntity item)
    {
      _dbContext.Entry(item).State = EntityState.Modified;
      _dbContext.SaveChanges();
    }

    public void Insert(TEntity entity)
    {
      _dbSet.Add(entity);
      _dbContext.SaveChanges();
    }
  }
}
