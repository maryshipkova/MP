using System.Collections.Generic;

namespace OntologyMain.Api.ViewModels
{
  public class ListViewModel<T>
  {
    public int Count { get; set; } = 0;
    public IEnumerable<T> List { get; set; } = new List<T>();
  }
}