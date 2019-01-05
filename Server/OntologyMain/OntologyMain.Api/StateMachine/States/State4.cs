namespace OntologyMain.Api.StateMachine.States
{
  public class State4 : BaseState
  {
    public State4(Patient patient) : base(patient)
    {
      Description = "Выписка пациента";
      Patient.MachineState = MachineState.State4;
    }

    public override BaseState NextState()
    {
      return new EndState(Patient);
    }
  }
}
