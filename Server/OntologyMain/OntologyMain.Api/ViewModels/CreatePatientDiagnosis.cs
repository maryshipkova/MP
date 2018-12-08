using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OntologyMain.Api.ViewModels
{
  public class CreatePatientDiagnosis
  {
    [Required]
    public int SymptomId { get; set; }

    public IEnumerable<CreatePatientDiagnosisDrug> Drugs { get; set; } = new List<CreatePatientDiagnosisDrug>();

    public float PatientIntensity { get; set; } = 0;

    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

    public class CreatePatientDiagnosisDrug
    {
      [Required]
      public int DrugId { get; set; }

      public float Dosage { get; set; } = 0;
    }
  }
}