using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Reports.BasicReports;


namespace Roker.Permit.Api.Controllers.Report
{
    [Route("admin/report")]
    public class BasicReportController : BaseController
    {
        [HttpPost("permit")]
        public async Task<QueryBasicReport.Response> GetPermitReport([FromBody] QueryBasicReport.PermitRequest request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPost("zonewise")]
        public async Task<QueryBasicReport.Response> GetZoneReport([FromBody] QueryBasicReport.ZoneRequest request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpGet("reporttype")]
        public async Task<QueryReportType.Response> GetReportType([FromBody] QueryReportType.Request request)
        {
            return await Executor.SendAsync(request);
        }

        [HttpPost("payment")]
        public async Task<QueryBasicReport.Response> GetPaymentReport([FromBody]QueryBasicReport.PaymentRequest request)
        {
            return await Executor.SendAsync(request);
        }
    }
}
