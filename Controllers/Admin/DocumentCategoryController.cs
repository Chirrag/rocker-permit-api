using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Admin.DocumentCategories;
namespace Roker.Permit.Api.Controllers.Admin
{
    [Route("admin/documentcategory")]  
    public class DocumentCategoryController : BaseController
    {
        [HttpPost("list")]
        public async Task<QueryDocumentCategory.Response> GetList([FromBody] QueryDocumentCategory.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPost("add")]
        public async Task<AddDocumentCategory.Response> Add([FromBody] AddDocumentCategory.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpGet("{documentCategoryId}/detail")]
        public async Task<QueryDocumentCategoryDetail.Response> GetDetail(short documentCategoryId)
        {
            return await Executor.SendAsync(new QueryDocumentCategoryDetail.Request
            {
                DocumentCategoryId = documentCategoryId
            });
        }
        [HttpDelete("{documentCategoryId}/delete")]
        public async Task<DeleteDocumentCategory.Response> Delete(short documentCategoryId)
        {
            return await Executor.SendAsync(new DeleteDocumentCategory.Request
            {
                DocumentCategoryId = documentCategoryId
            });
        }
        [HttpPut("edit")]
        public async Task<EditDocumentCategory.Response> Edit([FromBody] EditDocumentCategory.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpPut("activate")]
        public async Task<ActivateDocumentCategory.Response> Activate([FromBody] ActivateDocumentCategory.Request request)
        {
            return await Executor.SendAsync(request);
        }
    }
}
