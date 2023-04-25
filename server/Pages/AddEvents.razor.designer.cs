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
    public partial class AddEventsComponent : ComponentBase
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

        decimal? _returnedRecord;
        protected decimal? returnedRecord
        {
            get
            {
                return _returnedRecord;
            }
            set
            {
                if (!object.Equals(_returnedRecord, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "returnedRecord", NewValue = value, OldValue = _returnedRecord };
                    _returnedRecord = value;
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
            var coreGetTblHospitalsResult = await Core.GetTblHospitals();
            getTblHospitalsForHospitalIDResult = coreGetTblHospitalsResult;

            tblevent = new CoreRadzen.Models.Core.TblEvent(){};

            tblevent.EventDate=DateTime.Now;tblevent.StartTime=DateTime.Now;tblevent.EndTime=DateTime.Now;
        }

        protected async System.Threading.Tasks.Task Form0Submit(CoreRadzen.Models.Core.TblEvent args)
        {
            try
            {
                var coreCreateTblEventResult = await Core.CreateTblEvent(tblevent);
                UriHelper.NavigateTo("events");
            }
            catch (System.Exception coreCreateTblEventException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new TblEvent!" });
            }
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var coreGetSpEventStartNewEventsResult = await Core.GetSpEventStartNewEvents($"{tblevent.EventDate}", $"{tblevent.StartTime}", $"{tblevent.EndTime}", tblevent.HospitalID);
            returnedRecord = coreGetSpEventStartNewEventsResult.First().scopeIdentityValue;

            UriHelper.NavigateTo($"edit-events/{returnedRecord}");
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("events");
        }
    }
}
