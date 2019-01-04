using System;
using System.Collections.Generic;

namespace OntologyMain.Api.StateMachine
{
  public class Status
  {
    public Dictionary<Indicator, Sign> Signs = new Dictionary<Indicator, Sign>();
    public Status PreviousStatus { get; }
    public DateTime StartTime { get; } = DateTime.UtcNow;
    public DateTime EndTime { get; private set; }

    public Status(Status previousStatus)
    {
      PreviousStatus = previousStatus;
      PreviousStatus.EndTime = DateTime.UtcNow;
    }
  }
}