using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roker.BuildingBlocks.Common.EnumHelper;
using Roker.Permit.Api.Base;
using Roker.Permit.Application.UseCase.QueryCatalogues;
using Roker.Permit.Domain.QueryParams.AcceptedDocuments;
using Roker.Permit.Domain.QueryParams.Documentcategories;
using Roker.Permit.Domain.QueryParams.Durations;
using Roker.Permit.Domain.QueryParams.FileTypes;
using Roker.Permit.Domain.QueryParams.LicensePlateTypes;
using Roker.Permit.Domain.QueryParams.Locations;
using Roker.Permit.Domain.QueryParams.PermitCategories;
using Roker.Permit.Domain.QueryParams.PermitTypeCategories;
using Roker.Permit.Domain.QueryParams.PermitTypes;
using Roker.Permit.Domain.QueryParams.PricingPackage;
using Roker.Permit.Domain.QueryParams.PricingSchemes;
using Roker.Permit.Domain.QueryParams.States;
using Roker.Permit.Domain.QueryParams.VehicleMake;
using Roker.Permit.Domain.QueryParams.VehicleModels;
using Roker.Permit.Domain.QueryParams.VehicleType;
using Roker.Permit.Domain.QueryParams.VenueFeatures;
using Roker.Permit.Domain.QueryParams.Weekdays;
using Roker.Permit.Domain.QueryParams.Zones;

namespace Roker.Permit.Api.Controllers
{
    [Route("catalogue")]
    public class CatalogueController : BaseController
    {
        [HttpGet("permittypes")]
        public async Task<QueryPermitTypes.Response> GetPermitTypes(QueryPermitTypes.Request request)
        {
            return await Executor.SendAsync(request);
        }

        [HttpGet("allpermittypes")]
        public async Task<QueryAllPermitTypes.Response> GetAllPermitTypes()
        {
            return await Executor.SendAsync(new QueryAllPermitTypes.Request { });
        }

        [HttpGet("locations")]
        public async Task<QueryLocations.Response> GetLocations(QueryLocations.Request request)
        {
            return await Executor.SendAsync(request);
        }

        [HttpGet("zones")]
        public async Task<QueryZones.Response> GetZones(QueryZones.Request request)
        {
            return await Executor.SendAsync(request);
        }

        [HttpGet("vehiclemake")]
        public async Task<QueryVehicleMake.Response> GetVehicleMake()
        {
            return await Executor.SendAsync(new QueryVehicleMake.Request { });
        }

        [HttpGet("{vehicleMakeId}/vehiclemodels")]
        public async Task<QueryVehicleModels.Response> GetVehicleModels(short vehicleMakeId)
        {
            return await Executor.SendAsync(new QueryVehicleModels.Request
            {
                VehicleMakeId = vehicleMakeId
            });
        }
        
        [HttpGet("vehiclemodel")]
        public async Task<QueryVehicleModel.Response> GetVehicleModel(QueryVehicleModel.Request request)
        {
            return await Executor.SendAsync(request);
        }

        [HttpGet("{permitTypeId}/licenseplatetypes")]
        public async Task<QueryLicensePlateTypes.Response> GetLicensePlateTypes(int permitTypeId)
        {
            return await Executor.SendAsync(new QueryLicensePlateTypes.Request
            {
                PermitTypeId = permitTypeId
            });
        }

        [HttpGet("{permitTypeId}/pricingschemes")]
        public async Task<QueryPricingSchemes.Response> GetPricingSchemes(int permitTypeId)
        {
            return await Executor.SendAsync(new QueryPricingSchemes.Request
            {
                PermitTypeId = permitTypeId
            });
        }
        [HttpGet("permitcategories")]
        public async Task<QueryPermitCategories.Response> GetPermitCategories()
        {
            return await Executor.SendAsync(new QueryPermitCategories.Request(
            ));
        }
        [HttpGet("permitcategorytypes")]
        public async Task<QueryPermitTypeCategories.Response> GetPermitTypeCategories()
        {
            return await Executor.SendAsync(new QueryPermitTypeCategories.Request(
            ));
        }
        [HttpGet("liceseplatetypes")]
        public async Task<QueryLicensePlateTypes.Response> GetLicensePlateTypes()
        {
            return await Executor.SendAsync(new QueryLicensePlateTypes.GlobalRequest(
            ));
        }
        [HttpGet("documenttypes")]
        public async Task<QueryActiveAcceptedDocument.Response> GetAcceptedDocument()
        {
            return await Executor.SendAsync(new QueryActiveAcceptedDocument.Request
            {
            });
        }
        [HttpGet("{durationId}/pricingpackages")]
        public async Task<QueryActivePricingPackage.Response> GetPricingPackage(DurationEnum durationId)
        {
            return await Executor.SendAsync(new QueryActivePricingPackage.Request
            {
                DurationId = durationId
            });
        }
        [HttpGet("durations")]
        public async Task<QueryDuration.Response> GetDuration()
        {
            return await Executor.SendAsync(new QueryDuration.Request
            {
            });
        }
        [HttpGet("weekdays")]
        public async Task<QueryWeekday.Response> GetWeekdays()
        {
            return await Executor.SendAsync(new QueryWeekday.Request
            {
            });
        }
        [HttpGet("filetypes")]
        public async Task<QueryFileType.Response> GetFileTypes()
        {
            return await Executor.SendAsync(new QueryFileType.Request
            {
            });
        }
        [HttpGet("{permitTypeId}/documentcategories")]
        public async Task<QueryDocumentcategories.Response> GetDocumentcategories(int permitTypeId)
        {
            return await Executor.SendAsync(new QueryDocumentcategories.Request
            {
                PermitTypeId = permitTypeId
            });
        }
        [HttpGet("categorieswithdocuments")]
        public async Task<QueryDocumentcategories.Response> GetAllDocumentcategoriesWithDocuments()
        {
            return await Executor.SendAsync(new QueryDocumentcategories.DocumentRequest
            {                
            });
        }
        [HttpGet("vehicletypes")]
        public async Task<QueryVehicleType.Response> GetVehicleTypes()
        {
            return await Executor.SendAsync(new QueryVehicleType.Request());
        }

        [HttpGet("venuefeatures")]
        public async Task<QueryVenueFeatures.Response> GetVenueFeatures()
        {
            return await Executor.SendAsync(new QueryVenueFeatures.Request());
        }
        [HttpGet("documentcategories")]
        public async Task<QueryActiveDocumentCategory.Response> GetActiveDocumentCategory()
        {
            return await Executor.SendAsync(new QueryActiveDocumentCategory.Request());
        }

        [HttpPost("pricingpackages")]
        public async Task<QueryPricingPackagesForParking.Response> GetPricingPackagesForParking([FromBody]QueryPricingPackagesForParking.Request request)
        {
            return await Executor.SendAsync(request);
        }
        [HttpGet("states")]
        public async Task<QueryState.Response> GetStates()
        {
            return await Executor.SendAsync(new QueryState.Request());
        }

        [HttpGet("permittypes/{permittypeId}/parkingfacilities/{parkingfacilityId}/pricingpackages")]
        public async Task<QueryPermitPricingPackages.Response> GetPricingPackagesForParking(int permittypeId, int parkingfacilityId)
        {
            return await Executor.SendAsync(new QueryPermitPricingPackages.Request
            {
                ParkingFacilityId = parkingfacilityId,
                PermitTypeId = permittypeId
            });
        }
       
    }
}