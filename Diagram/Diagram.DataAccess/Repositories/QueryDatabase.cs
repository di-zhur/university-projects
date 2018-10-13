using Diagram.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Diagram.DataAccess.Repositories
{
    public class QueryDatabase : IQueryDatabase
    {
        private DataContext _dbContext;

        public QueryDatabase(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> ExecuteSqlQuery<TEntity>(string queryText, SqlParameter parameters = null)
        {
            //return _dbContext.Database.SqlQuery<TEntity>(queryText, parameters).ToListAsync().Result;
            return null;
        }

        public void ExecuteSqlCommand(string queryText)
        {
            //_dbContext.Database.ExecuteSqlCommand(queryText);
        }
    }
}
