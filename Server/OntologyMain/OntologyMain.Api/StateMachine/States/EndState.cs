using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public class EndState : BaseState
  {
    public EndState()
    {
      StateType = StateType.End;
    }

    public override StateType NextState(Status status)
    {
      return StateType;
    }
  }
}