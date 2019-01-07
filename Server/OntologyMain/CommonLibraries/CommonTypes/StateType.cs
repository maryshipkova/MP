using System.Collections.Generic;

namespace CommonLibraries.CommonTypes
{
  public class StateType : CustomEnum
  {
    public static StateType Base = (StateType) new CustomEnum(0, "Base");
    public static StateType Initial = (StateType) new CustomEnum(1, "Initial");
    public static StateType End = (StateType) new CustomEnum(2, "End");
    public static StateType State2 = (StateType) new CustomEnum(3, "State2");
    public static StateType State3 = (StateType) new CustomEnum(4, "State3");
    public static StateType State4 = (StateType) new CustomEnum(5, "State4");
    public static StateType State5 = (StateType) new CustomEnum(6, "State5");
    public static StateType State6 = (StateType) new CustomEnum(7, "State6");
    public static StateType State7 = (StateType) new CustomEnum(8, "State7");
    public static StateType State8 = (StateType) new CustomEnum(9, "State8");
    public static StateType State9 = (StateType) new CustomEnum(10, "State9");
    public static StateType State10 = (StateType) new CustomEnum(11, "State10");

    public static explicit operator StateType(int id)
    {
      return GetList().Find(x => x.Id == id);
    }

    public static List<StateType> GetList()
    {
      return new List<StateType>
      {
        Base,
        Initial,
        End,
        State2,
        State3,
        State4,
        State5,
        State6,
        State7,
        State8,
        State9,
        State10
      };
    }
  }
}