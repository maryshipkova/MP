namespace OntologyMain.Api.StateMachine
{
  public class MedicineType
  {
    public static Type MEDID001 = new Type(1, "MEDID001", "β2-агонисты ингаляции каждые 2-4 часа");
    public static Type MEDID002 = new Type(2, "MEDID002", "Глюкокортикостероиды перорально (преднизолон 30 мг)");
    public static Type MEDID003 = new Type(3, "MEDID003", "Ингаляции атровента 40 мкг с помощью дозированного аэрозоля или 0,5 мг через небулайзер или эуфиллин 2,4% — 10,0 внутривенно медленно");
    public static Type MEDID004 = new Type(4, "MEDID004", "β2-агонисты ингаляции каждый час");
    public static Type MEDID005 = new Type(5, "MEDID005", "Преднизолон внутрь 80 мг");
    public static Type MEDID006 = new Type(6, "MEDID006", "β2-агонисты короткого действия ингаляции с помощью небулайзера по 1 дозе (вентолин 2,5 мг или беротек 0,5 мг) каждые 20 мин в течение первого часа (если не проводились амбулаторно), далее ингаляционные β2-агонисты через небулайзер в прежних дозах каждые 60 мин.");
    public static Type MEDID007 = new Type(7, "MEDID007", "Оксигенотерапия");
    public static Type MEDID008 = new Type(8, "MEDID008", "Системные кортикостероиды, если нет ответа на лечение или больной недавно принимал стероиды");
    public static Type MEDID009 = new Type(9, "MEDID009", "Кортикостероиды внутривенно (преднизолон 90 мг, солюкортеф 100-200 мг)");
    public static Type MEDID010 = new Type(10, "MEDID010", "Эуфиллин внутривенно");
  }

  public class Type
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Type(int id, string description)
    {
      Id = id;
      Description = description;
    }

    public Type(int id, string name, string description)
    {
      Id = id;
      Name = name;
      Description = description;
    }
  }
}
