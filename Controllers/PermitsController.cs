using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Permit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Roker.Permit.Api.Controllers
{
    [Route("permits")]
    public class PermitsController : BaseController
    {
        [HttpPost("list")]
        public async Task<QueryPermit.Response> GetPermitList([FromBody]QueryPermit.Request request)
        {
            return await Executor.SendAsync(request);
        }

        [HttpGet("{permitApplicationId}/review")]
        public async Task<QueryPermitReviewDetail.Response> GetPermitReviewDetails(int permitApplicationId)
        {
            return await Executor.SendAsync(new QueryPermitReviewDetail.Request
            {
                PermitApplicationId = permitApplicationId
            });
        }

        [HttpPost("book")]
        public async Task<NewPermitApplication.Response> BookPermit([FromBody]NewPermitApplication.Request request)
        {
            request.Token = await HttpContext.GetTokenAsync("access_token");
            return await Executor.SendAsync(request);
        }

        [HttpGet("availablezone")]
        public async Task<QueryAvailableZone.Response> GetAvailableZone(QueryAvailableZone.Request request)
        {
            return await Executor.SendAsync(request);
        }

        [HttpPut("{permitApplicationId}/cancel")]
        public async Task<CancelPermit.Response> CancelPermit(int permitApplicationId)
        {
            // using token to pass it to notification services
            var token = await HttpContext.GetTokenAsync("access_token");
            return await Executor.SendAsync(new CancelPermit.Request
            {
                PermitApplicationId = permitApplicationId,
                Token = token
            });
        }

        [HttpGet("{permitApplicationId}/embed")]
        public async Task<GenerateBarcode.Response> GenerateBarcode(int permitApplicationId)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            return await Executor.SendAsync(new GenerateBarcode.Request
            {
                PermitApplicationId = permitApplicationId,
                Token = token
            });
        }

        [HttpGet("{permitApplicationId}/detail")]
        public async Task<QueryPermitDetail.Response> GetPermitDetails(int permitApplicationId)
        {
            return await Executor.SendAsync(new QueryPermitDetail.Request
            {
                PermitApplicationId = permitApplicationId
            });
        }

        [HttpPut("renew")]
        public async Task<RenewPermitApplication.Response> RenewPermitDetail([FromBody] RenewPermitApplication.Request request)
        {
            request.Token = await HttpContext.GetTokenAsync("access_token");
            return await Executor.SendAsync(request);
        }

        [HttpGet("fees")]
        public async Task<QueryFeesByPricingPackage.Response> GetFeesByPricingPackage(QueryFeesByPricingPackage.Request request)
        {
            return await Executor.SendAsync(request);
        }
    }
}