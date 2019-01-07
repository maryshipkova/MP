using System;
using System.Collections.Generic;

namespace OntologyMain.Api.ViewModels
{
  public class StatusViewModel
  {
    public int StatusId { get; set; }
    public IEnumerable<SignViewModel> Signs { get; set; }
    public string Description { get; set; }
    public IEnumerable<TypeViewModel> Medicines { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
  }
}