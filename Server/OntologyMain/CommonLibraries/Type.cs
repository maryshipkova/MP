namespace CommonLibraries
{
  public class Type
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    protected Type()
    {
    }

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