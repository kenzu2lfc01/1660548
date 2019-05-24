using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triluatsoft.tls.Services.Places
{
    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using triluatsoft.tls.Services.Places.Dto;
    using Abp.Domain.Entities;
    using triluatsoft.tls.Dto;

    public interface IPlaceAppService : IApplicationService
    {
        bool PartnerCodeIsExist(UpdatePlaceDto input);
        Task<PagedResultDto<GetListPlace>> GetPlace(GetPlaceDto input);
        object GetAllServerSideForSelect();
        object GetAllServerSideAsync(ServerSideDatatableInput input);
        Task<GetPlaceById> GetPlaceByIdAsync(EntityDto<Guid> input);
        Task<IdPlace> CreatePlaceAsync(CreatePlaceDto input);
        Task UpdatePlaceAsnc(UpdatePlaceDto input);
        Task UpdatePlacePartnerAsnc(UpdatePlaceDto input);
        Task DeletePlaceAsync(EntityDto<Guid> input);
        //Task<ListResultDto<DropdownModelDto>> GetDictrictForCombobox();
        Task DeleteBankInPlace(Guid Id);
        Task DeleteContactInPlace(Guid Id);
        Task DeleteLanguageInformationInPlace(Guid Id);
        List<GetImportExcelPlace> GetImportExcelPlace();
        void ImportExcelPlace(string path);
        void ImportContactAndAccount(string path);
        //void ImportPricePackage(string path);
        FileDto ExportExcelPlace(List<ExcelExportPlaceDto> input);
        List<ValidateImportExcelPlace> CheckImportExcel(string path);
        List<ValidateAccout> CheckImportExcelPrice(string path);
        List<ValidateImportContactPricePlace> CheckImportContactPrice(string path);
        object GetDestinationPlaceServerSideForSelect(string search);
        Array GetPlaceIndex();
        object GetDestinationPlaceServerSideForSelect2(string search);

        //Partner
        Task DeletePlacePartnerInHotel(Guid Id);
        Task<GetPlaceById> GetTransportPlaceByIdAsync(EntityDto<Guid> input);
        object GetAllServerSidePartner(ServerSideDatatableInput input);

    }
}
