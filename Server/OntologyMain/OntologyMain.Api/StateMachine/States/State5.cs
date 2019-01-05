using System;
using System.Collections.Generic;

namespace OntologyMain.Api.StateMachine.States
{
  public class State5 : BaseState
  {
    public State5(Patient patient) : base(patient)
    {
      Description = "Продолжить ингаляции β2-агонистов в прежних дозах каждый час; преднизолон внутрь 80 мг; осмотр пульмонологом для коррекции базисной терапии";
      Medicines.AddRange(new List<MedicineType> { MedicineType.MEDID004, MedicineType.MEDID005 });

      Patient.MachineState = MachineState.State5;
    }

    public override BaseState NextState()
    {
      var pef = Patient.Status.Signs.GetValueOrDefault(Indicator.Pef).Intensity;
      var isWheezing = Patient.Status.Signs.GetValueOrDefault(Indicator.Wheezing) != null;

      if (!isWheezing && pef > 0.8 && Patient.Status.ElapsedTime().TotalDays >= 4)
        return new State1(Patient);

      if (Patient.Status.ElapsedTime() < SignConstants.MaxTime && !Patient.Status.IsAnyChanged())
        return this;

      throw new Exception($"{nameof(State3)}.{nameof(NextState)}: This is no other condition to transit.");
    }
  }
}
