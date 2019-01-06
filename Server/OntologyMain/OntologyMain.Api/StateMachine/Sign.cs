using System;

namespace OntologyMain.Api.StateMachine
{
  public class Sign
  {
    public SignType SignType { get; }
    public float Intensity { get; }

    public Sign(SignType signType, float intensity)
    {
      SignType = signType;
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
}