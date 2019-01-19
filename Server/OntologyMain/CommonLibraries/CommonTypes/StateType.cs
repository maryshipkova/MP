using System.Collections.Generic;

namespace CommonLibraries.CommonTypes
{
  public class StateType : CustomEnum
  {
    public static readonly StateType Base = new StateType(0, "Base");
    public static readonly StateType Initial = new StateType(1, "Initial");
    public static readonly StateType End = new StateType(2, "End");
    public static readonly StateType State2 = new StateType(3, "State2");
    public static readonly StateType State3 = new StateType(4, "State3");
    public static readonly StateType State4 = new StateType(5, "State4");
    public static readonly StateType State5 = new StateType(6, "State5");
    public static readonly StateType State6 = new StateType(7, "State6");
    public static readonly StateType State7 = new StateType(8, "State7");
    public static readonly StateType State8 = new StateType(9, "State8");
    public static readonly StateType State9 = new StateType(10, "State9");
    public static readonly StateType State10 = new StateType(11, "State10");

    public StateType(int id, string name) : base(id, name, string.Empty)
    {
    }

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