using System.Collections.Generic;
using CommonLibraries;

namespace OntologyMain.Api.StateMachine
{
  public class MedicineType : Type
  {
    public static MedicineType MEDID001 = (MedicineType)new Type(1, "MEDID001", "β2-агонисты ингаляции каждые 2-4 часа");
    public static MedicineType MEDID002 = (MedicineType)new Type(2, "MEDID002", "Глюкокортикостероиды перорально (преднизолон 30 мг)");
    public static MedicineType MEDID003 = (MedicineType)new Type(3, "MEDID003", "Ингаляции атровента 40 мкг с помощью дозированного аэрозоля или 0,5 мг через небулайзер или эуфиллин 2,4% — 10,0 внутривенно медленно");
    public static MedicineType MEDID004 = (MedicineType)new Type(4, "MEDID004", "β2-агонисты ингаляции каждый час");
    public static MedicineType MEDID005 = (MedicineType)new Type(5, "MEDID005", "Преднизолон внутрь 80 мг");
    public static MedicineType MEDID006 = (MedicineType)new Type(6, "MEDID006", "β2-агонисты короткого действия ингаляции с помощью небулайзера по 1 дозе (вентолин 2,5 мг или беротек 0,5 мг) каждые 20 мин в течение первого часа (если не проводились амбулаторно), далее ингаляционные β2-агонисты через небулайзер в прежних дозах каждые 60 мин.");
    public static MedicineType MEDID007 = (MedicineType)new Type(7, "MEDID007", "Оксигенотерапия");
    public static MedicineType MEDID008 = (MedicineType)new Type(8, "MEDID008", "Системные кортикостероиды, если нет ответа на лечение или больной недавно принимал стероиды");
    public static MedicineType MEDID009 = (MedicineType)new Type(9, "MEDID009", "Кортикостероиды внутривенно (преднизолон 90 мг, солюкортеф 100-200 мг)");
    public static MedicineType MEDID010 = (MedicineType)new Type(10, "MEDID010", "Эуфиллин внутривенно");

    public static List<MedicineType> GetList()
    {
      return new List<MedicineType>
      {
        MEDID001,
        MEDID002,
        MEDID003,
        MEDID004,
        MEDID005,
        MEDID006,
        MEDID007,
        MEDID008,
        MEDID009,
        MEDID010
      };
    }
  }

  
}
