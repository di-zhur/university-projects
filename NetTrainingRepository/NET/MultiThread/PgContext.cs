using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;

namespace MultiThread
{

    public class Entity
    {
        public int Id { get; set; }
        public string Data { get; set; }
    }

    public class PgContext
    {
       
        private NpgsqlConnection PgConnection { get; }
        private const string ConnectionStr =
            "Host=localhost;Username=postgres;Password=123qweQWE;Database=UniverAnalytic";

        public PgContext()
        {
            PgConnection = new NpgsqlConnection(ConnectionStr);
        }

        public IEnumerable<Entity> Get()
        {
            using (var conn = PgConnection)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"SELECT * FROM test.\"Test\"";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Entity()
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Data = reader["data"].ToString()
                            };
                        }
                        reader.Close();
                    }
                }
            }
        }

        public void Insert(int id, string data)
        {
            using (var conn = PgConnection)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText =
                        $"INSERT INTO test.\"Test\"(id, data) VALUES(@id, @data)";
                    cmd.Parameters.AddWithValue("id", NpgsqlDbType.Integer, id);
                    cmd.Parameters.AddWithValue("data", NpgsqlDbType.Text, data);


                    cmd.ExecuteNonQuery();
                }
            }
        }
        /*
         INSERT INTO test."Test"(
	id, data)
	VALUES (?, ?);
             */
        public void Delete(int id)
        {
            using (var conn = PgConnection)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"DELETE FROM test.\"Test\" WHERE \"id\" = @id";
                    cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(int id, string data)
        {
            using (var conn = PgConnection)
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"UPDATE test.\"Test\" SET data = @data WHERE \"id\" = @id";
                    cmd.Parameters.AddWithValue("id", NpgsqlDbType.Integer, id);
                    cmd.Parameters.AddWithValue("data", NpgsqlDbType.Text, data);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
