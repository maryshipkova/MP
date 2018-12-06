namespace OntologyMain.Data.Repositories
{
  public class OntologyRepository
  {
    private OntologyMainContext Db { get; }

    public OntologyRepository(OntologyMainContext db)
    {
      Db = db;
    }
  }
}