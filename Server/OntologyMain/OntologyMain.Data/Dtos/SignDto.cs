using CommonLibraries.CommonTypes;

namespace OntologyMain.Data.Dtos
{
  public class SignDto
  {
    public int SignId { get; set; }
    public SignType SignType { get; set; }
    public float Intensity { get; set; }
  }
}