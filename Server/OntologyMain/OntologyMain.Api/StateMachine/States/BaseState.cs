using System;
using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  public abstract class BaseState
  {
    public StateType StateType { get; set; } = StateType.Base;

    public virtual BaseState NextState(Status status)
    {
      throw new Exception($"{nameof(BaseState)}.{nameof(NextState)}: There is no way from BaseState.");
    }
   
    public override string ToString()
    {
      return $"State: {StateType};";
    }
  }
}