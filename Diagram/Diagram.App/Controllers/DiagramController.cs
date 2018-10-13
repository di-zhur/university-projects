using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Diagram.DataAccess;
using Diagram.DataAccess.Repositories.Entity;
using Newtonsoft.Json;
using Diagram.Algorithm;
using Diagram.Algorithm.Algorithm.Forecast;
using Diagram.Algorithm.Algorithm.Classification;
using Diagram.Algorithm.Algorithm.Assessment;

namespace Diagram_App.Controllers
{
    [Route("api/[controller]")]
    public class DiagramController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiagramController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet("[action]")]
        public ActionResult GetUniveristyById(Guid id)
        {
            var universitys = _unitOfWork.
                UniversityRepository.
                GetWhere(o => o.Id == id);
            return Json(universitys);
        }

        [HttpGet("[action]")]
        public ActionResult GetUniversity()
        {
            var universitys = _unitOfWork.UniversityRepository.Get();
            return Json(universitys);
        }

        [HttpGet("[action]")]
        public ActionResult GetSpecialization()
        {
            var specializations = _unitOfWork.SpecializationRepository.Get();
            return Json(specializations);
        }

        [HttpGet("[action]")]
        public ActionResult GetFaculty()
        {
            var facultys = _unitOfWork.FacultyRepository.Get();
            return Json(facultys);
        }
        
        [HttpGet("[action]")]
        public ActionResult GetCity()
        {
            var citys = _unitOfWork.CityRepositoryRepository.Get();
            return Json(citys);
        }

        [HttpGet("[action]")]
        public ActionResult GetUniversityByCity(Guid cityId)
        {
            var universitys = _unitOfWork.UniversityRepository.GetWhere(o => o.CityId == cityId);
            return Json(universitys); 
        }

        [HttpGet("[action]")]
        public ActionResult GetFacultyByUniversity(Guid universityId)
        {
            var facultys = _unitOfWork.FacultyRepository.GetWhere(o => o.UniversityId == universityId);
            return Json(facultys);
        }

        [HttpGet("[action]")]
        public ActionResult GetSpecialtyByFaculty(Guid facultyId)
        {
            var specialtys = _unitOfWork.SpecialtyRepository.GetWhere(o => o.FacultyId == facultyId);
            return Json(specialtys);
        }

        [HttpGet("[action]")]
        public ActionResult GetSetTotalBy(Guid specialtyId)
        {
            var setTotals = _unitOfWork
                .SetTotalRepository
                .GetWhere(o => o.SpecialtyId == specialtyId)
                .Select(o => new {
                    Id = o.Id,
                    SpecialtyId = o.SpecialtyId,
                    BudgetPlaces = o.BudgetPlaces,
                    Request = o.Request,
                    Mark = o.Mark,
                    PayPlaces = o.PayPlaces,
                    Places = o.Places,
                    Year = o.Year.Year,
                    Contest = o.Contest
                })
                .OrderByDescending(e => e.Year);

            return Json(setTotals);
        }

        [HttpGet("[action]")]
        public ActionResult GetFacultyDescription(Guid universityId)
        {
            var specializations = _unitOfWork.SpecializationRepository.Get();
            var facultys = _unitOfWork.FacultyRepository
                .GetWhere(o => o.UniversityId == universityId)
                .Select(e => new
                {
                    Name = e.Name,
                    SpecializationName = specializations.FirstOrDefault(o => o.Id == e.SpecializationId).Name
                })
                .GroupBy(k => k.SpecializationName)
                .Select(i => new
                {
                    SpecializationGroup = i.Key,
                    Names = i.Select(p => p.Name)
                });

            return Json(facultys);
        }

        [HttpGet("[action]")]
        public ActionResult GetForecast(Guid universityId, Guid facultyId, Guid specialtyId)
        {
            var forecast = new Forecast();
            var algorithm = new AlgorithmCreator(forecast);
            var parameters = new Dictionary<string, string>()
            {
                { "UniversityId", universityId.ToString() },
                { "FacultyId", facultyId.ToString() },
                { "SpecialtyId", specialtyId.ToString() }
            };
            algorithm.Make(parameters);
            var result = forecast.GetResult();
            return Ok(result);
        }

        [HttpGet("[action]")]
        public ActionResult GetClassification(Guid universityId, Guid facultyId)
        {
            var classification = new Classification();
            var algorithm = new AlgorithmCreator(classification);
            var parameters = new Dictionary<string, string>()
            {
                { "UniversityId", universityId.ToString() },
                { "FacultyId", facultyId.ToString()}
            };
            algorithm.Make(parameters);
            var result = classification.GetResult();
            return Ok(result);
        }

        [HttpGet("[action]")]
        public ActionResult GetAssessment()
        {
            var assessment = new Assessment();
            var algorithm = new AlgorithmCreator(assessment);
            algorithm.Make();
            var result = assessment.GetResult();
            return Ok(result);
        }
    }
}

