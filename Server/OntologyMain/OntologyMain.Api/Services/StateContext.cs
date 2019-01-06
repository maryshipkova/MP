using System;
using System.Collections.Generic;
using OntologyMain.Api.StateMachine;
using OntologyMain.Api.StateMachine.States;

namespace OntologyMain.Api.Services
{
  public class StateContext
  {
    public string Description { get; set; } = string.Empty;
    public List<MedicineType> Medicines { get; set; } = new List<MedicineType>();

    public static StateContext ProcessState(StateType type)
    {
      switch (type)
      {
        case StateType.Initial: return new StateContext {Description = "Начальное состояние"};
        case StateType.State2:
          return new StateContext
          {
            Description = "Продолжить прием β2-агонистов каждые 3-4 часа",
            Medicines = new List<MedicineType> {MedicineType.MEDID001}
          };

        case StateType.State3: return new StateContext {Description = "Предложить госпитализацию"};
        case StateType.State4:
          return new StateContext
          {
            Description =
              "Продолжить ингаляции β2-агонистов в прежних дозах каждый час; преднизолон внутрь 80 мг; осмотр пульмонологом для коррекции базисной терапии",
            Medicines = new List<MedicineType> {MedicineType.MEDID001, MedicineType.MEDID002, MedicineType.MEDID003}
          };

        case StateType.State5: return new StateContext {Description = "Выписка пациента"};

        case StateType.State6:
          return new StateContext
          {
            Description =
              "Продолжить ингаляции β2-агонистов в прежних дозах каждый час; преднизолон внутрь 80 мг; осмотр пульмонологом для коррекции базисной терапии",
            Medicines = new List<MedicineType> {MedicineType.MEDID004, MedicineType.MEDID005}
          };
        case StateType.State7:
          return new StateContext
          {
            Description =
              "Ингаляционные β2-агонисты короткого действия с помощью небулайзера по 1 дозе (вентолин 2,5 мг или беротек 0,5 мг) каждые 20 мин в течение первого часа (если не проводились амбулаторно), далее ингаляционные β2-агонисты в прежних дозах каждые 60 мин через небулайзер. 2. Оксигенотерапия для достижения сатурации О2 > 90%. 3. Системные кортикостероиды, если нет ответа на лечение или больной недавно принимал стероиды.",
            Medicines = new List<MedicineType> {MedicineType.MEDID006, MedicineType.MEDID007, MedicineType.MEDID008}
          };
        case StateType.State8: return new StateContext {Description = "Госпитализация."};
        case StateType.State9:
          return new StateContext
          {
            Description =
              "В/в кортикостероиды (преднизолон 90 мг, солюкортеф 100-200 мг), эуфиллин в/в кап (мониторинг эуфиллина).",
            Medicines = new List<MedicineType> {MedicineType.MEDID009, MedicineType.MEDID010}
          };
        case StateType.State10: return new StateContext {Description = "Перевод в ОРИТ."};
        case StateType.End: return new StateContext {Description = "Конечное состояние"};
        case StateType.Base: return new StateContext();
        default: throw new ArgumentOutOfRangeException(nameof(type), type, null);
      }
    }

    public override string ToString()
    {
      return $"Description: {Description}; " + $"Medicines: [{string.Join(", ", Medicines)}]";
    }
  }
}