using Npgsql;

namespace PgDataAccess.Layer
{
    public abstract class PgConnection
    {
       protected NpgsqlConnection Connection { get; }
     
       protected PgConnection(string connectionStr)
       {
            Connection = new NpgsqlConnection(connectionStr);
       }
    }
}
