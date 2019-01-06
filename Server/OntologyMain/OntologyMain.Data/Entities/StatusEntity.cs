using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OntologyMain.Data.Entities
{
  [Table("Status")]
  public class StatusEntity
  {
    [Key]
    public int StatusId { get; set; }
    public int PatientId { get; set; }

    public int PreviousStatusId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
  }
}