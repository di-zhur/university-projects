using System;
using System.Collections.Generic;

namespace PgDataAccess.Layer
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Все объекты
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// По Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(Guid id);

        /// <summary>
        /// Добавить
        /// </summary>
        /// <param name="values"></param>
        bool Insert(TEntity values);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        bool Delete(Guid id);

        /// <summary>
        /// Изменить
        /// </summary>
        /// <param name="values"></param>
        bool Update(TEntity values);

        /// <summary>
        /// Добавить "партию"
        /// </summary>
        /// <param name="o"></param>
        void BulkInsert(IEnumerable<TEntity> o);
    }
}
