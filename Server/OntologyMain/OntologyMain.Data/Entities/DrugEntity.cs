using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OntologyMain.Data.Entities
{
  [Table("Drug")]
  public class DrugEntity
  {
    [Key]
    public int DrugEntityId { get; set; }

    public string Name { get; set; }
  }
}