using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public class State3 : BaseState
  {
    public State3()
    {
      StateType = StateType.State3;
    }

    public override BaseState NextState(Status status)
    {
      return status.Parameters.IsHospitalized ? (BaseState)new State6() : new State7();
    }
  }
}