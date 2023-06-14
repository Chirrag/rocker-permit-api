using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Admin.LicensePlateTypes;

namespace Roker.Permit.Api.Controllers.Admin
{
    [Route("admin/licenseplatetype")]  
    public class LicensePlateTypeController : BaseController
    {
        [HttpPost("list")]
        public async Task<QueryLicensePlateType.Response> GetList([FromBody] QueryLicensePlateType.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPost("add")]
        public async Task<AddLicensePlateType.Response> Add([FromBody] AddLicensePlateType.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpGet("{licensePlateTypeId}/detail")]
        public async Task<QueryLicensePlateTypeDetail.Response> GetDetail(short licensePlateTypeId)
        {
            return await Executor.SendAsync(new QueryLicensePlateTypeDetail.Request
            {
                LicensePlateTypeId = licensePlateTypeId
            });
        }
        [HttpDelete("{licensePlateTypeId}/delete")]
        public async Task<DeleteLicensePlateType.Response> Delete(short licensePlateTypeId)
        {
            return await Executor.SendAsync(new DeleteLicensePlateType.Request
            {
                LicensePlateTypeId = licensePlateTypeId
            });
        }
        [HttpPut("edit")]
        public async Task<EditLicensePlateType.Response> Edit([FromBody] EditLicensePlateType.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPut("activate")]
        public async Task<ActivateLicensePlateType.Response> Activate([FromBody] ActivateLicensePlateType.Request request)
        {
            return await Executor.SendAsync(request);
        }
    }
}
