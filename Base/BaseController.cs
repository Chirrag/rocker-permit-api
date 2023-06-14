using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Roker.Permit.Domain.Infrastructure;

namespace Roker.Permit.Api.Base
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : ControllerBase
    {
        private IExecutor _executor;

        protected IExecutor Executor => _executor ?? (_executor = HttpContext.RequestServices.GetService<IExecutor>());
    }
}