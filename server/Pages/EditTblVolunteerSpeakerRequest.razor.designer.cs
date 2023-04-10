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
    public partial class EditTblVolunteerSpeakerRequestComponent : ComponentBase
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
        public dynamic tblVolunteerSpeakerRequests_ID { get; set; }

        CoreRadzen.Models.Core.TblVolunteerSpeakerRequest _tblvolunteerspeakerrequest;
        protected CoreRadzen.Models.Core.TblVolunteerSpeakerRequest tblvolunteerspeakerrequest
        {
            get
            {
                return _tblvolunteerspeakerrequest;
            }
            set
            {
                if (!object.Equals(_tblvolunteerspeakerrequest, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "tblvolunteerspeakerrequest", NewValue = value, OldValue = _tblvolunteerspeakerrequest };
                    _tblvolunteerspeakerrequest = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<CoreRadzen.Models.Core.TblSpeaker> _getTblSpeakersResult;
        protected IEnumerable<CoreRadzen.Models.Core.TblSpeaker> getTblSpeakersResult
        {
            get
            {
                return _getTblSpeakersResult;
            }
            set
            {
                if (!object.Equals(_getTblSpeakersResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTblSpeakersResult", NewValue = value, OldValue = _getTblSpeakersResult };
                    _getTblSpeakersResult = value;
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
            var coreGetTblVolunteerSpeakerRequestBytblVolunteerSpeakerRequestsIdResult = await Core.GetTblVolunteerSpeakerRequestBytblVolunteerSpeakerRequestsId(tblVolunteerSpeakerRequests_ID);
            tblvolunteerspeakerrequest = coreGetTblVolunteerSpeakerRequestBytblVolunteerSpeakerRequestsIdResult;

            var coreGetTblSpeakersResult = await Core.GetTblSpeakers();
            getTblSpeakersResult = coreGetTblSpeakersResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(CoreRadzen.Models.Core.TblVolunteerSpeakerRequest args)
        {
            try
            {
                var coreUpdateTblVolunteerSpeakerRequestResult = await Core.UpdateTblVolunteerSpeakerRequest(tblVolunteerSpeakerRequests_ID, tblvolunteerspeakerrequest);
                DialogService.Close(tblvolunteerspeakerrequest);
            }
            catch (System.Exception coreUpdateTblVolunteerSpeakerRequestException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update TblVolunteerSpeakerRequest" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
