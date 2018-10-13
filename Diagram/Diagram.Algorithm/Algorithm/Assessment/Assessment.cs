using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Diagram.DataAccess;
using System.Linq;
using Newtonsoft.Json;

namespace Diagram.Algorithm.Algorithm.Assessment
{
    public class Assessment : BaseAlgorithm
    {
        public override void Execute(IDictionary<string, string> parameters)
        {
            var university = UnitOfWork.UniversityRepository.Get();
            var facultys = UnitOfWork.FacultyRepository.Get();
            var specialtys = UnitOfWork.SpecialtyRepository.Get();
            var setTotals = UnitOfWork.SetTotalRepository.Get();
            var maxYear = setTotals.Max(o => o.Year);
            var data = university
                .Join(facultys, u => u.Id, f => f.UniversityId, (u, f) => new { University = u, Faculty = f })
                .Join(specialtys, f => f.Faculty.Id, s => s.FacultyId, (f, s) => new { Specialty = s, University = f })
                .Join(setTotals.Where(o => o.Year == maxYear), s => s.Specialty.Id, st => st.SpecialtyId, (s, st) =>
                new
                {
                    University = s.University.University,
                    FacultyId = s.University.Faculty.Id,
                    SpecialtyId = s.Specialty.Id,
                    SpecializationId = s.University.Faculty.SpecializationId,
                    Mark = st.Mark,
                    Places = st.PayPlaces + st.Places
                });
               
            var universityInfo = data
                .GroupBy(o => o.University)
                .Select(e => new
                {
                    UniversityId = e.Key.Id,
                    Name = e.Key.Name,
                    ShortName = e.Key.ShortName,
                    CountFaculty = e.Key.Faculty.Count(),
                    MaxMark = Math.Round(e.Select(i => i.Mark).Max(), 2),
                    AverageMark = Math.Round(e.Select(i => i.Mark).Average(), 2),
                    Places = e.Select(i => i.Places).Sum(),
                    CountSpecialty = e.Select(i => i.SpecialtyId).Distinct().Count(),
                    CountSpecialization = e.Select(i => i.SpecializationId).Distinct().Count()
                });
            
            Result = JsonConvert.SerializeObject(universityInfo);
        }
    }
}
