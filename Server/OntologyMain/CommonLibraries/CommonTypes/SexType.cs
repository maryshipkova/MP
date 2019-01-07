using System.Collections.Generic;

namespace CommonLibraries.CommonTypes
{
  public class SexType : CustomEnum
  {
    public static SexType None = (SexType) new CustomEnum(0, "None");
    public static SexType Male = (SexType) new CustomEnum(1, "Male");
    public static SexType Female = (SexType) new CustomEnum(2, "Female");

    public static explicit operator SexType(int id)
    {
      return GetList().Find(x => x.Id == id);
    }

    public static List<SexType> GetList()
    {
      return new List<SexType> {None, Male, Female};
    }
  }
}