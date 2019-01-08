using System;
using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public class State6 : BaseState
  {
    public State6()
    {
      StateType = StateType.State6;
    }

    public override BaseState NextState(Status status)
    {
      var pef = status.Parameters.Pef;
      var isWheezing = status.Parameters.IsWheezing;

      if (!isWheezing && pef > 0.8 && status.ElapsedTime().TotalDays >= 4) return new State2();

      if (status.ElapsedTime() < ParametersConstants.MaxTime && !status.IsAnyChanged()) return new State6();

      return new State6();
    }
  }
}