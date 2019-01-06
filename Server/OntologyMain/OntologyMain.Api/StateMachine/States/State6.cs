using System;
using System.Collections.Generic;

namespace OntologyMain.Api.StateMachine.States
{
  public class State6 : BaseState
  {
    public State6()
    {
      StateType = StateType.State6;
    }

    public override StateType NextState(Status status)
    {
      var pef = status.Signs.GetValueOrDefault(SignType.Pef).Intensity;
      var isWheezing = status.Signs.GetValueOrDefault(SignType.Wheezing) != null;

      if (!isWheezing && pef > 0.8 && status.ElapsedTime().TotalDays >= 4) return StateType.State2;

      if (status.ElapsedTime() < SignConstants.MaxTime && !status.IsAnyChanged()) return StateType;

      throw new Exception($"{nameof(State4)}.{nameof(NextState)}: This is no other condition to transit.");
    }
  }
}