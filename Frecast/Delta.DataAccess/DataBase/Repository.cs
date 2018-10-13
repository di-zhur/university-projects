using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Delta.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        
        public IEnumerable<TEntity> Get()
        {
            return _dbSet;
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetWhere(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsQueryable().Where(predicate);
        }

        public TEntity Insert(TEntity item)
        {
            var entity = _dbSet.Add(item);
            SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> InsertRange(IEnumerable<TEntity> items)
        {
            var entitys = _dbSet.AddRange(items);
            SaveChanges();
            return entitys;
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> items)
        {
            _dbSet.RemoveRange(items);
            SaveChanges();
        }

        public bool Update(TEntity item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            SaveChanges();
            return true;
        }

        private void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
