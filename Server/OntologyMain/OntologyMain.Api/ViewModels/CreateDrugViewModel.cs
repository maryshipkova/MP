using System.ComponentModel.DataAnnotations;

namespace OntologyMain.Api.ViewModels
{
  public class CreateDrugViewModel
  {
    [Required]
    public string Name { get; set; }
  }
}