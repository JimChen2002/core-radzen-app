using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using CoreRadzen.Models.Core;

namespace CoreRadzen.Data
{
  public partial class CoreContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public CoreContext(DbContextOptions<CoreContext> options):base(options)
    {
    }

    public CoreContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<CoreRadzen.Models.Core.SpEventStartNewEvent>().HasNoKey();
        builder.Entity<CoreRadzen.Models.Core.TblAdminUser>().HasNoKey();
        builder.Entity<CoreRadzen.Models.Core.TblCoreAttendance>()
              .HasOne(i => i.TblEvent)
              .WithMany(i => i.TblCoreAttendances)
              .HasForeignKey(i => i.tblEvent_ID)
              .HasPrincipalKey(i => i.tblEvent_ID);
        builder.Entity<CoreRadzen.Models.Core.TblCoreAttendance>()
              .HasOne(i => i.TblAdUser)
              .WithMany(i => i.TblCoreAttendances)
              .HasForeignKey(i => i.tblADUser_ID)
              .HasPrincipalKey(i => i.tblADUser_ID);
        builder.Entity<CoreRadzen.Models.Core.TblEvent>()
              .HasOne(i => i.TblHospital)
              .WithMany(i => i.TblEvents)
              .HasForeignKey(i => i.HospitalID)
              .HasPrincipalKey(i => i.HospitalID);
        builder.Entity<CoreRadzen.Models.Core.TblSpeaker>()
              .HasOne(i => i.TblAdUser)
              .WithMany(i => i.TblSpeakers)
              .HasForeignKey(i => i.tblADUser_ID)
              .HasPrincipalKey(i => i.tblADUser_ID);
        builder.Entity<CoreRadzen.Models.Core.TblVolunteerSpeakerRequest>()
              .HasOne(i => i.TblEvent)
              .WithMany(i => i.TblVolunteerSpeakerRequests)
              .HasForeignKey(i => i.tblEvent_ID)
              .HasPrincipalKey(i => i.tblEvent_ID);
        builder.Entity<CoreRadzen.Models.Core.TblVolunteerSpeakerRequest>()
              .HasOne(i => i.TblSpeaker)
              .WithMany(i => i.TblVolunteerSpeakerRequests)
              .HasForeignKey(i => i.tblSpeaker_ID)
              .HasPrincipalKey(i => i.tblSpeaker_ID);


        builder.Entity<CoreRadzen.Models.Core.TblAdUser>()
              .Property(p => p.CreateDate)
              .HasColumnType("smalldatetime");

        builder.Entity<CoreRadzen.Models.Core.TblAdUser>()
              .Property(p => p.ModDate)
              .HasColumnType("smalldatetime");

        builder.Entity<CoreRadzen.Models.Core.TblEvent>()
              .Property(p => p.EventDate)
              .HasColumnType("date");

        builder.Entity<CoreRadzen.Models.Core.TblEvent>()
              .Property(p => p.StartTime)
              .HasColumnType("smalldatetime");

        builder.Entity<CoreRadzen.Models.Core.TblEvent>()
              .Property(p => p.EndTime)
              .HasColumnType("smalldatetime");
        this.OnModelBuilding(builder);
    }


    public DbSet<CoreRadzen.Models.Core.SpEventStartNewEvent> SpEventStartNewEvents
    {
      get;
      set;
    }

    public DbSet<CoreRadzen.Models.Core.TblAdUser> TblAdUsers
    {
      get;
      set;
    }

    public DbSet<CoreRadzen.Models.Core.TblAdminUser> TblAdminUsers
    {
      get;
      set;
    }

    public DbSet<CoreRadzen.Models.Core.TblCoreAttendance> TblCoreAttendances
    {
      get;
      set;
    }

    public DbSet<CoreRadzen.Models.Core.TblEvent> TblEvents
    {
      get;
      set;
    }

    public DbSet<CoreRadzen.Models.Core.TblHospital> TblHospitals
    {
      get;
      set;
    }

    public DbSet<CoreRadzen.Models.Core.TblSpeaker> TblSpeakers
    {
      get;
      set;
    }

    public DbSet<CoreRadzen.Models.Core.TblVolunteerSpeakerRequest> TblVolunteerSpeakerRequests
    {
      get;
      set;
    }
  }
}
