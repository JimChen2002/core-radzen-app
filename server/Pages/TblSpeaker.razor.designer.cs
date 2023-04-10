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
    public partial class TblSpeakerComponent : ComponentBase
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
        protected RadzenDataGrid<CoreRadzen.Models.Core.TblSpeaker> grid0;

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
            if (string.IsNullOrEmpty(search)) {
                search = "";
            }

            var coreGetTblSpeakersResult = await Core.GetTblSpeakers(new Query() { Filter = $@"i => i.Name.Contains(@0) || i.PhoneNumber.Contains(@1) || i.Email.Contains(@2) || i.Connection.Contains(@3) || i.Background.Contains(@4) || i.AccessibilityRequirements.Contains(@5) || i.Quote.Contains(@6)", FilterParameters = new object[] { search, search, search, search, search, search, search } });
            getTblSpeakersResult = coreGetTblSpeakersResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddTblSpeaker>("Add Tbl Speaker", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Core.ExportTblSpeakersToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "TblAdUser", Select = "tblSpeaker_ID,Name,PhoneNumber,Email,Connection,Background,AccessibilityRequirements,Quote,TblAdUser.UserName as TblAdUserUserName" }, $"Tbl Speaker");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Core.ExportTblSpeakersToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "TblAdUser", Select = "tblSpeaker_ID,Name,PhoneNumber,Email,Connection,Background,AccessibilityRequirements,Quote,TblAdUser.UserName as TblAdUserUserName" }, $"Tbl Speaker");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<CoreRadzen.Models.Core.TblSpeaker> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditTblSpeaker>("Edit Tbl Speaker", new Dictionary<string, object>() { {"tblSpeaker_ID", args.Data.tblSpeaker_ID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var coreDeleteTblSpeakerResult = await Core.DeleteTblSpeaker(data.tblSpeaker_ID);
                    if (coreDeleteTblSpeakerResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception coreDeleteTblSpeakerException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete TblSpeaker" });
            }
        }
    }
}
