namespace OntologyMain.Api.StateMachine.States
{
  public class State9 : BaseState
  {
    public State9()
    {
      StateType = StateType.State9;
    }

    public override StateType NextState(Status status)
    {
      return StateType.End;
    }
  }
}