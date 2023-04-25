using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Text.Encodings.Web;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using CoreRadzen.Data;

namespace CoreRadzen
{
    public partial class CoreService
    {
        CoreContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly CoreContext context;
        private readonly NavigationManager navigationManager;

        public CoreService(CoreContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);


      public async Task ExportSpEventStartNewEventsToExcel(string EventDate, string StartTime, string EndTime, int? HospitalID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/speventstartnewevents/excel(EventDate='{EventDate}', StartTime='{StartTime}', EndTime='{EndTime}', HospitalID={HospitalID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/speventstartnewevents/excel(EventDate='{EventDate}', StartTime='{StartTime}', EndTime='{EndTime}', HospitalID={HospitalID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportSpEventStartNewEventsToCSV(string EventDate, string StartTime, string EndTime, int? HospitalID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/speventstartnewevents/csv(EventDate='{EventDate}', StartTime='{StartTime}', EndTime='{EndTime}', HospitalID={HospitalID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/speventstartnewevents/csv(EventDate='{EventDate}', StartTime='{StartTime}', EndTime='{EndTime}', HospitalID={HospitalID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.Core.SpEventStartNewEvent>> GetSpEventStartNewEvents(string EventDate, string StartTime, string EndTime, int? HospitalID, Query query = null)
      {
          OnSpEventStartNewEventsDefaultParams(ref EventDate, ref StartTime, ref EndTime, ref HospitalID);

          var items = Context.SpEventStartNewEvents.FromSqlRaw("EXEC [dbo].[sp_Event_StartNewEvent] @EventDate={0}, @StartTime={1}, @EndTime={2}, @HospitalID={3}", string.IsNullOrEmpty(EventDate) ? DBNull.Value : (object)DateTime.Parse(EventDate, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(StartTime) ? DBNull.Value : (object)DateTime.Parse(StartTime, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(EndTime) ? DBNull.Value : (object)DateTime.Parse(EndTime, null, System.Globalization.DateTimeStyles.RoundtripKind), HospitalID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p.Trim());
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnSpEventStartNewEventsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnSpEventStartNewEventsDefaultParams(ref string EventDate, ref string StartTime, ref string EndTime, ref int? HospitalID);

      partial void OnSpEventStartNewEventsInvoke(ref IQueryable<Models.Core.SpEventStartNewEvent> items);
        public async Task ExportTblAdUsersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/tbladusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/tbladusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblAdUsersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/tbladusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/tbladusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblAdUsersRead(ref IQueryable<Models.Core.TblAdUser> items);

        public async Task<IQueryable<Models.Core.TblAdUser>> GetTblAdUsers(Query query = null)
        {
            var items = Context.TblAdUsers.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblAdUsersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblAdUserCreated(Models.Core.TblAdUser item);
        partial void OnAfterTblAdUserCreated(Models.Core.TblAdUser item);

        public async Task<Models.Core.TblAdUser> CreateTblAdUser(Models.Core.TblAdUser tblAdUser)
        {
            OnTblAdUserCreated(tblAdUser);

            var existingItem = Context.TblAdUsers
                              .Where(i => i.tblADUser_ID == tblAdUser.tblADUser_ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblAdUsers.Add(tblAdUser);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblAdUser).State = EntityState.Detached;
                throw;
            }

            OnAfterTblAdUserCreated(tblAdUser);

            return tblAdUser;
        }
        public async Task ExportTblAdminUsersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/tbladminusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/tbladminusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblAdminUsersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/tbladminusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/tbladminusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblAdminUsersRead(ref IQueryable<Models.Core.TblAdminUser> items);

        public async Task<IQueryable<Models.Core.TblAdminUser>> GetTblAdminUsers(Query query = null)
        {
            var items = Context.TblAdminUsers.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblAdminUsersRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportTblCoreAttendancesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/tblcoreattendances/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/tblcoreattendances/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblCoreAttendancesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/tblcoreattendances/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/tblcoreattendances/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblCoreAttendancesRead(ref IQueryable<Models.Core.TblCoreAttendance> items);

        public async Task<IQueryable<Models.Core.TblCoreAttendance>> GetTblCoreAttendances(Query query = null)
        {
            var items = Context.TblCoreAttendances.AsQueryable();

            items = items.Include(i => i.TblEvent);

            items = items.Include(i => i.TblAdUser);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblCoreAttendancesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblCoreAttendanceCreated(Models.Core.TblCoreAttendance item);
        partial void OnAfterTblCoreAttendanceCreated(Models.Core.TblCoreAttendance item);

        public async Task<Models.Core.TblCoreAttendance> CreateTblCoreAttendance(Models.Core.TblCoreAttendance tblCoreAttendance)
        {
            OnTblCoreAttendanceCreated(tblCoreAttendance);

            var existingItem = Context.TblCoreAttendances
                              .Where(i => i.tblCOREAttendance_ID == tblCoreAttendance.tblCOREAttendance_ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblCoreAttendances.Add(tblCoreAttendance);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblCoreAttendance).State = EntityState.Detached;
                tblCoreAttendance.TblEvent = null;
                tblCoreAttendance.TblAdUser = null;
                throw;
            }

            OnAfterTblCoreAttendanceCreated(tblCoreAttendance);

            return tblCoreAttendance;
        }
        public async Task ExportTblEventsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/tblevents/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/tblevents/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblEventsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/tblevents/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/tblevents/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblEventsRead(ref IQueryable<Models.Core.TblEvent> items);

        public async Task<IQueryable<Models.Core.TblEvent>> GetTblEvents(Query query = null)
        {
            var items = Context.TblEvents.AsQueryable();

            items = items.Include(i => i.TblHospital);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblEventsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblEventCreated(Models.Core.TblEvent item);
        partial void OnAfterTblEventCreated(Models.Core.TblEvent item);

        public async Task<Models.Core.TblEvent> CreateTblEvent(Models.Core.TblEvent tblEvent)
        {
            OnTblEventCreated(tblEvent);

            var existingItem = Context.TblEvents
                              .Where(i => i.tblEvent_ID == tblEvent.tblEvent_ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblEvents.Add(tblEvent);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblEvent).State = EntityState.Detached;
                tblEvent.TblHospital = null;
                throw;
            }

            OnAfterTblEventCreated(tblEvent);

            return tblEvent;
        }
        public async Task ExportTblHospitalsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/tblhospitals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/tblhospitals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblHospitalsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/tblhospitals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/tblhospitals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblHospitalsRead(ref IQueryable<Models.Core.TblHospital> items);

        public async Task<IQueryable<Models.Core.TblHospital>> GetTblHospitals(Query query = null)
        {
            var items = Context.TblHospitals.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblHospitalsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblHospitalCreated(Models.Core.TblHospital item);
        partial void OnAfterTblHospitalCreated(Models.Core.TblHospital item);

        public async Task<Models.Core.TblHospital> CreateTblHospital(Models.Core.TblHospital tblHospital)
        {
            OnTblHospitalCreated(tblHospital);

            var existingItem = Context.TblHospitals
                              .Where(i => i.HospitalID == tblHospital.HospitalID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblHospitals.Add(tblHospital);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblHospital).State = EntityState.Detached;
                throw;
            }

            OnAfterTblHospitalCreated(tblHospital);

            return tblHospital;
        }
        public async Task ExportTblSpeakersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/tblspeakers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/tblspeakers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblSpeakersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/tblspeakers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/tblspeakers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblSpeakersRead(ref IQueryable<Models.Core.TblSpeaker> items);

        public async Task<IQueryable<Models.Core.TblSpeaker>> GetTblSpeakers(Query query = null)
        {
            var items = Context.TblSpeakers.AsQueryable();

            items = items.Include(i => i.TblAdUser);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblSpeakersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblSpeakerCreated(Models.Core.TblSpeaker item);
        partial void OnAfterTblSpeakerCreated(Models.Core.TblSpeaker item);

        public async Task<Models.Core.TblSpeaker> CreateTblSpeaker(Models.Core.TblSpeaker tblSpeaker)
        {
            OnTblSpeakerCreated(tblSpeaker);

            var existingItem = Context.TblSpeakers
                              .Where(i => i.tblSpeaker_ID == tblSpeaker.tblSpeaker_ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblSpeakers.Add(tblSpeaker);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblSpeaker).State = EntityState.Detached;
                tblSpeaker.TblAdUser = null;
                throw;
            }

            OnAfterTblSpeakerCreated(tblSpeaker);

            return tblSpeaker;
        }
        public async Task ExportTblVolunteerSpeakerRequestsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/tblvolunteerspeakerrequests/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/tblvolunteerspeakerrequests/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTblVolunteerSpeakerRequestsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/core/tblvolunteerspeakerrequests/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/core/tblvolunteerspeakerrequests/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTblVolunteerSpeakerRequestsRead(ref IQueryable<Models.Core.TblVolunteerSpeakerRequest> items);

        public async Task<IQueryable<Models.Core.TblVolunteerSpeakerRequest>> GetTblVolunteerSpeakerRequests(Query query = null)
        {
            var items = Context.TblVolunteerSpeakerRequests.AsQueryable();

            items = items.Include(i => i.TblEvent);

            items = items.Include(i => i.TblSpeaker);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblVolunteerSpeakerRequestsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblVolunteerSpeakerRequestCreated(Models.Core.TblVolunteerSpeakerRequest item);
        partial void OnAfterTblVolunteerSpeakerRequestCreated(Models.Core.TblVolunteerSpeakerRequest item);

        public async Task<Models.Core.TblVolunteerSpeakerRequest> CreateTblVolunteerSpeakerRequest(Models.Core.TblVolunteerSpeakerRequest tblVolunteerSpeakerRequest)
        {
            OnTblVolunteerSpeakerRequestCreated(tblVolunteerSpeakerRequest);

            var existingItem = Context.TblVolunteerSpeakerRequests
                              .Where(i => i.tblVolunteerSpeakerRequests_ID == tblVolunteerSpeakerRequest.tblVolunteerSpeakerRequests_ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TblVolunteerSpeakerRequests.Add(tblVolunteerSpeakerRequest);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tblVolunteerSpeakerRequest).State = EntityState.Detached;
                tblVolunteerSpeakerRequest.TblEvent = null;
                tblVolunteerSpeakerRequest.TblSpeaker = null;
                throw;
            }

            OnAfterTblVolunteerSpeakerRequestCreated(tblVolunteerSpeakerRequest);

            return tblVolunteerSpeakerRequest;
        }

        partial void OnTblAdUserDeleted(Models.Core.TblAdUser item);
        partial void OnAfterTblAdUserDeleted(Models.Core.TblAdUser item);

        public async Task<Models.Core.TblAdUser> DeleteTblAdUser(int? tblAdUserId)
        {
            var itemToDelete = Context.TblAdUsers
                              .Where(i => i.tblADUser_ID == tblAdUserId)
                              .Include(i => i.TblSpeakers)
                              .Include(i => i.TblCoreAttendances)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblAdUserDeleted(itemToDelete);

            Context.TblAdUsers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblAdUserDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnTblAdUserGet(Models.Core.TblAdUser item);

        public async Task<Models.Core.TblAdUser> GetTblAdUserBytblAdUserId(int? tblAdUserId)
        {
            var items = Context.TblAdUsers
                              .AsNoTracking()
                              .Where(i => i.tblADUser_ID == tblAdUserId);

            var itemToReturn = items.FirstOrDefault();

            OnTblAdUserGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Core.TblAdUser> CancelTblAdUserChanges(Models.Core.TblAdUser item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblAdUserUpdated(Models.Core.TblAdUser item);
        partial void OnAfterTblAdUserUpdated(Models.Core.TblAdUser item);

        public async Task<Models.Core.TblAdUser> UpdateTblAdUser(int? tblAdUserId, Models.Core.TblAdUser tblAdUser)
        {
            OnTblAdUserUpdated(tblAdUser);

            var itemToUpdate = Context.TblAdUsers
                              .Where(i => i.tblADUser_ID == tblAdUserId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblAdUser);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterTblAdUserUpdated(tblAdUser);

            return tblAdUser;
        }

        partial void OnTblCoreAttendanceDeleted(Models.Core.TblCoreAttendance item);
        partial void OnAfterTblCoreAttendanceDeleted(Models.Core.TblCoreAttendance item);

        public async Task<Models.Core.TblCoreAttendance> DeleteTblCoreAttendance(int? tblCoreAttendanceId)
        {
            var itemToDelete = Context.TblCoreAttendances
                              .Where(i => i.tblCOREAttendance_ID == tblCoreAttendanceId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblCoreAttendanceDeleted(itemToDelete);

            Context.TblCoreAttendances.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblCoreAttendanceDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnTblCoreAttendanceGet(Models.Core.TblCoreAttendance item);

        public async Task<Models.Core.TblCoreAttendance> GetTblCoreAttendanceBytblCoreAttendanceId(int? tblCoreAttendanceId)
        {
            var items = Context.TblCoreAttendances
                              .AsNoTracking()
                              .Where(i => i.tblCOREAttendance_ID == tblCoreAttendanceId);

            items = items.Include(i => i.TblEvent);

            items = items.Include(i => i.TblAdUser);

            var itemToReturn = items.FirstOrDefault();

            OnTblCoreAttendanceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Core.TblCoreAttendance> CancelTblCoreAttendanceChanges(Models.Core.TblCoreAttendance item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblCoreAttendanceUpdated(Models.Core.TblCoreAttendance item);
        partial void OnAfterTblCoreAttendanceUpdated(Models.Core.TblCoreAttendance item);

        public async Task<Models.Core.TblCoreAttendance> UpdateTblCoreAttendance(int? tblCoreAttendanceId, Models.Core.TblCoreAttendance tblCoreAttendance)
        {
            OnTblCoreAttendanceUpdated(tblCoreAttendance);

            var itemToUpdate = Context.TblCoreAttendances
                              .Where(i => i.tblCOREAttendance_ID == tblCoreAttendanceId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblCoreAttendance);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterTblCoreAttendanceUpdated(tblCoreAttendance);

            return tblCoreAttendance;
        }

        partial void OnTblEventDeleted(Models.Core.TblEvent item);
        partial void OnAfterTblEventDeleted(Models.Core.TblEvent item);

        public async Task<Models.Core.TblEvent> DeleteTblEvent(int? tblEventId)
        {
            var itemToDelete = Context.TblEvents
                              .Where(i => i.tblEvent_ID == tblEventId)
                              .Include(i => i.TblCoreAttendances)
                              .Include(i => i.TblVolunteerSpeakerRequests)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblEventDeleted(itemToDelete);

            Context.TblEvents.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblEventDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnTblEventGet(Models.Core.TblEvent item);

        public async Task<Models.Core.TblEvent> GetTblEventBytblEventId(int? tblEventId)
        {
            var items = Context.TblEvents
                              .AsNoTracking()
                              .Where(i => i.tblEvent_ID == tblEventId);

            items = items.Include(i => i.TblHospital);

            var itemToReturn = items.FirstOrDefault();

            OnTblEventGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Core.TblEvent> CancelTblEventChanges(Models.Core.TblEvent item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblEventUpdated(Models.Core.TblEvent item);
        partial void OnAfterTblEventUpdated(Models.Core.TblEvent item);

        public async Task<Models.Core.TblEvent> UpdateTblEvent(int? tblEventId, Models.Core.TblEvent tblEvent)
        {
            OnTblEventUpdated(tblEvent);

            var itemToUpdate = Context.TblEvents
                              .Where(i => i.tblEvent_ID == tblEventId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblEvent);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterTblEventUpdated(tblEvent);

            return tblEvent;
        }

        partial void OnTblHospitalDeleted(Models.Core.TblHospital item);
        partial void OnAfterTblHospitalDeleted(Models.Core.TblHospital item);

        public async Task<Models.Core.TblHospital> DeleteTblHospital(int? hospitalId)
        {
            var itemToDelete = Context.TblHospitals
                              .Where(i => i.HospitalID == hospitalId)
                              .Include(i => i.TblEvents)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblHospitalDeleted(itemToDelete);

            Context.TblHospitals.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblHospitalDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnTblHospitalGet(Models.Core.TblHospital item);

        public async Task<Models.Core.TblHospital> GetTblHospitalByHospitalId(int? hospitalId)
        {
            var items = Context.TblHospitals
                              .AsNoTracking()
                              .Where(i => i.HospitalID == hospitalId);

            var itemToReturn = items.FirstOrDefault();

            OnTblHospitalGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Core.TblHospital> CancelTblHospitalChanges(Models.Core.TblHospital item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblHospitalUpdated(Models.Core.TblHospital item);
        partial void OnAfterTblHospitalUpdated(Models.Core.TblHospital item);

        public async Task<Models.Core.TblHospital> UpdateTblHospital(int? hospitalId, Models.Core.TblHospital tblHospital)
        {
            OnTblHospitalUpdated(tblHospital);

            var itemToUpdate = Context.TblHospitals
                              .Where(i => i.HospitalID == hospitalId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblHospital);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterTblHospitalUpdated(tblHospital);

            return tblHospital;
        }

        partial void OnTblSpeakerDeleted(Models.Core.TblSpeaker item);
        partial void OnAfterTblSpeakerDeleted(Models.Core.TblSpeaker item);

        public async Task<Models.Core.TblSpeaker> DeleteTblSpeaker(int? tblSpeakerId)
        {
            var itemToDelete = Context.TblSpeakers
                              .Where(i => i.tblSpeaker_ID == tblSpeakerId)
                              .Include(i => i.TblVolunteerSpeakerRequests)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblSpeakerDeleted(itemToDelete);

            Context.TblSpeakers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblSpeakerDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnTblSpeakerGet(Models.Core.TblSpeaker item);

        public async Task<Models.Core.TblSpeaker> GetTblSpeakerBytblSpeakerId(int? tblSpeakerId)
        {
            var items = Context.TblSpeakers
                              .AsNoTracking()
                              .Where(i => i.tblSpeaker_ID == tblSpeakerId);

            items = items.Include(i => i.TblAdUser);

            var itemToReturn = items.FirstOrDefault();

            OnTblSpeakerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Core.TblSpeaker> CancelTblSpeakerChanges(Models.Core.TblSpeaker item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblSpeakerUpdated(Models.Core.TblSpeaker item);
        partial void OnAfterTblSpeakerUpdated(Models.Core.TblSpeaker item);

        public async Task<Models.Core.TblSpeaker> UpdateTblSpeaker(int? tblSpeakerId, Models.Core.TblSpeaker tblSpeaker)
        {
            OnTblSpeakerUpdated(tblSpeaker);

            var itemToUpdate = Context.TblSpeakers
                              .Where(i => i.tblSpeaker_ID == tblSpeakerId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblSpeaker);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterTblSpeakerUpdated(tblSpeaker);

            return tblSpeaker;
        }

        partial void OnTblVolunteerSpeakerRequestDeleted(Models.Core.TblVolunteerSpeakerRequest item);
        partial void OnAfterTblVolunteerSpeakerRequestDeleted(Models.Core.TblVolunteerSpeakerRequest item);

        public async Task<Models.Core.TblVolunteerSpeakerRequest> DeleteTblVolunteerSpeakerRequest(int? tblVolunteerSpeakerRequestsId)
        {
            var itemToDelete = Context.TblVolunteerSpeakerRequests
                              .Where(i => i.tblVolunteerSpeakerRequests_ID == tblVolunteerSpeakerRequestsId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTblVolunteerSpeakerRequestDeleted(itemToDelete);

            Context.TblVolunteerSpeakerRequests.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTblVolunteerSpeakerRequestDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnTblVolunteerSpeakerRequestGet(Models.Core.TblVolunteerSpeakerRequest item);

        public async Task<Models.Core.TblVolunteerSpeakerRequest> GetTblVolunteerSpeakerRequestBytblVolunteerSpeakerRequestsId(int? tblVolunteerSpeakerRequestsId)
        {
            var items = Context.TblVolunteerSpeakerRequests
                              .AsNoTracking()
                              .Where(i => i.tblVolunteerSpeakerRequests_ID == tblVolunteerSpeakerRequestsId);

            items = items.Include(i => i.TblEvent);

            items = items.Include(i => i.TblSpeaker);

            var itemToReturn = items.FirstOrDefault();

            OnTblVolunteerSpeakerRequestGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Core.TblVolunteerSpeakerRequest> CancelTblVolunteerSpeakerRequestChanges(Models.Core.TblVolunteerSpeakerRequest item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTblVolunteerSpeakerRequestUpdated(Models.Core.TblVolunteerSpeakerRequest item);
        partial void OnAfterTblVolunteerSpeakerRequestUpdated(Models.Core.TblVolunteerSpeakerRequest item);

        public async Task<Models.Core.TblVolunteerSpeakerRequest> UpdateTblVolunteerSpeakerRequest(int? tblVolunteerSpeakerRequestsId, Models.Core.TblVolunteerSpeakerRequest tblVolunteerSpeakerRequest)
        {
            OnTblVolunteerSpeakerRequestUpdated(tblVolunteerSpeakerRequest);

            var itemToUpdate = Context.TblVolunteerSpeakerRequests
                              .Where(i => i.tblVolunteerSpeakerRequests_ID == tblVolunteerSpeakerRequestsId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tblVolunteerSpeakerRequest);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterTblVolunteerSpeakerRequestUpdated(tblVolunteerSpeakerRequest);

            return tblVolunteerSpeakerRequest;
        }
    }
}
