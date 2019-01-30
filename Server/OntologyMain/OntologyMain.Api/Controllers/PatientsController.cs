using System.Threading.Tasks;
using CommonLibraries.CommonTypes;
using CommonLibraries.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OntologyMain.Api.Services;
using OntologyMain.Api.ViewModels;

namespace OntologyMain.Api.Controllers
{
  /// <summary>
  /// Patients controller
  /// </summary>
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

    /// <summary>
    /// Create Patient
    /// </summary>
    /// <param name="patientViewmodel"></param>
    /// <returns>New patient</returns>
    [HttpPost]
    [ProducesResponseType(typeof(PatientViewModel), 200)]
    public async Task<IActionResult> CreatePatient([FromBody] CreatePatientViewModel patientViewmodel)
    {
      var newPatient = await PatientService.CreatePatient(patientViewmodel.FirstName, patientViewmodel.LastName, patientViewmodel.BirthDate, (GenderType) patientViewmodel.GenderType);
      return new OkResponseResult("Patient", new {Patient = newPatient});
    }

    /// <summary>
    /// Get patients
    /// </summary>
    /// <returns>List of the patients</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ListViewModel<PatientViewModel>), 200)]
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

    /// <summary>
    /// Get particular patient
    /// </summary>
    /// <param name="patientId"></param>
    /// <returns>Particular patient</returns>
    [HttpGet("{patientId}")]
    [ProducesResponseType(typeof(PatientViewModel), 200)]
    public async Task<IActionResult> GetPatient(int patientId)
    {
      var patient = await PatientService.GetPatient(patientId);
      if (patient == null)
        return new NotFoundResponseResult($"There is no patient with patientId: {patientId}");

      return new OkResponseResult("Patient", new {Patient = patient});
    }

    /// <summary>
    /// Add new status to the patient
    /// </summary>
    /// <param name="patientId"></param>
    /// <param name="createdStatus"></param>
    /// <returns>Patient with new status</returns>
    [HttpPost("{patientId}/status")]
    [ProducesResponseType(typeof(PatientViewModel), 200)]
    public async Task<IActionResult> AddPatientStatus(int patientId, [FromBody] CreateStatusViewModel createdStatus)
    {
      var patient = await PatientService.AddPatientStatus(patientId, createdStatus.Parameters);
      if (patient == null)
        return new NotFoundResponseResult($"There is no patient with patientId:{patientId}");

      return new OkResponseResult("Patient", new {Patient = patient});
    }

    /// <summary>
    /// Add new state to the patient
    /// </summary>
    /// <param name="patientId"></param>
    /// <returns>Patient with new state</returns>
    [HttpPost("{patientId}/state")]
    [ProducesResponseType(typeof(PatientViewModel), 200)]
    public async Task<IActionResult> AddPatientState(int patientId)
    {
      var patient = await PatientService.AddPatientState(patientId);
      if (patient == null)
        return new NotFoundResponseResult($"There is no patient with patientId:{patientId}");

      return new OkResponseResult("Patient", new {Patient = patient});
    }

    /// <summary>
    /// Get all patient statuses and states
    /// </summary>
    /// <param name="patientId"></param>
    /// <returns>List of the statuses</returns>
    [HttpGet("{patientId}/history")]
    [ProducesResponseType(typeof(HistoryViewModel), 200)]
    public async Task<IActionResult> GetPatientHitory(int patientId)
    {
      var history = await PatientService.GetPatientHistory(patientId);
      if (history == null)
        return new NotFoundResponseResult($"There is no patient with patientId: {patientId}");

      return new OkResponseResult("History", new {History = history});
    }
  }
}