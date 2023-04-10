using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreRadzen.Models.Core
{
  [Table("tblCOREAttendance", Schema = "dbo")]
  public partial class TblCoreAttendance
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int tblCOREAttendance_ID
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
    public int tblADUser_ID
    {
      get;
      set;
    }
    public TblAdUser TblAdUser { get; set; }
  }
}
