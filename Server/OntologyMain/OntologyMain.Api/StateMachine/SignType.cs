using System.Collections.Generic;
using CommonLibraries;

namespace OntologyMain.Api.StateMachine
{
  public class SignType : Type
  {
    public static SignType None = (SignType) new Type(0, "None");
    public static SignType Wheezing = (SignType) new Type(1, "Wheezing");
    public static SignType Hospitalize = (SignType) new Type(2, "Hospitalize");
    public static SignType Pef = (SignType) new Type(3, "Pef");
    public static SignType SpO2 = (SignType) new Type(4, "SpO2");

    public static List<SignType> GetList()
    {
      return new List<SignType> {None, Wheezing, Hospitalize, Pef, SpO2};
    }
  }
}