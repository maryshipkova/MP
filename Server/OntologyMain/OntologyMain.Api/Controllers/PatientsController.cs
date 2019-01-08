using System.Threading.Tasks;
using CommonLibraries.CommonTypes;
using CommonLibraries.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OntologyMain.Api.Services;
using OntologyMain.Api.ViewModels;

namespace OntologyMain.Api.Controllers
{
  [EnableCors("AllowAllOrigin")]
  [Route("patients")]
  [ApiController]
  public class PatientsController : ControllerBase
  {
    private PatientService PatientService { get; }

    public PatientsController(PatientService patientService)
    {
      PatientService = patientService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] CreatePatientViewModel patientViewmodel)
    {
      var newPatient = await PatientService.CreatePatient(patientViewmodel.FirstName, patientViewmodel.LastName, patientViewmodel.BirthDate, (GenderType) patientViewmodel.GenderType);
      return new OkResponseResult("Patient", new {Patient = newPatient});
    }

    [HttpGet]
    public async Task<IActionResult> GetPatients()
    {
      var patients = await PatientService.GetPatients();
      return new OkResponseResult("Patients",
        new
        {
          Patients = new ListViewModel<PatientViewModel>
          {
            Count = patients.Count,
            List = patients
          }
        });
    }

    [HttpGet("{patientId}")]
    public async Task<IActionResult> GetPatient(int patientId)
    {
      var patient = await PatientService.GetPatient(patientId);
      if (patient == null)
        return new NotFoundResponseResult($"There is no patient with patientId: {patientId}");

      return new OkResponseResult("Patient", new {Patient = patient});
    }

    [HttpPost("{patientId}/status")]
    public async Task<IActionResult> AddPatientStatus(int patientId, [FromBody] CreateStatusViewModel createdStatus)
    {
      var patient = await PatientService.AddPatientStatus(patientId, createdStatus.Parameters);
      if (patient == null)
        return new NotFoundResponseResult($"There is no patient with patientId:{patientId}");

      return new OkResponseResult("Patient", new {Patient = patient});
    }

    [HttpPost("{patientId}/state")]
    public async Task<IActionResult> AddPatientState(int patientId)
    {
      var patient = await PatientService.AddPatientState(patientId);
      if (patient == null)
        return new NotFoundResponseResult($"There is no patient with patientId:{patientId}");

      return new OkResponseResult("Patient", new {Patient = patient});
    }

    [HttpGet("{patientId}/history")]
    public async Task<IActionResult> GetPatientHitory(int patientId)
    {
      var history = await PatientService.GetPatientHistory(patientId);
      if (history == null)
        return new NotFoundResponseResult($"There is no patient with patientId: {patientId}");

      return new OkResponseResult("History", new {History = history});
    }
  }
}