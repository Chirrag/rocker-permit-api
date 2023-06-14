using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Document.Permit;

namespace Roker.Permit.Api.Controllers.Document
{
    [Route("document/permit")]
    public class PermitDocumentController : BaseController
    {
        [HttpPost("add")]
        public async Task<AddPermitDocument.Response> AddDocuments([FromForm] AddPermitDocument.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpGet("{permitApplicationId}/list")]
        public async Task<QueryPermitDocument.Response> List(int permitApplicationId)
        {
            return await Executor.SendAsync(new QueryPermitDocument.Request{ 
                PermitApplicationId=permitApplicationId
            });
        }
    }
}
