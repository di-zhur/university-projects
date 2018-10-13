using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Diagram.DataAccess.Repositories.Interfaces
{
    public interface IQueryDatabase
    {
        IEnumerable<TEntity> ExecuteSqlQuery<TEntity>(string queryText, SqlParameter parameters = null);
        void ExecuteSqlCommand(string queryText);
    }
}
