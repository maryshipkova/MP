using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public class State2 : BaseState
  {
    public State2()
    {
      StateType = StateType.State2;
    }

    public override BaseState NextState(Status status)
    {
      return status.IsAnyChanged() ?   (BaseState) new State2() : new State5();
    }
  }
}