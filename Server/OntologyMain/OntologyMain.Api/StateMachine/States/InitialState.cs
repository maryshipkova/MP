using System;
using System.Collections.Generic;

namespace OntologyMain.Api.StateMachine.States
{
  public class InitialState : BaseState
  {
    public InitialState(Patient patient) : base(patient)
    {
      Description = "Начальное состояние";
    }

    public override BaseState NextState()
    {
      if (!Patient.Status.IsAnyChanged()) return this;

      var pef = Patient.Status.Signs.GetValueOrDefault(SignType.Pef);
      var wheezing = Patient.Status.Signs.GetValueOrDefault(SignType.Wheezing);

      if (pef == null) return this;

      if (pef.Intensity > 0.8 && wheezing == null && Patient.Status.StartTime.Subtract(DateTime.UtcNow).TotalHours >= 5)
        return new State1(Patient);

      if (pef.Intensity < 0.6 && wheezing != null) return new State2(Patient);

      if (pef.Intensity < 0.6) return new State3(Patient);
      throw new Exception($"{nameof(State3)}.{nameof(NextState)}: This is no other condition to transit.");
    }
  }
}