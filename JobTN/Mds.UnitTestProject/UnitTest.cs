using Mds.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mds.UnitTestProject
{
  [TestClass]
  public class UnitTest
  {

    [TestMethod]
    public void TestMethod1()
    {
      var db = new ModelDbContext();
      //var data2 = db.SqlQuery(@"SELECT t1.Id, t1.Name, t2.Name as VersionName, t2.ModelId, t2.IsWorked FROM [dbo].[Model] t1 
      //                          JOIN [dbo].[ModelVersion] t2 ON t1.Id = t2.ModelId").ToList();
    }

    [TestMethod]
    public void TestMethod2()
    {
      var db = new UnitOfWork();
      //var data2 = db.CatalogRepository.Get("ModelVersion").ToList();
      db.CatalogRepository.DropTable("Table1");
    }
  }
}
