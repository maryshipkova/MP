using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public class EndState : BaseState
  {
    public EndState()
    {
      StateType = StateType.End;
    }

    public override BaseState NextState(Status status)
    {
      return new EndState();
    }
  }
}