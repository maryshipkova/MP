using System;
using System.Collections.Generic;
using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.Services
{
  public class StateContext
  {
    public string Description { get; set; } = string.Empty;
    public IEnumerable<MedicineType> Medicines { get; set; } = new List<MedicineType>();

    public static StateContext FromState(StateType type)
    {
      if (type == StateType.Initial) return new StateContext {Description = $"Состояние: 'Initial State'.{Environment.NewLine}Начальное состояние" };
      if (type == StateType.State2)
        return new StateContext
        {
          Description = $"Состояние: 'State2'.{Environment.NewLine}Продолжить прием β2-агонистов каждые 3-4 часа",
          Medicines = new List<MedicineType> {MedicineType.MEDID001}
        };
      if (type == StateType.State3) return new StateContext {Description = $"Состояние: 'State3'.{Environment.NewLine}Предложить госпитализацию" };
      if (type == StateType.State4)
        return new StateContext
        {
          Description =
            $"Состояние: 'State4'.{Environment.NewLine}Продолжить ингаляции β2-агонистов в прежних дозах каждый час; преднизолон внутрь 80 мг; осмотр пульмонологом для коррекции базисной терапии",
          Medicines = new List<MedicineType> {MedicineType.MEDID001, MedicineType.MEDID002, MedicineType.MEDID003}
        };
      if (type == StateType.State5) return new StateContext {Description = $"Состояние: 'State5'.{Environment.NewLine}Выписка пациента" };
      if (type == StateType.State6)
        return new StateContext
        {
          Description =
            $"Состояние: 'State6'.{Environment.NewLine}Продолжить ингаляции β2-агонистов в прежних дозах каждый час; преднизолон внутрь 80 мг; осмотр пульмонологом для коррекции базисной терапии",
          Medicines = new List<MedicineType> {MedicineType.MEDID004, MedicineType.MEDID005}
        };
      if (type == StateType.State7)
        return new StateContext
        {
          Description =
            $"Состояние: 'State7'.{Environment.NewLine}Ингаляционные β2-агонисты короткого действия с помощью небулайзера по 1 дозе (вентолин 2,5 мг или беротек 0,5 мг) каждые 20 мин в течение первого часа (если не проводились амбулаторно), далее ингаляционные β2-агонисты в прежних дозах каждые 60 мин через небулайзер. 2. Оксигенотерапия для достижения сатурации О2 > 90%. 3. Системные кортикостероиды, если нет ответа на лечение или больной недавно принимал стероиды.",
          Medicines = new List<MedicineType> {MedicineType.MEDID006, MedicineType.MEDID007, MedicineType.MEDID008}
        };
      if (type == StateType.State8) return new StateContext {Description = $"Состояние: 'State8'.{Environment.NewLine}Госпитализация."};
      if (type == StateType.State9)
        return new StateContext
        {
          Description =
            $"Состояние: 'State9'.{Environment.NewLine}В/в кортикостероиды (преднизолон 90 мг, солюкортеф 100-200 мг), эуфиллин в/в кап (мониторинг эуфиллина).",
          Medicines = new List<MedicineType> {MedicineType.MEDID009, MedicineType.MEDID010}
        };
      if (type == StateType.State10) return new StateContext {Description = $"Состояние: 'State10'.{Environment.NewLine}Перевод в ОРИТ."};
      if (type == StateType.End) return new StateContext {Description = $"Состояние: 'End State'.{Environment.NewLine}Конечное состояние" };
      if (type == StateType.Base) return new StateContext();
      throw new ArgumentOutOfRangeException(nameof(type), type, null);
    }

    public override string ToString()
    {
      return $"Description: {Description}; " + $"Medicines: [{string.Join(", ", Medicines)}]";
    }
  }
}