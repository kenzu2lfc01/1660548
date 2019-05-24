using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Dto;
using triluatsoft.tls.Services.Packages.Dto;
using triluatsoft.tls.Services.Packages.Tourlands.Dto;
namespace triluatsoft.tls.Services.Packages
{
    public interface IPackageAppService : IApplicationService
    {
        bool PartnerCodeIsExist(UpdatePackageDto input);
        ListResultDto<PackageListDto> GetAll(GetPackageInput input);
        Task<PagedResultDto<GetListPackage>> GetPackage(GetPackageDto input);
        object GetAllServerSideAsync(ServerSideDatatableInput input);
        Task<GetPackageById> GetPackageByIdAsync(EntityDto<Guid> input);
        Task<IdPackage> CreatePackageAsync(CreatePackageDto input);
        Task UpdatePackageAsnc(UpdatePackageDto input);
        Task UpdatePackagePartnerAsnc(UpdatePackageDto input);
        Task DeletePackageAsync(EntityDto<Guid> input);
        //Task<ListResultDto<DropdownModelDto>> GetDictrictForCombobox();
        Task DeleteBankInPackage(Guid Id);
        Task DeleteContactInPackage(Guid Id);
        object GetAllServerSideForSelect(string search);
        List<GetImportExcelPackage> GetImportExcelPackage();
        void ImportContactAndAccountPackage(string path);
        void ImportExcelPackage(string path);
        List<ValidateImporteExcel> CheckImportExcel(string path);
        List<ValidateTaiKhoan> CheckImportExcelPrice(string path);
        List<ValidateContactPrice> CheckImportContactPrice(string path);
        Array GetPackageIndex();

        //Partner
        Task DeletePackagePartnerInHotel(Guid Id);
        Task<GetPackageById> GetPackagePartnerByIdAsync(EntityDto<Guid> input);
        object GetAllServerSidePartner(ServerSideDatatableInput input);
    }


}
