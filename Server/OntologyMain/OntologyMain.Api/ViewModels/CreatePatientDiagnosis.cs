using System;
using System.Collections.Generic;

namespace OntologyMain.Api.ViewModels
{
  public class CreatePatientDiagnosis
  {
    public int SymptomId { get; set; }
    public IEnumerable<CreatePatientDiagnosisDrug> Drugs { get; set; } = new List<CreatePatientDiagnosisDrug>();
    public float PatientIntensity { get; set; }
    public DateTime UpdatedDate { get; set; }

    public class CreatePatientDiagnosisDrug
    {
      public int DrugId { get; set; }
      public float Dosage { get; set; }
    }
  }
}