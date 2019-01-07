using System.Collections.Generic;
using OntologyMain.Data.Dtos;

namespace OntologyMain.Api.ViewModels
{
  public class HistoryViewModel
  {
    public PatientViewModel Patient { get; set; }
    public List<StateDto> States { get; set; }
    public List<StatusDto> Statuses { get; set; }
  }
}