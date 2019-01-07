using System;
using System.Collections.Generic;
using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public class State7 : BaseState
  {
    public State7()
    {
      StateType = StateType.State7;
    }

    public override StateType NextState(Status status)
    {
      var pef = status.Signs.GetValueOrDefault(SignType.Pef).Intensity;
      var spO2 = status.Signs.GetValueOrDefault(SignType.SpO2).Intensity;

      if (status.ElapsedTime() < SignConstants.MaxTime && !status.IsAnyChanged()) return StateType;

      if (pef > 0.5 && pef < 0.7 && spO2 < 0.9) return StateType.State9;

      if (status.ElapsedTime() >= SignConstants.MaxTime && !status.IsAnyChanged()) return StateType.State10;

      throw new Exception($"{nameof(State4)}.{nameof(NextState)}: This is no other condition to transit.");
    }
  }
}