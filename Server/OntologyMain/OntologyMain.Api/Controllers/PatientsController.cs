using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibraries.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OntologyMain.Api.ViewModels;
using OntologyMain.Data.Dtos;
using OntologyMain.Data.Repositories;

namespace OntologyMain.Api.Controllers
{
  [EnableCors("AllowAllOrigin")]
  [Route("patients")]
  [ApiController]
  public class PatientsController : ControllerBase
  {
    private PatientsRepository Db { get; }
    private ILogger<PatientsController> Logger { get; }

    public PatientsController(ILogger<PatientsController> logger, PatientsRepository db)
    {
      Logger = logger;
      Db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] PatientViewModel patientViewmodel)
    {
      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(CreatePatient)}: Start.");

      var result = await Db.CreatePatient(patientViewmodel.FirstName, patientViewmodel.LastName,
        patientViewmodel.BirthDate, patientViewmodel.SexType);

      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(CreatePatient)}: End.");
      return new OkResponseResult("Patient", new {Patient = result});
    }

    [HttpGet]
    public async Task<IActionResult> GetPatients()
    {
      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(GetPatients)}: Start.");

      var result = await Db.GetPatients();

      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(GetPatients)}: End.");
      return new OkResponseResult("Patients", new {Patients = result});
    }

    [HttpGet("{patientId}")]
    public async Task<IActionResult> GetPatient(int patientId)
    {
      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(GetPatient)}: Start.");

      var result = await Db.GetPatient(patientId);

      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(GetPatient)}: End.");

      if (result.PatientId == 0) return new NotFoundResponseResult($"There is no patient with patientId:{patientId}");

      return new OkResponseResult("Patient", new {Patient = result});
    }

    [HttpGet("{patientId}/diagnoses")]
    public async Task<IActionResult> GetPatientDiagnosis(int patientId)
    {
      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(GetPatientDiagnosis)}: Start.");

      var patient = await Db.GetPatient(patientId);
      var diagnoses = new List<DiagnosisDto>();

      if (patient.PatientId != 0) diagnoses = await Db.GetPatientDiagnoses(patientId);

      var result = new {Patient = patient, Diagnoses = diagnoses};

      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(GetPatientDiagnosis)}: End.");

      if (patient.PatientId == 0)
        return new NotFoundResponseResult($"There is no patient with patientId:{patientId}", result);

      return new OkResponseResult("Patient", result);
    }

    [HttpPost("{patientId}/diagnoses")]
    public async Task<IActionResult> AddPatientDiagnosis(int patientId,
      [FromBody] CreatePatientDiagnosis diagnosisViewModel)
    {
      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(AddPatientDiagnosis)}: Start.");

      var patient = await Db.GetPatient(patientId);
      var diagnosis = new DiagnosisDto();
      if (patient.PatientId != 0)
        diagnosis = await Db.AddPatientDiagnosis(patient.PatientId, diagnosisViewModel.PatientIntensity, diagnosisViewModel.SymptomId, diagnosisViewModel.Drugs.Select(x => (x.DrugId, x.Dosage)).ToList());

      var result = new {Patient = patient, Diagnosis = diagnosis};

      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(AddPatientDiagnosis)}: End.");

      if (patient.PatientId == 0)
        return new NotFoundResponseResult($"There is no patient with patientId:{patientId}", result);

      return new OkResponseResult("Patient", result);
    }
  }
}