using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Reports.Analytics;
using System.Threading.Tasks;

namespace Roker.Permit.Api.Controllers.Report
{
    [Route("admin/Analytic")]
    public class AnalyticReportController : BaseController
    {
        [HttpGet("permit")]
        public async Task<QueryPermitStatusAnalytics.Response> GetPermitStatusReport(QueryPermitStatusAnalytics.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPost("zonewise")]
        public async Task<QueryZoneWiseAnalytic.Response> GetZoneWiseReport([FromBody]QueryZoneWiseAnalytic.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpGet("payment")]
        public async Task<QueryPaymentAnalytics.Response> GetPaymentReport(QueryPaymentAnalytics.Request request)
        {
            return await Executor.SendAsync(request);
        }
    }
}
