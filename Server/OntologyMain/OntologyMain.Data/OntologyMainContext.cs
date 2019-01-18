using Microsoft.EntityFrameworkCore;
using OntologyMain.Data.Entities;

namespace OntologyMain.Data
{
  public class OntologyMainContext : DbContext
  {
    public virtual DbSet<PatientEntity> PatientEntities { get; set; }
    public virtual DbSet<StatusEntity>  StatusEntities { get; set; }
    public virtual DbSet<StateEntity>  StateEntities { get; set; }

    public OntologyMainContext(DbContextOptions options) : base(options)
    {
    }
  }
}