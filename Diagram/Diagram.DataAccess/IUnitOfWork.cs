using Diagram.DataAccess.Repositories.Entity;
using Diagram.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.DataAccess
{
    public interface IUnitOfWork
    {
        IRepository<City> CityRepositoryRepository { get; }

        IRepository<ClassStatistic> ClassStatisticRepository { get; }

        IRepository<Faculty> FacultyRepository { get; }

        IRepository<Profession> ProfessionRepository { get; }

        IRepository<SetTotal> SetTotalRepository { get; }

        IRepository<Specialization> SpecializationRepository { get; }

        IRepository<Specialty> SpecialtyRepository { get; }

        IRepository<Statistic> StatisticRepository { get; }

        IRepository<University> UniversityRepository { get; }

        IQueryDatabase QueryDatabase { get; }

        void Dispose();
    }
}
