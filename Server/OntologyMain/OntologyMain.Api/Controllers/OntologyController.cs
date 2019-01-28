using System.Linq;
using CommonLibraries.CommonTypes;
using CommonLibraries.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OntologyMain.Api.ViewModels;

namespace OntologyMain.Api.Controllers
{
  [EnableCors("AllowAllOrigin")]
  [Route("ontology")]
  [ApiController]
  public class OntologyController : ControllerBase
  {
    private ILogger<PatientsController> Logger { get; }

    public OntologyController(ILogger<PatientsController> logger)
    {
      Logger = logger;
    }

    [HttpGet("medicines")]
    public IActionResult GetMedicines()
    {
      Logger.LogInformation($"{nameof(OntologyController)}.{nameof(GetMedicines)}: Start.");

      var result = MedicineType.GetList()
        .Select(x => new TypeViewModel {Id = x.Id, Name = x.Name, Description = x.Description});

      Logger.LogInformation($"{nameof(OntologyController)}.{nameof(GetMedicines)}: End.");
      return new OkResponseResult("Medicines", new {Medicines = result});
    }
  }
}