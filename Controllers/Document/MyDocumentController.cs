using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Document.My;

namespace Roker.Document.Controllers
{
    [Route("document/my")]  
    public class MyDocumentController : BaseController
    {       
        [HttpPost("add")]
        public async Task<AddMyDocument.Response> AddDocuments([FromForm] AddMyDocument.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpDelete("{documentId}/delete")]
        public async Task<DeleteMyDocument.Response> DeleteDocuments(int documentId)
        {
            return await Executor.SendAsync(new DeleteMyDocument.Request { 
                DocumentId=documentId
            });
        }
        [HttpGet("list")]
        public async Task<QueryMyDocument.Response> ListDocuments()
        {
            return await Executor.SendAsync(new QueryMyDocument.Request
            {
            });
        }
       
    }
}
