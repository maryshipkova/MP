using System.ComponentModel.DataAnnotations;

namespace OntologyMain.Api.ViewModels
{
  public class CreateSymptomViewModel
  {
    [Required]
    public string Name { get; set; }

    public float NormalIntensity { get; set; } = 0;
  }
}