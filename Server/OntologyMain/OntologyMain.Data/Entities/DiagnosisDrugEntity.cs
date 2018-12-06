using System.ComponentModel.DataAnnotations.Schema;

namespace OntologyMain.Data.Entities
{
  [Table("DiagnosisDrug")]
  public class DiagnosisDrugEntity
  {
    public int DiagnosisId { get; set; }
    public int DrugId { get; set; }

    public float Dosage { get; set; }
  }
}