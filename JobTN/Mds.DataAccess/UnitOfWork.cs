using Mds.DataAccess.Entitys;
using Mds.DataAccess.Repositories;
using Mds.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mds.DataAccess
{
  public class UnitOfWork : IUnitOfWork, IDisposable
  {
    private ModelDbContext _dbContext = new ModelDbContext();
    private bool disposed = false;
    private IGenericRepository<Model> _modelRepository;
    private IGenericRepository<ModelVersion> _modelVersionRepository;
    private ICatalogRepository _catalogRepository;

    public IGenericRepository<Model> ModelRepository
    {
      get
      {
        if (_modelRepository == null)
          _modelRepository = new GenericRepository<Model>(_dbContext);

        return _modelRepository;
      }
    }

    public IGenericRepository<ModelVersion> ModelVersionRepository
    {
      get
      {
        if (_modelVersionRepository == null)
          _modelVersionRepository = new GenericRepository<ModelVersion>(_dbContext);

        return _modelVersionRepository;
      }
    }

    public ICatalogRepository CatalogRepository
    {
      get
      {
        if (_catalogRepository == null)
          _catalogRepository = new CatalogRepository(_dbContext);

        return _catalogRepository;
      }
    }

    public virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          _dbContext.Dispose();
        }
        this.disposed = true;
      }
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}
