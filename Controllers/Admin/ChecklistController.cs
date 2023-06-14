using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Admin.Checklists;
using System.Threading.Tasks;

namespace Roker.Permit.Api.Controllers.Admin
{
    [Route("admin/checklist")]    
    public class ChecklistController : BaseController
    {
        [HttpPost("list")]
        public async Task<QueryChecklist.Response> GetCheckList([FromBody] QueryChecklist.Request request)
        {
            return await Executor.SendAsync(request);
        }
    }
}
