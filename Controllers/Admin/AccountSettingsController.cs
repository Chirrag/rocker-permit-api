using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Admin.AccountSettings;

namespace Roker.Permit.Api.Controllers.Admin
{
    [Route("admin/accountsettings")]
    public class AccountSettingsController : BaseController
    {
        [HttpGet("keys")]
        public async Task<QueryAccountSetting.Response> GetList()
        {
            return await Executor.SendAsync(new QueryAccountSetting.Request());
        }

        [HttpPut]
        public async Task<UpdateAccountSetting.Response> Update([FromBody] UpdateAccountSetting.Request request)
        {
            return await Executor.SendAsync(request);
        }
    }
}
