using System.Collections.Generic;
using System.Data.SqlClient;

namespace Delta.DataAccess
{
    public interface IQueryDatabase
    {
        IEnumerable<TEntity> ExecuteSqlQuery<TEntity>(string queryText, SqlParameter parameters = null);

        void ExecuteSqlCommand(string queryText);
    }
}
