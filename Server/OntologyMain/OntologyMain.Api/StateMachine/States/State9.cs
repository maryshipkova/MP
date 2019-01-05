namespace OntologyMain.Api.StateMachine.States
{
  public class State9 : BaseState
  {
    public State9(Patient patient) : base(patient)
    {
      Description = "Перевод в ОРИТ.";

      Patient.MachineState = MachineState.State9;
    }

    public override BaseState NextState()
    {
      return new EndState(Patient);
    }
  }
}