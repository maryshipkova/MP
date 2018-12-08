using System;
using System.Collections.Generic;
using OntologyMain.Data.Entities;

namespace OntologyMain.Data.Dtos
{
  public class DiagnosisDto
  {
    public int DiagnosisId { get; set; }

    public SymptomEntity Symptom { get; set; }
    public IEnumerable<DiagnosisDrugDto> Drugs { get; set; }
    public float PatientIntensity { get; set; }
    public DateTime UpdatedDate { get; set; }
  }
}