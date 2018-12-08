using CommonLibraries.CommonTypes;
using CommonLibraries.Exceptions.ApiExceptions;
using OntologyMain.Data.Dtos;
using OntologyMain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OntologyMain.Data.Repositories
{
  public class PatientsRepository
  {
    private OntologyMainContext Db { get; }

    public PatientsRepository(OntologyMainContext db)
    {
      Db = db;
    }

    public bool IsPatientExist(int patientId)
    {
      return Db.PatientEntities.Any(x => x.PatientId == patientId);
    }

    public async Task<PatientEntity> CreatePatient(string firstName, string lastName, DateTime birthDate, SexType sexType )
    {
      PatientEntity newPatient = new PatientEntity
      {
        FirstName = firstName,
        LastName = lastName,
        BirthDate = birthDate,
        SexType = sexType
      };
      Db.PatientEntities.Add(newPatient);
      await Db.SaveChangesAsync();
      return newPatient;
    }

    public async Task<List<PatientEntity>> GetPatients()
    {
      return await Db.PatientEntities.ToListAsync();
    }


    public async Task<PatientEntity> GetPatient(int patientId)
    {
      return await Db.PatientEntities.FirstOrDefaultAsync(x => x.PatientId == patientId) ?? new PatientEntity();
    }

    public async Task<DiagnosisDto> AddPatientDiagnosis(int patientId, float patientDiagnosisIntensity, int symptomId, List<(int DrugId, float Dosage)> drugs)
    {
      var symptom = await Db.SymptomEntities.FirstAsync(x => x.SymptomId == symptomId);
      var drugEntities = await Db.DrugEntities.Where(x => drugs.Any(drug => drug.DrugId == x.DrugId)).ToListAsync();
      var drugsDtos = drugEntities.Select(x=>new DiagnosisDrugDto{ DrugId = x.DrugId,  Name = x.Name, Dosage = drugs.First(drug=> drug.DrugId == x.DrugId).Dosage }).ToList();

      var diagnosis = new DiagnosisEntity
      {
        PatientId = patientId,
        SymptomId = symptomId,
        PatientIntensity = patientDiagnosisIntensity,
        UpdatedDate = DateTime.UtcNow
      };

      Db.DiagnosisEntities.Add(diagnosis);

      await Db.SaveChangesAsync();

      var diagnosisDrugs = drugsDtos.Select(x => new DiagnosisDrugEntity { DiagnosisId = diagnosis.DiagnosisId, Dosage = x.Dosage, DrugId = x.DrugId}).ToList();
      Db.DiagnosisDrugEntities.AddRange(diagnosisDrugs);

      await Db.SaveChangesAsync();



      return new DiagnosisDto{ DiagnosisId = diagnosis.DiagnosisId, PatientIntensity = diagnosis.PatientIntensity, Symptom = symptom , UpdatedDate = diagnosis.UpdatedDate, Drugs = drugsDtos };

    }


    public async Task<List<DiagnosisDto>> GetPatientDiagnoses(int patientId)
    {
      var diagnosesAndSymptoms = from diagnosis in Db.DiagnosisEntities
                                 where diagnosis.PatientId == patientId
                                 join symptom in Db.SymptomEntities on diagnosis.SymptomId equals symptom.SymptomId
                                 select new { Diagnosis = diagnosis, Symptom = symptom };

      var result = from diagnosesAndSymptomRow in diagnosesAndSymptoms
        join diagnosisDrug in Db.DiagnosisDrugEntities on diagnosesAndSymptomRow.Diagnosis.DiagnosisId equals
        diagnosisDrug.DiagnosisId
        join drug in Db.DrugEntities on diagnosisDrug.DrugId equals drug.DrugId
        select new {DiagnosisSymptom = diagnosesAndSymptomRow, DiagnosisDrug = new {diagnosisDrug, drug}}
        into mainSelect
        group mainSelect by mainSelect.DiagnosisSymptom
        into g
        select new DiagnosisDto
        {
          DiagnosisId = g.Key.Diagnosis.DiagnosisId,
          Symptom = g.Key.Symptom,
          UpdatedDate = g.Key.Diagnosis.UpdatedDate,
          PatientIntensity = g.Key.Diagnosis.PatientIntensity,
          Drugs = from item in g
            select new DiagnosisDrugDto
            {
              DrugId = item.DiagnosisDrug.drug.DrugId,
              Name = item.DiagnosisDrug.drug.Name,
              Dosage = item.DiagnosisDrug.diagnosisDrug.Dosage
            }
        };


      return await result.ToListAsync();
    }
  }
}