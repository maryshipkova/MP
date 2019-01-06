using OntologyMain.Api.StateMachine.States;

namespace OntologyMain.Api.Services
{
  public class PatientProcessor
  {
    private StateMachine.StateMachine StateMachine { get; set; } = new StateMachine.StateMachine();

    public BaseState ProcessPatient(Patient patient)
    {
      switch (patient)
      {
        case MachineStates.Base: return new BaseState();
        case MachineStates.State1:
          break;
        case MachineStates.State2:
          break;
        case MachineStates.State3:
          break;
        case MachineStates.State4:
          break;
        case MachineStates.State5:
          break;
        case MachineStates.State6:
          break;
        case MachineStates.State7:
          break;
        case MachineStates.State8:
          break;
        case MachineStates.State9:
          break;
        case MachineStates.State10:
          break;
      }
    }
  }

 

}
