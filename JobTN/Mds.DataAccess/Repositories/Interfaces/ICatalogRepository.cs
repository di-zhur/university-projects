using System;
using System.Collections.Generic;
using System.Text;

namespace Mds.DataAccess.Repositories.Interfaces
{
  public interface ICatalogRepository
  {
    List<object> Get(string table);

    void CreateTable(string table);

    void DropTable(string table);
  }
}
