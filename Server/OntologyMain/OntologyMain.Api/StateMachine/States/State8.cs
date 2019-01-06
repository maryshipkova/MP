using System.Collections.Generic;

namespace OntologyMain.Api.StateMachine.States
{
  public class State8 : BaseState
  {
    public State8(Patient patient) : base(patient)
    {
      Description = "В/в кортикостероиды (преднизолон 90 мг, солюкортеф 100-200 мг), эуфиллин в/в кап (мониторинг эуфиллина).";
      Medicines.AddRange(new List<MedicineType> {MedicineType.MEDID009, MedicineType.MEDID010});

      Patient.MachineState = MachineState.State8;
    }

    public override BaseState NextState()
    {
      return new EndState(Patient);
    }
  }
}