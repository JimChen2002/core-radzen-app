using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreRadzen.Models.Core
{
  [Table("tblHospitals", Schema = "dbo")]
  public partial class TblHospital
  {
    [Key]
    public int HospitalID
    {
      get;
      set;
    }

    public ICollection<TblEvent> TblEvents { get; set; }
    public string HospitalName
    {
      get;
      set;
    }
    public string PGCode
    {
      get;
      set;
    }
    public string AgencyType
    {
      get;
      set;
    }
    public string HospitalStatus
    {
      get;
      set;
    }
    public string HospitalAddress1
    {
      get;
      set;
    }
    public string HospitalAddress2
    {
      get;
      set;
    }
    public string HospitalCity
    {
      get;
      set;
    }
    public string HospitalState
    {
      get;
      set;
    }
    public string HospitalZip
    {
      get;
      set;
    }
    public string HospitalCounty
    {
      get;
      set;
    }
    public string PerDiem
    {
      get;
      set;
    }
    public string PSL
    {
      get;
      set;
    }
    public string IsClosed
    {
      get;
      set;
    }
  }
}
