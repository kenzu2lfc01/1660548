using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using triluatsoft.tls.Dto;
using triluatsoft.tls.Services.Restaurant.Dto;
using triluatsoft.tls.Services.Restaurants.Dto;

namespace triluatsoft.tls.Services.Restaurant
{
    public interface IRestaurantAppService: IApplicationService
    {
        bool PartnerCodeIsExist(UpdateRestaurantDto input);
        Array GetRestaurant(GetRestaurantDto input);
        object GetRestaurantServerSideAsync(ServerSideDatatableInput input);
        Task<GetRestaurantById> GetRestaurantByIdAsync(EntityDto<Guid> input);
        Task<IdRestaurant> CreateRestaurantAsync(CreateRestaurantDto input);
        Task UpdateRestaurantAsnc(UpdateRestaurantDto input);

        Task UpdateRestaurantPartnerAsnc(UpdateRestaurantDto input);
        Task DeleteRestaurantAsync(EntityDto<Guid> input);
        //Task<ListResultDto<DropdownModelDto>> GetDictrictForCombobox();
        Task DeleteBankInReference(Guid Id);
        Task DeleteBankInRestaurant(Guid Id);
        Task DeleteContactInRestaurant(Guid Id);
        List<GetImportExcelRestaurant> GetImportExcelRestaurant();
        void ImportContactAndAccountRes(string path);
        void ImportExcelRestaurant(string path);
        FileDto GetRestaurantsToExcel(List<ExcelRestaurantInputDto> input);
        void ImportExcelRestaurantRestaurantType(string path);
        List<ValidateThongTinChungRestaurant> CheckImportExcel(string path);
        List<ValidateTaiKhoanRestaurant> CheckImportExcelPrice(string path);
        List<ValidateContactPriceRestaurant> CheckImportContactPrice(string path);
        List<ValidateRestauranttype> CheckComlumnRestauranttype(string path);
        object GetDestinationRestaurantServerSideForSelect(string search);
        Task<ListResultDto<GetListRestaurant>> GetAllServerSideDanhGia(string search);
        Array GetRestaurantIndex();
        object GetImageReviewServiceLinker(Guid id);

        //Partner
        Task DeleteRestaurantPartnerAsync(Guid Id);
        object GetAllServerSideRestaurantByIdAsync(ServerSideDatatableInput input);
        Task<GetRestaurantById> GetRestaurantPartnerByIdAsync(EntityDto<Guid> input);
        
        
    }
}
