using System;
using System.Collections.Generic;
using Npgsql;
using NpgsqlTypes;

namespace PgDataAccess.Layer
{
    public class GenericRepository<TEntity> : PgConnection, IGenericRepository<TEntity> where TEntity : class 
    {
        private readonly string _tableName;
        
        public GenericRepository(string tableName, string connectionStr) :base(connectionStr)
        {
            _tableName = tableName;
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var connection = Connection)
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = $"SELECT * FROM {_tableName}";

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
        
        public TEntity GetById(Guid id) 
        {
            using (var connection = Connection)
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = $"SELECT * FROM {_tableName} WHERE \"Id\" = @Id";
                    cmd.Parameters.AddWithValue("Id", NpgsqlTypes.NpgsqlDbType.Uuid, id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            return reader.GetEntity<TEntity>();

                        reader.Close();
                    }
                }
                connection.Close();
                return null;
            }
        }

        public bool Insert(TEntity values)
        {
            using (var connection = Connection)
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText =
                        $"INSERT INTO {_tableName}" +
                        $"({RepositoryHelper.GetFieldsQuery<TEntity>()}) " +
                        $"VALUES ({RepositoryHelper.GetValuesQueryInsert<TEntity>()})";
                    cmd.ParametesAddWithValue(values);

                    return cmd.ExecuteNonQuery() != 0;
                }
            }
        }

        public void BulkInsert(IEnumerable<TEntity> o)
        {
            using (var connection = Connection)
            {
                connection.Open();
                using (
                    var writer =
                        connection.BeginBinaryImport($"COPY {_tableName} " +
                                                     $"({RepositoryHelper.GetFieldsQuery<TEntity>()}) " +
                                                     "FROM STDIN (FORMAT BINARY)")
                    )
                {
                    writer.SetValuesBinaryImporter(o);
                }
                connection.Close();
            }
        }

        public bool Delete(Guid id)
        {
            using (var connection = Connection)
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = $"DELETE FROM {_tableName} WHERE \"Id\" = @Id";
                    cmd.Parameters.AddWithValue("Id", NpgsqlTypes.NpgsqlDbType.Uuid, id);

                    return cmd.ExecuteNonQuery() != 0;
                }
            }
        }

        public bool Update(TEntity values)
        {
            using (var connection = Connection)
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = $"UPDATE {_tableName} " +
                                      $"SET {RepositoryHelper.GetValuesQueryUpdate<TEntity>()} " +
                                      $"WHERE \"Id\" = @Id";
                    cmd.ParametesAddWithValue(values);
                    return cmd.ExecuteNonQuery() != 0;
                }
            }
        }

        public IEnumerable<TEntity> GetByWhere(string nameParameter, NpgsqlDbType type, dynamic value)
        {
            using (var connection = Connection)
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = $"SELECT * FROM {_tableName} WHERE \"{nameParameter}\" = @{nameParameter}";
                    cmd.Parameters.AddWithValue(nameParameter, type, value);

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
    }
}
