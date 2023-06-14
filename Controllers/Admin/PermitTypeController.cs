using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Admin.PermitType;

namespace Roker.Permit.Api.Controllers.Admin
{
    [Route("admin/permittype")]   
    public class PermitTypeController : BaseController
    {
        [HttpPost("list")]
        public async Task<QueryPermitType.Response> GetPermitTypeList([FromBody] QueryPermitType.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPost("add")]
        public async Task<AddPermitType.Response> AddPermitType([FromBody]  AddPermitType.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPut("activate")]
        public async Task<ActivatePermitType.Response> ActivatePermitType([FromBody] ActivatePermitType.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPut("edit")]
        public async Task<EditPermitType.Response> UpdatePermitType([FromBody] EditPermitType.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpDelete("{permitTypeId}/delete")]
        public async Task<DeletePermitType.Response> DeletePermitType(int permitTypeId)
        {
            return await Executor.SendAsync(new DeletePermitType.Request { PermitTypeId = permitTypeId });
        }
        [HttpGet("{permitTypeId}/detail")]
        public async Task<QueryPermitTypeDetail.Response> GetPermitTypeDetail(int permitTypeId)
        {
            return await Executor.SendAsync(new QueryPermitTypeDetail.Request { PermitTypeId = permitTypeId });
        }

        [HttpGet("{permitTypeId}/checklists")]
        public async Task<QueryPermitTypeChecklist.Response> GetCheckList(int permitTypeId)
        {
            return await Executor.SendAsync(new QueryPermitTypeChecklist.Request {PermitTypeId=permitTypeId });
        }
        [HttpPut("assignchecklists")]
        public async Task<AssignChecklistPermitType.Response> AssignCheckList([FromBody]AssignChecklistPermitType.Request request)
        {
            return await Executor.SendAsync(request);
        }
    }
}
