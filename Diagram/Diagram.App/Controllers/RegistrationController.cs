using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Diagram.DataAccess;
using Diagram.DataAccess.Repositories.Entity;
using Newtonsoft.Json;

namespace Diagram.App.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegistrationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult InsertUniversity()
        {
            _unitOfWork.UniversityRepository.Insert(new University());
            return Ok();
        }

        public ActionResult InsertFaculty()
        {
            _unitOfWork.FacultyRepository.Insert(new Faculty());
            return Ok();
        }

        public ActionResult InsertSpecialty()
        {
            _unitOfWork.SpecialtyRepository.Insert(new Specialty());
            return Ok();
        }

        public ActionResult InsertSetTotal()
        {
            _unitOfWork.SetTotalRepository.Insert(new SetTotal());
            return Ok();
        }
    }
}
