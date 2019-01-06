namespace OntologyMain.Api.StateMachine.States
{
  public class State8 : BaseState
  {
    public State8()
    {
      StateType = StateType.State8;
    }

    public override StateType NextState(Status status)
    {
      return StateType.End;
    }
  }
}