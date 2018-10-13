using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jackdaw.DataLayer;
using Jackdaw.WebApi.Models;
using Jackdaw.Infrastructure;
using Newtonsoft.Json;

namespace Jackdaw.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RegisteredParticipantController : Controller
    {
        private IRepositoryDataAdapter _dataAdapter;
        
        public RegisteredParticipantController(IRepositoryDataAdapter dataAdapter)
        {
            _dataAdapter = dataAdapter;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = (from rp in _dataAdapter.RegisteredParticipants.Get()
                        join p in _dataAdapter.Participants.Get() on rp.ParticipantId equals p.Id
                        join i in _dataAdapter.Institutions.Get() on rp.InstitutionId equals i.Id
                        select new
                        {
                            Id = p.Id,
                            Fio = p.Fio,
                            NameWork = rp.NameWork,
                            Institution = i.Name,
                            Marks = rp.Marks == null ? "Нет" : "Да",
                            Mark = rp.Mark
                        }).OrderByDescending(ob => ob.Mark);

            float prevMark = 0;
            int numPlace = 0;
            var result = new List<СalculatedParticipant>();
            foreach (var o in data)
            {
                if (o.Mark == null)
                    continue;

                var calculatedParticipant = new СalculatedParticipant()
                {
                    Id = o.Id,
                    Fio = o.Fio,
                    NameWork = o.NameWork,
                    Institution = o.Institution,
                    Marks = o.Marks,
                    Mark = o.Mark
                };

                if (prevMark == o.Mark)
                {
                    calculatedParticipant.Place = numPlace;
                }
                else
                {
                    numPlace++;
                    calculatedParticipant.Place = numPlace;
                }

                prevMark = (float)o.Mark;

                result.Add(calculatedParticipant);
            }

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetСalculated()
        {
            var data = (from rp in _dataAdapter.RegisteredParticipants.Get()
                          join p in _dataAdapter.Participants.Get() on rp.ParticipantId equals p.Id
                          join i in _dataAdapter.Institutions.Get() on rp.InstitutionId equals i.Id
                          select new
                          {
                              Id = p.Id,
                              Fio = p.Fio,
                              NameWork = rp.NameWork,
                              Institution = i.Name,
                              Marks = rp.Marks == null ? "Нет" : "Да",
                              Mark = rp.Mark
                          }).OrderByDescending(ob => ob.Mark);

            float prevMark = 0;
            int numPlace = 0;
            var result = new List<СalculatedParticipant>();
            foreach (var o in data)
            {
                if (o.Mark == null)
                    continue;

                var calculatedParticipant = new СalculatedParticipant()
                {
                    Id = o.Id,
                    Fio = o.Fio,
                    NameWork = o.NameWork,
                    Institution = o.Institution,
                    Marks = o.Marks,
                    Mark = o.Mark
                };

                if (prevMark == o.Mark)
                {
                    calculatedParticipant.Place = numPlace;
                }
                else
                {
                    numPlace++;
                    calculatedParticipant.Place = numPlace;
                }

                result.Add(calculatedParticipant);
            }

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = from rp in _dataAdapter.RegisteredParticipants.Get()
                         join p in _dataAdapter.Participants.Get().Where(o => o.Id == id) on rp.ParticipantId equals p.Id
                         join i in _dataAdapter.Institutions.Get() on rp.InstitutionId equals i.Id
                         select new
                         {
                             Id = p.Id,
                             Fio = p.Fio,
                             Email = p.Email,
                             NameWork = rp.NameWork,
                             Institution = i.Name,
                             Marks = rp.Marks ?? "Не выставлено",
                             Mark = rp.Mark 
                         };

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]PostRegisteredParticipant registeredParticipant)
        {
            var participant = _dataAdapter.Participants.Insert(
                new Participant()
                {
                    Fio = registeredParticipant.Fio,
                    Email = registeredParticipant.Email
                });

            _dataAdapter.RegisteredParticipants.Insert(
                new RegisteredParticipant()
                {
                    ParticipantId = participant.Id,
                    RegisteredContestId = registeredParticipant.RegisteredContestId,
                    InstitutionId = registeredParticipant.InstitutionId,
                    NameWork = registeredParticipant.NameWork,
                    Comment = registeredParticipant.Comment
                });

            return Ok();
        }

        [HttpPost]
        public IActionResult CalculationMarks([FromBody]int registeredContestId)
        {
            var parameterAlgorithms = _dataAdapter.RegisteredParticipants
                .GetWhere(w => w.RegisteredContestId == registeredContestId)
                .Select(o => new ParameterAlgorithm()
                {
                    ParticipantId = o.ParticipantId,
                    Marks = JsonConvert.DeserializeObject<Criterion>(o.Marks)
                })
                .ToList();

            var algorithm = new ContestAlgorithm();
            var dataCalcs = algorithm.Execute(registeredContestId, parameterAlgorithms);

            foreach (var item in dataCalcs)
            {
                var entity = _dataAdapter
                    .RegisteredParticipants
                    .GetWhere(w => w.ParticipantId == item.Key)?.FirstOrDefault();

                entity.Mark = (float)item.Value;
                _dataAdapter.RegisteredParticipants.Update(entity);
            }


            return Ok();
        }


       
    }
}
