using System;
using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.Services
{
  public class PatientState
  {
    public int PatientStateId { get; set; }
    public int StatusId { get; set; }
    public StateType StateType { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}