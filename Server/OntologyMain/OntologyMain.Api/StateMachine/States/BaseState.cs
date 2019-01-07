using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public abstract class BaseState
  {
    public StateType StateType { get; set; } = StateType.Base;

    public virtual StateType NextState(Status status)
    {
      return StateType;
    }

    public override string ToString()
    {
      return $"State: {StateType};";
    }
  }
}