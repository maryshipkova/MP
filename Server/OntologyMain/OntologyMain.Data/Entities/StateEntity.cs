using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OntologyMain.Data.Entities
{
  [Table("State")]
  public class StateEntity
  {
    [Key]
    public int StateId { get; set; }
    public int PreviousStateId { get; set; }

    public int PatientId { get; set; }
    public int StatusId { get; set; }
    public int StateTypeId { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}