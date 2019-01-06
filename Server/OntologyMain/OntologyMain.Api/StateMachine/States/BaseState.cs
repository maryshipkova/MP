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

  public enum StateType
  {
    Base = 0,
    Initial = 1,
    End = 2,
    State2 = 3,
    State3 = 4,
    State4 = 5,
    State5 = 6,
    State6 = 7,
    State7 = 8,
    State8 = 9,
    State9 = 10,
    State10 = 11
  }
}