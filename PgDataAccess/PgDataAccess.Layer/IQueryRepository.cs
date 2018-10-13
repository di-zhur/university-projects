using Npgsql;
using System.Collections.Generic;

namespace PgDataAccess.Layer
{
   public interface IQueryRepository
    {
        /// <summary>
        /// Универсальная выборка
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        IEnumerable<TEntity> ExecuteCommandQuery<TEntity>(NpgsqlCommand command) where TEntity : class;


        /// <summary>
        /// Универсальная команда CommandNoQuery
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        void ExecuteCommandNoQuery(NpgsqlCommand command);
    }
}
