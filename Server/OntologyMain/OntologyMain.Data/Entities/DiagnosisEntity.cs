using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OntologyMain.Data.Entities
{
  [Table("Diagnosis")]
  public class DiagnosisEntity
  {
    [Key]
    public int DiagnosisId { get; set; }

    public int PatientId { get; set; }
    public int SymptomId { get; set; }
    public float PatientIntensity { get; set; }
    public DateTime UpdatedDate { get; set; }
  }
}