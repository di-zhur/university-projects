using Mds.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Mds.Type;

namespace Mds.DataAccess.Repositories
{
  public class CatalogRepository : ICatalogRepository
  {
    private ModelDbContext _dbContext;
    private string _schema = "dbo";

    public CatalogRepository(ModelDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public List<object> Get(string table)
    {
      try
      {
        //var sql = $"SELECT * FROM [{_schema}].[{table}]";
        var sql = @"SELECT t1.Id, t1.Name, t2.Name as VersionName, t2.ModelId, t2.IsWorked FROM [dbo].[Model] t1 
                                JOIN [dbo].[ModelVersion] t2 ON t1.Id = t2.ModelId";
        return _dbContext.SqlQuery(sql);
      }
      catch (Exception e)
      {
        return null;
      }
    }

    public void CreateTable(string table)
    {
      try
      {
        var sql = $@"CREATE TABLE [{_schema}].[{table}]
                    (
                      [Id] INT IDENTITY(1,1) NOT NULL,
                      PRIMARY KEY CLUSTERED ([Id] ASC)
                   )";
        _dbContext.Database.ExecuteSqlCommand(sql);
      }
      catch (Exception e)
      {
        
      }
    }

    public void DropTable(string table)
    {
      try
      {
        var sql = $@"DROP TABLE [{_schema}].[{table}];";
        _dbContext.Database.ExecuteSqlCommand(sql);
      }
      catch (Exception e)
      {

      }
    }

    public void AddColumn(string table, Column column)
    {
      try
      {
        var sql = $"ALTER TABLE [{_schema}].[{table}] ADD {column.Name} {column.DataType};";
        _dbContext.Database.ExecuteSqlCommand(sql);
      }
      catch (Exception e)
      {

      }
    }
  }
}


