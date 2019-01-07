using System;
using CommonLibraries.CommonTypes;
using OntologyMain.Data.Entities;

namespace OntologyMain.Data.Dtos
{
  public class StateDto
  {
    public int StateId { get; set; }
    public int StatusId { get; set; }
    public StateType StateType { get; set; }
    public DateTime CreatedDate { get; set; }

    public static StateDto FromEntity(StateEntity state)
    {
      var result = new StateDto
      {
        StateId = state.StateId,
        StatusId = state.StatusId,
        CreatedDate = state.CreatedDate,
        StateType = (StateType) state.StateTypeId
      };
      return result;
    }
  }
}