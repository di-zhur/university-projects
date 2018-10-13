using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jackdaw.DataLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jackdaw.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RegisteredContestController : Controller
    {
        private IRepositoryDataAdapter _dataAdapter;

        public RegisteredContestController(IRepositoryDataAdapter dataAdapter)
        {
            _dataAdapter = dataAdapter;
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            var contests = _dataAdapter.DirContests.Get();
            var nominations = _dataAdapter.DirNominations.Get()
                .Join(contests, outer => outer.ContestId, inner => inner.Id, (o, i) => new
                {
                    Id = o.Id,
                    Name = o.Name,
                    ContestName = i.ShortName
                });

            var regcontests = _dataAdapter.RegisteredContests.Get()
                .Join(nominations, outer => outer.NominationId, inner => inner.Id, (o, i) => new
                {
                    Id = o.Id,
                    Date = o.СompletionDate.GetDateTimeFormats()[4].ToString(),
                    Nomination = i
                })
                .OrderBy(ob => ob.Date); 
           
            if (regcontests == null)
            {
                return NotFound();
            }

            return Ok(regcontests);
        }
        
    }
}
