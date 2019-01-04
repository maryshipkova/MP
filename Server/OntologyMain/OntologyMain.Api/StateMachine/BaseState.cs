using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OntologyMain.Api.Controllers;

namespace OntologyMain.Api.StateMachine
{
  public abstract class BaseState
  {
    public Guid Guid { get; } = Guid.NewGuid();
    public List<MedicineType> Medicines = new List<MedicineType>();
    public string Description { get; set; } = string.Empty;
    public Patient Patient { get; set; }
    public ILogger<BaseState> Logger { get; set; }
    public BaseState PreviousState { get; set; }
    public MachineState MachineState { get; set; }

    public BaseState(Patient patient)
    {
      Patient = patient;
    }

    public BaseState(BaseState state)
    {
      PreviousState = state;
    }


    public virtual BaseState NextState()
    {
      Logger.LogError($"{nameof(BaseState)}.{nameof(NextState)}. Override this method to call it.");
      return this;
    }

    public override string ToString()
    {
      return $"Guid: {Guid}; "+
        $"State: {MachineState}; "+
        $"Description: {Description}; "+
        $"Medicines: [{string.Join(", ", Medicines)}]";
    }

  }

  public enum MachineState
  {
    Initial = 0,
    State1 = 1,
    State2 = 2,
    State3 = 3,
    State4 = 4,
    State5 = 5,
    State6 = 6,
    State7 = 7,
    State8 = 8,
    State9 = 9,
    End = 100
  }
}
