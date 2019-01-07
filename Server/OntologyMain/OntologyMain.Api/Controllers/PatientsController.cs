using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibraries.CommonTypes;
using CommonLibraries.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OntologyMain.Api.Services;
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
    public async Task<IActionResult> CreatePatient([FromBody] CreatePatientViewModel patientViewmodel)
    {
      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(CreatePatient)}: Start.");

      var result = await Db.CreatePatientAsync(patientViewmodel.FirstName, patientViewmodel.LastName,
        patientViewmodel.BirthDate, (SexType)patientViewmodel.SexType);

      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(CreatePatient)}: End.");
      return new OkResponseResult("Patient", new {Patient = result});
    }

    [HttpGet]
    public async Task<IActionResult> GetPatients()
    {
      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(GetPatients)}: Start.");

      var result = await Db.GetPatientsAsync();

      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(GetPatients)}: End.");
      return new OkResponseResult("Patients", new {Patients = result});
    }

    [HttpGet("{patientId}")]
    public async Task<IActionResult> GetPatient(int patientId, bool? @short)
    {
      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(GetPatient)}: Start.");

      var patientDb = await Db.GetPatientAsync(patientId);

      if (patientDb == null) return new NotFoundResponseResult($"There is no patient with patientId:{patientId}");

      if (@short.GetValueOrDefault(false))
      {
        var shortPatient = new ShortPatientViewModel
        {
          PatientId = patientDb.PatientId,
          BirthDate = patientDb.BirthDate,
          FirstName = patientDb.FirstName,
          LastName = patientDb.LastName,
          SexType = patientDb.SexType
        };
        return new OkResponseResult("Patient", new { Patient = shortPatient });
      }
      var result = new PatientViewModel
      {
        PatientId = patientDb.PatientId,
        BirthDate = patientDb.BirthDate,
        FirstName = patientDb.FirstName,
        LastName = patientDb.LastName,
        SexType = patientDb.SexType
      };

      var stateDb = await Db.GetPatientState(patientDb.PatientId);
      var context = StateContext.ProcessState(stateDb.StateType);

      var statusDb = await Db.GetPatientStatus(patientDb.PatientId);
      var status = new StatusViewModel
      {
        StatusId = statusDb.StatusId,
        StartDate = statusDb.CreatedDate,
        Signs = statusDb.Signs.Select(x => new SignViewModel {SignType = x.SignType, Intensity = x.Intensity}),
        Description = context.Description,
        Medicines = TypeViewModel.FromCustomEnums(context.Medicines)
      };

      result.Status = status;

      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(GetPatient)}: End.");

      return new OkResponseResult("Patient", new {Patient = result});
    }

    [HttpPost("{patientId}/status")]
    public async Task<IActionResult> AddPatientStatus(int patientId, [FromBody]CreateStatusViewModel createdStatus)
    {
      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(AddPatientStatus)}: Start.");

      var patientDb = await Db.GetPatientAsync(patientId);
      if (patientDb == null)
        return new NotFoundResponseResult($"There is no patient with patientId: {patientId}");

      var newStatus = await Db.AddStatusAsync(patientId,
        createdStatus.Signs.Select(x => new SignDto {Intensity = x.Intensity, SignType = (SignType) x.SignTypeId}));


      var result = new PatientViewModel
      {
        PatientId = patientDb.PatientId,
        BirthDate = patientDb.BirthDate,
        FirstName = patientDb.FirstName,
        LastName = patientDb.LastName,
        SexType = patientDb.SexType
      };

      var stateDb = await Db.GetPatientState(patientDb.PatientId);
      var context = StateContext.ProcessState(stateDb.StateType);

      var status = new StatusViewModel
      {
        StatusId = newStatus.StatusId,
        StartDate = newStatus.CreatedDate,
        Signs = newStatus.Signs.Select(x => new SignViewModel { SignType = x.SignType, Intensity = x.Intensity }),
        Description = context.Description,
        Medicines = TypeViewModel.FromCustomEnums(context.Medicines)
      };

      result.Status = status;

      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(AddPatientStatus)}: End.");

      return new OkResponseResult("Patient", new {Patient = result});
    }

    [HttpPost("{patientId}/state")]
    public async Task<IActionResult> AddPatientState(int patientId)
    {
      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(AddPatientStatus)}: Start.");

      var patientDb = await Db.GetPatientAsync(patientId);
      if (patientDb == null)
        return new NotFoundResponseResult($"There is no patient with patientId: {patientId}");

      var result = new PatientViewModel
      {
        PatientId = patientDb.PatientId,
        BirthDate = patientDb.BirthDate,
        FirstName = patientDb.FirstName,
        LastName = patientDb.LastName,
        SexType = patientDb.SexType
      };

      var stateDb = await Db.GetPatientState(patientDb.PatientId);
      var context = StateContext.ProcessState(stateDb.StateType);

      var status = new StatusViewModel
      {
        StatusId = newStatus.StatusId,
        StartDate = newStatus.CreatedDate,
        Signs = newStatus.Signs.Select(x => new SignViewModel { SignType = x.SignType, Intensity = x.Intensity }),
        Description = context.Description,
        Medicines = TypeViewModel.FromCustomEnums(context.Medicines)
      };

      result.Status = status;


      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(AddPatientStatus)}: End.");

      return new OkResponseResult("Patient", result);
    }

    [HttpGet("{patientId}/history")]
    public async Task<IActionResult> GetPatientDiagnosis(int patientId)
    {
      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(GetPatientDiagnosis)}: Start.");

      var patient = await Db.GetPatientAsync(patientId);
      var history = new HistoryViewModel();
      var result = new {History = history};
      if (patient == null)
        return new NotFoundResponseResult($"There is no patient with patientId:{patientId}", result);


      var statuses = new List<StatusDto>();
      var states = new List<StateDto>();

      statuses = await Db.GetStatusesAsync(patient.PatientId);

       states = await Db.GetStatesAsync(patient.PatientId);

      history.States = states;
      history.Statuses = statuses;


      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(GetPatientDiagnosis)}: End.");



      return new OkResponseResult("Patient", result);
    }

    //[HttpPost("{patientId}/diagnoses")]
    //public async Task<IActionResult> AddPatientDiagnosis(int patientId,
    //  [FromBody] CreatePatientDiagnosis diagnosisViewModel)
    //{
    //  Logger.LogInformation($"{nameof(PatientsController)}.{nameof(AddPatientDiagnosis)}: Start.");

    //  var patient = await Db.GetPatient(patientId);
    //  var diagnosis = new DiagnosisDto();
    //  if (patient.PatientId != 0)
    //    diagnosis = await Db.AddPatientDiagnosis(patient.PatientId, diagnosisViewModel.PatientIntensity, diagnosisViewModel.SymptomId, diagnosisViewModel.Drugs.Select(x => (x.DrugId, x.Dosage)).ToList());

    //  var result = new {Patient = patient, Diagnosis = diagnosis};

    //  Logger.LogInformation($"{nameof(PatientsController)}.{nameof(AddPatientDiagnosis)}: End.");

    //  if (patient.PatientId == 0)
    //    return new NotFoundResponseResult($"There is no patient with patientId:{patientId}", result);

    //  return new OkResponseResult("Patient", result);
    //}
  }
}