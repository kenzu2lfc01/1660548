using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Dto;
using triluatsoft.tls.Services.Transport.Dto;


namespace triluatsoft.tls.Services.Transport
{
    public interface ITransportAppService : IApplicationService
    {
        bool PartnerCodeIsExist(UpdateTransportDto input);
        Task<PagedResultDto<GetListTransport>> GetTransport(GetTransportDto input);
        object GetAllServerSideAsync(ServerSideDatatableInput input);
        Task<GetTransportById> GetTransportByIdAsync(EntityDto<Guid> input);
        Task<IdTransport> CreateTransportAsync(CreateTransportDto input);
        Task UpdateTransportAsnc(UpdateTransportDto input);
        Task UpdateTransportPartnerAsnc(UpdateTransportDto input);
        Task DeleteTransportAsync(EntityDto<Guid> input);
        //Task<ListResultDto<DropdownModelDto>> GetDictrictForCombobox();
        Task DeleteBankInTransport(Guid Id);
        Task DeleteContactInTransport(Guid Id);

        //xuất file excel
        FileDto GetTransportToExcel(List<ExelTransportInputDto> input);

        object GetAllServerSideForSelect(string search);
        List<GetImportExcelTransport> GetImportExcelTransport();
        void ImportExcelTransport(string path);
        void ImportContactAndAccountTransport(string path);

        List<ValidateImporteExcelTransport> CheckImportExcel(string path);
        List<ValidateTaiKhoanTransport> CheckImportExcelPrice(string path);
        List<ValidateContactPriceTransport> CheckImportContactPrice(string path);
        Array GetTransportForIndex();

        //Partner
        Task DeleteTransportPartnerInHotel(Guid Id);
        Task<GetTransportById> GetTransportPartnerByIdAsync(EntityDto<Guid> input);
        object GetAllServerSidePartner(ServerSideDatatableInput input);


    }
}
