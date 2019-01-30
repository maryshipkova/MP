using System;
using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  /// <summary>
  /// Базовый класс, несущий основной каркас состояния машины состояний
  /// </summary>
  public abstract class BaseState
  {
    public StateType StateType { get; set; } = StateType.Base;

    /// <summary>
    /// Метод, который необходимо переопределять в каждой реализации состояния
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
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