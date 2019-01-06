using OntologyMain.Api.StateMachine;

namespace OntologyMain.Api.Services
{
  public class Patient
  {
    public Status Status { get; set; } = new VoidStatus();
  }
}