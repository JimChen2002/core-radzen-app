using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreRadzen.Models.Core
{
  [Table("tblSpeakers", Schema = "dbo")]
  public partial class TblSpeaker
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int tblSpeaker_ID
    {
      get;
      set;
    }

    public ICollection<TblVolunteerSpeakerRequest> TblVolunteerSpeakerRequests { get; set; }
    public string Name
    {
      get;
      set;
    }
    public string PhoneNumber
    {
      get;
      set;
    }
    public string Email
    {
      get;
      set;
    }
    public string Connection
    {
      get;
      set;
    }
    public string Background
    {
      get;
      set;
    }
    public string AccessibilityRequirements
    {
      get;
      set;
    }
    public string Quote
    {
      get;
      set;
    }
    public int? tblADUser_ID
    {
      get;
      set;
    }
    public TblAdUser TblAdUser { get; set; }
  }
}
