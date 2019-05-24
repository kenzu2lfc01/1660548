using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Domain.Tours.TourHotels;
using triluatsoft.tls.Dto;
using triluatsoft.tls.Services.Tour.Dto.CreateDto;
using triluatsoft.tls.Services.Tour.Dto.ExcelDto;
using triluatsoft.tls.Services.Tour.Dto.GetByIdDto;
using triluatsoft.tls.Services.Tour.Dto.NewCreateTourDto;
using triluatsoft.tls.Services.Tour.Dto.Proposal;
using triluatsoft.tls.Services.Tour.Dto.UpdateDto;

namespace triluatsoft.tls.Services.Tour
{
    public interface ITourAppService : IApplicationService
    {
        //ham lay ds gia khach san theo tourId va ngay
        GetTourById GetTourHotelByIdAndDayPos(GetTourInputDto input);
        //update tour (co thay doi ngay)
        bool UpdateTourPriceWhenChangeDate(UpdateTourInput input);
        //coppy tour
        bool CoppyTour(Guid id);
        Task<bool> UpdateOneDayInTour2(CreateTourDto input);
//Create
        IdTour CreatePlaceAsync(CreateTourInput input);

//Delete
        Task DeleteTourAsync(EntityDto<Guid> input);
        Task DeleteTourBeEventPriceAsync(EntityDto<Guid> input);
        Task DeleteTourHotelGalaPriceAsync(EntityDto<Guid> input);
        Task DeleteTourHotelAsync(EntityDto<Guid> input);
        Task DeleteTourHotelPriceAsync(EntityDto<Guid> input);
        Task DeleteTourInBoundPriceAsync(EntityDto<Guid> input);
        Task DeleteTourInlandPriceAsync(EntityDto<Guid> input);
        Task DeleteTourOutBoundAsync(EntityDto<Guid> input);
        Task DeleteTourPackageAsync(EntityDto<Guid> input);
        Task DeleteTourPackagePriceAsync(EntityDto<Guid> input);
        Task DeleteTourPlaceAsync(EntityDto<Guid> input);
        Task DeleteTourPlacePriceAsync(EntityDto<Guid> input);
        //Task DeleteTourPlaceSubPriceAsync(EntityDto<Guid> input);
        Task DeleteTourRestaurantAsync(EntityDto<Guid> input);
        Task DeleteTourRestaurantPriceAsync(EntityDto<Guid> input);
        Task DeleteTourTransportAsync(EntityDto<Guid> input);
        Task DeleteTourTransportPriceAsync(EntityDto<Guid> input);
        //Task DeleteTourTransportSubPriceAsync(EntityDto<Guid> input);
        //Create
        Task CreateTourHotelPriceAsnc(Guid priceId);
        //Update
        Task UpdateTourAsnc(UpdateTourInput input);
        Task UpdateTourHotelAsnc(UpdateTourHotelInput input);
        Task UpdateTourRestaurantAsnc(UpdateTourRestaurantInput input);
        Task UpdateTourPlaceAsnc(UpdateTourPlaceInput input);
        Task UpdateTourPackageAsnc(UpdateTourPackageInput input);
        Task UpdateTourTransportAsnc(UpdateTourTransportInput input);
        Task UpdateTourInlandPriceAsnc(UpdateTourInlandPriceInput input);
        Task UpdateTourInBoundPriceAsnc(UpdateTourInBoundPriceInput input);
        Task UpdateTourOutboundAsnc(UpdateTourOutboundInput input);
        Task UpdateTourBeEventPriceAsnc(UpdateTourBeEventPriceInput input);
        Task UpdateTourHotelPriceAsnc(UpdateTourHotelPriceInput input);
        Task UpdateTourHotelGalaPriceAsnc(UpdateTourHotelGalaPriceInput input);
        Task UpdateTourRestaurantPriceAsnc(UpdateTourRestaurantPriceInput input);
        Task UpdateTourPlacePriceAsnc(UpdateTourPlacePriceInput input);
        //Task UpdateTourPlaceSubPriceAsnc(UpdateTourPlaceSubPriceInput input);
        Task UpdateTourPackagePriceAsnc(UpdateTourPackagePriceInput input);
        Task UpdateTourTransportPriceAsnc(UpdateTourTransportPriceInput input);
        //Task UpdateTourTransportSubPriceAsnc(UpdateTourTransportSubPriceInput input);

