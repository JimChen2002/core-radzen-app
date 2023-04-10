using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreRadzen.Models.Core
{
  [Table("sp_Event_StartNewEvent", Schema = "dbo")]
  public partial class SpEventStartNewEvent
  {
    public decimal? scopeIdentityValue
    {
      get;
      set;
    }
  }
}
