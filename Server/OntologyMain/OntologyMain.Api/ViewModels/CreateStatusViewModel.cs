using System.Collections.Generic;

namespace OntologyMain.Api.ViewModels
{
  public class CreateStatusViewModel
  {
    public IEnumerable<AddSignViewModel> Signs { get; set; }
  }

  public class AddSignViewModel
  {
    public int SignTypeId { get; set; }
    public float Intensity { get; set; }
  }
}