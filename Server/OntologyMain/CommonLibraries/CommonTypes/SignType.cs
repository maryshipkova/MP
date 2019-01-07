using System.Collections.Generic;

namespace CommonLibraries.CommonTypes
{
  public class SignType : CustomEnum
  {
    public static SignType None = (SignType) new CustomEnum(0, "None");
    public static SignType Wheezing = (SignType) new CustomEnum(1, "Wheezing");
    public static SignType Hospitalize = (SignType) new CustomEnum(2, "Hospitalize");
    public static SignType Pef = (SignType) new CustomEnum(3, "Pef");
    public static SignType SpO2 = (SignType) new CustomEnum(4, "SpO2");

    public static explicit operator SignType(int id)
    {
      return GetList().Find(x => x.Id == id);
    }

    public static List<SignType> GetList()
    {
      return new List<SignType> {None, Wheezing, Hospitalize, Pef, SpO2};
    }
  }
}