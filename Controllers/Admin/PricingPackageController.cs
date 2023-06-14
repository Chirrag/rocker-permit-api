using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Admin.PricingPackages;

namespace Roker.Permit.Api.Controllers.Admin
{
    [Route("admin/pricingpackage")]  
    public class PricingPackageController : BaseController
    {
        [HttpPost("list")]
        public async Task<QueryPricingPackage.Response> GetPricingPackageList([FromBody] QueryPricingPackage.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPost("add")]
        public async Task<AddPricingPackage.Response> AddPricingPackage([FromBody] AddPricingPackage.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPut("activate")]
        public async Task<ActivatePricingPackage.Response> ActivatePricingPackage([FromBody] ActivatePricingPackage.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPut("edit")]
        public async Task<EditPricingPackage.Response> UpdatePricingPackage([FromBody] EditPricingPackage.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpDelete("{pricingPackageId}/delete")]
        public async Task<DeletePricingPackage.Response> DeletePricingPackage(int pricingPackageId)
        {
            return await Executor.SendAsync(new DeletePricingPackage.Request { PricingPackageId = pricingPackageId });
        }
        [HttpGet("{pricingPackageId}/detail")]
        public async Task<QueryPricingPackageDetail.Response> GetPricingPackageDetail(int pricingPackageId)
        {
            return await Executor.SendAsync(new QueryPricingPackageDetail.Request { PricingPackageId = pricingPackageId });
        }
    }
}
