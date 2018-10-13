using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jackdaw.DataLayer
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetWhere(Func<TEntity, bool> predicate);
        TEntity Insert(TEntity item);
        void InserRange(IEnumerable<TEntity> items);
        void Remove(TEntity item);
        void RemoveRange(IEnumerable<TEntity> items);
        void Update(TEntity item);
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private JackdawDbContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public Repository(JackdawDbContext dbContext)
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
            _dbContext.SaveChanges();
            return entity.Entity;
        }

        public void InserRange(IEnumerable<TEntity> items)
        {
            _dbSet.AddRange(items);
            _dbContext.SaveChanges();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _dbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> items)
        {
            _dbSet.RemoveRange(items);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
