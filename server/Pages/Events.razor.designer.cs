using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using CoreRadzen.Models.Core;
using Microsoft.EntityFrameworkCore;
using CoreRadzen.Models;

namespace CoreRadzen.Pages
{
    public partial class EventsComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected CoreService Core { get; set; }
        protected RadzenDataGrid<CoreRadzen.Models.Core.TblEvent> grid0;
        protected RadzenDataGrid<CoreRadzen.Models.Core.TblVolunteerSpeakerRequest> grid2;
        protected RadzenDataGrid<CoreRadzen.Models.Core.TblCoreAttendance> grid1;

        string _search;
        protected string search
        {
            get
            {
                return _search;
            }
            set
            {
                if (!object.Equals(_search, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "search", NewValue = value, OldValue = _search };
                    _search = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<CoreRadzen.Models.Core.TblEvent> _getTblEventsResult;
        protected IEnumerable<CoreRadzen.Models.Core.TblEvent> getTblEventsResult
        {
            get
            {
                return _getTblEventsResult;
            }
            set
            {
                if (!object.Equals(_getTblEventsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTblEventsResult", NewValue = value, OldValue = _getTblEventsResult };
                    _getTblEventsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        CoreRadzen.Models.Core.TblEvent _master;
        protected CoreRadzen.Models.Core.TblEvent master
        {
            get
            {
                return _master;
            }
            set
            {
                if (!object.Equals(_master, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "master", NewValue = value, OldValue = _master };
                    _master = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _lastFilter;
        protected string lastFilter
        {
            get
            {
                return _lastFilter;
            }
            set
            {
                if (!object.Equals(_lastFilter, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "lastFilter", NewValue = value, OldValue = _lastFilter };
                    _lastFilter = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<CoreRadzen.Models.Core.TblCoreAttendance> _TblCoreAttendances;
        protected IEnumerable<CoreRadzen.Models.Core.TblCoreAttendance> TblCoreAttendances
        {
            get
            {
                return _TblCoreAttendances;
            }
            set
            {
                if (!object.Equals(_TblCoreAttendances, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "TblCoreAttendances", NewValue = value, OldValue = _TblCoreAttendances };
                    _TblCoreAttendances = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<CoreRadzen.Models.Core.TblVolunteerSpeakerRequest> _TblVolunteerSpeakerRequests;
        protected IEnumerable<CoreRadzen.Models.Core.TblVolunteerSpeakerRequest> TblVolunteerSpeakerRequests
        {
            get
            {
                return _TblVolunteerSpeakerRequests;
            }
            set
            {
                if (!object.Equals(_TblVolunteerSpeakerRequests, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "TblVolunteerSpeakerRequests", NewValue = value, OldValue = _TblVolunteerSpeakerRequests };
                    _TblVolunteerSpeakerRequests = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Security.InitializeAsync(AuthenticationStateProvider);
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            if (string.IsNullOrEmpty(search)) {
                search = "";
            }

            var coreGetTblEventsResult = await Core.GetTblEvents(new Query() { Filter = $@"i => i.LocationDetails.Contains(@0) || i.EventType.Contains(@1) || i.EventDescription.Contains(@2) || i.EventDetails.Contains(@3) || i.SpeakerNeeds.Contains(@4) || i.LeadershipSpeaker.Contains(@5) || i.AudienceTypes.Contains(@6) || i.EstimatedAttendees.Contains(@7) || i.SocialMediaOrVideoNeeds.Contains(@8) || i.QuiltNumber.Contains(@9) || i.QuiltCoordinator.Contains(@10) || i.VehicleDriver.Contains(@11) || i.OnsiteContactName.Contains(@12) || i.OnsiteContactPhone.Contains(@13) || i.OnsiteContactEmail.Contains(@14) || i.PlaceToMeet.Contains(@15) || i.AdditionalInformation.Contains(@16)", FilterParameters = new object[] { search, search, search, search, search, search, search, search, search, search, search, search, search, search, search, search, search } });
            getTblEventsResult = coreGetTblEventsResult;
        }

        protected async void Grid0Render(DataGridRenderEventArgs<CoreRadzen.Models.Core.TblEvent> args)
        {
            if (grid0.Query.Filter != lastFilter) {
                master = grid0.View.FirstOrDefault();
            }

            if (grid0.Query.Filter != lastFilter)
            {
                await grid0.SelectRow(master);
            }

            lastFilter = grid0.Query.Filter;
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<CoreRadzen.Models.Core.TblEvent> args)
        {
            UriHelper.NavigateTo($"edit-events/{args.Data.tblEvent_ID}");
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CoreRadzen.Models.Core.TblEvent args)
        {
            master = args;

            if (args == null) {
                TblCoreAttendances = null;
            }

            if (args != null)
            {
                var coreGetTblCoreAttendancesResult = await Core.GetTblCoreAttendances(new Query() { Filter = $@"i => i.tblEvent_ID == {args.tblEvent_ID}" });
                TblCoreAttendances = coreGetTblCoreAttendancesResult;
            }

            if (args != null)
            {
                var coreGetTblVolunteerSpeakerRequestsResult = await Core.GetTblVolunteerSpeakerRequests(new Query() { Filter = $@"i => i.tblEvent_ID == {args.tblEvent_ID}" });
                TblVolunteerSpeakerRequests = coreGetTblVolunteerSpeakerRequestsResult;
            }
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var coreDeleteTblEventResult = await Core.DeleteTblEvent(data.tblEvent_ID);
                    if (coreDeleteTblEventResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception coreDeleteTblEventException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete TblEvent" });
            }
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("add-events");
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Core.ExportTblEventsToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "TblHospital", Select = "tblEvent_ID,EventDate,StartTime,EndTime,TblHospital.HospitalName as TblHospitalHospitalName,LocationDetails,EventType,EventDescription,EventDetails,SpeakerNeeds,LeadershipSpeakerRequested,LeadershipSpeaker,LeadershipSpeechLength,VolunteerSpeechLength,AudienceTypes,EstimatedAttendees,SocialMediaOrVideoNeeds,IsLegislatorsInvited,IsLegislatorsAttending,IsQuiltRequested,QuiltNumber,QuiltCoordinator,IsVehicleRequested,IsVehicleReserved,VehicleDriver,OnsiteContactName,OnsiteContactPhone,OnsiteContactEmail,IsLocked,PlaceToMeet,AdditionalInformation" }, $"Tbl Events");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Core.ExportTblEventsToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "TblHospital", Select = "tblEvent_ID,EventDate,StartTime,EndTime,TblHospital.HospitalName as TblHospitalHospitalName,LocationDetails,EventType,EventDescription,EventDetails,SpeakerNeeds,LeadershipSpeakerRequested,LeadershipSpeaker,LeadershipSpeechLength,VolunteerSpeechLength,AudienceTypes,EstimatedAttendees,SocialMediaOrVideoNeeds,IsLegislatorsInvited,IsLegislatorsAttending,IsQuiltRequested,QuiltNumber,QuiltCoordinator,IsVehicleRequested,IsVehicleReserved,VehicleDriver,OnsiteContactName,OnsiteContactPhone,OnsiteContactEmail,IsLocked,PlaceToMeet,AdditionalInformation" }, $"Tbl Events");

            }
        }

        protected async System.Threading.Tasks.Task Grid2RowSelect(CoreRadzen.Models.Core.TblVolunteerSpeakerRequest args)
        {
            var dialogResult = await DialogService.OpenAsync<EditTblVolunteerSpeakerRequest>("Edit Tbl Volunteer Speaker Request", new Dictionary<string, object>() { {"tblVolunteerSpeakerRequests_ID", args.tblVolunteerSpeakerRequests_ID} });
            await grid2.Reload();
        }

        protected async System.Threading.Tasks.Task TblVolunteerSpeakerRequestDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var coreDeleteTblVolunteerSpeakerRequestResult = await Core.DeleteTblVolunteerSpeakerRequest(data.tblVolunteerSpeakerRequests_ID);
                    if (coreDeleteTblVolunteerSpeakerRequestResult != null)
                    {
                        await grid2.Reload();
                    }
                }
            }
            catch (System.Exception coreDeleteTblVolunteerSpeakerRequestException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete TblEvent" });
            }
        }

        protected async System.Threading.Tasks.Task TblVolunteerSpeakerRequestAddButtonClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTblVolunteerSpeakerRequest>("Add Tbl Volunteer Speaker Request", new Dictionary<string, object>() { {"tblEvent_ID", master.tblEvent_ID} });
            await grid2.Reload();
        }

        protected async System.Threading.Tasks.Task Grid1RowSelect(CoreRadzen.Models.Core.TblCoreAttendance args)
        {
            var dialogResult = await DialogService.OpenAsync<EditTblCoreAttendance>("Edit Tbl Core Attendance", new Dictionary<string, object>() { {"tblCOREAttendance_ID", args.tblCOREAttendance_ID} });
            await grid1.Reload();
        }

        protected async System.Threading.Tasks.Task TblCoreAttendanceAddButtonClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTblCoreAttendance>("Add Tbl Core Attendance", new Dictionary<string, object>() { {"tblEvent_ID", master.tblEvent_ID} });
            await grid1.Reload();
        }
    }
}
