using System;
using System.ComponentModel.DataAnnotations;
using CommonLibraries.CommonTypes;
using OntologyMain.Data.Dtos;
using OntologyMain.Data.Entities;

namespace OntologyMain.Api.ViewModels
{
  public class CreatePatientViewModel
  {
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public int GenderType { get; set; }
  }

  public class PatientViewModel
  {
    public int PatientId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public TypeViewModel GenderType { get; set; }

    public static PatientViewModel FromPatientEntity(PatientEntity patient)
    {
      var result = new PatientViewModel
      {
        PatientId = patient.PatientId,
        BirthDate = patient.BirthDate,
        FirstName = patient.FirstName,
        LastName = patient.LastName,
        GenderType = (GenderType) patient.GenderTypeId
      };
      return result;
    }
  }

  public class FullPatientViewModel : PatientViewModel
  {
    public StatusViewModel Status { get; set; }

    public static FullPatientViewModel FromPatientDto(PatientDto patient)
    {
      var result = new FullPatientViewModel
      {
        PatientId = patient.PatientId,
        BirthDate = patient.BirthDate,
        FirstName = patient.FirstName,
        LastName = patient.LastName,
        GenderType = patient.GenderType,
        Status = new StatusViewModel
        {
          CreatedDate = patient.Status.CreatedDate,
          StatusId = patient.Status.StatusId,
          Parameters = patient.Status.Parameters
        }
      };
      return result;
    }
  }
}