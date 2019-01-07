using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommonLibraries.CommonTypes;
using OntologyMain.Data.Entities;

namespace OntologyMain.Data.Dtos
{
  public class StatusDto
  {
    public int StatusId { get; set; }
    public int PreviousStatusId { get; set; }
    public IEnumerable<SignDto> Signs { get; set; }
    public DateTime CreatedDate { get; set; }

    public static StatusDto FromEntity(StatusEntity statusEntity, IEnumerable<SignEntity> signs)
    {
      var result = new StatusDto
      {
        StatusId = statusEntity.StatusId,
        PreviousStatusId = statusEntity.PreviousStatusId,
        Signs = signs.Select(x => new SignDto
        {
          SignId = x.SignId,
          Intensity = x.Intensity,
          SignType = (SignType)x.SignTypeId
        }),
        CreatedDate = statusEntity.CreatedDate
      };

      return result;
    }
  }
}