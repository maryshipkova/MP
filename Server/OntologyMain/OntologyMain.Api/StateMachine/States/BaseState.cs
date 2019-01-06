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
    State2 = 2,
    State3 = 3,
    State4 = 4,
    State5 = 5,
    State6 = 6,
    State7 = 7,
    State8 = 8,
    State9 = 9,
    State10 = 10,
    End = 100
  }
}