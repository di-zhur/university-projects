using System;

namespace Delta.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;
        private FrecastDb _dbContext = new FrecastDb();
        private IRepository<Frecast> _frecastRepository;
        private IRepository<FrecastData> _frecastDataRepository;
        private IRepository<FrecastError> _frecastErrorRepository;
        private IRepository<FrecastParameters> _frecastParametersRepository;
        private IRepository<FrecastResult> _frecastResultRepository;
        private IRepository<FrecastState> _frecastStateRepository;
        private IQueryDatabase _queryDatabase;

        public IRepository<Frecast> FrecastRepository
        {
            get 
            {
                if (_frecastRepository == null)
                   return new Repository<Frecast>(_dbContext);
                
                return _frecastRepository;
            }
        }

        public IRepository<FrecastData> FrecastDataRepository
        {
            get
            {
                if (_frecastDataRepository == null)
                    return new Repository<FrecastData>(_dbContext);

                return _frecastDataRepository;
            }
        }

        public IRepository<FrecastError> FrecastErrorRepository
        {
            get
            {
                if (_frecastErrorRepository == null)
                    return new Repository<FrecastError>(_dbContext);

                return _frecastErrorRepository;
            }
        }

        public IRepository<FrecastParameters> FrecastParametersRepository
        {
            get
            {
                if (_frecastParametersRepository == null)
                    return new Repository<FrecastParameters>(_dbContext);

                return _frecastParametersRepository;
            }
        }

        public IRepository<FrecastResult> FrecastResultRepository
        {
            get
            {
                if (_frecastResultRepository == null)
                    return new Repository<FrecastResult>(_dbContext);

                return _frecastResultRepository;
            }
        }

        public IRepository<FrecastState> FrecastStateRepository
        {
            get
            {
                if (_frecastStateRepository == null)
                    return new Repository<FrecastState>(_dbContext);

                return _frecastStateRepository;
            }
        }

        public IQueryDatabase QueryDatabase
        {
            get
            {
                if (_queryDatabase == null)
                    return new QueryDatabase(_dbContext);

                return _queryDatabase;
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


