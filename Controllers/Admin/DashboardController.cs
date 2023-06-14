using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Admin.Dashboard;

namespace Roker.Permit.Api.Controllers.Admin
{
    [Route("admin/dashboard")]
    public class DashboardController : BaseController
    {
        [HttpGet("scoreboard")]
        public async Task<QueryDashboard.Response> GetList(QueryDashboard.Request request)
        {
            return await Executor.SendAsync(request);
        }
    }
}
