using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public class State5 : BaseState
  {
    public State5()
    {
      StateType = StateType.State5;
    }

    public override BaseState NextState(Status status)
    {
      return new EndState();
    }
  }
}
