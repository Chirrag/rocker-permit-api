using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.ImportCSV;
using System.Threading.Tasks;

namespace Roker.Permit.Api.Controllers
{
    [Route("import")]
    public class ImportCSVController : BaseController
    {
        [HttpGet("MakeModel")]
        public async Task<QueryImportCsv.Response> ImportMakeModel()
        {
            QueryImportCsv.Request request = new QueryImportCsv.Request();
            return await Executor.SendAsync(request);
        }

        [HttpGet("ZoneLocation")]
        public async Task<QueryImportZoneLocationCSV.Response> ImportZoneLocation()
        {
            QueryImportZoneLocationCSV.Request request = new QueryImportZoneLocationCSV.Request();
            return await Executor.SendAsync(request);
        }
        [HttpPost("importmasterdata")]
        public async Task<ImportMasterDataExcel.Response> ImportMasterData([FromForm] ImportMasterDataExcel.Request request)
        {            
            return await Executor.SendAsync(request);
        }
    }
}
