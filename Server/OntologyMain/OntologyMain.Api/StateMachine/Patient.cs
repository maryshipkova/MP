using System;
using System.Linq;
using OntologyMain.Api.StateMachine.States;

namespace OntologyMain.Api.StateMachine
{
  public class Patient
  {
    public Status Status { get; set; } = new FirsStatus();
    public BaseState State { get; set; }
    public MachineState MachineState { get; set; }
  }
}