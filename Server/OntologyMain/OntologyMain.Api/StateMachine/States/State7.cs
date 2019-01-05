namespace OntologyMain.Api.StateMachine.States
{
  public class State7 : BaseState
  {
    public State7(Patient patient) : base(patient)
    {
      Description = "Госпитализация.";

      Patient.MachineState = MachineState.State7;
    }

    public override BaseState NextState()
    {
      return new EndState(Patient);
    }
  }
}