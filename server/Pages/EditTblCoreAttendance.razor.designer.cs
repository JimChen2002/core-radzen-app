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
    public partial class EditTblCoreAttendanceComponent : ComponentBase
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
        public dynamic tblCOREAttendance_ID { get; set; }

        CoreRadzen.Models.Core.TblCoreAttendance _tblcoreattendance;
        protected CoreRadzen.Models.Core.TblCoreAttendance tblcoreattendance
        {
            get
            {
                return _tblcoreattendance;
            }
            set
            {
                if (!object.Equals(_tblcoreattendance, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "tblcoreattendance", NewValue = value, OldValue = _tblcoreattendance };
                    _tblcoreattendance = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<CoreRadzen.Models.Core.TblAdUser> _getTblAdUsersResult;
        protected IEnumerable<CoreRadzen.Models.Core.TblAdUser> getTblAdUsersResult
        {
            get
            {
                return _getTblAdUsersResult;
            }
            set
            {
                if (!object.Equals(_getTblAdUsersResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTblAdUsersResult", NewValue = value, OldValue = _getTblAdUsersResult };
                    _getTblAdUsersResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _isAdmin;
        protected bool isAdmin
        {
            get
            {
                return _isAdmin;
            }
            set
            {
                if (!object.Equals(_isAdmin, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "isAdmin", NewValue = value, OldValue = _isAdmin };
                    _isAdmin = value;
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
            var coreGetTblCoreAttendanceBytblCoreAttendanceIdResult = await Core.GetTblCoreAttendanceBytblCoreAttendanceId(tblCOREAttendance_ID);
            tblcoreattendance = coreGetTblCoreAttendanceBytblCoreAttendanceIdResult;

            var coreGetTblAdUsersResult = await Core.GetTblAdUsers();
            getTblAdUsersResult = coreGetTblAdUsersResult;

            var coreGetTblAdminUsersResult = await Core.GetTblAdminUsers(new Query() { Filter = $@"i => string.Equals(i.UserName, ""{Security.User?.Name}"")" });
            isAdmin = coreGetTblAdminUsersResult.Count() > 0;
        }

        protected async System.Threading.Tasks.Task Form0Submit(CoreRadzen.Models.Core.TblCoreAttendance args)
        {
            try
            {
                var coreUpdateTblCoreAttendanceResult = await Core.UpdateTblCoreAttendance(tblCOREAttendance_ID, tblcoreattendance);
                DialogService.Close(tblcoreattendance);
            }
            catch (System.Exception coreUpdateTblCoreAttendanceException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update TblCoreAttendance" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
