using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using triluatsoft.tls.Dto;
using triluatsoft.tls.Services.TourGuides.InBounds.Dto;

namespace triluatsoft.tls.Services.TourGuides.InBounds
{
    public interface IInBoundAppService: IApplicationService
    {
        Task<ListResultDto<GetInBoundByIdInput>> GetInBoudByIdAsyn(Guid Id);
        object GetAllServerSideAsync(ServerSideDatatableInput input);
        Task<GetInBoundByIdInput> GetSingleInboundById(Guid Id);
        Task CreateInBoundAsyn(CreateInBoundDto input);
        Task DeleteInBoundAsyn(Guid Id);
        Task UpdateInBoundAsnc(UpdateInBoundDto input);
        object GetInboundPrice(Guid input);
        Array InboundIndex();
    }
}
