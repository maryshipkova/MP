using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OntologyMain.Data.Entities
{
  [Table("Patient")]
  public class PatientEntity
  {
    [Key]
    public int PatientId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public int SexTypeId { get; set; }
    public int StatusId { get; set; }
    public int StateId { get; set; }
  }
}