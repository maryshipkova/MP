using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public class State10 : BaseState
  {
    public State10()
    {
      StateType = StateType.State10;
    }

    public override StateType NextState(Status status)
    {
      return StateType.End;
    }
  }
}