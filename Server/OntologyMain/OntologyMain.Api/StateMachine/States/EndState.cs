namespace OntologyMain.Api.StateMachine.States
{
  public class EndState : BaseState
  {
    public EndState(Patient patient) : base(patient)
    {
      Description = "Конечное состояние";
      Patient.MachineState = MachineState.End;
    }

    public override BaseState NextState()
    {
      return this;
    }
  }
}