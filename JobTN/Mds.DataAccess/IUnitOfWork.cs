using Mds.DataAccess.Entitys;
using Mds.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mds.DataAccess
{
  public interface IUnitOfWork
  {
    IGenericRepository<Model> ModelRepository { get; }

    IGenericRepository<ModelVersion> ModelVersionRepository { get; }

    ICatalogRepository CatalogRepository { get; }
  }
}
