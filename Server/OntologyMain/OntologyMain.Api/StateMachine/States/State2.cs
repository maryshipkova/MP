namespace OntologyMain.Api.StateMachine.States
{
  public class State2 : BaseState
  {
    public State2()
    {
      StateType = StateType.State2;
    }

    public override StateType NextState(Status status)
    {
      return status.IsAnyChanged() ? StateType : StateType.State5;
    }
  }
}