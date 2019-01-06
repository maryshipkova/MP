using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OntologyMain.Data.Entities
{
  [Table("Sign")]
  public class SignEntity
  {
    [Key]
    public int SignId { get; set; }

    public int StatusId { get; set; }
    public int SignTypeId { get; set; }
    public float Intensity { get; set; }
  }
}