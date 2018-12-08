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
      Logger.LogInformation($"{nameof(OntologyController)}.{nameof(GetSymptoms)}: Start.");

      var result = Db.GetSymptoms();

      Logger.LogInformation($"{nameof(OntologyController)}.{nameof(GetSymptoms)}: End.");
      return new OkResponseResult("Symptoms", new {Symptoms = result});
    }

    [HttpPost("symptoms")]
    public IActionResult CreateSymptom([FromBody] CreateSymptomViewModel symptomViewModel)
    {
      Logger.LogInformation($"{nameof(OntologyController)}.{nameof(CreateSymptom)}: Start.");

      var newSymptom = Db.CreateSymptom(symptomViewModel.Name, symptomViewModel.NormalIntensity);

      Logger.LogInformation($"{nameof(OntologyController)}.{nameof(CreateSymptom)}: End.");
      return new OkResponseResult("Symptom", new {Symptom = newSymptom});
    }

    [HttpGet("drugs")]
    public IActionResult GetDrugs()
    {
      Logger.LogInformation($"{nameof(OntologyController)}.{nameof(GetDrugs)}: Start.");

      var result = Db.GetDrugs();

      Logger.LogInformation($"{nameof(OntologyController)}.{nameof(GetDrugs)}: End.");
      return new OkResponseResult("Drugs", new {Drugs = result});
    }

    [HttpPost("drugs")]
    public IActionResult CreateDrug([FromBody] string name)
    {
      Logger.LogInformation($"{nameof(OntologyController)}.{nameof(CreateDrug)}: Start.");

      var newDrug = Db.CreateDrug(name);

      Logger.LogInformation($"{nameof(OntologyController)}.{nameof(CreateDrug)}: End.");
      return new OkResponseResult("Drug", new {Drug = newDrug});
    }
  }
}