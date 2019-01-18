using System;
using CommonLibraries.CommonTypes;
using OntologyMain.Api.StateMachine;
using OntologyMain.Api.StateMachine.States;

namespace OntologyMain.Api.Services
{
  public class PatientProcessor
  {
    public static StateType ProcessPatient(StateType currentStateType, Status currentStatus)
    {
      var currentState = Switch(currentStateType);
      return currentState.NextState(currentStatus).StateType;
    }

    private static BaseState Switch(StateType stateType)
    {
      if (stateType == StateType.Initial) return new InitialState();
      if (stateType == StateType.End) return new EndState();
      if (stateType == StateType.State2) return new State2();
      if (stateType == StateType.State3) return new State3();
      if (stateType == StateType.State4) return new State4();
      if (stateType == StateType.State5) return new State5();
      if (stateType == StateType.State6) return new State6();
      if (stateType == StateType.State7) return new State7();
      if (stateType == StateType.State8) return new State8();
      if (stateType == StateType.State9) return new State9();
      if (stateType == StateType.State10) return new State10();
      throw new ArgumentOutOfRangeException($"{nameof(PatientProcessor)}.{nameof(Switch)}: There is no such state: {stateType.Id} {stateType.Name}");
    }
  }
}