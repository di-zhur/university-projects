using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Mds.DataAccess
{
  internal static class DbContextHelper
  {

    public static List<object> SqlQuery(this DbContext dbContext, string sql)
    {
      using (var connection = dbContext.Database.GetDbConnection())
      using (var command = connection.CreateCommand())
      {
        connection.Open();
        command.CommandText = sql;
        var reader = command.ExecuteReader();

        if (reader.HasRows)
        {
          return ToObjectList(reader);
        }

        return null;
      }
    }

    private static List<object> ToObjectList(IDataReader dataReader)
    {
      var data = new List<object>();

      while (dataReader.Read())
      {
        var schemaTable = dataReader.GetSchemaTable();
        var columnsName = schemaTable == null
          ? Enumerable.Empty<string>()
          : schemaTable.Rows
                       .OfType<DataRow>()
                       .Select(row => row["ColumnName"].ToString());

        var obj = new ExpandoObject() as IDictionary<string, object>;

        foreach (var columnName in columnsName)
        {
          obj.Add(columnName, dataReader[columnName]);
        }

        var expando = (ExpandoObject)obj;
        data.Add(expando);
      }

      return data;
    }
  }
}
