using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OntologyMain.Data.Entities
{
  [Table("Symptom")]
  public class SymptomEntity
  {
    [Key]
    public int SymptomId { get; set; }

    public string Name { get; set; }
    public float NormalIntensity { get; set; }
  }
}