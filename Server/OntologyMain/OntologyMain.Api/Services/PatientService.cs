using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibraries.CommonTypes;
using Microsoft.Extensions.Logging;
using OntologyMain.Api.Controllers;
using OntologyMain.Api.ViewModels;
using OntologyMain.Data.Repositories;

namespace OntologyMain.Api.Services
{
  public class PatientService
  {
    private PatientsRepository Db { get; }

    private StateMachine.StateMachine StateMachine { get; } = new StateMachine.StateMachine();

    public PatientService(ILogger<PatientsController> logger,  PatientsRepository db)
    {
      Db = db;
    }

    public PatientViewModel CreatePatient()
    {
      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(CreatePatient)}: Start.");

      var result = await Db.CreatePatientAsync(patientViewmodel.FirstName, patientViewmodel.LastName,
        patientViewmodel.BirthDate, (SexType)patientViewmodel.SexType);

      Logger.LogInformation($"{nameof(PatientsController)}.{nameof(CreatePatient)}: End.");
    }

    public async Task ProcessPatient(Patient patient)
    {
      var currentState = StateMachine.Switch(patient.PatientState.StateType);
      var nextState = currentState.NextState(patient.Status);
      var addedState = await Db.AddStateAsync(patient.PatientId, nextState);
      patient.PatientState = new PatientState
      {
        PatientStateId = addedState.StateId,
        CreatedDate = addedState.CreatedDate,
        StateType = addedState.StateType,
        StatusId = addedState.StatusId
      };
    }
  }
}
