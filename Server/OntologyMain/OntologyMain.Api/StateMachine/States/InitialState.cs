using System;
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

      var pef = status.Parameters.Pef;
      var isWheezing = status.Parameters.IsWheezing;

      if (pef > 0.8 && !isWheezing && status.ElapsedTime().TotalHours >= 5)
        return StateType.State2;

      if (pef < 0.6 && isWheezing) return StateType.State3;

      if (pef < 0.6) return StateType.State4;

      return StateType;
    }
  }
}