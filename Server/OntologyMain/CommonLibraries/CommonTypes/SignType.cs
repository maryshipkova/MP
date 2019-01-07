using System.Collections.Generic;

namespace CommonLibraries.CommonTypes
{
  public class SignType : CustomEnum
  {
    public static SignType None = new SignType(0, "None");
    public static SignType Wheezing = new SignType(1, "Wheezing");
    public static SignType Hospitalize = new SignType(2, "Hospitalize");
    public static SignType Pef = new SignType(3, "Pef");
    public static SignType SpO2 = new SignType(4, "SpO2");

    public SignType(int id, string name) : base(id, name, string.Empty)
    {
    }

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