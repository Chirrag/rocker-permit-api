using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Api.Model;
using Roker.Permit.Domain.QueryParams.Admin.Permits;

namespace Roker.Permit.Api.Controllers.Admin
{
    [Route("admin/permits")]
    public class PermitsController : BaseController
    {
        [HttpPost("list")]
        public async Task<QueryPermit.Response> GetPermits([FromBody]QueryPermit.Request request)
        {
            return await Executor.SendAsync(request);
        }

        [HttpGet("{permitApplicationId}/review")]
        public async Task<QueryPermitDetails.Response> GetPermitDetails(int permitApplicationId)
        {
            return await Executor.SendAsync(new QueryPermitDetails.Request
            {
                PermitApplicationId = permitApplicationId
            });
        }

        [HttpGet("{permitApplicationId}/shortreview")]
        public async Task<QueryPermitShortDetails.Response> GetShortPermitDetails(int permitApplicationId)
        {
            return await Executor.SendAsync(new QueryPermitShortDetails.Request
            {
                PermitApplicationId = permitApplicationId
            });
        }


        [HttpPost("checklist/status")]
        public async Task<PermitCheckListStatus.Response> UpdatePermitCheckListStatus([FromBody]PermitCheckListStatus.Request request)
        {
            return await Executor.SendAsync(request);
        }

        [HttpPost("checklist/comment")]
        public async Task<PermitCheckListComments.Response> AddPermitCheckListComment([FromBody]PermitCheckListComments.Request request)
        {
            request.Token = await HttpContext.GetTokenAsync("access_token");
            return await Executor.SendAsync(request);
        }

        [HttpPut("{permitApplicationId}/cancel")]
        public async Task<CancelPermitApplication.Response> SetPermitAsCanceled(int permitApplicationId)
        {
            return await Executor.SendAsync(new CancelPermitApplication.Request
            {
                PermitApplicationId = permitApplicationId,
                Token = await HttpContext.GetTokenAsync("access_token")
            });
        }

        [HttpPut("{permitApplicationId}/reject")]
        public async Task<RejectPermitApplication.Response> SetPermitAsRejected(int permitApplicationId, [FromBody]PermitStatusModel model)
        {
            return await Executor.SendAsync(new RejectPermitApplication.Request
            {
                PermitApplicationId = permitApplicationId,
                Comment = model.Comment,
                Token = await HttpContext.GetTokenAsync("access_token")
            });
        }

        [HttpPut("{permitApplicationId}/approve")]
        public async Task<ApprovePermitApplication.Response> SetPermitAsApproved(int permitApplicationId)
        {
            return await Executor.SendAsync(new ApprovePermitApplication.Request
            {
                PermitApplicationId = permitApplicationId,
                Token = await HttpContext.GetTokenAsync("access_token")
            });
        }

        [HttpPut("{permitApplicationId}/inprogress")]
        public async Task<InProgressPermitApplication.Response> SetPermitAsInprogress(int permitApplicationId)
        {
            return await Executor.SendAsync(new InProgressPermitApplication.Request
            {
                PermitApplicationId = permitApplicationId
            });
        }
    }
}