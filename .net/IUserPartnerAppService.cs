using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Dto;
using triluatsoft.tls.Services.UserPartner.Dto;

namespace triluatsoft.tls.Services.UserPartner
{
    public interface IUserPartnerAppService : IApplicationService
    {
        object GetAllHotelServerSideAsync(ServerSideDatatableInput input);

        object GetAllRestaurantServerSideAsync(ServerSideDatatableInput input);

        object GetAllPlaceServerSideAsync(ServerSideDatatableInput input);

        object GetAllTransportServerSideAsync(ServerSideDatatableInput input);

        object GetAllPackageServerSideAsync(ServerSideDatatableInput input);

        Task DeleteUserPartner(CreateUserPartnerDto input);

        Task CreateUserPartner(CreateUserPartnerDto input);

        Guid GetHotelUserPartnerManager();
       Guid GetTransportUserPartnerManager();
       Guid GetRestaurantUserPartnerManager();
        Guid GetPlaceUserPartnerManager();
       Guid GetPackageUserPartnerManager();
    }
}
