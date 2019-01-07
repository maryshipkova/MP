using System.Collections.Generic;
using System.Linq;
using CommonLibraries.CommonTypes;

namespace OntologyMain.Api.ViewModels
{
  public class TypeViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public static implicit operator TypeViewModel(CustomEnum customEnum)
    {
      return new TypeViewModel {Id = customEnum.Id, Name = customEnum.Name, Description = customEnum.Description};
    }

    public static IEnumerable<TypeViewModel> FromCustomEnums(IEnumerable<CustomEnum> customEnums)
    {
      return customEnums.Select(customEnum => new TypeViewModel
      {
        Id = customEnum.Id,
        Name = customEnum.Name,
        Description = customEnum.Description
      });
    }
  }
}