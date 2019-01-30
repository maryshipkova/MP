namespace OntologyMain.Api.StateMachine
{
  /// <summary>
  /// Параметры, описывающие состояния больного при бронхиальной астмы
  /// </summary>
  public class Parameters
  {
    public bool IsWheezing { get; set; }
    public bool IsHospitalized { get; set; }
    public float Pef { get; set; }
    public float SpO2 { get; set; }
  }
}