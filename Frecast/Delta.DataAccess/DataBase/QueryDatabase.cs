using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Delta.DataAccess
{
    public class QueryDatabase : IQueryDatabase
    {
        private DbContext _dbContext;

        public QueryDatabase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> ExecuteSqlQuery<TEntity>(string queryText, SqlParameter parameters = null)
        {
            return _dbContext.Database.SqlQuery<TEntity>(queryText, parameters).ToListAsync().Result; 
        }

        public void ExecuteSqlCommand(string queryText)
        {
            _dbContext.Database.ExecuteSqlCommand(queryText);
        }
    }
}
