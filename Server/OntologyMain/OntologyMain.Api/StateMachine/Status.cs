using System;
using System.Collections.Generic;
using System.Linq;
using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.StateMachine
{
  public class Status
  {
    public int StatusId { get; set; }
    public Dictionary<SignType, Sign> Signs = new Dictionary<SignType, Sign>();
    public Status PreviousStatus { get; }
    public DateTime StartTime { get; } = DateTime.UtcNow;
    public DateTime EndTime { get; private set; } = DateTime.MinValue;

    protected Status()
    {
      PreviousStatus = null;
    }

    public Status(Status previousStatus)
    {
      PreviousStatus = previousStatus ?? throw new ArgumentNullException($"{nameof(Status)}.ctor: {nameof(previousStatus)} is null.");
      PreviousStatus.EndTime = DateTime.UtcNow;
    }

    public bool IsAnyChanged()
    {
      if (!Signs.Any() || PreviousStatus is VoidStatus || !PreviousStatus.Signs.Any()) return false;
      var currentSigns = Signs;
      var previousSigns = PreviousStatus.Signs;
      foreach (var currentSign in currentSigns)
      {
        if (!previousSigns.TryGetValue(currentSign.Key, out Sign previousSign)) return false;
        if (!currentSign.Value.IsTheSameIntensity(previousSign)) return false;
      }
      return true;
    }

    public bool IsSignChanged(Sign sign)
    {
      if (!Signs.TryGetValue(sign.SignType, out Sign currentSign)) return false;
      if (PreviousStatus is VoidStatus ||
          !PreviousStatus.Signs.TryGetValue(sign.SignType, out Sign previousSign)) return false;

      return currentSign.IsTheSameIntensity(previousSign);
    }

    public TimeSpan ElapsedTime() => ElapsedTime(EndTime == DateTime.MinValue ? DateTime.UtcNow : EndTime);
    public TimeSpan ElapsedTime(DateTime endTime) => StartTime.Subtract(DateTime.UtcNow);
  }

  public sealed class VoidStatus : Status
  {
  }
}