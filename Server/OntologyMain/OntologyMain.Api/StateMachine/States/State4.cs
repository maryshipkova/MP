using System;
using System.Collections.Generic;
using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public class State4 : BaseState
  {
    public State4()
    {
      StateType = StateType.State4;
    }

    public override StateType NextState(Status status)
    {
      var pef = status.Signs.GetValueOrDefault(SignType.Pef).Intensity;
      var isWheezing = status.Signs.GetValueOrDefault(SignType.Wheezing) != null;

      if (pef > 0.6 && pef < 0.8 && isWheezing)
        return StateType.State3;

      if (status.ElapsedTime() < SignConstants.MaxTime && !status.IsAnyChanged())
        return StateType;

      if (status.ElapsedTime() >= SignConstants.MaxTime)
        return StateType.State8;

      throw new Exception($"{nameof(State4)}.{nameof(NextState)}: This is no other condition to transit.");
    }
  }
}