        //GetById
        Task<GetTourById> GetTourByIdDateAsync(GetTourInputDto input);


        Task<GetTourBeEventPriceById> GetTourBeEventByIdAsync(Guid Id);
        Task<GetTourHotelPriceById> GetTourHotelPriceByIdAsync(Guid Id);
        Task<GetTourHotelGalaPriceById> GetTourHotelGalaPriceByIdAsync(Guid Id);
        Task<GetTourInBoundPriceById> GetTourInBoundPriceByIdAsync(Guid Id);
        Task<GetTourInlandPriceById> GetTourInlandPriceByIdAsync(Guid Id);
        Task<GetTourPackagePriceById> GetTourPackagePriceByIdAsync(Guid Id);
        Task<GetTourPlacePriceById> GetTourPlacePriceByIdAsync(Guid Id);
        //Task<GetTourPlaceSubPriceById> GetTourPlaceSubPriceByIdAsync(Guid Id);
        Task<GetTourRestaurantPriceById> GetTourRestaurantPriceByIdAsync(Guid Id);
        Task<GetTourTransportPriceById> GetTourTransportPriceByIdAsync(Guid Id);
        //Task<GetTourTransportSubPriceById> GetTourTransportSubPriceByIdAsync(Guid Id);
        Task<GetTourHotelById> GetTourHotelByIdAsync(Guid Id);
        Task<GetTourRestaurantById> GetTourRestaurantByIdAsync(Guid Id);
        Task<GetTourTransportId> GetTourTransportIdAsync(Guid Id);
        Task<GetTourPackageById> GetTourPackageByIdAsync(Guid Id);
        Task<GetTourPlaceById> GetTourPlaceById(Guid Id);
        Task<GetTourOutboundById> GetTourOutboundByIdAsync(Guid Id);
        object GetTourServerSideAsync(ServerSideDatatableInput input);
        object GetTourFormServerSideAsync(ServerSideDatatableInput input);
        //get by TourId
        object GetTourHotelPriceByTourId(Guid tourId);
        //
        Task<FileDto> ExportToExcel(Guid input);
        Task<FileDto> InboundExportToExcel(TourExcelExportInput input);


        //New Service
        Task<bool> CreateOneDayInTour(CreateTourDto input);
        Task<bool> UpdateOneDayInTour(CreateTourDto input);

        //Get Service Each Day

        Task<List<GetTourHotelPriceById>> GetHotelPriceOneDayInTour(GetTourInputDto input);
        Task<List<GetTourPackagePriceById>> GetPackagePriceOneDayInTour(GetTourInputDto input);
        Task<List<GetTourTransportPriceById>> GetTransportPriceOneDayInTour(GetTourInputDto input);
        Task<List<GetTourPlacePriceById>> GetPlacePriceOneDayInTour(GetTourInputDto input);
        Task<List<GetTourRestaurantPriceById>> GetRestaurantPriceOneDayInTour(GetTourInputDto input);
        Task<List<GetTourInlandPriceById>> GetInlandPriceOneDayInTour(GetTourInputDto input);
        Task<List<GetTourOutboundById>> GetOutboundPriceOneDayInTour(GetTourInputDto input);
        Task<List<GetTourInBoundPriceById>> GetInboundPriceOneDayInTour(GetTourInputDto input);
        Task<List<GetTourBeEventPriceById>> GetBeEventPriceOneDayInTour(GetTourInputDto input);
        Task<List<GetTourInlandSubPriceById>> GetInlandSubPriceOneDayInTour(GetTourInputDto input);

        Task<List<GetTourGiftPriceById>> GetGiftPriceOneDayInTour(GetTourInputDto input);
        //NewInLand

        Task<ProposalData> GetProposalDataForExport(GetTourProposalDataInput input);

    }
}

