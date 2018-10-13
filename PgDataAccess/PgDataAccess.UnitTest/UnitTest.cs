using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PgDataAccess.Layer;
using System.Linq;

namespace PgDataAccess.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {

              var connectionStr =
            "Host=localhost;Username=postgres;Password=123qweQWE;Database=UniverAnalytic" ;

            var repositoryClassAnalytic = new GenericRepository<Cathedra>("university.\"Cathedra\"", connectionStr).GetAll();
            var list = repositoryClassAnalytic.ToList();
    }
    }
}

public class ClassAnalytic
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
public class Cathedra
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid UniverId { get; set; }
    public Guid SpecializationId { get; set; }
}