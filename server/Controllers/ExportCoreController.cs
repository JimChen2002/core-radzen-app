using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreRadzen.Data;

namespace CoreRadzen
{
    public partial class ExportCoreController : ExportController
    {
        private readonly CoreContext context;
        private readonly CoreService service;
        public ExportCoreController(CoreContext context, CoreService service)
        {
            this.service = service;
            this.context = context;
        }


        [HttpGet("/export/Core/speventstartnewevents/csv(EventDate='{EventDate}', StartTime='{StartTime}', EndTime='{EndTime}', HospitalID={HospitalID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSpEventStartNewEventsToCSV(string EventDate, string StartTime, string EndTime, int? HospitalID, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSpEventStartNewEvents(EventDate, StartTime, EndTime, HospitalID), Request.Query), fileName);
        }

        [HttpGet("/export/Core/speventstartnewevents/excel(EventDate='{EventDate}', StartTime='{StartTime}', EndTime='{EndTime}', HospitalID={HospitalID}, fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportSpEventStartNewEventsToExcel(string EventDate, string StartTime, string EndTime, int? HospitalID, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSpEventStartNewEvents(EventDate, StartTime, EndTime, HospitalID), Request.Query), fileName);
        }
        [HttpGet("/export/Core/tbladusers/csv")]
        [HttpGet("/export/Core/tbladusers/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTblAdUsersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblAdUsers(), Request.Query), fileName);
        }

        [HttpGet("/export/Core/tbladusers/excel")]
        [HttpGet("/export/Core/tbladusers/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTblAdUsersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblAdUsers(), Request.Query), fileName);
        }
        [HttpGet("/export/Core/tbladminusers/csv")]
        [HttpGet("/export/Core/tbladminusers/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTblAdminUsersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblAdminUsers(), Request.Query), fileName);
        }

        [HttpGet("/export/Core/tbladminusers/excel")]
        [HttpGet("/export/Core/tbladminusers/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTblAdminUsersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblAdminUsers(), Request.Query), fileName);
        }
        [HttpGet("/export/Core/tblcoreattendances/csv")]
        [HttpGet("/export/Core/tblcoreattendances/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTblCoreAttendancesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblCoreAttendances(), Request.Query), fileName);
        }

        [HttpGet("/export/Core/tblcoreattendances/excel")]
        [HttpGet("/export/Core/tblcoreattendances/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTblCoreAttendancesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblCoreAttendances(), Request.Query), fileName);
        }
        [HttpGet("/export/Core/tblevents/csv")]
        [HttpGet("/export/Core/tblevents/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTblEventsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblEvents(), Request.Query), fileName);
        }

        [HttpGet("/export/Core/tblevents/excel")]
        [HttpGet("/export/Core/tblevents/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTblEventsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblEvents(), Request.Query), fileName);
        }
        [HttpGet("/export/Core/tblhospitals/csv")]
        [HttpGet("/export/Core/tblhospitals/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTblHospitalsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblHospitals(), Request.Query), fileName);
        }

        [HttpGet("/export/Core/tblhospitals/excel")]
        [HttpGet("/export/Core/tblhospitals/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTblHospitalsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblHospitals(), Request.Query), fileName);
        }
        [HttpGet("/export/Core/tblspeakers/csv")]
        [HttpGet("/export/Core/tblspeakers/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTblSpeakersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblSpeakers(), Request.Query), fileName);
        }

        [HttpGet("/export/Core/tblspeakers/excel")]
        [HttpGet("/export/Core/tblspeakers/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTblSpeakersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblSpeakers(), Request.Query), fileName);
        }
        [HttpGet("/export/Core/tblvolunteerspeakerrequests/csv")]
        [HttpGet("/export/Core/tblvolunteerspeakerrequests/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTblVolunteerSpeakerRequestsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTblVolunteerSpeakerRequests(), Request.Query), fileName);
        }

        [HttpGet("/export/Core/tblvolunteerspeakerrequests/excel")]
        [HttpGet("/export/Core/tblvolunteerspeakerrequests/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportTblVolunteerSpeakerRequestsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTblVolunteerSpeakerRequests(), Request.Query), fileName);
        }
    }
}
