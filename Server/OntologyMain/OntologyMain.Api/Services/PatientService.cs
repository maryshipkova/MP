using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibraries.CommonTypes;
using Microsoft.Extensions.Logging;
using OntologyMain.Api.StateMachine;
using OntologyMain.Api.ViewModels;
using OntologyMain.Data.Dtos;
using OntologyMain.Data.Repositories;

namespace OntologyMain.Api.Services
{
  public class PatientService
  {
    private PatientsRepository Db { get; }
    private ILogger<PatientService> Logger { get; }
    private StateSwitcher StateSwitcher { get; }

    public PatientService(ILogger<PatientService> logger, PatientsRepository db, StateSwitcher stateSwitcher)
    {
      Db = db;
      Logger = logger;
      StateSwitcher = stateSwitcher;
    }

    public async Task<FullPatientViewModel> CreatePatient(string firstName, string lastName, DateTime birthDate,
      GenderType sexType)
    {
      Logger.LogInformation($"{nameof(PatientService)}.{nameof(CreatePatient)}: Start.");

      var patientDb = await Db.CreatePatientAsync(firstName, lastName, birthDate, sexType);
      var patient = FromDtoToViewModel(patientDb);

      Logger.LogInformation($"{nameof(PatientService)}.{nameof(CreatePatient)}: End.");
      return patient;
    }

    public async Task<FullPatientViewModel> GetPatient(int patientId)
    {
      Logger.LogInformation($"{nameof(PatientService)}.{nameof(GetPatient)}: Start.");

      var patientDb = await Db.GetPatientAsync(patientId);
      if (patientDb == null)
      {
        Logger.LogError(
          $"{nameof(PatientService)}.{nameof(GetPatient)}: There is no patient with patientId: {patientId}.");
        Logger.LogInformation($"{nameof(PatientService)}.{nameof(GetPatient)}: End.");
        return null;
      }

      var patient = FromDtoToViewModel(patientDb);

      Logger.LogInformation($"{nameof(PatientService)}.{nameof(GetPatient)}: End.");

      return patient;
    }

    public async Task<List<PatientViewModel>> GetPatients()
    {
      Logger.LogInformation($"{nameof(PatientService)}.{nameof(GetPatients)}: Start.");

      var patientsDb = await Db.GetPatientsAsync();
      var patients = patientsDb.Select(PatientViewModel.FromPatientEntity).ToList();

      Logger.LogInformation($"{nameof(PatientService)}.{nameof(GetPatients)}: End.");
      return patients;
    }

    public async Task<FullPatientViewModel> AddPatientStatus(int patientId, IEnumerable<AddSignViewModel> signs)
    {
      Logger.LogInformation($"{nameof(PatientService)}.{nameof(AddPatientStatus)}: Start.");

      var patientDb = await Db.GetPatientAsync(patientId);
      if (patientDb == null) return null;

      var prevStatusDb = patientDb.Status;
      var newStatusDb = await Db.AddStatusAsync(patientId,
        signs.Select(x => new SignDto {Intensity = x.Intensity, SignType = (SignType) x.SignTypeId}));

      var status = Status.CreateStatus(prevStatusDb, newStatusDb);

      var newStateType = ProcessPatient(patientDb.PatientState.StateType, status);
      await Db.AddStateAsync(patientId, newStateType);

      var newPatientDb = await Db.GetPatientAsync(patientId);
      var patient = FromDtoToViewModel(newPatientDb);

      Logger.LogInformation($"{nameof(PatientService)}.{nameof(AddPatientStatus)}: End.");
      return patient;
    }

    public async Task<FullPatientViewModel> AddPatientState(int patientId)
    {
      Logger.LogInformation($"{nameof(PatientService)}.{nameof(AddPatientStatus)}: Start.");

      var patientDb = await Db.GetPatientAsync(patientId);
      if (patientDb == null) return null;

      var currentStatusDb = patientDb.Status;
      var prevStatusDb = await Db.GetStatusAsync(patientDb.PatientId, currentStatusDb.PreviousStatusId);

      var status = Status.CreateStatus(prevStatusDb, currentStatusDb);

      var newStateType = ProcessPatient(patientDb.PatientState.StateType, status);
      await Db.AddStateAsync(patientId, newStateType);

      var newPatientDb = await Db.GetPatientAsync(patientId);
      var patient = FromDtoToViewModel(newPatientDb);

      Logger.LogInformation($"{nameof(PatientService)}.{nameof(AddPatientStatus)}: End.");
      return patient;
    }

    public async Task<HistoryViewModel> GetPatientHistory(int patientId)
    {
      Logger.LogInformation($"{nameof(PatientService)}.{nameof(GetPatientHistory)}: Start.");

      var patientDb = await Db.GetPatientAsync(patientId);
      if (patientDb == null) return null;

      var patient = FromDtoToViewModel(patientDb);

      var statusesDb = await Db.GetStatusesAsync(patientId);

      var statesDb = await Db.GetStatesAsync(patientId);

      var statuses = new List<StatusViewModel>();
      foreach (var stateDb in statesDb)
      {
        var statusDb = statusesDb.Find(x => x.StatusId == stateDb.StatusId);
        var context = StateContext.FromState(stateDb.StateType);
        var description = context.Description;
        var medicines = TypeViewModel.FromCustomEnums(context.Medicines);

        var status = new StatusViewModel
        {
          CreatedDate = statusDb.CreatedDate,
          StatusId = statusDb.StatusId,
          Signs = statusDb.Signs.Select(x => new SignViewModel {SignType = x.SignType, Intensity = x.Intensity}),
          Description = description,
          Medicines = medicines,
          PatientState = stateDb.StateType
        };
        statuses.Add(status);
      }

      var history = new HistoryViewModel
      {
        Patient = patient,
        Statuses = new ListViewModel<StatusViewModel> {Count = statuses.Count, List = statuses}
      };

      Logger.LogInformation($"{nameof(PatientService)}.{nameof(GetPatientHistory)}: End.");
      return history;
    }

    private static FullPatientViewModel FromDtoToViewModel(PatientDto patientDto)
    {
      var patient = FullPatientViewModel.FromPatientDto(patientDto);
      var context = StateContext.FromState(patientDto.PatientState.StateType);
      patient.Status.Description = context.Description;
      patient.Status.Medicines = TypeViewModel.FromCustomEnums(context.Medicines);
      patient.Status.PatientState = patientDto.PatientState.StateType;
      return patient;
    }

    private StateType ProcessPatient(StateType currentStateType, Status currentStatus)
    {
      var currentState = StateSwitcher.Switch(currentStateType);
      return currentState.NextState(currentStatus);
      //var addedState = await Db.AddStateAsync(patient.PatientId, nextState);
      //patient.PatientState = new PatientState
      //{
      //  PatientStateId = addedState.StateId,
      //  CreatedDate = addedState.CreatedDate,
      //  StateType = addedState.StateType,
      //  StatusId = addedState.StatusId
      //};
    }
  }
}