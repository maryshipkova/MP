using System;

namespace OntologyMain.Api.StateMachine
{
  public class Sign
  {
    public DateTime StartTime { get; } = DateTime.UtcNow;
    public Indicator Indicator { get; }
    public float Intensity { get; }

    public Sign(Indicator indicator, float intensity)
    {
      Indicator = indicator;
      Intensity = intensity;
    }

    public static bool IsTheSameIntensity(Sign left, Sign right, double tolerance = 0.000001)
    {
      return left.IsTheSameIntensity(right);
    }

    public bool IsTheSameIntensity(Sign otherSign, double tolerance = 0.000001)
    {
      return Math.Abs(Intensity - otherSign.Intensity) > tolerance;
    }
  }

  public enum Indicator
  {
    None = 0,
    Wheezing = 1,
    Hospitalize = 2,
    Pef = 3
  }
}