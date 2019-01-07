using System;
using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine
{
  public class Sign
  {
    public int SignId { get; }
    public SignType SignType { get; }
    public float Intensity { get; }

    public Sign(int signId, SignType signType, float intensity)
    {
      SignId = signId;
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