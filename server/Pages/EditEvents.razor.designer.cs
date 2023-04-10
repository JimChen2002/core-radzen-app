﻿using System;
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
    public partial class EditEventsComponent : ComponentBase
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

        [Parameter]
        public dynamic tblEvent_ID { get; set; }
        protected RadzenDataGrid<CoreRadzen.Models.Core.TblVolunteerSpeakerRequest> grid2;

        CoreRadzen.Models.Core.TblEvent _tblevent;
        protected CoreRadzen.Models.Core.TblEvent tblevent
        {
            get
            {
                return _tblevent;
            }
            set
            {
                if (!object.Equals(_tblevent, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "tblevent", NewValue = value, OldValue = _tblevent };
                    _tblevent = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<CoreRadzen.Models.Core.TblHospital> _getTblHospitalsForHospitalIDResult;
        protected IEnumerable<CoreRadzen.Models.Core.TblHospital> getTblHospitalsForHospitalIDResult
        {
            get
            {
                return _getTblHospitalsForHospitalIDResult;
            }
            set
            {
                if (!object.Equals(_getTblHospitalsForHospitalIDResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTblHospitalsForHospitalIDResult", NewValue = value, OldValue = _getTblHospitalsForHospitalIDResult };
                    _getTblHospitalsForHospitalIDResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<AudienceTypesDropDown> _audienceTypeList;
        protected IEnumerable<AudienceTypesDropDown> audienceTypeList
        {
            get
            {
                return _audienceTypeList;
            }
            set
            {
                if (!object.Equals(_audienceTypeList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "audienceTypeList", NewValue = value, OldValue = _audienceTypeList };
                    _audienceTypeList = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<string> _selectedAudienceTypes;
        protected IEnumerable<string> selectedAudienceTypes
        {
            get
            {
                return _selectedAudienceTypes;
            }
            set
            {
                if (!object.Equals(_selectedAudienceTypes, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedAudienceTypes", NewValue = value, OldValue = _selectedAudienceTypes };
                    _selectedAudienceTypes = value;
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
            var coreGetTblEventBytblEventIdResult = await Core.GetTblEventBytblEventId(Convert.ChangeType(tblEvent_ID, Type.GetTypeCode(typeof(int))));
            tblevent = coreGetTblEventBytblEventIdResult;

            var coreGetTblHospitalsResult = await Core.GetTblHospitals();
            getTblHospitalsForHospitalIDResult = coreGetTblHospitalsResult;

            audienceTypeList = new List<AudienceTypesDropDown>(){new AudienceTypesDropDown(){Id=1,Name="a"}, new AudienceTypesDropDown(){Id=2,Name="b"}};

            selectedAudienceTypes = !string.IsNullOrEmpty(tblevent.AudienceTypes) ? tblevent.AudienceTypes.Split(';') : Enumerable.Empty<string>();;

            var coreGetTblVolunteerSpeakerRequestsResult = await Core.GetTblVolunteerSpeakerRequests(new Query() { Filter = $@"i => i.tblEvent_ID == {tblEvent_ID}" });
            TblVolunteerSpeakerRequests = coreGetTblVolunteerSpeakerRequestsResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(CoreRadzen.Models.Core.TblEvent args)
        {
            try
            {
                var coreUpdateTblEventResult = await Core.UpdateTblEvent(Convert.ChangeType(tblEvent_ID, Type.GetTypeCode(typeof(int))), tblevent);
                UriHelper.NavigateTo("tbl-events");
            }
            catch (System.Exception coreUpdateTblEventException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update TblEvent" });
            }
        }

        protected async System.Threading.Tasks.Task TblVolunteerSpeakerRequestAddButtonClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTblVolunteerSpeakerRequest>("Add Tbl Volunteer Speaker Request", new Dictionary<string, object>() { {"tblEvent_ID", tblEvent_ID} });
            await grid2.Reload();
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTblSpeaker>("Add Tbl Speaker", null);
            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid2RowSelect(CoreRadzen.Models.Core.TblVolunteerSpeakerRequest args)
        {
            UriHelper.NavigateTo($"edit-tbl-volunteer-speaker-request/{args.tblVolunteerSpeakerRequests_ID}");
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

        protected async System.Threading.Tasks.Task Dropdown0Change(dynamic args)
        {
            tblevent.AudienceTypes = string.Join(';', selectedAudienceTypes);
        }

        protected async System.Threading.Tasks.Task Button4Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("tbl-events");
        }
    }
}
