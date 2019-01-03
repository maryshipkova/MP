using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OntologyMain.Api.StateMachine
{
  public abstract class BaseState
  {
    public List<MedicineType> Medicines = new List<MedicineType>();
    public string Description { get; set; } = string.Empty;
    public Patient Patient { get; set; }

    public BaseState(Patient patient)
    {
      Patient = patient;
    }


    public virtual BaseState NextState()
    {
      throw new NotImplementedException($"{nameof(BaseState)}.{nameof(NextState)}. Override this method to call it.");
    }

  }
}
