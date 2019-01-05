namespace OntologyMain.Api.StateMachine.States
{
  public class State2 : BaseState
  {
    public State2(Patient patient) : base(patient)
    {
      Description = "Предложить госпитализацию";

      Patient.MachineState = MachineState.State2;
    }

    public override BaseState NextState()
    {
      if (Patient.Status.Signs.ContainsKey(Indicator.Hospitalize))
        return new State5(Patient);

      return new State6(Patient);
    }
  }
}