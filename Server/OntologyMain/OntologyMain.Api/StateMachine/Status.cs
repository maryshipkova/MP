using System;
using CommonLibraries;
using OntologyMain.Data.Dtos;

namespace OntologyMain.Api.StateMachine
{
  /// <summary>
  /// Неизменяемый объект, описывающий текущий статус (физическое состояние) пациента
  /// </summary>
  public class Status
  {
    public int StatusId { get; set; }
    public Parameters Parameters { get; private set; }
    public Status PreviousStatus { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public static Status CreateStatus(StatusDto previousStatusDto, StatusDto newStatusDto)
    {
      var result = new Status
      {
        StartDate = newStatusDto.CreatedDate,
        EndDate = DateTime.UtcNow,
        StatusId = newStatusDto.StatusId,
        Parameters =
          new Parameters
          {
            IsHospitalized = newStatusDto.Parameters.IsHospitalized,
            IsWheezing = newStatusDto.Parameters.IsWheezing,
            Pef = newStatusDto.Parameters.Pef,
            SpO2 = newStatusDto.Parameters.SpO2
          },
        PreviousStatus = new Status
        {
          StartDate = previousStatusDto.CreatedDate,
          EndDate = newStatusDto.CreatedDate,
          StatusId = previousStatusDto.StatusId,
          Parameters = new Parameters
          {
            IsHospitalized = previousStatusDto.Parameters.IsHospitalized,
            IsWheezing = previousStatusDto.Parameters.IsWheezing,
            Pef = previousStatusDto.Parameters.Pef,
            SpO2 = previousStatusDto.Parameters.SpO2
          }
        }
      };

      return result;
    }

    /// <summary>
    /// Сравниваем текущий и предыдущий статус на изменения.
    /// </summary>
    /// <returns>Булевское значение - есть ли изменения</returns>
    public bool IsAnyChanged()
    {
      if (PreviousStatus == null) return false;

      var prevParam = PreviousStatus.Parameters;
      if (Parameters.IsHospitalized != prevParam?.IsHospitalized) return true;
      if (Parameters.IsWheezing != prevParam.IsWheezing) return true;
      if (!Parameters.Pef.EqualsStrict(prevParam.Pef)) return true;
      if (!Parameters.SpO2.EqualsStrict(prevParam.SpO2)) return true;

      return false;
    }

    /// <summary>
    /// Получение времени существования текущего статуса пациента
    /// </summary>
    /// <returns>Время существования статуса</returns>
    public TimeSpan ElapsedTime()
    {
      return ElapsedTime(EndDate == DateTime.MinValue ? DateTime.UtcNow : EndDate);
    }

    public TimeSpan ElapsedTime(DateTime endTime)
    {
      return StartDate.Subtract(DateTime.UtcNow);
    }
  }
}