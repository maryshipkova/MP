using System;
using System.Linq;

namespace OntologyMain.Api.StateMachine
{
  public class Patient
  {
    public Status Status { get; set; }
    public BaseState State { get; set; }
    public MachineState MachineState { get; set; }

    public bool HasSign(Indicator indicator)
    {
      if (Status == null) throw new Exception("Patient does not have any status.");
      return Status.Signs.ContainsKey(indicator);
    }

    public bool IsAnyChanged()
    {
      if (Status == null) throw new Exception("Patient does not have any status.");
      if (!Status.Signs.Any() || Status.PreviousStatus == null || !Status.PreviousStatus.Signs.Any()) return false;
      var currentSigns = Status.Signs;
      var previousSigns = Status.PreviousStatus.Signs;
      foreach (var currentSign in currentSigns)
      {
        if (!previousSigns.TryGetValue(currentSign.Key, out var previousSign)) return false;
        if (!currentSign.Value.IsTheSameIntensity(previousSign)) return false;
      }
      return true;
    }

    public bool IsSignChanged(Sign sign)
    {
      if (Status == null) throw new Exception("Patient does not have any status.");
      if (!Status.Signs.TryGetValue(sign.Indicator, out var currentSign)) return false;
      if (Status.PreviousStatus == null ||
          !Status.PreviousStatus.Signs.TryGetValue(sign.Indicator, out var previousSign)) return false;

      return currentSign.IsTheSameIntensity(previousSign);
    }
  }
}