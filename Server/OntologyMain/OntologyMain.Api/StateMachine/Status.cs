using System;
using System.Collections.Generic;
using System.Linq;
using CommonLibraries.CommonTypes;
using OntologyMain.Data.Dtos;

namespace OntologyMain.Api.StateMachine
{
  public class Status
  {
    public int StatusId { get; set; }
    public Dictionary<SignType, Sign> Signs { get; private set; }
    public Status PreviousStatus { get; private set; }
    public DateTime StartDate { get; private set; } 
    public DateTime EndDate { get; private set; } 

    protected Status()
    {
   
    }


    public static Status CreateStatus(StatusDto previousStatusDto, StatusDto newStatusDto)
    {
      var result = new Status
      {
        StartDate = newStatusDto.CreatedDate,
        EndDate = DateTime.UtcNow,
        StatusId = newStatusDto.StatusId,
        Signs = new Dictionary<SignType, Sign>()
      };

      foreach (var signDto in newStatusDto.Signs)
      {
        result.Signs.Add(signDto.SignType, new Sign(signDto.SignId, signDto.SignType, signDto.Intensity) );
      }

      result.PreviousStatus = previousStatusDto.StatusId == newStatusDto.StatusId ? new VoidStatus() : new Status();

      result.PreviousStatus.StartDate = previousStatusDto.CreatedDate;
      result.PreviousStatus.EndDate = newStatusDto.CreatedDate;
      result.PreviousStatus.StatusId = previousStatusDto.StatusId;
      result.PreviousStatus.Signs = new Dictionary<SignType, Sign>();
      foreach (var signDto in newStatusDto.Signs)
      {
        result.PreviousStatus.Signs.Add(signDto.SignType, new Sign(signDto.SignId, signDto.SignType, signDto.Intensity));
      }

      return result;
    }

    public bool IsAnyChanged()
    {
      if (PreviousStatus is VoidStatus) return true;
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

    public TimeSpan ElapsedTime() => ElapsedTime(EndDate == DateTime.MinValue ? DateTime.UtcNow : EndDate);
    public TimeSpan ElapsedTime(DateTime endTime) => StartDate.Subtract(DateTime.UtcNow);

    
  }

  public sealed class VoidStatus : Status
  {
  }
}