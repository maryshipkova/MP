using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine.States
{
  /// <summary>
  /// Конечное состояние пациента (техническое состояние)
  /// </summary>
  public class EndState : BaseState
  {
    public EndState()
    {
      StateType = StateType.End;
    }

    public override BaseState NextState(Status status)
    {
      return new EndState();
    }
  }
}