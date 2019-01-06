namespace OntologyMain.Api.StateMachine.States
{
  public class State1 : BaseState
  {
    public State1(Patient patient) : base(patient)
    {
      Description = "Продолжить прием β2-агонистов каждые 3-4 часа";
      Medicines = new System.Collections.Generic.List<MedicineType> { MedicineType.MEDID001 };

      Patient.MachineState = MachineState.State1;
    }

    public override BaseState NextState()
    {
      if (Patient.Status.IsAnyChanged()) return this;

      return new State4(Patient);
    }
  }
}