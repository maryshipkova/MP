using Microsoft.EntityFrameworkCore;
using OntologyMain.Data.Entities;

namespace OntologyMain.Data
{
  public class OntologyMainContext : DbContext
  {
    public virtual DbSet<PatientEntity> PatientEntities { get; set; }
    public virtual DbSet<SymptomEntity> SymptomEntities { get; set; }
    public virtual DbSet<DrugEntity> DrugEntities { get; set; }
    public virtual DbSet<DiagnosisDrugEntity> DiagnosisDrugEntities { get; set; }
    public virtual DbSet<DiagnosisEntity> DiagnosisEntities { get; set; }

    public OntologyMainContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<DiagnosisDrugEntity>().HasKey(x => new {x.DiagnosisId, x.DrugId});
    }
  }
}