using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreRadzen.Models.Core
{
  [Table("tblAdminUsers", Schema = "dbo")]
  public partial class TblAdminUser
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int tblAdminUser_ID
    {
      get;
      set;
    }
    public int tblADUser_ID
    {
      get;
      set;
    }
    public string UserName
    {
      get;
      set;
    }
  }
}
