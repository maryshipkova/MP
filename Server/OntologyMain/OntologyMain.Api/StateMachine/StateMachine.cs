using System;
using CommonLibraries.CommonTypes;
using OntologyMain.Api.StateMachine.States;

namespace OntologyMain.Api.StateMachine
{
  public class StateMachine
  {
    public InitialState InitialState { get; set; } = new InitialState();
    public EndState EndState { get; set; } = new EndState();
    public State2 State2 { get; set; } = new State2();
    public State3 State3 { get; set; } = new State3();
    public State4 State4 { get; set; } = new State4();
    public State5 State5 { get; set; } = new State5();
    public State6 State6 { get; set; } = new State6();
    public State7 State7 { get; set; } = new State7();
    public State8 State8 { get; set; } = new State8();
    public State9 State9 { get; set; } = new State9();
    public State10 State10 { get; set; } = new State10();

    public BaseState Switch(StateType stateType)
    {
      if (stateType == StateType.Initial) return InitialState;
      if (stateType == StateType.End) return InitialState;
      if (stateType == StateType.State2) return State2;
      if (stateType == StateType.State3) return State3;
      if (stateType == StateType.State4) return State4;
      if (stateType == StateType.State5) return State5;
      if (stateType == StateType.State6) return State6;
      if (stateType == StateType.State7) return State7;
      if (stateType == StateType.State8) return State8;
      if (stateType == StateType.State9) return State9;
      if (stateType == StateType.State10) return State10;
      throw new ArgumentOutOfRangeException($"There is no such state: {stateType.Id} {stateType.Name}");
    }
  }
}