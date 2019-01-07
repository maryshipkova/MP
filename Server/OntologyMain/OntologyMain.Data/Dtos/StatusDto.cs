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
    public IEnumerable<SignDto> Signs { get; set; }
    public DateTime CreatedDate { get; set; }

    public static StatusDto FromEntity(StatusEntity statusEntity, IEnumerable<SignEntity> signs)
    {
      var result = new StatusDto
      {
        StatusId = statusEntity.StatusId,
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

    //public static (StatusEntity, IEnumerable<SignEntity>) ToEntity(int patientId, int previousStatusId, StatusDto status)
    //{
    //  var newStatus = new StatusEntity
    //  {
    //    PatientId = patientId,
    //    PreviousStatusId = previousStatusId,
    //    CreatedDate = status.CreatedDate,
    //  };

    //  var newSigns = status.Signs.Select(x => new SignEntity
    //  {
    //    StatusId = newStatus.StatusId,
    //    SignTypeId = x.SignType.Id,
    //    Intensity = x.Intensity
    //  }).ToList();
    //}
  }
}