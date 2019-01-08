using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public class State8 : BaseState
  {
    public State8()
    {
      StateType = StateType.State8;
    }

    public override BaseState NextState(Status status)
    {
      return new EndState();
    }
  }
}