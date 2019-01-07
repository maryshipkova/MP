using System;
using CommonLibraries.CommonTypes;
using OntologyMain.Data.Entities;

namespace OntologyMain.Data.Dtos
{
  public class PatientDto
  {
    public int PatientId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public GenderType GenderType { get; set; }

    public StateDto PatientState { get; set; }
    public StatusDto Status { get; set; }

    public static PatientDto FromEntity(PatientEntity patient)
    {
      var result = new PatientDto
      {
        PatientId = patient.PatientId,
        FirstName = patient.FirstName,
        LastName = patient.LastName,
        BirthDate = patient.BirthDate,
        GenderType = (GenderType)patient.GenderTypeId
      };
      return result;
    }
  }
}