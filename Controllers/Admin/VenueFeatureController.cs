using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Admin.VenueFeatures;
namespace Roker.Permit.Api.Controllers.Admin
{
    [Route("admin/venuefeature")]
    public class VenueFeatureController : BaseController
    {
        [HttpPost("list")]
        public async Task<QueryVenueFeature.Response> GetList([FromBody] QueryVenueFeature.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPost("add")]
        public async Task<AddVenueFeature.Response> Add([FromBody] AddVenueFeature.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpGet("{venueFeatureId}/detail")]
        public async Task<QueryVenueFeatureDetail.Response> GetDetail(short venueFeatureId)
        {
            return await Executor.SendAsync(new QueryVenueFeatureDetail.Request
            {
                VenueFeatureId = venueFeatureId
            });
        }
        [HttpDelete("{venueFeatureId}/delete")]
        public async Task<DeleteVenueFeature.Response> Delete(short venueFeatureId)
        {
            return await Executor.SendAsync(new DeleteVenueFeature.Request
            {
                VenueFeatureId = venueFeatureId
            });
        }
        [HttpPut("edit")]
        public async Task<EditVenueFeature.Response> Edit([FromBody] EditVenueFeature.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPut("activate")]
        public async Task<ActivateVenueFeature.Response> Activate([FromBody] ActivateVenueFeature.Request request)
        {
            return await Executor.SendAsync(request);
        }
    }
}
