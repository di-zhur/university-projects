using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mds.DataAccess;
using Mds.Type;
using Microsoft.AspNetCore.Mvc;

namespace Mds.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DataController : ControllerBase
  {

    private IUnitOfWork _unitOfWork;

    public DataController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }


    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] { "value1", "value2" };
    }

    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    [HttpPost]
    public IActionResult CreateTable([FromBody] Table table)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      return CreatedAtAction(nameof(CreateTable), new { id = 1 });
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
