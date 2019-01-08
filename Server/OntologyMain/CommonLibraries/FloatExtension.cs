using System;

namespace CommonLibraries
{
  public static class FloatExtension
  {
    public static bool EqualsStrict(this float left, float right, double tolerance = 0.000001)
    {
      return Math.Abs(left - right) < tolerance;
    }
  }
}