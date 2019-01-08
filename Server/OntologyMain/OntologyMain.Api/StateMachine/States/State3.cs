using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public class State3 : BaseState
  {
    public State3()
    {
      StateType = StateType.State3;
    }

    public override StateType NextState(Status status)
    {
      return status.Parameters.IsHospitalized ? StateType.State6 : StateType.State7;
    }
  }
}