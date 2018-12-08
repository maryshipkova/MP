using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OntologyMain.Data.Entities;

namespace OntologyMain.Data.Repositories
{
  public class OntologyRepository
  {
    private OntologyMainContext Db { get; }

    public OntologyRepository(OntologyMainContext db)
    {
      Db = db;
    }

    public async Task<List<SymptomEntity>> GetSymptoms()
    {
      return await Db.SymptomEntities.ToListAsync();
    }

    public async Task<SymptomEntity> CreateSymptom(string name, float normalIntensity)
    {
      var symptom = Db.SymptomEntities.FirstOrDefault(x => x.Name == name);
      if (symptom != null)
        return symptom;

      var newSymptom = new SymptomEntity {Name = name, NormalIntensity = normalIntensity};
      Db.SymptomEntities.Add(newSymptom);
      await Db.SaveChangesAsync();
      return newSymptom;
    }

    public async Task<List<DrugEntity>> GetDrugs()
    {
      return await Db.DrugEntities.ToListAsync();
    }

    public async Task<DrugEntity> CreateDrug(string name)
    {
      var drug = Db.DrugEntities.FirstOrDefault(x => x.Name == name);
      if (drug != null)
        return drug;

      var newDrug = new DrugEntity {Name = name};
      Db.DrugEntities.Add(newDrug);
      await Db.SaveChangesAsync();
      return newDrug;
    }
  }
}