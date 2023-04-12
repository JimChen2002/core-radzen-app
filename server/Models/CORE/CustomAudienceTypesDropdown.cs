using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRadzen.Models.Core
{
  public class AudienceTypesDropDown {
    public string Id {get; set;}
    public string Name {get; set;}
  }
  public partial class TblEvent
  {
    [NotMapped]
    public IEnumerable<string> SelectedAudienceTypes
    {
      get{
        return !string.IsNullOrEmpty(AudienceTypes) ? AudienceTypes.Split(';') : Enumerable.Empty<string>();
      }
      set{
        AudienceTypes = string.Join(';', value);
      }
    }
  }
}
