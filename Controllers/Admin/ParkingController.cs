using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Admin.Parking;
using System.Threading.Tasks;

namespace Roker.Permit.Api.Controllers.Admin
{
    [Route("admin/parking")]
    public class ParkingController : BaseController
    {
        [HttpPost("list")]
        public async Task<QueryParking.Response> GetParkingList([FromBody]QueryParking.Request request)
        {
            return await Executor.SendAsync(request);
        }

        [HttpPost("add")]
        public async Task<AddParkingDetail.Response> AddParkingDetail([FromBody] AddParkingDetail.Request request)
        {
            return await Executor.SendAsync(request);
        }

        [HttpPut("edit")]
        public async Task<EditParkingDetail.Response> EditParkingDetail([FromBody] EditParkingDetail.Request request)
        {
            return await Executor.SendAsync(request);
        }

        [HttpDelete("{parkingFacilityId}/delete")]
        public async Task<DeleteParkingDetail.Response> DeleteParkingDetail(int parkingFacilityId)
        {
            return await Executor.SendAsync(new DeleteParkingDetail.Request
            {
                ParkingFacilityId = parkingFacilityId
            });
        }

        [HttpGet("{parkingFacilityId}/review")]
        public async Task<QueryParkingReviewDetail.Response> GetParkingReviewDetail(int parkingFacilityId)
        {
            return await Executor.SendAsync(new QueryParkingReviewDetail.Request
            {
                ParkingFacilityId = parkingFacilityId
            });
        }

        [HttpGet("{parkingFacilityId}/detail")]
        public async Task<QueryParkingDetail.Response> GetParkingDetail(int parkingFacilityId)
        {
            return await Executor.SendAsync(new QueryParkingDetail.Request
            {
                ParkingFacilityId = parkingFacilityId
            });
        }
       
        [HttpPost("pricingPackage")]
        public async Task<AddPricingPackage.Response> AddPricingPackage([FromBody]AddPricingPackage.Request request)
        {
            return await Executor.SendAsync(request);
        }

    }
}