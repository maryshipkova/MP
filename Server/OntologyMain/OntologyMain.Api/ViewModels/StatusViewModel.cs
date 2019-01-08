using System;
using System.Collections.Generic;
using OntologyMain.Data.Dtos;

namespace OntologyMain.Api.ViewModels
{
  public class StatusViewModel
  {
    public int StatusId { get; set; }
    public ParametersDto Parameters { get; set; }
    public string Description { get; set; } = string.Empty;
    public IEnumerable<TypeViewModel> Medicines { get; set; } = new List<TypeViewModel>();
    public TypeViewModel PatientState { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}