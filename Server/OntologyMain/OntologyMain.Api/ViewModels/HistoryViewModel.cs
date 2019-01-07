namespace OntologyMain.Api.ViewModels
{
  public class HistoryViewModel
  {
    public FullPatientViewModel Patient { get; set; }
    public ListViewModel<StatusViewModel> Statuses { get; set; }
  }
}