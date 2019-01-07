using System.Collections.Generic;

namespace CommonLibraries.CommonTypes
{
  public class GenderType : CustomEnum
  {
    public static GenderType None = new GenderType(0, "None");
    public static GenderType Male = new GenderType(1, "Male");
    public static GenderType Female = new GenderType(2, "Female");

    public GenderType(int id, string name) : base(id, name, string.Empty)
    {
    }

    public static explicit operator GenderType(int id)
    {
      return GetList().Find(x => x.Id == id);
    }

    public static List<GenderType> GetList()
    {
      return new List<GenderType> {None, Male, Female};
    }
  }
}