using System;
using System.Collections.Generic;
using CommonLibraries.CommonTypes;
using OntologyMain.Api.StateMachine;
using OntologyMain.Api.StateMachine.States;

namespace OntologyMain.Api.Services
{
  public class PatientProcessor
  {
    private static readonly Dictionary<StateType, Func<BaseState>> stateSwitch = new Dictionary<StateType, Func<BaseState>>()
    {
      { StateType.Initial, () => new InitialState() },
      { StateType.End, () => new EndState() },
      { StateType.State2, () => new State2() },
      { StateType.State3, () => new State3() },
      { StateType.State4, () => new State4() },
      { StateType.State5, () => new State5() },
      { StateType.State6, () => new State6() },
      { StateType.State7, () => new State7() },
      { StateType.State8, () => new State8() },
      { StateType.State9, () => new State9() },
      { StateType.State10, () => new State10() }
    };

    public static StateType ProcessPatient(StateType currentStateType, Status currentStatus)
    {
      var currentState = stateSwitch[currentStateType]();
      return currentState.NextState(currentStatus).StateType;
    }
  }
}