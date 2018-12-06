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
  [Route("api/patients")]
  [ApiController]
  public class PatientsController : ControllerBase
  {
    private OntologyRepository Db { get; }
    private ILogger<PatientsController> Logger { get; }

    public PatientsController(ILogger<PatientsController> logger, OntologyRepository db)
    {
      Logger = logger;
      Db = db;
    }

    [HttpPost]
    public IActionResult CreatePatient([FromBody]PatientViewModel newPatient)
    {
      throw new NotImplementedException();
    }
    [HttpGet]
    public IActionResult GetPatients()
    {
      throw new NotImplementedException();
    }

    [HttpGet("{patientId}")]
    public IActionResult GetPatient(int patientId)
    {
      throw new NotImplementedException();
    }

    [HttpGet("{patientId}/diagnoses")]
    public IActionResult GetPatientDiagnosis(int patientId)
    {
      throw new NotImplementedException();
    }

    [HttpPost("{patientId}/states")]
    public IActionResult CreatePatientState(int patientId) // ?????
    {
      throw new NotImplementedException();
    }


  }
}