using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Roker.Permit.Api.Controllers
{
    [Route("health")]    
    public class HealthController : Controller
    {
        [HttpHead]
        [HttpGet]
        public async Task<IActionResult> CheckSystemHealthAsync()
        {
            return Json(new HeadResponse
            {
                Version = "1.2.3",
                StatusCode = 200,
                Result = "Service Healthy"
            });
        }


        #region Supportive Entity
        public class HeadResponse
        {
            public string Version { get; set; }
            public int StatusCode { get; set; }
            public string ErrorMessage { get; set; }
            public string Result { get; set; }
        }
        #endregion
    }
}