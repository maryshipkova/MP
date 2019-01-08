using System;
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
      var pef = status.Parameters.Pef;
      var isWheezing = status.Parameters.IsWheezing;

      if (pef > 0.6 && pef < 0.8 && isWheezing) return StateType.State3;

      if (status.ElapsedTime() < ParametersConstants.MaxTime && !status.IsAnyChanged()) return StateType;

      if (status.ElapsedTime() >= ParametersConstants.MaxTime) return StateType.State8;

      return StateType;
    }
  }
}