using Diagram.DataAccess.Repositories;
using Diagram.DataAccess.Repositories.Entity;
using Diagram.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;
        private DataContext _dbContext = new DataContext();
        private IRepository<City> _cityRepository;
        private IRepository<ClassStatistic> _classStatistic;
        private IRepository<Faculty> _faculty;
        private IRepository<Profession> _profession;
        private IRepository<SetTotal> _setTotal;
        private IRepository<Specialization> _specialization;
        private IRepository<Specialty> _specialty;
        private IRepository<Statistic> _statistic;
        private IRepository<University> _university;
        private IQueryDatabase _queryDatabase;


        public IRepository<City> CityRepositoryRepository
        {
            get
            {
                if (_cityRepository == null)
                    return new Repository<City>(_dbContext);

                return _cityRepository;
            }
        }

        public IRepository<ClassStatistic> ClassStatisticRepository
        {
            get
            {
                if (_classStatistic == null)
                    return new Repository<ClassStatistic>(_dbContext);

                return _classStatistic;
            }
        }

        public IRepository<Faculty> FacultyRepository
        {
            get
            {
                if (_faculty == null)
                    return new Repository<Faculty>(_dbContext);

                return _faculty;
            }
        }

        public IRepository<Profession> ProfessionRepository
        {
            get
            {
                if (_profession == null)
                    return new Repository<Profession>(_dbContext);

                return _profession;
            }
        }

        public IRepository<SetTotal> SetTotalRepository
        {
            get
            {
                if (_setTotal == null)
                    return new Repository<SetTotal>(_dbContext);

                return _setTotal;
            }
        }

        public IRepository<Specialization> SpecializationRepository
        {
            get
            {
                if (_specialization == null)
                    return new Repository<Specialization>(_dbContext);

                return _specialization;
            }
        }

        public IRepository<Specialty> SpecialtyRepository
        {
            get
            {
                if (_specialty == null)
                    return new Repository<Specialty>(_dbContext);

                return _specialty;
            }
        }

        public IRepository<Statistic> StatisticRepository
        {
            get
            {
                if (_statistic == null)
                    return new Repository<Statistic>(_dbContext);

                return _statistic;
            }
        }

        public IRepository<University> UniversityRepository
        {
            get
            {
                if (_university == null)
                    return new Repository<University>(_dbContext);

                return _university;
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
