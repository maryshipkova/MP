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
    public bool IsWheezing { get; set; }
    public bool IsHospitalized { get; set; }
    public float Pef { get; set; }
    public float SpO2 { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}