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

    public override BaseState NextState(Status status)
    {
      if (!status.IsAnyChanged()) return new InitialState();

      var pef = status.Parameters.Pef;
      var isWheezing = status.Parameters.IsWheezing;

      if (pef > 0.8 && !isWheezing && status.ElapsedTime().TotalHours >= 5)
        return new State2();

      if (pef < 0.6 && isWheezing) return new State3();

      if (pef < 0.6) return new State4();

      return new InitialState();
    }
  }
}