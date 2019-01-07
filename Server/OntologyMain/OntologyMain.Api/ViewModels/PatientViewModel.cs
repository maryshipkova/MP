using System;

namespace OntologyMain.Api.ViewModels
{
  public class CreatePatientViewModel
  {
    public int PatientId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public int SexType { get; set; }
  }

  public class ShortPatientViewModel
  {
    public int PatientId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public TypeViewModel SexType { get; set; }
  }

  public class PatientViewModel
  {
    public int PatientId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public TypeViewModel SexType { get; set; }
    public StatusViewModel Status { get; set; }
  }
}