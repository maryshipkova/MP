using System;
using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public class State7 : BaseState
  {
    public State7()
    {
      StateType = StateType.State7;
    }

    public override BaseState NextState(Status status)
    {
      var pef = status.Parameters.Pef;
      var spO2 = status.Parameters.SpO2;

      if (status.ElapsedTime() < ParametersConstants.MaxTime && !status.IsAnyChanged()) return new State7();

      if (pef > 0.5 && pef < 0.7 && spO2 < 0.9) return new State9();

      if (status.ElapsedTime() >= ParametersConstants.MaxTime && !status.IsAnyChanged()) return new State10();

      //throw new Exception($"{nameof(State4)}.{nameof(NextState)}: This is no other condition to transit.");
      return new State7();
    }
  }
}