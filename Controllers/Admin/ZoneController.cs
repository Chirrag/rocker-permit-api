using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Admin.Zones;

namespace Roker.Permit.Api.Controllers.Admin
{
    [Route("admin/zone")]
    public class ZoneController : BaseController
    {
        [HttpPost("list")]
        public async Task<QueryZone.Response> GetZones([FromBody] QueryZone.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPost("add")]
        public async Task<AddZone.Response> AddZone([FromBody] AddZone.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPut("activate")]
        public async Task<ActivateZone.Response> ActivateZone([FromBody] ActivateZone.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPut("edit")]
        public async Task<EditZone.Response> UpdateZone([FromBody] EditZone.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpDelete("{zoneId}/delete")]
        public async Task<DeleteZone.Response> DeleteZone(int zoneId)
        {
            return await Executor.SendAsync(new DeleteZone.Request { ZoneId=zoneId });
        }
        [HttpGet("{zoneId}/detail")]
        public async Task<QueryZoneDetail.Response> GetZoneDetail(int zoneId)
        {
            return await Executor.SendAsync(new QueryZoneDetail.Request { ZoneId = zoneId });
        }
    }
}
