using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roker.Permit.Api.Base;
using Roker.Permit.Domain.QueryParams.Document.Parking;

namespace Roker.Permit.Api.Controllers.Document
{
    [Route("document/parkingvenuephoto")]
    public class ParkingVenuePhotoController : BaseController
    {
        [HttpPost("add")]
        public async Task<AddParkingVenuePhoto.Response> AddDocuments([FromForm] IList<IFormFile> files)
        {
            return await Executor.SendAsync(new AddParkingVenuePhoto.Request
            {
                Files = files
            });
        }
        [HttpDelete("{parkingVenuePhotoId}/delete")]
        public async Task<DeleteParkingVenuePhoto.Response> DeleteDocuments(int parkingVenuePhotoId)
        {
            return await Executor.SendAsync(new DeleteParkingVenuePhoto.Request
            {
                ParkingVenuePhotoId = parkingVenuePhotoId
            });
        }
        [HttpGet("{parkingFacilityId}/list")]
        public async Task<QueryParkingVenuePhoto.Response> ListDocuments(int parkingFacilityId)
        {
            return await Executor.SendAsync(new QueryParkingVenuePhoto.Request
            {
                ParkingfacilityId = parkingFacilityId
            });
        }

        [HttpPut("parkingfacilities/{parkingFacilityId}/venuephotos/{photoId}/MakeDefault")]
        public async Task<MakeDefaultParkingVenuePhoto.Response> MakeDefaultParkingVenuePhoto(int parkingFacilityId, int photoId)
        {
            return await Executor.SendAsync(new MakeDefaultParkingVenuePhoto.Request
            {
                ParkingVenuePhotoId = photoId,
                ParkingFacilityId = parkingFacilityId
            });
        }

    }
}
