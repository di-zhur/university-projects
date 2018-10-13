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
    public class DirNominationController : Controller
    {
        private IRepositoryDataAdapter _dataAdapter;

        public DirNominationController(IRepositoryDataAdapter dataAdapter)
        {
            _dataAdapter = dataAdapter;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var items = _dataAdapter.DirNominations.Get();
            if (items == null)
            {
                return NotFound();
            }

            return Ok(items);
        }
        
    }
}
