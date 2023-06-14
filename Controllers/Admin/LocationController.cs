using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Admin.Locations;

namespace Roker.Permit.Api.Controllers.Admin
{
    [Route("admin/locations")]
    public class LocationController : BaseController
    {
        [HttpPost("list")]
        public async Task<QueryLocation.Response> GetList([FromBody] QueryLocation.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPost("add")]
        public async Task<AddLocation.Response> Add([FromBody] AddLocation.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpGet("{locationId}/detail")]
        public async Task<QueryLocationDetail.Response> GetDetail(int locationId)
        {
            return await Executor.SendAsync(new QueryLocationDetail.Request
            {
                LocationId = locationId
            });
        }
        [HttpDelete("{locationId}/delete")]
        public async Task<DeleteLocation.Response> Delete(int locationId)
        {
            return await Executor.SendAsync(new DeleteLocation.Request
            {
                LocationId = locationId
            });
        }
        [HttpPut("edit")]
        public async Task<EditLocation.Response> Edit([FromBody] EditLocation.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPut("activate")]
        public async Task<ActivateLocation.Response> Activate([FromBody] ActivateLocation.Request request)
        {
            return await Executor.SendAsync(request);
        }
    }
}
