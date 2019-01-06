using System;
using System.Collections.Generic;

namespace OntologyMain.Api.StateMachine.States
{
  public class State3 : BaseState
  {
    public State3(Patient patient) : base(patient)
    {
      Description = "Начальное состояние";
      Medicines.AddRange(new List<MedicineType> { MedicineType.MEDID001, MedicineType.MEDID002, MedicineType.MEDID003 });

      Patient.MachineState = MachineState.State3;
    }

    public override BaseState NextState()
    {
      var pef = Patient.Status.Signs.GetValueOrDefault(SignType.Pef).Intensity;
      var isWheezing = Patient.Status.Signs.GetValueOrDefault(SignType.Wheezing) != null;

      if (pef > 0.6 && pef < 0.8 && isWheezing)
        return new State2(Patient);

      if (Patient.Status.ElapsedTime() < SignConstants.MaxTime && !Patient.Status.IsAnyChanged())
        return this;

      if (Patient.Status.ElapsedTime() >= SignConstants.MaxTime)
        return new State7(Patient);

      throw new Exception($"{nameof(State3)}.{nameof(NextState)}: This is no other condition to transit.");
    }
  }
}
