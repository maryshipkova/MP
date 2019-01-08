using System;
using OntologyMain.Data.Entities;

namespace OntologyMain.Data.Dtos
{
  public class StatusDto
  {
    public int StatusId { get; set; }
    public int PreviousStatusId { get; set; }
    public ParametersDto Parameters { get; set; }
    public DateTime CreatedDate { get; set; }

    public static StatusDto FromEntity(StatusEntity statusEntity)
    {
      var result = new StatusDto
      {
        StatusId = statusEntity.StatusId,
        PreviousStatusId = statusEntity.PreviousStatusId,
        Parameters =
          new ParametersDto
          {
            IsHospitalized = statusEntity.IsHospitalized,
            IsWheezing = statusEntity.IsWheezing,
            Pef = statusEntity.Pef,
            SpO2 = statusEntity.SpO2
          },
        CreatedDate = statusEntity.CreatedDate
      };

      return result;
    }
  }
}