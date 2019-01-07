using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public class State5 : BaseState
  {
    public State5()
    {
      StateType = StateType.State5;
    }

    public override StateType NextState(Status status)
    {
      return StateType.End;
    }
  }
}
