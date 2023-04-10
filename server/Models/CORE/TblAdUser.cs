using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreRadzen.Models.Core
{
  [Table("tblADUsers", Schema = "dbo")]
  public partial class TblAdUser
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int tblADUser_ID
    {
      get;
      set;
    }

    public ICollection<TblSpeaker> TblSpeakers { get; set; }
    public ICollection<TblCoreAttendance> TblCoreAttendances { get; set; }
    public string UserName
    {
      get;
      set;
    }
    public string Email
    {
      get;
      set;
    }
    public string Department
    {
      get;
      set;
    }
    public string Title
    {
      get;
      set;
    }
    public string Manager
    {
      get;
      set;
    }
    public DateTime CreateDate
    {
      get;
      set;
    }
    public DateTime ModDate
    {
      get;
      set;
    }
    public string Extension
    {
      get;
      set;
    }
    public string CellPhone
    {
      get;
      set;
    }
    public string HomePhone
    {
      get;
      set;
    }
    public Byte[] EmployeePhoto
    {
      get;
      set;
    }
    public string EmployeePhotoString
    {
      get;
      set;
    }
    public string Company
    {
      get;
      set;
    }
    public string EmploymentStatus
    {
      get;
      set;
    }
    public bool Leadership
    {
      get;
      set;
    }
    public string LeadershipGroup
    {
      get;
      set;
    }
    public bool AOC
    {
      get;
      set;
    }
    public bool TOC
    {
      get;
      set;
    }
    public string Pager
    {
      get;
      set;
    }
    public string Fax
    {
      get;
      set;
    }
    public bool NewEmployee
    {
      get;
      set;
    }
    public bool ServiceAccount
    {
      get;
      set;
    }
    public bool ViewInApp
    {
      get;
      set;
    }
    public string DirectDial
    {
      get;
      set;
    }
    public string FirstName
    {
      get;
      set;
    }
    public string LastName
    {
      get;
      set;
    }
    public string GROUP
    {
      get;
      set;
    }
    public string DN
    {
      get;
      set;
    }
  }
}
