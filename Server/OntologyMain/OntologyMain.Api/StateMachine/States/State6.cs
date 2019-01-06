using System;
using System.Collections.Generic;

namespace OntologyMain.Api.StateMachine.States
{
  public class State6 : BaseState
  {
    public State6(Patient patient) : base(patient)
    {
      Description =
        "Ингаляционные β2-агонисты короткого действия с помощью небулайзера по 1 дозе (вентолин 2,5 мг или беротек 0,5 мг) каждые 20 мин в течение первого часа (если не проводились амбулаторно), далее ингаляционные β2-агонисты в прежних дозах каждые 60 мин через небулайзер. 2. Оксигенотерапия для достижения сатурации О2 > 90%. 3. Системные кортикостероиды, если нет ответа на лечение или больной недавно принимал стероиды.";
      Medicines.AddRange(new List<MedicineType> { MedicineType.MEDID006, MedicineType.MEDID007, MedicineType.MEDID008 });

      Patient.MachineState = MachineState.State6;
    }

    public override BaseState NextState()
    {
      var pef = Patient.Status.Signs.GetValueOrDefault(SignType.Pef).Intensity;
      var spO2 = Patient.Status.Signs.GetValueOrDefault(SignType.SpO2).Intensity;

      if (Patient.Status.ElapsedTime() < SignConstants.MaxTime && !Patient.Status.IsAnyChanged()) return this;
      if (pef > 0.5 && pef < 0.7 && spO2 < 0.9) return new State8(Patient);
      if (Patient.Status.ElapsedTime() >= SignConstants.MaxTime && !Patient.Status.IsAnyChanged())
        return new State9(Patient);

      throw new Exception($"{nameof(State3)}.{nameof(NextState)}: This is no other condition to transit.");
    }
  }
}