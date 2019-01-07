using OntologyMain.Api.StateMachine;

namespace OntologyMain.Api.Services
{
  public class Patient
  {
    public int PatientId { get; set; }
    public Status Status { get; set; }
    public PatientState PatientState { get; set; }
  }
}