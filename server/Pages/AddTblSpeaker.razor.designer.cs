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
    public partial class AddTblSpeakerComponent : ComponentBase
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

        IEnumerable<CoreRadzen.Models.Core.TblAdUser> _getTblAdUsersFortblADUser_IDResult;
        protected IEnumerable<CoreRadzen.Models.Core.TblAdUser> getTblAdUsersFortblADUser_IDResult
        {
            get
            {
                return _getTblAdUsersFortblADUser_IDResult;
            }
            set
            {
                if (!object.Equals(_getTblAdUsersFortblADUser_IDResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTblAdUsersFortblADUser_IDResult", NewValue = value, OldValue = _getTblAdUsersFortblADUser_IDResult };
                    _getTblAdUsersFortblADUser_IDResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        CoreRadzen.Models.Core.TblSpeaker _tblspeaker;
        protected CoreRadzen.Models.Core.TblSpeaker tblspeaker
        {
            get
            {
                return _tblspeaker;
            }
            set
            {
                if (!object.Equals(_tblspeaker, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "tblspeaker", NewValue = value, OldValue = _tblspeaker };
                    _tblspeaker = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        List<string> _connectionList;
        protected List<string> connectionList
        {
            get
            {
                return _connectionList;
            }
            set
            {
                if (!object.Equals(_connectionList, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "connectionList", NewValue = value, OldValue = _connectionList };
                    _connectionList = value;
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
            var coreGetTblAdUsersResult = await Core.GetTblAdUsers();
            getTblAdUsersFortblADUser_IDResult = coreGetTblAdUsersResult;

            tblspeaker = new CoreRadzen.Models.Core.TblSpeaker(){};

            connectionList = new List<string>(){"Donor Family", "Waiting List Candidate", "Recipient", "Recipient Family"};
        }

        protected async System.Threading.Tasks.Task Form0Submit(CoreRadzen.Models.Core.TblSpeaker args)
        {
            try
            {
                var coreCreateTblSpeakerResult = await Core.CreateTblSpeaker(tblspeaker);
                DialogService.Close(tblspeaker);
            }
            catch (System.Exception coreCreateTblSpeakerException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new TblSpeaker!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
