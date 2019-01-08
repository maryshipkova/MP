using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibraries.CommonTypes;
using Microsoft.EntityFrameworkCore;
using OntologyMain.Data.Dtos;
using OntologyMain.Data.Entities;

namespace OntologyMain.Data.Repositories
{
  public class PatientsRepository
  {
    private OntologyMainContext Db { get; }

    public PatientsRepository(OntologyMainContext db)
    {
      Db = db;
    }

    public async Task<bool> IsPatientExistAsync(int patientId)
    {
      return await Db.PatientEntities.AnyAsync(x => x.PatientId == patientId);
    }

    public async Task<PatientDto> CreatePatientAsync(string firstName, string lastName, DateTime birthDate,
      GenderType sexType)
    {
      var newPatient = new PatientEntity
      {
        FirstName = firstName,
        LastName = lastName,
        BirthDate = birthDate,
        GenderTypeId = sexType.Id
      };
      Db.PatientEntities.Add(newPatient);
      await Db.SaveChangesAsync();

      var newStatus = new StatusEntity
      {
        CreatedDate = DateTime.UtcNow,
        PatientId = newPatient.PatientId,
        PreviousStatusId = 0
      };
      Db.StatusEntities.Add(newStatus);
      await Db.SaveChangesAsync();
      newStatus.PreviousStatusId = newStatus.StatusId;
      await Db.SaveChangesAsync();

      var newState = new StateEntity
      {
        CreatedDate = DateTime.UtcNow,
        PatientId = newPatient.PatientId,
        StatusId = newStatus.StatusId,
        PreviousStateId = 0,
        StateTypeId = StateType.Initial.Id
      };
      Db.StateEntities.Add(newState);
      await Db.SaveChangesAsync();
      newState.PreviousStateId = newState.StatusId;
      await Db.SaveChangesAsync();

      newPatient.StatusId = newStatus.StatusId;
      newPatient.StateId = newState.StateId;

      await Db.SaveChangesAsync();

      var result = PatientDto.FromEntity(newPatient);
      result.Status = StatusDto.FromEntity(newStatus);
      result.PatientState = StateDto.FromEntity(newState);

      return result;
    }

    public async Task<List<PatientEntity>> GetPatientsAsync()
    {
      return await Db.PatientEntities.ToListAsync();
    }

    public async Task<PatientDto> GetPatientAsync(int patientId)
    {
      var patient = await Db.PatientEntities.FirstOrDefaultAsync(x => x.PatientId == patientId);
      if (patient == null)
        return null;

      var state = await Db.StateEntities.FirstOrDefaultAsync(x => x.StateId == patient.StateId);
      var status = await Db.StatusEntities.FirstOrDefaultAsync(x => x.StatusId == patient.StatusId);
      var result = PatientDto.FromEntity(patient);
      result.Status = StatusDto.FromEntity(status);
      result.PatientState = StateDto.FromEntity(state);

      return result;
    }

    public async Task<StateDto> GetStateAsync(int patientId, int stateId)
    {
      var state = await Db.StateEntities.FirstOrDefaultAsync(x => x.PatientId == patientId && x.StateId == stateId);
      var result = StateDto.FromEntity(state);
      return result;
    }

    public async Task<StatusDto> GetStatusAsync(int patientId, int statusId)
    {
      var status = await Db.StatusEntities.FirstOrDefaultAsync(x => x.PatientId == patientId && x.StatusId == statusId);
      var result = StatusDto.FromEntity(status);
      return result;
    }

    public async Task<StatusDto> AddStatusAsync(int patientId, ParametersDto parameters)
    {
      var patient = await Db.PatientEntities.FirstOrDefaultAsync(x => x.PatientId == patientId);

      var newStatus = new StatusEntity
      {
        PatientId = patientId,
        PreviousStatusId = patient.StatusId,
         IsHospitalized = parameters.IsHospitalized,
          IsWheezing = parameters.IsWheezing,
           Pef = parameters.Pef,
            SpO2 = parameters.SpO2,
        CreatedDate = DateTime.UtcNow
      };

      Db.StatusEntities.Add(newStatus);
      Db.SaveChanges();

      patient.StatusId = newStatus.StatusId;
      await Db.SaveChangesAsync();

      var result = StatusDto.FromEntity(newStatus);
      return result;
    }

