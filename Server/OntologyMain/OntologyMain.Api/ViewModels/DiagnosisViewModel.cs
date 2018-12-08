using System;
using System.Collections.Generic;

namespace OntologyMain.Api.ViewModels
{
  public class DiagnosisViewModel
  {
    public SymptomViewModel Symptom { get; set; }
    public List<DrugViewModel> Drugs { get; set; }
    public float PatientIntensity { get; set; }
    public DateTime UpdatedDate { get; set; }
  }
}