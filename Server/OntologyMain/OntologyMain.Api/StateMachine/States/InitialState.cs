using System;
using System.Collections.Generic;
using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public class InitialState : BaseState
  {
    public InitialState()
    {
      StateType = StateType.Initial;
    }

    public override StateType NextState(Status status)
    {
      if (!status.IsAnyChanged()) return StateType;

      var pef = status.Signs.GetValueOrDefault(SignType.Pef);
      var wheezing = status.Signs.GetValueOrDefault(SignType.Wheezing);

      if (pef == null) return StateType;

      if (pef.Intensity > 0.8 && wheezing == null && status.ElapsedTime().TotalHours >= 5)
        return StateType.State2;

      if (pef.Intensity < 0.6 && wheezing != null) return StateType.State3;

      if (pef.Intensity < 0.6) return StateType.State4;
      throw new Exception($"{nameof(State4)}.{nameof(NextState)}: This is no other condition to transit.");
    }
  }
}