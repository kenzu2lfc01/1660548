using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Dto;
using triluatsoft.tls.Services.RequestPartners.Dto;

namespace triluatsoft.tls.Services.RequestPartners
{
    public interface IRequestPartnerAppService : IApplicationService
    {
        Task CreateRequestPartnerAsync(CreateRequestDtoInput input);
        Task DeleteRequestAsync(Guid Id);
        Task<ListResultDto<GetRequestPartnerDtoInput>> GetListRequestPartnerByIdAsync(Guid Id);
        //hotel
        object GetAllServerSideHotelPartner(ServerSideDatatableInput input);
        object GetAllServerSideAllotmentPricePartner(ServerSideDatatableInput input);
        object GetAllServerSideHComboPartner(ServerSideDatatableInput input);
        object GetAllServerSideHotelPricePartner(ServerSideDatatableInput input);
        object GetAllServerSideHotelRoomPartner(ServerSideDatatableInput input);
        object GetAllServerSideHPromotionPartner(ServerSideDatatableInput input);
        //Package
        object GetAllServerSidePackageDetailPartner(ServerSideDatatableInput input);
        object GetAllServerSidePackagePartner(ServerSideDatatableInput input);
        object GetAllServerSidePackagePricePartner(ServerSideDatatableInput input);
        //Place
        object GetAllServerSidePlacePartner(ServerSideDatatableInput input);
        object GetAllServerSidePlacePricePartner(ServerSideDatatableInput input);
        object GetAllServerSidePlaceServicePartner(ServerSideDatatableInput input);
        //Restaurant
        object GetAllServerSideRestaurantMenuPartner(ServerSideDatatableInput input);
        object GetAllServerSideRestaurantPartner(ServerSideDatatableInput input);
        object GetAllServerSideRestaurantPricePartner(ServerSideDatatableInput input);
        object GetAllServerSideRestaurantRoomPartner(ServerSideDatatableInput input);
        //Transport
        object GetAllServerSideDeclareTransportPartner(ServerSideDatatableInput input);
        object GetAllServerSideDestinationTransportPartner(ServerSideDatatableInput input);
        object GetAllServerSideTransportPartner(ServerSideDatatableInput input);
        object GetAllServerSideTransportPricePartner(ServerSideDatatableInput input);
        //TimePeriod
        object GetAllServerSideTimePeriodPartner(ServerSideDatatableInput input);
        
        
    }
}
