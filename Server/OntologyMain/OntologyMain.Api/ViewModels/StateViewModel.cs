using System;

namespace OntologyMain.Api.ViewModels
{
  public class StateViewModel
  {
    public int StateId { get; set; }
    public int StatusId { get; set; }
    public TypeViewModel StateType { get; set; }
    public DateTime StartDate { get; set; }
  }
}