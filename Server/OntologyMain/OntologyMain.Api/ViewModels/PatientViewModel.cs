using System;
using System.Collections.Generic;
using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.ViewModels
{
  public class PatientViewModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public SexType SexType { get; set; }
    public List<DiagnosisViewModel> Diagnoses { get; set; }
  }
}