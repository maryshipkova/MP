using CommonLibraries.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OntologyMain.Data.Repositories;

namespace OntologyMain.Api.Controllers
{
  [EnableCors("AllowAllOrigin")]
  [Route("api/[controller]")]
  [ApiController]
  public class OntologyController : ControllerBase
  {
    private OntologyRepository Db { get; }
    private ILogger<OntologyController> Logger { get; }

    public OntologyController(ILogger<OntologyController> logger, OntologyRepository db)
    {
      Logger = logger;
      Db = db;
    }

    // GET api/values
    [HttpGet("HelloWorld")]
    public IActionResult HelloWorld()
    {
      return new OkResponseResult("Hello World!");
    }
  }
}