using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mds.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Mds.WebApi.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class CatalogController : ControllerBase
  {

    private IUnitOfWork _unitOfWork;

    public CatalogController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(new string[] { "value1", "value2" });
    }
  }
}