    public async Task<StateDto> AddStateAsync(int patientId, StateType nextState)
    {
      var patient = await Db.PatientEntities.FirstOrDefaultAsync(x => x.PatientId == patientId);

      var newState = new StateEntity
      {
        PatientId = patientId,
        PreviousStateId = patient.StateId,
        StateTypeId = nextState.Id,
        CreatedDate = DateTime.UtcNow,
        StatusId = patient.StatusId
      };

      Db.StateEntities.Add(newState);
      await Db.SaveChangesAsync();

      patient.StateId = newState.StateId;
      await Db.SaveChangesAsync();

      var result = StateDto.FromEntity(newState);
      return result;
    }

    public async Task<List<StateDto>> GetStatesAsync(int patientId)
    {
      return await Db.StateEntities.Where(x => x.PatientId == patientId).OrderBy(x=>x.CreatedDate).Select(state => StateDto.FromEntity(state))
        .ToListAsync();
    }

    public async Task<List<StatusDto>> GetStatusesAsync(int patientId)
    {
      var result = await Db.StatusEntities.Where(x => x.PatientId == patientId).OrderBy(x => x.CreatedDate).Select(status => StatusDto.FromEntity(status))
        .ToListAsync();
      return result;
    }

    //  Db.DiagnosisEntities.Add(diagnosis);

    //  };
    //    UpdatedDate = DateTime.UtcNow

    //public async Task<DiagnosisDto> AddPatientDiagnosis(int patientId, float patientDiagnosisIntensity, int symptomId, List<(int DrugId, float Dosage)> drugs)
    //{
    //  var symptom = await Db.SymptomEntities.FirstAsync(x => x.SymptomId == symptomId);
    //  var drugEntities = await Db.DrugEntities.Where(x => drugs.Any(drug => drug.DrugId == x.DrugId)).ToListAsync();
    //  var drugsDtos = drugEntities.Select(x=>new DiagnosisDrugDto{ DrugId = x.DrugId,  Name = x.Name, Dosage = drugs.First(drug=> drug.DrugId == x.DrugId).Dosage }).ToList();

    //  var diagnosis = new StateEntity
    //  {
    //    PatientId = patientId,
    //    SymptomId = symptomId,

    //  await Db.SaveChangesAsync();

    //    PatientIntensity = patientDiagnosisIntensity,

    //  var diagnosisDrugs = drugsDtos.Select(x => new DiagnosisDrugEntity { DiagnosisId = diagnosis.DiagnosisId, Dosage = x.Dosage, DrugId = x.DrugId}).ToList();
    //  Db.DiagnosisDrugEntities.AddRange(diagnosisDrugs);

    //  await Db.SaveChangesAsync();

    //  return new DiagnosisDto{ DiagnosisId = diagnosis.DiagnosisId, PatientIntensity = diagnosis.PatientIntensity, Symptom = symptom , UpdatedDate = diagnosis.UpdatedDate, Drugs = drugsDtos };

    //}

    //public async Task<List<DiagnosisDto>> GetPatientDiagnoses(int patientId)
    //{
    //  var diagnosesAndSymptoms = from diagnosis in Db.DiagnosisEntities
    //                             where diagnosis.PatientId == patientId
    //                             join symptom in Db.SymptomEntities on diagnosis.SymptomId equals symptom.SymptomId
    //                             select new { Diagnosis = diagnosis, Symptom = symptom };

    //  var result = from diagnosesAndSymptomRow in diagnosesAndSymptoms
    //    join diagnosisDrug in Db.DiagnosisDrugEntities on diagnosesAndSymptomRow.Diagnosis.DiagnosisId equals
    //    diagnosisDrug.DiagnosisId
    //    join drug in Db.DrugEntities on diagnosisDrug.DrugId equals drug.DrugId
    //    select new {DiagnosisSymptom = diagnosesAndSymptomRow, DiagnosisDrug = new {diagnosisDrug, drug}}
    //    into mainSelect
    //    group mainSelect by mainSelect.DiagnosisSymptom
    //    into g
    //    select new DiagnosisDto
    //    {
    //      DiagnosisId = g.Key.Diagnosis.DiagnosisId,
    //      Symptom = g.Key.Symptom,
    //      UpdatedDate = g.Key.Diagnosis.UpdatedDate,
    //      PatientIntensity = g.Key.Diagnosis.PatientIntensity,
    //      Drugs = from item in g
    //        select new DiagnosisDrugDto
    //        {
    //          DrugId = item.DiagnosisDrug.drug.DrugId,
    //          Name = item.DiagnosisDrug.drug.Name,
    //          Dosage = item.DiagnosisDrug.diagnosisDrug.Dosage
    //        }
    //    };

    //  return await result.ToListAsync();
    //}
  }
}