using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreRadzen.Models.Core
{
  [Table("tblVolunteerSpeakerRequests", Schema = "dbo")]
  public partial class TblVolunteerSpeakerRequest
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int tblVolunteerSpeakerRequests_ID
    {
      get;
      set;
    }
    public int tblEvent_ID
    {
      get;
      set;
    }
    public TblEvent TblEvent { get; set; }
    public int tblSpeaker_ID
    {
      get;
      set;
    }
    public TblSpeaker TblSpeaker { get; set; }
  }
}
