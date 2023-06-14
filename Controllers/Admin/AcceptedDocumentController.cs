using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Admin.AcceptedDocuments;
using System.Threading.Tasks;

namespace Roker.Permit.Api.Controllers.Admin
{
    [Route("admin/accepteddocument")]
  
    public class AcceptedDocumentController : BaseController
    {
        [HttpPost("list")]
        public async Task<QueryAcceptedDocument.Response> GetDocumentList([FromBody] QueryAcceptedDocument.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPost("add")]
        public async Task<AddAcceptedDocument.Response> AddDocuments([FromBody] AddAcceptedDocument.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpGet("{acceptedDocumentId}/detail")]
        public async Task<QueryAcceptedDocumentDetail.Response> GetDocumentDetail(short acceptedDocumentId)
        {
            return await Executor.SendAsync(new QueryAcceptedDocumentDetail.Request { 
                AcceptedDocumentId= acceptedDocumentId
            });
        }
        [HttpDelete("{acceptedDocumentId}/delete")]
        public async Task<DeleteAcceptedDocument.Response> DeleteDocument(short acceptedDocumentId)
        {
            return await Executor.SendAsync(new DeleteAcceptedDocument.Request
            {
                AcceptedDocumentId = acceptedDocumentId
            });
        }
        [HttpPut("edit")]
        public async Task<EditAcceptedDocument.Response> EditDocument([FromBody] EditAcceptedDocument.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPut("activate")]
        public async Task<ActivateAcceptedDocument.Response> ActivateDocument([FromBody] ActivateAcceptedDocument.Request request)
        {
            return await Executor.SendAsync(request);
        }
    }
}
