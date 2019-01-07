using System;
using System.Collections.Generic;

namespace OntologyMain.Api.ViewModels
{
  public class StatusViewModel
  {
    public int StatusId { get; set; }
    public IEnumerable<SignViewModel> Signs { get; set; } = new List<SignViewModel>();
    public string Description { get; set; } = string.Empty;
    public IEnumerable<TypeViewModel> Medicines { get; set; } = new List<TypeViewModel>();
    public TypeViewModel PatientState { get; set; }
    public DateTime CreatedDate { get; set; }
  }
}