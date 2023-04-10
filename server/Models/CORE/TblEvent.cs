using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreRadzen.Models.Core
{
  [Table("tblEvents", Schema = "dbo")]
  public partial class TblEvent
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int tblEvent_ID
    {
      get;
      set;
    }

    public ICollection<TblCoreAttendance> TblCoreAttendances { get; set; }
    public ICollection<TblVolunteerSpeakerRequest> TblVolunteerSpeakerRequests { get; set; }
    public DateTime EventDate
    {
      get;
      set;
    }
    public DateTime StartTime
    {
      get;
      set;
    }
    public DateTime EndTime
    {
      get;
      set;
    }
    public int HospitalID
    {
      get;
      set;
    }
    public TblHospital TblHospital { get; set; }
    public string LocationDetails
    {
      get;
      set;
    }
    public string EventType
    {
      get;
      set;
    }
    public string EventDescription
    {
      get;
      set;
    }
    public string EventDetails
    {
      get;
      set;
    }
    public string SpeakerNeeds
    {
      get;
      set;
    }
    public bool LeadershipSpeakerRequested
    {
      get;
      set;
    }
    public string LeadershipSpeaker
    {
      get;
      set;
    }
    public int? LeadershipSpeechLength
    {
      get;
      set;
    }
    public int? VolunteerSpeechLength
    {
      get;
      set;
    }
    [Timestamp]
    public Byte[] SpeakerArrivalTime
    {
      get;
      set;
    }
    public string AudienceTypes
    {
      get;
      set;
    }
    public string EstimatedAttendees
    {
      get;
      set;
    }
    public string SocialMediaOrVideoNeeds
    {
      get;
      set;
    }
    public bool IsLegislatorsInvited
    {
      get;
      set;
    }
    public bool IsLegislatorsAttending
    {
      get;
      set;
    }
    public bool IsQuiltRequested
    {
      get;
      set;
    }
    public string QuiltNumber
    {
      get;
      set;
    }
    public string QuiltCoordinator
    {
      get;
      set;
    }
    public bool IsVehicleRequested
    {
      get;
      set;
    }
    public bool? IsVehicleReserved
    {
      get;
      set;
    }
    public string VehicleDriver
    {
      get;
      set;
    }
    public string OnsiteContactName
    {
      get;
      set;
    }
    public string OnsiteContactPhone
    {
      get;
      set;
    }
    public string OnsiteContactEmail
    {
      get;
      set;
    }
    public bool IsLocked
    {
      get;
      set;
    }
    public string PlaceToMeet
    {
      get;
      set;
    }
    public string AdditionalInformation
    {
      get;
      set;
    }
  }
}
