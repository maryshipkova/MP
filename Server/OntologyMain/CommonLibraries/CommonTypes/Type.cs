namespace CommonLibraries.CommonTypes
{
  public class CustomEnum
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    protected CustomEnum()
    {
    }

    public CustomEnum(int id, string description)
    {
      Id = id;
      Description = description;
    }

    public CustomEnum(int id, string name, string description)
    {
      Id = id;
      Name = name;
      Description = description;
    }
  }
}