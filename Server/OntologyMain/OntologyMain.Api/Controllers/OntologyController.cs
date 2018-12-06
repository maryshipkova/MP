using System;
using CommonLibraries.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OntologyMain.Api.ViewModels;
using OntologyMain.Data.Repositories;

namespace OntologyMain.Api.Controllers
{
  [EnableCors("AllowAllOrigin")]
  [Route("api/ontology")]
  [ApiController]
  public class OntologyController : ControllerBase
  {
    private OntologyRepository Db { get; }
    private ILogger<PatientsController> Logger { get; }

    public OntologyController(ILogger<PatientsController> logger, OntologyRepository db)
    {
      Logger = logger;
      Db = db;
    }


    [HttpGet("symptoms")]
    public IActionResult GetSymptoms()
    {
      throw new NotImplementedException();
    }

    [HttpGet("drugs")]
    public IActionResult GetDrugs()
    {
      throw new NotImplementedException();
    }



  }
}