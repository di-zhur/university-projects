using Npgsql;
using System.Collections.Generic;

namespace PgDataAccess.Layer
{
    public class QueryRepository : PgConnection, IQueryRepository
    {
        public QueryRepository(string connectionStr) : base(connectionStr)
        {
        }

        public IEnumerable<TEntity> ExecuteCommandQuery<TEntity>(NpgsqlCommand command) where TEntity : class
        {
            using (var connection = Connection)
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = command.CommandText;
                    foreach (NpgsqlParameter p in command.Parameters)
                        cmd.Parameters.AddWithValue(p.ParameterName, p.NpgsqlDbType, p.Value);
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            yield return reader.GetEntity<TEntity>();

                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public void ExecuteCommandNoQuery(NpgsqlCommand command)
        {
            using (var connection = Connection)
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = command.CommandText;
                    foreach (NpgsqlParameter p in command.Parameters)
                        cmd.Parameters.AddWithValue(p.ParameterName, p.NpgsqlDbType, p.Value);

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
