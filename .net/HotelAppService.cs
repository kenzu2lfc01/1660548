using System;
using System.Linq;
using System.Threading.Tasks;

namespace triluatsoft.tls.Services.Hotels
{
    using Dto;
    using triluatsoft.tls.Domain.Districts;
    using triluatsoft.tls.Domain.Hotels;
    using Abp.Application.Services.Dto;
    using System.Data.Entity;
    using Abp.Collections.Extensions;
    using Abp.Extensions;
    using System.Linq.Dynamic.Core;
    using Abp.Linq.Extensions;
    using Abp.AutoMapper;
    using Abp.Domain.Repositories;
    using triluatsoft.tls.Domain.Contacts;
    using triluatsoft.tls.Domain.BankInformations;
    using triluatsoft.tls.Helpers;
    using triluatsoft.tls.Domain.Countries;
    using triluatsoft.tls.Domain.Currencies;
    using triluatsoft.tls.Domain.Provinces;
    using triluatsoft.tls.Dto;
    using System.Web;
    using System.Collections.Generic;
    using triluatsoft.tls.Ward.Dto;
    using triluatsoft.tls.Authorization.Users.Exporting;
    using triluatsoft.tls.ServiceHotels.Dto;
    using System.IO;
    using triluatsoft.tls.Domain.Locations;
    using triluatsoft.tls.Domain.Stars;
    using triluatsoft.tls.Domain.Customers;
    using triluatsoft.tls.Domain.Roomtypes;
    using triluatsoft.tls.Domain.Prioritys;
    using triluatsoft.tls.Services.Places.Dto;
    using triluatsoft.tls.Domain.Payments;
    using triluatsoft.tls.Domain.ContractPrice.AddPackageContractPrice;
    using triluatsoft.tls.Domain.TypeBreakfast;
    using triluatsoft.tls.Notifications;
    using triluatsoft.tls.Authorization.Users;
    using System.Web.Hosting;
    using triluatsoft.tls.Domain.CardsType;
    using triluatsoft.tls.Domain.KindOfService;
    using triluatsoft.tls.Domain.TypeCustomer;
    using triluatsoft.tls.Domain.TypeBill;
    using System.Drawing;
    using triluatsoft.tls.Domain.ServiceLinkeds;
    using triluatsoft.tls.Domain.Restaurants;
    using triluatsoft.tls.Domain.Places;
    using Abp.Authorization;
    using triluatsoft.tls.Authorization;
    using Abp.Runtime.Session;
    using Domain.Packages;
    using Domain.Transports;
    using triluatsoft.tls.Domain.FilesSub;
    using triluatsoft.tls.PartnerDomain.Hotels;
    using triluatsoft.tls.PartnerDomain.BankInformations;
    using triluatsoft.tls.PartnerDomain.Contacts;
    using Microsoft.AspNet.Identity;
    using triluatsoft.tls.PartnerDomain.Requests;

    public class HotelAppService : tlsAppServiceBase, IHotelAppService
    {
        private readonly IRepository<Hotel, Guid> _hotelRepository;
        private readonly IRepository<Package, Guid> _packageRepository;
        private readonly IRepository<Place, Guid> _placeRepository;
        private readonly IRepository<Restaurant, Guid> _restaurantRepository;
        private readonly IRepository<Transport, Guid> _transportRepository;
        private readonly IAppNotifier _appNotifier;
        private readonly IRepository<AddPackageContractPrice, Guid> _addPackageContractPriceRepository;
        private readonly IRepository<District, Guid> _districtRepository;
        private readonly IRepository<Contact, Guid> _contactRepository;
        private readonly IRepository<BankInformation, Guid> _bankRepository;
        private readonly IRepository<Country, Guid> _countryRepository;
        private readonly IRepository<Currency, Guid> _currencyRepository;
        private readonly IRepository<Province, Guid> _provinceRepository;
        private readonly IUserListExcelExporter _userListExcelExporter;
        private readonly IRepository<Star, Guid> _starRepository;
        private readonly IRepository<Location, Guid> _locationRepository;
        private readonly IRepository<Customer, Guid> _customerRepository;
        private readonly IRepository<Roomtype, Guid> _roomtypeRepository;
        private readonly IRepository<Domain.Hotels.HotelRoom, Guid> _hotelRoomRepository;
        private readonly IRepository<Priority, Guid> _priorityRepository;
        private readonly IRepository<Payment, Guid> _paymentRepository;
        private readonly IRepository<TypeBreakfast, Guid> _typeBreakfastRepository;
        private readonly IRepository<CardsType, Guid> _cardsTypefastRepository;
        private readonly IRepository<KindOfService, Guid> _kindOfServiceRepository;
        private readonly IRepository<TypeCustomer, Guid> _typeCustomerRepository;
        private readonly IRepository<TypeBill, Guid> _typeBillRepository;
        private readonly IRepository<ServiceLinked, Guid> _serviceLinkedRepository;
        private readonly IRepository<FilePicSub, Guid> _filePicSubdRepository;
        private readonly UserManager _userManager;
        private readonly IPermissionChecker _permissionChecker;
        private readonly IAbpSession _session;
        private readonly IRepository<HotelPartner, Guid> _hotelPartnerRepository;
        private readonly IRepository<BankInformationPartner, Guid> _bankInformationPartnerRepository;
        private readonly IRepository<ContactPartner, Guid> _contactPartnerPartnerRepository;
        private readonly IRepository<RequestPartner, Guid> _requestPartnerRepository;

        public HotelAppService(
            IRepository<FilePicSub, Guid> filePicSubdRepository,
          IRepository<Hotel, Guid> hotelRepository,
          IRepository<Package, Guid> packageRepository,
          IRepository<Place, Guid> placeRepository,
          IRepository<Restaurant, Guid> restaurantRepository,
          IRepository<Transport, Guid> transportRepository,
          IAppNotifier appNotifier,
          IRepository<Roomtype, Guid> roomtypeRepository,
          IRepository<TypeBill, Guid> typeBillRepository,
          IRepository<Domain.Hotels.HotelRoom, Guid> hotelRoomRepository,
          IRepository<AddPackageContractPrice, Guid> addPackageContractPriceRepository,
          IRepository<KindOfService, Guid> kindOfServiceRepository,
          IRepository<TypeCustomer, Guid> typeCustomerRepository,
          IRepository<Payment, Guid> paymentRepository,
          IRepository<Priority, Guid> priorityRepository,
          IRepository<District, Guid> districtRepository,
          IRepository<Contact, Guid> contactRepository,
          IRepository<BankInformation, Guid> bankRepository,
          IRepository<Country, Guid> countryRepository,
          IRepository<Currency, Guid> currencyRepository,
          IRepository<Province, Guid> provinceRepository,
          IUserListExcelExporter userListExcelExporter,
          IRepository<Location, Guid> locationRepository,
          IRepository<Star, Guid> starRepository,
          IRepository<Customer, Guid> customerRepository,
          IRepository<TypeBreakfast, Guid> typeBreakfastRepository,
          IRepository<CardsType, Guid> cardsTypefastRepository,
          UserManager userManager,
          IRepository<ServiceLinked, Guid> serviceLinkedRepository,
        IPermissionChecker permissionChecker,
          IAbpSession session,
          IRepository<HotelPartner, Guid> hotelPartnerRepository,
        IRepository<BankInformationPartner, Guid> bankInformationPartnerRepository,
        IRepository<ContactPartner, Guid> contactPartnerPartnerRepository,
        IRepository<RequestPartner, Guid> requestPartnerRepository
         )
        {
            _hotelRepository = hotelRepository;
            _packageRepository = packageRepository;
            _placeRepository = placeRepository;
            _restaurantRepository = restaurantRepository;
            _transportRepository = transportRepository;
            _appNotifier = appNotifier;
            _roomtypeRepository = roomtypeRepository;
            _typeBillRepository = typeBillRepository;
            _hotelRoomRepository = hotelRoomRepository;
            _typeCustomerRepository = typeCustomerRepository;
            _kindOfServiceRepository = kindOfServiceRepository;
            _addPackageContractPriceRepository = addPackageContractPriceRepository;
            _cardsTypefastRepository = cardsTypefastRepository;
            _paymentRepository = paymentRepository;
            _priorityRepository = priorityRepository;
            _customerRepository = customerRepository;
            _starRepository = starRepository;
            _locationRepository = locationRepository;
            _districtRepository = districtRepository;
            _contactRepository = contactRepository;
            _bankRepository = bankRepository;
            _countryRepository = countryRepository;
            _currencyRepository = currencyRepository;
            _provinceRepository = provinceRepository;
            _userListExcelExporter = userListExcelExporter;
            _typeBreakfastRepository = typeBreakfastRepository;
            _userManager = userManager;
            _serviceLinkedRepository = serviceLinkedRepository;
            _permissionChecker = permissionChecker;
            _session = session;
            _hotelPartnerRepository = hotelPartnerRepository;
            _bankInformationPartnerRepository = bankInformationPartnerRepository;
            _contactPartnerPartnerRepository = contactPartnerPartnerRepository;
            _requestPartnerRepository = requestPartnerRepository;
        }
        public bool PartnerCodeIsExist(UpdateHotelDto input)
        {
            if (input.PartnerCode != null)
            {
                if (input.Id == new Guid() || input.Id == null)
                {
                    var PNHotel = _hotelRepository.FirstOrDefault(p => p.PartnerCode == input.PartnerCode);
                    if (PNHotel != null) return true;

                    var PNPackage = _packageRepository.FirstOrDefault(p => p.PartnerCode == input.PartnerCode);
                    if (PNPackage != null) return true;

                    var PNPlace = _placeRepository.FirstOrDefault(p => p.PartnerCode == input.PartnerCode);
                    if (PNPlace != null) return true;

                    var PNRestaurant = _restaurantRepository.FirstOrDefault(p => p.PartnerCode == input.PartnerCode);
                    if (PNRestaurant != null) return true;

                    var PNTransport = _transportRepository.FirstOrDefault(p => p.PartnerCode == input.PartnerCode);
                    if (PNTransport != null) return true;
                }
                else if (input.Id != new Guid() && input.Id != null) 
                {
                    var PNHotel = _hotelRepository.FirstOrDefault(p => p.PartnerCode == input.PartnerCode);
                    if (PNHotel != null)
                    {
                        if (PNHotel.Id != input.Id) return true;
                    }

                    var PNPackage = _packageRepository.FirstOrDefault(p => p.PartnerCode == input.PartnerCode);
                    if (PNPackage != null)
                    {
                        if (PNPackage.Id != input.Id) return true;
                    }

                    var PNPlace = _placeRepository.FirstOrDefault(p => p.PartnerCode == input.PartnerCode);
                    if (PNPlace != null)
                    {
                        if (PNPlace.Id != input.Id) return true;
                    }

                    var Restaurant = _restaurantRepository.FirstOrDefault(p => p.PartnerCode == input.PartnerCode);
                    if (Restaurant != null)
                    {
                        if (Restaurant.Id != input.Id) return true;
                    }

                    var transport = _transportRepository.FirstOrDefault(p => p.PartnerCode == input.PartnerCode);
                    if (transport != null)
                    {
                        if (transport.Id != input.Id) return true;
                    }
                }
            }
            return false;
        }
        public async Task<IdHotel> CreateHotelAsync(CreateHotelDto input)
        {
            var createHotel = input.MapTo<Hotel>();
            await _hotelRepository.InsertAsync(createHotel);
            FluentFtp.CreateServiceDirectory(triluatsoft.tls.Helpers.Constants.p_Hotel, createHotel.Id.ToString());
            var user = await _userManager.FindByIdAsync(createHotel.CreatorUserId.Value);
            await _appNotifier.Subscribe_Hotel(user, createHotel);
            return new IdHotel { Id = createHotel.Id };
        }

        public async Task DeleteBankInHotel(Guid Id)
        {
            await _bankRepository.DeleteAsync(Id);
        }

        public async Task DeleteContactInHotel(Guid Id)
        {
            await _contactRepository.DeleteAsync(Id);
        }

        public async Task DeleteHotelAsync(EntityDto<Guid> input)
        {
            var hotel = await _hotelRepository.GetAsync(input.Id);
            await _hotelRepository.DeleteAsync(input.Id);
            FluentFtp.DeleteServiceDirectory(triluatsoft.tls.Helpers.Constants.p_Hotel, input.Id.ToString());
            var user = await GetCurrentUserAsync();
            await _appNotifier.Subscribe_DeleteHotel(user, hotel);
        }
         public Array  GetHotelForNewIndex()
        {
            var listAll = _hotelRepository.GetAll().OrderByDescending(p => p.CreationTime)
                .Select((p) => new
                {
                    p.CreationTime,
                    Location = (p.Location != null) ? p.Location.Name : "",
                    p.LocationId,
                    p.Name,
                    p.PartnerCode,
                    Star = (p.Star != null) ? p.Star.Name : "",
                    p.StarId,
                    p.Address,
                    p.Website,
                    Country = (p.Country != null) ? p.Country.Name : "",
                    p.CountryId,
                    Province = (p.Province != null) ? p.Province.Name : "",
                    p.ProvinceId,
                    District = (p.District != null) ? p.District.Name : "",
                    p.CapacityRoom,
                    p.Id,
                    p.Latitude,
                    p.Longitude,
                    price = p.AddPackageContractPrices.OrderBy(x => x.Price).Select(x => new
                    {
                        CurrrencyName = x.Currency.Name,
                        x.Price,
                        x.HotelRoom.Roomtype.Name,
                        x.Note,
                        menu = x.TypeBreakfast.Name,
                    }).FirstOrDefault(),
                    ImageId = (p.FilePicSubs.Where(x => x.Position == 1).FirstOrDefault() != null) ? p.FilePicSubs.Where(x => x.Position == 1).FirstOrDefault().Id.ToString() : "",
                    ImageName = (p.FilePicSubs.Where(x => x.Position == 1).FirstOrDefault() != null) ? p.FilePicSubs.Where(x => x.Position == 1).FirstOrDefault().FileName : "",
                    Icons = p.FilePicSubs.Where(x => x.NewColumn1 != null).Select(x => new
                    {
                        x.NewColumn1,
                        x.Id,
                    }).ToList(),
                }).ToList().Take(4);

            return listAll.ToArray();
        }

        public async Task<PagedResultDto<GetListHotel>> GetHotel(GetHotelDto input)
        {
            var districtID = input.Id;
            var query = _districtRepository.GetAll()
              .WhereIf(
                  !input.Filter.IsNullOrWhiteSpace(),
                  u =>
                      u.Name.Contains(input.Filter)
              );
            var totalCount = await query.CountAsync();

            var items = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            return new PagedResultDto<GetListHotel>(
                totalCount,
                items.Select(
                item =>
                {
                    var dto = item.MapTo<GetListHotel>();

                    return dto;
                }
                ).ToList());
        }
        private bool ParaRequestIsNullOrEmpty(string[] param) {
            if (param == null) return false;
            else if (param[0] == "") return false;
            return true;
        }
        public object GetAllServerSideAsync(ServerSideDatatableInput input)
        {
            
            //get parameter
            if (input.orderColumnName.IsNullOrEmpty() && input.dir.IsNullOrEmpty() && input.search.IsNullOrEmpty())
            {
                input.search = HttpContext.Current.Request.Params.GetValues("search[value]") != null ?
                    HttpContext.Current.Request.Params.GetValues("search[value]")[0].Trim().ToLower() : "";
                var orderColumnIndex = HttpContext.Current.Request.Params.GetValues("order[0][column]") != null ?
                    HttpContext.Current.Request.Params.GetValues("order[0][column]")[0] : "";
                input.orderColumnName = HttpContext.Current.Request.Params.GetValues("columns[" + orderColumnIndex + "][name]") != null ?
                    HttpContext.Current.Request.Params.GetValues("columns[" + orderColumnIndex + "][name]")[0] : "";
                input.dir = HttpContext.Current.Request.Params.GetValues("order[0][dir]") != null ?
                    HttpContext.Current.Request.Params.GetValues("order[0][dir]")[0] : "";
            }
            //get advance search
            #region get advance search
            var countryS = HttpContext.Current.Request.Params.GetValues("country");
            Guid countryGuidId = new Guid();
            if (ParaRequestIsNullOrEmpty(countryS)) countryGuidId = new Guid(countryS[0]);
            var provinceS = HttpContext.Current.Request.Params.GetValues("province");
            Guid provinceGuidId = new Guid();
            if (ParaRequestIsNullOrEmpty(provinceS)) provinceGuidId = new Guid(provinceS[0]);
            var districtS = HttpContext.Current.Request.Params.GetValues("district");
            Guid districtGuidId = new Guid();
            if (ParaRequestIsNullOrEmpty(districtS)) districtGuidId = new Guid(districtS[0]);
            var starS = HttpContext.Current.Request.Params.GetValues("star");

            Guid starGuidId = new Guid();
            if (ParaRequestIsNullOrEmpty(starS)) starGuidId = new Guid(starS[0]);
            

            var locationS = HttpContext.Current.Request.Params.GetValues("location");
            Guid locationGuidId = new Guid();
            if (ParaRequestIsNullOrEmpty(locationS)) locationGuidId = new Guid(locationS[0]);

            var partnerCodefromS = HttpContext.Current.Request.Params.GetValues("partnerCode");
            var partnerCode = "";
     
            if (ParaRequestIsNullOrEmpty(partnerCodefromS)) partnerCode = partnerCodefromS[0].ToLower();

            var nameFromS = HttpContext.Current.Request.Params.GetValues("name");
            var name = "";

            if (ParaRequestIsNullOrEmpty(nameFromS)) name = nameFromS[0].ToLower();

            var idRequest = HttpContext.Current.Request.Params.GetValues("id");
            long id = -1;
            if (ParaRequestIsNullOrEmpty(idRequest))
            {
                id = Convert.ToInt64(idRequest[0]);
            }
            #endregion
            //get all 
            var listAll = _hotelRepository.GetAll()
                .WhereIf(id != -1, c => !c.UserServicePartner.Any(p=>p.HotelId==c.Id && p.UserId==id))
                .WhereIf(_permissionChecker.IsGranted(AppPermissions.Partner_Hotel), p => p.UserServicePartner.Any(c=>c.UserId==_session.UserId))
                .OrderByDescending(p => p.CreationTime)
                .Select((p) => new
                {
                    //TypeCustomer = (p.TypeCustomer != null) ? p.TypeCustomer.Name : "",
                    //p.TypeCustomerId,
                    p.CreationTime,
                    Location = (p.Location != null) ? p.Location.Name : "",
                    p.LocationId,
                    p.Name,
                    p.PartnerCode,
                    Star = (p.Star != null) ? p.Star.Name : "",
                    p.StarId,
                    p.Address,
                    p.Website,
                    Country = (p.Country != null) ? p.Country.Name : "",
                    p.CountryId,
                    Province = (p.Province != null) ? p.Province.Name : "",
                    p.ProvinceId,
                    District = (p.District != null) ? p.District.Name : "",
                    p.CapacityRoom,
                    p.Id,
                    p.DisctrictId
                   //SeriesCheck = (p.SeriesBookingHotels.FirstOrDefault() != null) ? true:false,
                  

            }).ToList();
            //filter
            var listFilter = listAll.Where(p => p.Name!=null?
            VietToEngStr.RemoveSign4VietnameseString(p.Name.ToLower()).Contains(VietToEngStr.RemoveSign4VietnameseString(input.search)):true);

            listFilter = listFilter.Where(p => p.Name != null ?
            VietToEngStr.RemoveSign4VietnameseString(p.Name.ToLower()).Contains(VietToEngStr.RemoveSign4VietnameseString(name)) : true);

            listFilter = listFilter.Where(p => p.PartnerCode != null ?
            VietToEngStr.RemoveSign4VietnameseString(p.PartnerCode.ToLower()).Contains(VietToEngStr.RemoveSign4VietnameseString(partnerCode)) : true);


            //filter price 
            if (ParaRequestIsNullOrEmpty(countryS))
                listFilter = listFilter.Where(p => p.CountryId == countryGuidId);
            if (ParaRequestIsNullOrEmpty(provinceS))
                listFilter = listFilter.Where(p => p.ProvinceId == provinceGuidId);
            if (ParaRequestIsNullOrEmpty(starS))
                listFilter = listFilter.Where(p => p.StarId != null && p.StarId == starGuidId);
            if (ParaRequestIsNullOrEmpty(locationS))
                listFilter = listFilter.Where(p => p.LocationId == locationGuidId);
            if (ParaRequestIsNullOrEmpty(districtS))
                listFilter = listFilter.Where(p => p.DisctrictId == districtGuidId);
            //sort
            if (input.orderColumnName == "Name")
            {
                if (input.dir == "asc") listFilter = listFilter.OrderBy(p => p.Name);
                else listFilter = listFilter.OrderByDescending(p => p.Name);
            }
            else if (input.orderColumnName == "Star")
            {
                if (input.dir == "asc") listFilter = listFilter.OrderBy(p => p.Star);
                else listFilter = listFilter.OrderByDescending(p => p.Star);
            }
            

            //skip take
            var listSkipTake = listFilter.Skip(input.start).Take(input.length);
            var result = listSkipTake.ToArray();
            return new
            {
                draw = input.draw,
                recordsTotal = listAll.Count(),
                recordsFiltered = listFilter.Count(),
                data = result
            };
        }
       
        public string GetIDStarByIdHotel(Guid id)
        {
            var n =_hotelRepository.FirstOrDefault(p => p.Id == id);
            Guid? starId =  n.StarId;
            var starName = _starRepository.FirstOrDefault(p => p.Id == starId);
            return starName.Name.ToString();
        }
        public async Task<GetHotelById> GetHotelByIdAsync(EntityDto<Guid> input)
        {
            var hotel = await _hotelRepository.GetAsync(input.Id);
            if (hotel != null)
            {
                var contactList = await _contactRepository.GetAllListAsync(p => p.HotelId == hotel.Id);
                if (contactList != null)
                {
                    foreach (var contact in contactList)
                    {
                        hotel.Contacts.Add(contact);
                    }
                }
                var bankList = await _bankRepository.GetAllListAsync(p => p.HotelId == hotel.Id);
                if (bankList != null)
                {
                    foreach (var bank in bankList)
                    {
                        hotel.BankInformations.Add(bank);
                    }
                }
                var linkedList = await _serviceLinkedRepository.GetAllListAsync(p => p.HotelId == hotel.Id);
                if (linkedList != null)
                {
                    foreach (var link in linkedList)
                    {
                        hotel.ServiceLinkeds.Add(link);
                       
                    }
                }
                var output =  hotel.MapTo<GetHotelById>();
                foreach(var linked in output.ServiceLinkeds)
                {
                    if(linked.RestaurantId==null)
                    {
                        var check = _placeRepository.FirstOrDefault(p => p.Id == linked.PlaceId);
                        if(check != null)
                        {
                            linked.Name = check.Name;
                            linked.Address = check.Address;
                            linked.Facility = check.PlaceDecriptionV;
                          
                        }

                      
                    }
                    else if(linked.PlaceId==null)
                    {
                        var check = _restaurantRepository.FirstOrDefault(p => p.Id == linked.RestaurantId);
                        if (check != null)
                        {
                            linked.Name = check.Name;
                            linked.Address = check.Address;
                            linked.Facility = check.Facility;
                        }

                    }
                }
                return output;
            }
            return null;
        }
        public List<ValidateContactPriceHotel> CheckImportContactPrice(string path)
        {
            var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"), path);
            var pck = new OfficeOpenXml.ExcelPackage();
            using (var stream = File.OpenRead(tempFilePath))
            {
                pck.Load(stream);
                var workbook = pck.Workbook;
                var worksheet4 = workbook.Worksheets["Gia hop dong"];
                var error = new List<ValidateContactPriceHotel>();
                int totalRow = worksheet4.Dimension.End.Row;
                for (int i = 2; i <= totalRow; i++)
                {
                    var CodePartner = worksheet4.Cells[i, 1].Text.ToString();
                    if (CodePartner != "")
                    {
                        var HighPrice = worksheet4.Cells[i, 9].Text.ToString();
                        var LowPrice = worksheet4.Cells[i, 10].Text.ToString();
                        string errorRoomType = null, errorCustomerZone = null, errorCustomer = null, errorCurrency = null, errorBreakfast = null, errorHighPrice = null, errorLowPrice = null ;
                        var RoomType = worksheet4.Cells[i, 3].Text.ToString();
                        var CustomerZone = worksheet4.Cells[i, 5].Text.ToString();
                        var Customer = worksheet4.Cells[i, 6].Text.ToString();
                        var Currency = worksheet4.Cells[i, 12].Text.ToString();
                        var Breakfast = worksheet4.Cells[i, 13].Text.ToString();
                        var checkCurrencyId = _currencyRepository.FirstOrDefault(p => p.Name == Currency);
                        var checkRoomTypeId = _roomtypeRepository.FirstOrDefault(p => p.Name == RoomType);
                        var checkCustomerZoneId = _customerRepository.FirstOrDefault(p => p.Name == CustomerZone);
                        var checkCustomerId = _typeCustomerRepository.FirstOrDefault(p => p.Name == Customer);
                        var checkBreakfastId = _typeBreakfastRepository.FirstOrDefault(p => p.Name == Breakfast);
                        if (HighPrice != "")
                        {
                            float n;
                            if (!float.TryParse(HighPrice, out n))
                            {
                                errorHighPrice = "Sheet " + worksheet4.ToString() + " Row I" + i + " with value " + HighPrice + " not correct format -- Correct Examp : 50,000";
                                worksheet4.Cells[i, 9].Style.Font.Color.SetColor(Color.Red);
                               
                            }
                            else
                            {
                                errorHighPrice = null;
                            }

                        }
                        if (LowPrice != "")
                        {
                            float n;
                            if (!float.TryParse(LowPrice, out n))
                            {
                                errorLowPrice = "Sheet " + worksheet4.ToString() + " Row J" + i + " with value " + HighPrice + " not correct format -- Correct Examp : 50,000";
                            }
                            else
                            {
                                errorLowPrice = null;
                            }

                        }
                        if (RoomType != "")
                        {
                            if (checkRoomTypeId == null)
                            {
                                errorRoomType = "Sheet " + worksheet4.ToString() + " Row C" + i + " with value " + RoomType + " not correct";
                            }
                            else
                            {
                                errorRoomType = null;
                            }

                        }
                        if (CustomerZone != "")
                        {
                            if (checkCustomerZoneId == null)
                            {
                                errorCustomerZone = "Sheet " + worksheet4.ToString() + " Row E" + i + " with value " + CustomerZone + " not correct";
                            }
                            else
                            {
                                errorCustomerZone = null;
                            }

                        }
                        if (Breakfast != "")
                        {
                            if (checkBreakfastId == null)
                            {
                                errorBreakfast = "Sheet " + worksheet4.ToString() + " Row M" + i + " with value " + Breakfast + " not correct";
                            }
                            else
                            {
                                errorBreakfast = null;
                            }

                        }
                        if (Currency != "")
                        {
                            if (checkCurrencyId == null)
                            {
                                errorCurrency = "Sheet " + worksheet4.ToString() + " Row L" + i + " with value " + Currency + " not correct";
                            }
                            else
                            {
                                errorCurrency = null;
                            }

                        }
                        if (Customer != "")
                        {
                            if (checkCustomerId == null)
                            {
                                errorCustomer = "Sheet " + worksheet4.ToString() + " Row F" + i + " with value " + Currency + " not correct";
                            }
                            else
                            {
                                errorCustomer = null;
                            }

                        }
                        error.Add(new ValidateContactPriceHotel
                        {
                           ErrorBreakfast = errorBreakfast,
                           ErrorCurrency = errorCurrency,
                           ErrorTypeRoom  = errorRoomType,
                           ErrorCustomer = errorCustomer,
                           ErrorCustomerType = errorCustomerZone,
                           ErrorPriceHigh = errorHighPrice,
                           ErrorPriceLow = errorLowPrice
                           
                        });
                        
                    }

                }
              
                return error;
            }
        }
        public List<ValidateTaiKhoanHotel> CheckImportExcelPrice(string path)
        {
            var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"), path);
            var pck = new OfficeOpenXml.ExcelPackage();
            using (var stream = File.OpenRead(tempFilePath))
            {
                pck.Load(stream);
                var workbook = pck.Workbook;
                var worksheet2 = workbook.Worksheets["Thông tin tài khoản"];
                var error = new List<ValidateTaiKhoanHotel>();
                int totalRow = worksheet2.Dimension.End.Row;
                for (int i = 2; i <= totalRow; i++)
                {
                    var CodePartner = worksheet2.Cells[i, 1].Text.ToString();
                    if (CodePartner != "")
                    {
                        string errorCurrency = null;
                        var Currency = worksheet2.Cells[i, 7].Text.ToString();
                        var checkIdCurrencyId = _currencyRepository.FirstOrDefault(p => p.Name == Currency);
                        if (Currency != "")
                        {
                            if (checkIdCurrencyId == null)
                            {
                                errorCurrency = "Sheet " + worksheet2.ToString() + " Row G" + i + " with value " + Currency + " not correct";
                                error.Add(new ValidateTaiKhoanHotel
                                {
                                    ErrorCurrency = errorCurrency,
                                });
                            }
                        }

                    }

                }
                return error;
            }
        }
        public List<ValidateImporteExcelHotel> CheckImportExcel(string path)
        {
            var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"), path);
            var pck = new OfficeOpenXml.ExcelPackage();
            using (var stream = File.OpenRead(tempFilePath))
            {
                pck.Load(stream);

                var workbook = pck.Workbook;
                var worksheet = workbook.Worksheets.First();
                var error = new List<ValidateImporteExcelHotel>();
                int totalRow = worksheet.Dimension.End.Row;
                for (int i = 3; i <= totalRow; i++)
                {
                    var CodePartner = worksheet.Cells[i, 2].Text.ToString();
                    if (CodePartner != "")
                    {
                        string errorKindOfService = null;
                        string errorPriorType = null;
                        string customerType = null;
                        string errorCountry = null;
                        string errorProvince = null;
                        string errorDistrict = null;
                        string errorLocation = null;
                        string errorCardType = null;
                        string errorBill = null;
                        string errorPayment = null;
                        string errorStar = null;
                        var Star = worksheet.Cells[i, 4].Text.ToString();
                        var PriorityType = worksheet.Cells[i, 5].Text.ToString();
                        var CustomerType = worksheet.Cells[i, 6].Text.ToString();
                        var Country = worksheet.Cells[i, 10].Text.ToString();
                        var Province = worksheet.Cells[i, 11].Text.ToString();
                        var District = worksheet.Cells[i, 12].Text.ToString();
                        var Location = worksheet.Cells[i, 14].Text.ToString();
                        var Bill = worksheet.Cells[i, 22].Text.ToString();
                        var CardTypeName = worksheet.Cells[i, 25].Text.ToString();
                        var Payment = worksheet.Cells[i, 21].Text.ToString();
                        var KindOfService = worksheet.Cells[i, 31].Text.ToString();
                        // check
                        var checkPriorityType = _priorityRepository.FirstOrDefault(p => p.Name == PriorityType);
                        var getIdStar = _starRepository.FirstOrDefault(p => p.Name == Star);
                        var getIdBill = _typeBillRepository.FirstOrDefault(p => p.Name == Bill);
                        var getIdLocation = _locationRepository.FirstOrDefault(p => p.Name == Location);
                        var getCardTypeId = _cardsTypefastRepository.FirstOrDefault(p => p.Name == CardTypeName);
                        var getIDCustomerType = _typeCustomerRepository.FirstOrDefault(p => p.Name == CustomerType);
                        var getIDCountry = _countryRepository.FirstOrDefault(p => p.Name == Country);
                        var getIDProvince = _provinceRepository.FirstOrDefault(p => p.Name == Province);
                        var getIDDistrict = _districtRepository.FirstOrDefault(p => p.Name == District);
                        var getIDPaymenthod = _paymentRepository.FirstOrDefault(p => p.Name == Payment);
                        var getIDKindOfService = _kindOfServiceRepository.FirstOrDefault(p => p.Name == KindOfService);
                        if (PriorityType != "")
                        {
                            if (checkPriorityType == null)
                            {
                                errorPriorType = "Sheet " + worksheet.ToString() + " Row E" + i + " with value " + PriorityType + " not correct";
                            }
                            else
                            {
                                errorPriorType = null;
                            }
                        }
                        if (CustomerType != "")
                        {
                            if (getIDCustomerType == null)
                            {
                                customerType = "Sheet " + worksheet.ToString() + " Row F" + i + " with value " + CustomerType + " not correct";
                            }
                            else
                            {
                                customerType = null;
                            }
                        }
                        if (Country != "")
                        {
                            if (getIDCountry == null)
                            {
                                errorCountry = "Sheet " + worksheet.ToString() + " Row J" + i + " with value " + Country + " not correct";
                            }
                            else
                            {
                                errorCountry = null;
                            }
                        }
                        else
                        {
                            errorCountry = "Sheet " + worksheet.ToString() + " Row J" + i + " can't empty";
                        }
                        if (Province != "")
                        {
                            if (getIDProvince == null)
                            {
                                errorDistrict = "Sheet " + worksheet.ToString() + " Row K" + i + " with value " + Province + " not correct";
                            }
                            else
                            {
                                errorDistrict = null;
                            }
                        }
                        if (District != "")
                        {
                            if (getIDDistrict == null)
                            {
                                errorDistrict = "Sheet " + worksheet.ToString() + " Row L" + i + " with value " + District + " not correct";
                            }
                            else
                            {
                                errorDistrict = null;
                            }
                        }
                        if (Location != "")
                        {
                            if (getIdLocation == null)
                            {
                                errorLocation = "Sheet " + worksheet.ToString() + " Row N" + i + " with value " + Location + " not correct";
                            }
                            else
                            {
                                errorLocation = null;
                            }
                        }
                        if (CardTypeName != "")
                        {
                            if (getCardTypeId == null)
                            {
                                errorCardType = "Sheet " + worksheet.ToString() + " Row Y" + i + " with value " + CardTypeName + " not correct";
                            }
                            else
                            {
                                errorCardType = null;
                            }
                        }
                        if (Bill != "")
                        {
                            if (getIdBill == null)
                            {
                                errorBill = "Sheet " + worksheet.ToString() + " Row V" + i + " with value " + Bill + " not correct";
                            }
                            else
                            {
                                errorBill = null;
                            }
                        }
                        if (Payment != "")
                        {
                            if (getIDPaymenthod == null)
                            {
                                errorPayment = "Sheet " + worksheet.ToString() + " Row U" + i + " with value " + Payment + " not correct ";
                            }
                            else
                            {
                                errorPayment = null;
                            }
                        }
                        if (Star != "")
                        {
                            if (getIdStar == null)
                            {
                                errorStar = "Sheet " + worksheet.ToString() + " Row D" + i + " with value " + Star + " not correct ";
                            }
                            else
                            {
                                errorStar = null;
                            }
                        }
                        if (KindOfService != "")
                        {
                            if (getIDKindOfService == null)
                            {
                                errorKindOfService = "Sheet " + worksheet.ToString() + " Row AE" + i + " with value " + KindOfService + " not correct ";
                            }
                            else
                            {
                                errorKindOfService = null;
                            }
                        }
                        var validateTTC = new List<ValidateThongTinChungHotel>();
                        validateTTC.Add(new ValidateThongTinChungHotel
                        {
                            ErrorPayment = errorPayment,
                            ErrorDistrict = errorDistrict,
                            ErrorBill = errorBill,
                            ErrorCountry = errorCountry,
                            ErrorCardType = errorCardType,
                            ErrorCustomerType = customerType,
                            ErrorLocation = errorLocation,
                            ErrorProvince = errorProvince,
                            ErrorUuTien = errorPriorType,
                            ErrorStar = errorStar,
                            ErrorKindOfService = errorKindOfService

                        });

                        error.Add(new ValidateImporteExcelHotel
                        {
                            ValidateThongTinChung = validateTTC,
                        });
                    }


                }
                return error;
            }
        }
        public List<GetImportExcelValue> GetImportExcelHotel()
        {
            var test = HttpContext.Current.Request.Params.GetValues("path");
            var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"),test[0]);
            var pck = new OfficeOpenXml.ExcelPackage();
            using (var stream = File.OpenRead(tempFilePath))
            {
                pck.Load(stream);

                var workbook = pck.Workbook;
                var worksheet = workbook.Worksheets.First();
                var ls = new List<GetImportExcelValue>();
                int totalRow = worksheet.Dimension.End.Row;
              
                
                for (int i = 3; i <= totalRow; i++)
                {
                    string code = worksheet.Cells[i, 2].Text.ToString();
                    if(code != "")
                    {
                        ls.Add(new GetImportExcelValue
                        {
                            MCodePartner = worksheet.Cells[i, 1].Text.ToString(),
                            CodePartner = worksheet.Cells[i, 2].Text.ToString(),
                            HotelName = worksheet.Cells[i, 3].Text.ToString(),
                            Star = worksheet.Cells[i, 4].Text.ToString(),
                            PriorityType = worksheet.Cells[i, 5].Text.ToString(),
                            CustomerType = worksheet.Cells[i, 6].Text.ToString(),
                            CapacityRoom = worksheet.Cells[i, 7].Text.ToString(),
                            NumberAddress = worksheet.Cells[i, 8].Text.ToString(),
                            Address = worksheet.Cells[i, 9].Text.ToString(),
                            Country = worksheet.Cells[i, 10].Text.ToString(),
                            District = worksheet.Cells[i, 11].Text.ToString(),
                            Province = worksheet.Cells[i, 12].Text.ToString(),
                            ZipCode = worksheet.Cells[i, 13].Text.ToString(),
                            Location = worksheet.Cells[i, 14].Text.ToString(),
                            Longitude = worksheet.Cells[i, 15].Text.ToString(),
                            Latitude = worksheet.Cells[i, 16].Text.ToString(),
                            Phone = worksheet.Cells[i, 17].Text.ToString(),
                            Fax = worksheet.Cells[i, 15].Text.ToString(),
                            Email = worksheet.Cells[i, 16].Text.ToString(),
                            Website = worksheet.Cells[i, 17].Text.ToString(),
                            Payment = worksheet.Cells[i, 18].Text.ToString(),
                            Cash = worksheet.Cells[i, 19].Text.ToString(),
                            CreditCard = worksheet.Cells[i, 20].Text.ToString(),
                            CardTypeName = worksheet.Cells[i, 21].Text.ToString(),
                            Transfer = worksheet.Cells[i, 22].Text.ToString(),
                           
                         });
                    }
                   
                }

                return ls;
              
            }
         

        }
       
        public void ImportExcelHotel(string path)
        {
            var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"), path);
            var pck = new OfficeOpenXml.ExcelPackage();
            using (var stream = File.OpenRead(tempFilePath))
            {
                pck.Load(stream);

                var workbook = pck.Workbook;
                var worksheet = workbook.Worksheets["Thông tin chung"];
                var ls = new List<GetImportExcelValue>();
                int totalRow = worksheet.Dimension.End.Row;
                for (int i = 3; i <= totalRow; i++)
                {
                    string code = worksheet.Cells[i, 2].Text.ToString();
                    if (code != "")
                    {
                        ls.Add(new GetImportExcelValue
                        {
                            MCodePartner = worksheet.Cells[i, 1].Text.ToString(),
                            CodePartner = worksheet.Cells[i, 2].Text.ToString(),
                            HotelName = worksheet.Cells[i, 3].Text.ToString(),
                            Star = worksheet.Cells[i, 4].Text.ToString(),
                            PriorityType = worksheet.Cells[i, 5].Text.ToString(),
                            CustomerType = worksheet.Cells[i, 6].Text.ToString(),
                            CapacityRoom = worksheet.Cells[i, 7].Text.ToString(),
                            NumberAddress = worksheet.Cells[i, 8].Text.ToString(),
                            Address = worksheet.Cells[i, 9].Text.ToString(),
                            Country = worksheet.Cells[i, 10].Text.ToString(),
                            Province = worksheet.Cells[i, 11].Text.ToString(),
                            District = worksheet.Cells[i, 12].Text.ToString(),
                            ZipCode = worksheet.Cells[i, 13].Text.ToString(),
                            Location = worksheet.Cells[i, 14].Text.ToString(),
                            Longitude = worksheet.Cells[i, 15].Text.ToString(),
                            Latitude = worksheet.Cells[i, 16].Text.ToString(),
                            Phone = worksheet.Cells[i, 17].Text.ToString(),
                            Fax = worksheet.Cells[i, 18].Text.ToString(),
                            Email = worksheet.Cells[i, 19].Text.ToString(),
                            Website = worksheet.Cells[i, 20].Text.ToString(),
                            Payment = worksheet.Cells[i, 21].Text.ToString(),
                            Bill = worksheet.Cells[i, 22].Text.ToString(),
                            Cash = worksheet.Cells[i, 23].Text.ToString(),
                            CreditCard = worksheet.Cells[i, 24].Text.ToString(),
                            CardTypeName = worksheet.Cells[i, 25].Text.ToString(),
                            Transfer = worksheet.Cells[i, 26].Text.ToString(),
                            TaxCode = worksheet.Cells[i, 27].Text.ToString(),
                            Alias = worksheet.Cells[i, 28].Text.ToString(),
                            DirectorName = worksheet.Cells[i, 29].Text.ToString(),
                            PositionName = worksheet.Cells[i, 30].Text.ToString(),
                            ProductType = worksheet.Cells[i, 31].Text.ToString(),
                            DayOfWeek = worksheet.Cells[i, 32].Text.ToString(),
                        });
                    }
                }
                for (int i = 0; i < ls.Count; i++)
                {
                    var cash = ls[i].Cash;
                    var transfer = ls[i].Transfer;
                    var credit = ls[i].CreditCard;
                    var getNameBill = ls[i].Bill;
                    var codePat = ls[i].CodePartner;
                    var idCountry = ls[i].Country;
                    var idProvince = ls[i].Province;
                    var idDistrict = ls[i].District;
                    var idLocation = ls[i].Location;
                    var idStar = ls[i].Star;
                    var idCustomer = ls[i].CustomerType;
                    var idPriority = ls[i].PriorityType;
                    var idPayment = ls[i].Payment;
                    var getCardTypeName = ls[i].CardTypeName;
                    var getNameTypeofService = ls[i].ProductType;
                    var getIdBill = _typeBillRepository.FirstOrDefault(p => p.Name == getNameBill);
                    var getIDCustomer = _typeCustomerRepository.FirstOrDefault(p => p.Name == idCustomer);
                    var getIDPayment = _paymentRepository.FirstOrDefault(p => p.Name == idPayment);
                    var getIDCountry = _countryRepository.FirstOrDefault(p => p.Name == idCountry);
                    var getIDProvince = _provinceRepository.FirstOrDefault(p => p.Name == idProvince);
                    var getIDDistrict = _districtRepository.FirstOrDefault(p => p.Name == idDistrict);
                    var getIDLocation = _locationRepository.FirstOrDefault(p => p.Name == idLocation);
                    var getIDStar = _starRepository.FirstOrDefault(p => p.Name == idStar);
                    var getIDPriority = _priorityRepository.FirstOrDefault(p => p.Name == idPriority);
                    var getIDCNameHotel = _hotelRepository.FirstOrDefault(p => p.PartnerCode == codePat);
                    var getIdCardTypeName = _cardsTypefastRepository.FirstOrDefault(p => p.Name == getCardTypeName);
                    var getIdTypeOfService = _kindOfServiceRepository.FirstOrDefault(p => p.Name == getNameTypeofService);
                    Guid? StarId,BillId,CardTypeId,TypeOfServiceId,ProvinceId,DistrictId,LocationId,PaymentId,PriorityId,TypeCustomerId;
                    int Cash, Credit, Transfer;
                    if (cash == "")
                    {
                        Cash = 0;
                    }
                    else
                    {
                        Cash = int.Parse(cash);
                    }
                    if (credit == "")
                    {
                        Credit = 0;
                    }
                    else
                    {
                        Credit = int.Parse(credit);
                    }
                    if (transfer == "")
                    {
                        Transfer = 0;
                    }
                    else
                    {
                        Transfer = int.Parse(transfer);
                    }
                    if (idProvince == "")
                    {
                        ProvinceId = null;
                    }
                    else
                    {
                        ProvinceId = getIDProvince.Id;
                    }
                    if (idCustomer == "")
                    {
                        TypeCustomerId = null;
                    }
                    else
                    {
                        TypeCustomerId = getIDCustomer.Id;
                    }
                    if (idPayment == "")
                    {
                        PaymentId = null;
                    }
                    else
                    {
                        PaymentId = getIDPayment.Id;
                    }
                    if (idLocation == "")
                    {
                        LocationId = null;
                    }
                    else
                    {
                        LocationId = getIDLocation.Id;
                    }
                    if (idPriority == "")
                    {
                        PriorityId = null;
                    }
                    else
                    {
                        PriorityId = getIDPriority.Id;
                    }
                    if (idDistrict == "")
                    {
                        DistrictId = null;
                    }
                    else
                    {
                        DistrictId = getIDDistrict.Id;
                    }
                    if (idStar == "")
                    {
                        StarId = null;
                    }
                    else
                    {
                        StarId = getIDStar.Id;
                    }
                    if(getNameBill == "")
                    {
                        BillId = null;
                    }
                    else
                    {
                        BillId = getIdBill.Id;
                    }
                    if(getCardTypeName == "")
                    {
                        CardTypeId = null;
                    }
                    else
                    {
                        CardTypeId = getIdCardTypeName.Id;
                    }
                    if (getNameTypeofService == "")
                    {
                        TypeOfServiceId = null;
                    }
                    else
                    {
                        TypeOfServiceId = getIdTypeOfService.Id;
                    }
                    
                    bool t2 = false;
                    bool t3 = false;
                    bool t4 = false;
                    bool t5 = false;
                    bool t6 = false;
                    bool t7 = false;
                    bool cn = false;
                    string str = null;
                    string[] strArr = null;
                    int count = 0;
                    str = ls[i].DayOfWeek;
                    char[] splitchar = { ',' };
                    strArr = str.Split(splitchar);
                    for (count = 0; count <= strArr.Length - 1; count++)
                    {
                        if (strArr[count] == "T2")
                        {
                            t2 = true;
                        }
                        else if (strArr[count] == "T3")
                        {
                            t3 = true;
                        }
                        else if (strArr[count] == "T4")
                        {
                            t4 = true;
                        }
                        else if (strArr[count] == "T5")
                        {
                            t5 = true;
                        }
                        else if (strArr[count] == "T6")
                        {
                            t6 = true;
                        }
                        else if (strArr[count] == "T7")
                        {
                            t7 = true;
                        }
                        else if (strArr[count] == "CN")
                        {
                            cn = true;
                        }
                    }
                    if (getIDCNameHotel == null)
                    {
                            Hotel hotel = new Hotel
                        {

                            MPartnerCode = ls[i].MCodePartner,
                            PartnerCode = ls[i].CodePartner,
                            Name = ls[i].HotelName,
                            StarId = StarId,
                            PriorityId = PriorityId,
                            TypeCustomerId = TypeCustomerId,
                            CapacityRoom = ls[i].CapacityRoom,
                            HomeNumber = ls[i].NumberAddress,
                            Address = ls[i].Address,
                            CountryId = getIDCountry.Id,
                            ProvinceId = ProvinceId,
                            DisctrictId = DistrictId,
                            ZipCode = ls[i].ZipCode,
                            LocationId = LocationId,
                            Longitude = ls[i].Longitude,
                            Latitude = ls[i].Latitude,
                            PhoneNumber = ls[i].Phone,
                            FaxNumber = ls[i].Fax,
                            EmailAdress = ls[i].Email,
                            Website = ls[i].Website,
                            PaymentId = PaymentId,
                            Cash = Convert.ToBoolean(Convert.ToInt16(Cash)),
                            CreditCard = Convert.ToBoolean(Convert.ToInt16(Credit)),
                            CardsTypeId = CardTypeId,
                            Transfer = Convert.ToBoolean(Convert.ToInt16(Transfer)),
                            TaxCode = ls[i].TaxCode,
                            DirectorName = ls[i].DirectorName,
                            PositionName = ls[i].PositionName,
                            //KindOfServiceId = TypeOfServiceId,
                            MonsurchargePeriod = t2,
                            TuesurchargePeriod = t3,
                            WedsurchargePeriod = t4,
                            ThursurchargePeriod = t5,
                            FrisurchargePeriod = t6,
                            SatsurchargePeriod = t7,
                            SunsurchargePeriod = cn,
                            Alias = ls[i].Alias,
                            TypeBillId = BillId,
                          };
                        _hotelRepository.InsertAsync(hotel);
                    }
                    else
                    {
                        getIDCNameHotel.MPartnerCode = ls[i].MCodePartner;
                        getIDCNameHotel.PartnerCode = ls[i].CodePartner;
                        getIDCNameHotel.Name = ls[i].HotelName;
                        getIDCNameHotel.StarId = StarId;
                        getIDCNameHotel.PriorityId = PriorityId;
                        getIDCNameHotel.TypeCustomerId = TypeCustomerId;
                        getIDCNameHotel.CapacityRoom = ls[i].CapacityRoom;
                        getIDCNameHotel.HomeNumber = ls[i].NumberAddress;
                        getIDCNameHotel.Address = ls[i].Address;
                        getIDCNameHotel.CountryId = getIDCountry.Id;
                        getIDCNameHotel.ProvinceId = ProvinceId;
                        getIDCNameHotel.DisctrictId = DistrictId;
                        getIDCNameHotel.ZipCode = ls[i].ZipCode;
                        getIDCNameHotel.LocationId = LocationId;
                        getIDCNameHotel.Longitude = ls[i].Longitude;
                        getIDCNameHotel.Latitude = ls[i].Latitude;
                        getIDCNameHotel.PhoneNumber = ls[i].Phone;
                        getIDCNameHotel.FaxNumber = ls[i].Fax;
                        getIDCNameHotel.EmailAdress = ls[i].Email;
                        getIDCNameHotel.Website = ls[i].Website;
                        getIDCNameHotel.PaymentId = PaymentId;
                        getIDCNameHotel.Cash = Convert.ToBoolean(Convert.ToInt16(Cash));
                        getIDCNameHotel.CreditCard = Convert.ToBoolean(Convert.ToInt16(Credit));
                        getIDCNameHotel.CardsTypeId = CardTypeId;
                        getIDCNameHotel.Transfer = Convert.ToBoolean(Convert.ToInt16(Transfer));
                        getIDCNameHotel.TaxCode = ls[i].TaxCode;
                        getIDCNameHotel.DirectorName = ls[i].DirectorName;
                        getIDCNameHotel.PositionName = ls[i].PositionName;
                        //getIDCNameHotel.KindOfServiceId = TypeOfServiceId;
                        getIDCNameHotel.MonsurchargePeriod = t2;
                        getIDCNameHotel.TuesurchargePeriod = t3;
                        getIDCNameHotel.WedsurchargePeriod = t4;
                        getIDCNameHotel.ThursurchargePeriod = t5;
                        getIDCNameHotel.FrisurchargePeriod = t6;
                        getIDCNameHotel.SatsurchargePeriod = t7;
                        getIDCNameHotel.SunsurchargePeriod = cn;
                        getIDCNameHotel.Alias = ls[i].Alias;
                        getIDCNameHotel.TypeBillId = BillId;
                        _hotelRepository.UpdateAsync(getIDCNameHotel);
                    }
                  
                }

            }
        }
        public async Task<ListResultDto<GetListHotel>> GetAllServerSideDanhGia(string search)
        {
            var provinceIdS = HttpContext.Current.Request.Params.GetValues("search");
            if (ParaRequestIsNullOrEmpty(provinceIdS)) search = (provinceIdS[0]).Trim().ToLower();
            var list = await _hotelRepository.GetAllListAsync(p => p.Name.Contains(search) || p.PartnerCode.Contains(search));
            if (list.Count() == 0)
            {
                return null;
            }
            return new ListResultDto<GetListHotel>(list.MapTo<List<GetListHotel>>());
        }
        public void ImportContactAndAccountHotel(string path)
        {
            var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"), path);
            var pck = new OfficeOpenXml.ExcelPackage();
            using (var stream = File.OpenRead(tempFilePath))
            {
                pck.Load(stream);
                var workbook = pck.Workbook;
                var worksheet2 = workbook.Worksheets["Thông tin tài khoản"];
                var worksheet3 = workbook.Worksheets["Thông tin liên hệ"];
                var worksheet4 = workbook.Worksheets["Gia hop dong"];
                int totalRow2 = worksheet2.Dimension.End.Row;
                int totalRow3 = worksheet3.Dimension.End.Row;
                int totalRow4 = worksheet4.Dimension.End.Row;
                var TaiKhoan = new List<AccountExcelHotel>();
                var Contact = new List<ContractImfoExcelHotel>();
                var NhapGia = new List<ImportExcelInputPriceHotel>();
              
                for (int i = 2; i <= totalRow2; i++)
                {
                    string CodePartner = worksheet2.Cells[i, 1].Text.ToString();
                        if (CodePartner != "")
                    {
                            TaiKhoan.Add(new AccountExcelHotel
                        {
                            CodePartner = worksheet2.Cells[i, 1].Text.ToString(),
                            AccountName = worksheet2.Cells[i, 5].Text.ToString(),
                            AccountNumber = worksheet2.Cells[i, 6].Text.ToString(),
                            Currency = worksheet2.Cells[i, 7].Text.ToString(),
                            BankName = worksheet2.Cells[i, 8].Text.ToString(),
                            SwiftCode = worksheet2.Cells[i, 9].Text.ToString(),
                        });
                    }
                }
                for (int i = 2; i <= totalRow3; i++)
                {
                    string CodePartner = worksheet3.Cells[i, 1].Text.ToString();
                    if(CodePartner != "")
                    {
                        Contact.Add(new ContractImfoExcelHotel
                        {
                            CodePartner = worksheet3.Cells[i, 1].Text.ToString(),
                            DanhXung = worksheet3.Cells[i, 6].Text.ToString(),
                            ChucDanhNLH = worksheet3.Cells[i, 7].Text.ToString(),
                            HoTenNLH = worksheet3.Cells[i, 8].Text.ToString(),
                            EmailNLH = worksheet3.Cells[i, 10].Text.ToString(),
                            PhoneNLH = worksheet3.Cells[i, 9].Text.ToString(),
                        });
                    }
                }
                for (int i = 2; i <= totalRow4; i++)
                {
                    string CodeParner = worksheet4.Cells[i, 1].Text.ToString();
                    if (CodeParner != "")
                    {
                        NhapGia.Add(new ImportExcelInputPriceHotel
                        {
                            CodeParner = worksheet4.Cells[i, 1].Text.ToString(),
                            RoomType = worksheet4.Cells[i,3].Text.ToString(),
                            CustomerZone = worksheet4.Cells[i, 5].Text.ToString(),
                            Customer = worksheet4.Cells[i, 6].Text.ToString(),
                            From = worksheet4.Cells[i, 7].Text.ToString(),
                            To = worksheet4.Cells[i, 8].Text.ToString(),
                            HighPrice = worksheet4.Cells[i, 9].Text.ToString(),
                            LowPrice = worksheet4.Cells[i, 10].Text.ToString(),
                            Prioritize = worksheet4.Cells[i, 11].Text.ToString(),
                            Currency = worksheet4.Cells[i, 12].Text.ToString(),
                            Breakfast = worksheet4.Cells[i, 13].Text.ToString(),
                            Description = worksheet4.Cells[i, 14].Text.ToString(),
                           
                        });
                    }
                }
                for (int i = 0; i < TaiKhoan.Count; i++)
                {
                    Guid? CurrencyId;
                    var BankAccountNumber = TaiKhoan[i].AccountNumber;
                    var CodePartner = TaiKhoan[i].CodePartner;
                    var Currency = TaiKhoan[i].Currency;
                    var getIDCNameHotel = _hotelRepository.FirstOrDefault(p => p.PartnerCode ==  CodePartner);
                    var getIDCurrency = _currencyRepository.FirstOrDefault(p => p.Name == Currency);
                    var getIDHotelInBankInfo = _bankRepository.FirstOrDefault(p => p.HotelId == getIDCNameHotel.Id && p.BankAccountNumber == BankAccountNumber);
                    if(Currency != "")
                    {
                        CurrencyId = getIDCurrency.Id;
                    }
                    else
                    {
                        CurrencyId = null;
                    }
                    if(getIDHotelInBankInfo == null)
                    {
                        BankInformation BankInfo = new BankInformation
                        {
                            
                            HotelId = getIDCNameHotel.Id,
                            BankAccountName = TaiKhoan[i].AccountName,
                            BankAccountNumber = TaiKhoan[i].AccountNumber,
                            CurrencyId = CurrencyId,
                            BankName = TaiKhoan[i].BankName,
                            SwiftCode = TaiKhoan[i].SwiftCode,
                            
                        };
                        _bankRepository.InsertAsync(BankInfo);
                    }
                    else
                    {
                        getIDHotelInBankInfo.HotelId = getIDCNameHotel.Id;
                        getIDHotelInBankInfo.BankAccountName = TaiKhoan[i].AccountName;
                        getIDHotelInBankInfo.BankAccountNumber = TaiKhoan[i].AccountNumber;
                        getIDHotelInBankInfo.CurrencyId = CurrencyId;
                        getIDHotelInBankInfo.BankName = TaiKhoan[i].BankName;
                        getIDHotelInBankInfo.SwiftCode = TaiKhoan[i].SwiftCode;
                        _bankRepository.UpdateAsync(getIDHotelInBankInfo);
                    }
                   
                }
               
                for (int i = 0; i < Contact.Count; i++)
                {
                    var Name = Contact[i].HoTenNLH;
                    var CodePartner = Contact[i].CodePartner;
                    var getID = _hotelRepository.FirstOrDefault(p => p.PartnerCode == CodePartner);
                    var getIDHotelInContactInfo = _contactRepository.FirstOrDefault(p => p.HotelId == getID.Id && p.Name == Name);
                    if(getIDHotelInContactInfo == null)
                    {
                        Contact contactInfo = new Contact
                        {

                            HotelId = getID.Id,
                            alias = Contact[i].DanhXung,
                            Position = Contact[i].ChucDanhNLH,
                            Name = Contact[i].HoTenNLH,
                            EmailAdress = Contact[i].EmailNLH,
                            PhoneNumber = Contact[i].PhoneNLH,
                            
                        };
                        _contactRepository.InsertAsync(contactInfo);
                    }
                    else
                    {
                        getIDHotelInContactInfo.HotelId = getID.Id;
                        getIDHotelInContactInfo.alias = Contact[i].DanhXung;
                        getIDHotelInContactInfo.Position = Contact[i].ChucDanhNLH;
                        getIDHotelInContactInfo.Name = Contact[i].HoTenNLH;
                        getIDHotelInContactInfo.EmailAdress = Contact[i].EmailNLH;
                        getIDHotelInContactInfo.PhoneNumber = Contact[i].PhoneNLH;
                        _contactRepository.UpdateAsync(getIDHotelInContactInfo);
                    }

                }
                for (int i = 0; i < NhapGia.Count; i++)
                {
                    Guid? RoomTypeId, TypeCustomerId, CustomerId, CurrencyId,TypeBreakfastId;
                    float PriceMax, Price;
                    int IsYes;
                    var isyes = NhapGia[i].Prioritize;
                    var pricemax = NhapGia[i].HighPrice;
                    var pricelow = NhapGia[i].LowPrice;
                    var TransportEffectiveDate = DateTime.Parse(NhapGia[i].From);
                    var TransportExpiartionDate = DateTime.Parse(NhapGia[i].To);
                    string From = TransportEffectiveDate.ToString("yyyy-MM-dd HH:mm:ss");
                    string To = TransportExpiartionDate.ToString("yyyy-MM-dd HH:mm:ss");
                    var from = DateTime.Parse(From);
                    var to = DateTime.Parse(To);
                    var getTypeCustomerName = NhapGia[i].Customer;
                    var getTypeBreafast = NhapGia[i].Breakfast;
                    var codePartner = NhapGia[i].CodeParner;
                    var customer = NhapGia[i].CustomerZone;
                    var getIDHotel = _hotelRepository.FirstOrDefault(p => p.PartnerCode == codePartner);
                    var getCustomer = _customerRepository.FirstOrDefault(p => p.Name == customer);      
                    var NameCurrency = NhapGia[i].Currency;
                    var NamePaymenthod = NhapGia[i].Payment;
                    var getRoomTypeName = NhapGia[i].RoomType;
                   var getIDCurrency = _currencyRepository.FirstOrDefault(p => p.Name == NameCurrency);
                    var getIDPaymenthod = _paymentRepository.FirstOrDefault(p => p.Name == NamePaymenthod);
                    var getIdCustomerType = _typeCustomerRepository.FirstOrDefault(p => p.Name == getTypeCustomerName);
                    var getIdRoomType = _roomtypeRepository.FirstOrDefault(p => p.Name == getRoomTypeName);
                    var getIdBreafast = _typeBreakfastRepository.FirstOrDefault(p => p.Name == getTypeBreafast);
                    var getIDHotelInContactInfo = _addPackageContractPriceRepository.FirstOrDefault(p => p.HotelId == getIDHotel.Id && p.EffectiveDate == from && p.ExpiartionDate == to && p.RoomtypeId == getIdRoomType .Id);
                    if (NameCurrency != "")
                    {
                        CurrencyId =getIDCurrency.Id;
                    }
                    else
                    {
                        CurrencyId = null;
                    }
                    if (getTypeBreafast != "")
                    {
                        TypeBreakfastId = getIdBreafast.Id;
                    }
                    else
                    {
                        TypeBreakfastId = null;
                    }
                    if (isyes != "")
                    {
                        IsYes = int.Parse(isyes);
                    }
                    else
                    {
                        IsYes = 0;
                    }
                    if (pricemax != "")
                    {
                        PriceMax = float.Parse(pricemax);
                    }
                    else
                    {
                        PriceMax = 0;
                    }
                    if (pricelow != "")
                    {
                        Price = float.Parse(pricelow);
                    }
                    else
                    {
                        Price = 0;
                    }
                    if (getRoomTypeName != "")
                    {
                        var HotelRoomId = _hotelRoomRepository.FirstOrDefault(p => p.HotelId == getIDHotel.Id && p.RoomtypeId == getIdRoomType.Id);
                        RoomTypeId = HotelRoomId.Id;
                    }
                    else
                    {
                        RoomTypeId = null;
                    }
                    if (getTypeCustomerName != "")
                    {
                        TypeCustomerId = getIdCustomerType.Id;
                    }
                    else
                    {
                        TypeCustomerId = null;
                    }
                    if (customer != "")
                    {
                        CustomerId = getCustomer.Id;
                    }
                    else
                    {
                        CustomerId = null;
                    }

                    if (getIDHotelInContactInfo == null)
                    {
                        AddPackageContractPrice price = new AddPackageContractPrice
                        {

                            HotelId = getIDHotel.Id,
                            HotelRoomId = RoomTypeId,
                            TypeCustomerId = TypeCustomerId,
                            CustomerId = CustomerId,
                            EffectiveDate = from,
                            ExpiartionDate = to,
                            PriceMax = PriceMax,
                            Price = Price,
                            IsYes = Convert.ToBoolean(Convert.ToInt16(IsYes)),
                            CurrencyId = CurrencyId,
                            TypeBreakfastId = TypeBreakfastId,
                            Note = NhapGia[i].Description,
                        
                        };
                        _addPackageContractPriceRepository.InsertAsync(price);
                    }
                    else
                    {
                        getIDHotelInContactInfo.HotelId = getIDHotel.Id;
                        getIDHotelInContactInfo.HotelRoomId = RoomTypeId;
                        getIDHotelInContactInfo.TypeCustomerId = TypeCustomerId;
                        getIDHotelInContactInfo.CustomerId = CustomerId;
                        getIDHotelInContactInfo.EffectiveDate =from;
                        getIDHotelInContactInfo.ExpiartionDate =to;
                        getIDHotelInContactInfo.PriceMax = PriceMax;
                        getIDHotelInContactInfo.Price = Price;
                        getIDHotelInContactInfo.IsYes = Convert.ToBoolean(Convert.ToInt16(IsYes));
                        getIDHotelInContactInfo.CurrencyId = CurrencyId;
                        getIDHotelInContactInfo.TypeBreakfastId = TypeBreakfastId;
                        getIDHotelInContactInfo.Note = NhapGia[i].Description;
                        _addPackageContractPriceRepository.UpdateAsync(getIDHotelInContactInfo);

                    }
                   
                }
            }
          
        }
        public async Task UpdateHotelAsnc(UpdateHotelDto input)
        {
                DateTime Times = DateTime.Now;
                var updateHotel = input.MapTo<HotelPartner>();
                updateHotel.Id = Guid.Empty;
                updateHotel.HotelId = input.Id;
                updateHotel.StatusPurchasing = 1;
                updateHotel.RequestDate = Times;
                updateHotel.DepartmentRequest = input.Name;
                foreach (var contact in updateHotel.Contacts)
                {
                    contact.Id = Guid.Empty;
                }
                foreach (var bank in updateHotel.BankInformations)
                {
                    bank.Id = Guid.Empty;
                }
                foreach (var linked in updateHotel.ServiceLinkeds)
                {
                    linked.Id = Guid.Empty;
                }
                var idPartner = await _hotelPartnerRepository.InsertOrUpdateAndGetIdAsync(updateHotel);
                var request = new RequestPartner();
                request.HotelPartnerId = idPartner;
                request.NotePartner = input.NotePartner;
                request.RequestDatimePartner = Times;
                request.Department = updateHotel.Name;
                _requestPartnerRepository.Insert(request);
            
        }

        public object GetAllServerSideForSelect(string search)
        {
            IEnumerable<Hotel> listAll = _hotelRepository.GetAll().ToList();
            var list = listAll.Select(p => new
            {
                id = p.Name + " - " + p.Star + " s- " + p.Address,
                text = p.Name + " - " + p.Star + " s- " + p.Address
            });
            if (search != null)
            {
                var filter = list
                 .Where(p => VietToEngStr.RemoveSign4VietnameseString(p.text.ToLower())
                  .Contains(VietToEngStr.RemoveSign4VietnameseString(search.ToLower())));
                var result = filter.Take(30).ToArray();
                return result;
            }
            else
            {
                var result = list.Take(30).ToArray();
                return result;
            }
        }

        public FileDto GetHotelsToExcel(List<ExelHotelInputDto> input)
        {
            return _userListExcelExporter.ExportToFile(input);
        }

        public object GetDestinationHotelServerSideForSelect(string search)
        {
            search = HttpContext.Current.Request.Params.GetValues("term") != null ?
                    HttpContext.Current.Request.Params.GetValues("term")[0].Trim().ToLower() : "";

            var provinceIdS = HttpContext.Current.Request.Params.GetValues("provinceId");
            var provinceId = new Guid();
            if (ParaRequestIsNullOrEmpty(provinceIdS)) provinceId = new Guid(provinceIdS[0]);

            var listAll = _hotelRepository.GetAll();
            if (provinceId != new Guid()) listAll = listAll.Where(p => p.ProvinceId == provinceId)
                 .OrderByDescending(p => p.CreationTime);
            var listAllSelect=listAll
                 .Select(p => new
                 {

                //id = p.Name + " - " + p.Star + " s- " + p.Address,
                id = p.Id,
                text = p.Name + ", ",
                 }).ToList();
            if (search != null)
            {
                var filter = listAllSelect
                 .Where(p => VietToEngStr.RemoveSign4VietnameseString(p.text.ToLower())
                  .Contains(VietToEngStr.RemoveSign4VietnameseString(search.ToLower())));
                
                var result = filter.Take(30).ToArray();
                return result;
            }
            else
            {
                var result = listAll.ToArray().Take(30);
                return result;
            }
        }

        public async Task DeleteServiceLinked(Guid Id)
        {
            await _serviceLinkedRepository.DeleteAsync(Id);
        }
        public object GetImageReviewServiceLinker(Guid id)
        {
            var place = "Place";
            var res = "Restaurant";
            var picPlace = "PicturePlace";
            var picRestaurant = "PictureRestaurant";
            var listAll = _hotelRepository.GetAll()
                .Where(p => p.Id == id)
                .Select((p) => new
                {
                    linker = p.ServiceLinkeds.Select(x => new
                    {
                        RestaurantType = (x.Restaurant != null) ? x.Restaurant.ReferenceRestaurants.Select(a => a.Restauranttype).FirstOrDefault() : null,
                        LowPrice = (x.Restaurant != null) ? x.Restaurant.Menus.OrderBy(m => m.Price).Select(m => new
                        {
                            m.Price,
                            m.Currency.Name,

                        }).FirstOrDefault() : null,
                        KindService = (x.RestaurantId != null) ? x.Restaurant.KindService.Name : x.Place.KindService.Name,
                        OpenTime = (x.Place != null) ? x.Place.Open : x.Restaurant.OpenTime.Name,
                        CloseTime = (x.Place != null) ? x.Place.Close : null,
                        Address = (x.Restaurant != null) ? x.Restaurant.Address : x.Place.Address,
                        Tag = (x.RestaurantId != null) ? x.Restaurant.PlaceType.Name : x.Place.TypePlace.Name,
                        Country = (x.PlaceId != null)? x.Place.Country.Name : x.Restaurant.Country.Name,
                        Name = (x.PlaceId != null) ? x.Place.Name : x.Restaurant.Name,
                        ServiceUrl = (x.PlaceId != null) ? place : res,
                        ServiceId = (x.PlaceId != null) ? x.PlaceId : x.RestaurantId,
                        PicUrl = (x.PlaceId != null) ? picPlace : picRestaurant,
                        FileName = (x.Place.FilePicSubs.Where(n => n.Position == 1).FirstOrDefault() != null) ? x.Place.FilePicSubs.Where(n => n.Position == 1).FirstOrDefault().FileName : x.Restaurant.FilePicSubs.Where(n => n.Position == 1).FirstOrDefault().FileName,
                        PicId = (x.Place.FilePicSubs.Where(n => n.Position == 1).FirstOrDefault() != null) ? x.Place.FilePicSubs.Where(n => n.Position == 1).FirstOrDefault().Id.ToString() : x.Restaurant.FilePicSubs.Where(n => n.Position == 1).FirstOrDefault().Id.ToString(),
                    }).ToList(),
                  
                }).ToList();
            return listAll;
        }
        public object GetAllServerSideAll1(ServerSideDatatableInput input)
        {

            //get parameter
            if (input.orderColumnName.IsNullOrEmpty() && input.dir.IsNullOrEmpty() && input.search.IsNullOrEmpty())
            {
                input.search = HttpContext.Current.Request.Params.GetValues("search[value]") != null ?
                    HttpContext.Current.Request.Params.GetValues("search[value]")[0].Trim().ToLower() : "";
                var orderColumnIndex = HttpContext.Current.Request.Params.GetValues("order[0][column]") != null ?
                    HttpContext.Current.Request.Params.GetValues("order[0][column]")[0] : "";
                input.orderColumnName = HttpContext.Current.Request.Params.GetValues("columns[" + orderColumnIndex + "][name]") != null ?
                    HttpContext.Current.Request.Params.GetValues("columns[" + orderColumnIndex + "][name]")[0] : "";
                input.dir = HttpContext.Current.Request.Params.GetValues("order[0][dir]") != null ?
                    HttpContext.Current.Request.Params.GetValues("order[0][dir]")[0] : "";
            }
            //get advance search
            #region get advance search
            var countryS = HttpContext.Current.Request.Params.GetValues("country");
            Guid countryGuidId = new Guid();
            if (ParaRequestIsNullOrEmpty(countryS)) countryGuidId = new Guid(countryS[0]);
            var provinceS = HttpContext.Current.Request.Params.GetValues("province");
            Guid provinceGuidId = new Guid();
            if (ParaRequestIsNullOrEmpty(provinceS)) provinceGuidId = new Guid(provinceS[0]);
            var starS = HttpContext.Current.Request.Params.GetValues("star");
            Guid starGuidId = new Guid();
            if (ParaRequestIsNullOrEmpty(starS)) starGuidId = new Guid(starS[0]);
            var roomNumberS = HttpContext.Current.Request.Params.GetValues("roomNumber");
            var roomNumberString = "";
            if (ParaRequestIsNullOrEmpty(roomNumberS)) roomNumberString = roomNumberS[0];
            var priceFromS = HttpContext.Current.Request.Params.GetValues("priceFrom");
            var priceFromString = "";
            if (ParaRequestIsNullOrEmpty(priceFromS)) priceFromString = priceFromS[0];
            var priceToS = HttpContext.Current.Request.Params.GetValues("priceTo");
            var priceToString = "";
            if (ParaRequestIsNullOrEmpty(provinceS)) priceToString = priceToS[0];

            var locationS = HttpContext.Current.Request.Params.GetValues("location");
            Guid locationGuidId = new Guid();
            if (ParaRequestIsNullOrEmpty(locationS)) locationGuidId = new Guid(locationS[0]);

            var partnerCodefromS = HttpContext.Current.Request.Params.GetValues("partnerCode");
            var partnerCode = "";

            if (ParaRequestIsNullOrEmpty(partnerCodefromS)) partnerCode = partnerCodefromS[0].ToLower();

            var nameFromS = HttpContext.Current.Request.Params.GetValues("name");
            var name = "";

            if (ParaRequestIsNullOrEmpty(nameFromS)) name = nameFromS[0].ToLower();
            #endregion
            //get all 
            var listAll = _hotelRepository.GetAll()
                .WhereIf(_permissionChecker.IsGranted(AppPermissions.CongThongTin_View), p => p.CreatorUserId == _session.UserId)
                .OrderByDescending(p => p.CreationTime)
                .Select((p) => new
                {
                    p.CreationTime,
                    Location = (p.Location != null) ? p.Location.Name : "",
                    p.LocationId,
                    p.Name,
                    p.PartnerCode,
                    Star = (p.Star != null) ? p.Star.Name : "",
                    p.StarId,
                    p.Address,
                    p.Website,
                    Country = (p.Country != null) ? p.Country.Name : "",
                    p.CountryId,
                    Province = (p.Province != null) ? p.Province.Name : "",
                    p.ProvinceId,
                    District = (p.District != null) ? p.District.Name : "",
                    p.CapacityRoom,
                    p.Id,
                    p.Latitude,
                    p.Longitude,
                    price = p.AddPackageContractPrices.Where(x => x.Currency.Name == "VND").OrderBy(x => x.Price).Select(x => new
                    {
                        x.Price,
                        x.HotelRoom.Roomtype.Name,
                        x.Note,
                        menu = x.TypeBreakfast.Name,
                       }).FirstOrDefault(),
                    ImageId = (p.FilePicSubs.Where(x => x.Position == 1).FirstOrDefault() != null) ? p.FilePicSubs.Where(x => x.Position == 1).FirstOrDefault().Id.ToString() : "",
                    ImageName = (p.FilePicSubs.Where(x => x.Position == 1).FirstOrDefault() != null) ? p.FilePicSubs.Where(x => x.Position == 1).FirstOrDefault().FileName : "",
                    Icons = p.FilePicSubs.Where(x => x.NewColumn1 != null).Select(x => new
                    {
                        x.NewColumn1,
                        x.Id,
                    }).ToList(),
                }).ToList();
            //filter
            var listFilter = listAll.Where(p => p.Name != null ?
            VietToEngStr.RemoveSign4VietnameseString(p.Name.ToLower()).Contains(VietToEngStr.RemoveSign4VietnameseString(input.search)) : true);

            listFilter = listFilter.Where(p => p.Name != null ?
            VietToEngStr.RemoveSign4VietnameseString(p.Name.ToLower()).Contains(VietToEngStr.RemoveSign4VietnameseString(name)) : true);

            listFilter = listFilter.Where(p => p.PartnerCode != null ?
            VietToEngStr.RemoveSign4VietnameseString(p.PartnerCode.ToLower()).Contains(VietToEngStr.RemoveSign4VietnameseString(partnerCode)) : true);

            if (ParaRequestIsNullOrEmpty(roomNumberS))
                listFilter = listFilter.Where(p => p.CapacityRoom == roomNumberString);
            //filter price 
            if (ParaRequestIsNullOrEmpty(countryS))
                listFilter = listFilter.Where(p => p.CountryId == countryGuidId);
            if (ParaRequestIsNullOrEmpty(provinceS))
                listFilter = listFilter.Where(p => p.ProvinceId == provinceGuidId);
            if (ParaRequestIsNullOrEmpty(starS))
                listFilter = listFilter.Where(p => p.StarId != null && p.StarId == starGuidId);
            if (ParaRequestIsNullOrEmpty(locationS))
                listFilter = listFilter.Where(p => p.LocationId == locationGuidId);
            //sort
            if (input.orderColumnName == "Name")
            {
                if (input.dir == "asc") listFilter = listFilter.OrderBy(p => p.Name);
                else listFilter = listFilter.OrderByDescending(p => p.Name);
            }
            else if (input.orderColumnName == "Star")
            {
                if (input.dir == "asc") listFilter = listFilter.OrderBy(p => p.Star);
                else listFilter = listFilter.OrderByDescending(p => p.Star);
            }


            //skip take
            var listSkipTake = listFilter.Skip(input.start).Take(input.length);
            var result = listSkipTake.ToArray();
            return new
            {
                draw = input.draw,
                recordsTotal = listAll.Count(),
                recordsFiltered = listFilter.Count(),
                data = result
            };
        }

        public object GetAllServerSideAsyncp(ServerSideDatatableInput input)
        {
            //get parameter
            if (input.orderColumnName.IsNullOrEmpty() && input.dir.IsNullOrEmpty() && input.search.IsNullOrEmpty())
            {
                input.search = HttpContext.Current.Request.Params.GetValues("search[value]") != null ?
                    HttpContext.Current.Request.Params.GetValues("search[value]")[0].Trim().ToLower() : "";
                var orderColumnIndex = HttpContext.Current.Request.Params.GetValues("order[0][column]") != null ?
                    HttpContext.Current.Request.Params.GetValues("order[0][column]")[0] : "";
                input.orderColumnName = HttpContext.Current.Request.Params.GetValues("columns[" + orderColumnIndex + "][name]") != null ?
                    HttpContext.Current.Request.Params.GetValues("columns[" + orderColumnIndex + "][name]")[0] : "";
                input.dir = HttpContext.Current.Request.Params.GetValues("order[0][dir]") != null ?
                    HttpContext.Current.Request.Params.GetValues("order[0][dir]")[0] : "";
            }
            //get advance search
            #region get advance search
            var countryS = HttpContext.Current.Request.Params.GetValues("country");
            Guid countryGuidId = new Guid();
            if (ParaRequestIsNullOrEmpty(countryS)) countryGuidId = new Guid(countryS[0]);
            var provinceS = HttpContext.Current.Request.Params.GetValues("province");
            Guid provinceGuidId = new Guid();
            if (ParaRequestIsNullOrEmpty(provinceS)) provinceGuidId = new Guid(provinceS[0]);
            var starS = HttpContext.Current.Request.Params.GetValues("star");
            Guid starGuidId = new Guid();
            if (ParaRequestIsNullOrEmpty(starS)) starGuidId = new Guid(starS[0]);
            var roomNumberS = HttpContext.Current.Request.Params.GetValues("roomNumber");
            var roomNumberString = "";
            if (ParaRequestIsNullOrEmpty(roomNumberS)) roomNumberString = roomNumberS[0];
            var priceFromS = HttpContext.Current.Request.Params.GetValues("priceFrom");
            var priceFromString = "";
            if (ParaRequestIsNullOrEmpty(priceFromS)) priceFromString = priceFromS[0];
            var priceToS = HttpContext.Current.Request.Params.GetValues("priceTo");
            var priceToString = "";
            if (ParaRequestIsNullOrEmpty(provinceS)) priceToString = priceToS[0];

            var locationS = HttpContext.Current.Request.Params.GetValues("location");
            Guid locationGuidId = new Guid();
            if (ParaRequestIsNullOrEmpty(locationS)) locationGuidId = new Guid(locationS[0]);

            var partnerCodefromS = HttpContext.Current.Request.Params.GetValues("partnerCode");
            var partnerCode = "";
            if (ParaRequestIsNullOrEmpty(partnerCodefromS)) partnerCode = partnerCodefromS[0].ToLower();

            var nameFromS = HttpContext.Current.Request.Params.GetValues("name");
            var name = "";
            if (ParaRequestIsNullOrEmpty(nameFromS)) name = nameFromS[0].ToLower();
            #endregion
            //get all 
            var listAll = _hotelRepository.GetAll()
                .Where(p => p.CreatorUserId == 6)
                .OrderByDescending(p => p.CreationTime)
                .Select((p) => new
                {
                    //TypeCustomer = (p.TypeCustomer != null) ? p.TypeCustomer.Name : "",
                    //p.TypeCustomerId,
                    p.CreationTime,
                    Location = (p.Location != null) ? p.Location.Name : "",
                    p.LocationId,
                    p.Name,
                    p.PartnerCode,
                    Star = (p.Star != null) ? p.Star.Name : "",
                    p.StarId,
                    p.Address,
                    p.Website,
                    Country = (p.Country != null) ? p.Country.Name : "",
                    p.CountryId,
                    Province = (p.Province != null) ? p.Province.Name : "",
                    p.ProvinceId,
                    District = (p.District != null) ? p.District.Name : "",
                    p.CapacityRoom,
                    p.Id,
                    //SeriesCheck = (p.SeriesBookingHotels.FirstOrDefault() != null) ? true:false,


                }).ToList();
            //filter
            var listFilter = listAll.Where(p => p.Name != null ?
            VietToEngStr.RemoveSign4VietnameseString(p.Name.ToLower()).Contains(VietToEngStr.RemoveSign4VietnameseString(input.search)) : true);

            listFilter = listFilter.Where(p => p.Name != null ?
            VietToEngStr.RemoveSign4VietnameseString(p.Name.ToLower()).Contains(VietToEngStr.RemoveSign4VietnameseString(name)) : true);

            listFilter = listFilter.Where(p => p.PartnerCode != null ?
            VietToEngStr.RemoveSign4VietnameseString(p.PartnerCode.ToLower()).Contains(VietToEngStr.RemoveSign4VietnameseString(partnerCode)) : true);

            if (ParaRequestIsNullOrEmpty(roomNumberS))
                listFilter = listFilter.Where(p => p.CapacityRoom == roomNumberString);
            //filter price 
            if (ParaRequestIsNullOrEmpty(countryS))
                listFilter = listFilter.Where(p => p.CountryId == countryGuidId);
            if (ParaRequestIsNullOrEmpty(provinceS))
                listFilter = listFilter.Where(p => p.ProvinceId == provinceGuidId);
            if (ParaRequestIsNullOrEmpty(starS))
                listFilter = listFilter.Where(p => p.StarId != null && p.StarId == starGuidId);
            if (ParaRequestIsNullOrEmpty(locationS))
                listFilter = listFilter.Where(p => p.LocationId == locationGuidId);
            //sort
            if (input.orderColumnName == "Name")
            {
                if (input.dir == "asc") listFilter = listFilter.OrderBy(p => p.Name);
                else listFilter = listFilter.OrderByDescending(p => p.Name);
            }
            else if (input.orderColumnName == "Star")
            {
                if (input.dir == "asc") listFilter = listFilter.OrderBy(p => p.Star);
                else listFilter = listFilter.OrderByDescending(p => p.Star);
            }


            //skip take
            var listSkipTake = listFilter.Skip(input.start).Take(input.length);
            var result = listSkipTake.ToArray();
            return new
            {
                draw = input.draw,
                recordsTotal = listAll.Count(),
                recordsFiltered = listFilter.Count(),
                data = result
            };
        }

        public object GetAllServerSideForSelect2PartnerCode()

        {
            var term = HttpContext.Current.Request.Params.GetValues("term");
            string search = "";
            if (term != null) search = term[0];
            var page = HttpContext.Current.Request.Params.GetValues("page");

            var listHotel = _hotelRepository.GetAll().Where(p => p.PartnerCode != null).Select(p => new
            {
                id = p.Id,
                text = p.PartnerCode
            }).ToList();
            var listPackage = _packageRepository.GetAll().Where(p => p.PartnerCode != null).Select(p => new
            {
                id = p.Id,
                text = p.PartnerCode
            }).ToList();
            var listPlace = _placeRepository.GetAll().Where(p => p.PartnerCode != null).Select(p => new
            {
                id = p.Id,
                text = p.PartnerCode
            }).ToList();
            var listRestaurant = _restaurantRepository.GetAll().Where(p => p.PartnerCode != null).Select(p => new
            {
                id = p.Id,
                text = p.PartnerCode
            }).ToList();
            var listTransport = _transportRepository.GetAll().Where(p => p.PartnerCode != null).Select(p => new
            {
                id = p.Id,
                text = p.PartnerCode
            }).ToList();

            //var listHotel1 = listHotel.Select(p => new
            //{
            //    id=p.Id,
            //    text=  p.PartnerCode
            //});

            //var listPackage1 = listPackage.Select(p => new
            //{
            //    id = p.Id,
            //    text = p.PartnerCode
            //});

            //var listPlace1 = listPlace.Select(p => new
            //{
            //    id = p.Id,
            //    text = p.PartnerCode
            //});

            //var listRestaurant1 = listRestaurant.Select(p => new
            //{
            //    id = p.Id,
            //    text = p.PartnerCode
            //});

            //var listTransport1 = listTransport.Select(p => new
            //{
            //    id = p.Id,
            //    text = p.PartnerCode
            //});

            var listNew1 = listHotel
                .Concat(listPackage)
                .Concat(listPlace)
                .Concat(listRestaurant)
                .Concat(listTransport).ToList();

            if (search == "" || search.IsNullOrEmpty())
            {
                var filter2 = listNew1.Select(p => new
                {
                    id = p.id,
                    text = p.text
                }).OrderBy(p => p.text).ToList();

                var result = filter2.Take(30).ToArray();

                return result;
            }
            else {
                var filter1 = listNew1
                  .Where(a => VietToEngStr.RemoveSign4VietnameseString(a.text.ToLower())
                  .Contains(VietToEngStr.RemoveSign4VietnameseString(search.ToLower())));

                var filter2 = filter1.Select(p => new
                {
                    id = p.id,
                    text = p.text
                }).OrderBy(p => p.text).ToList();

                var result = filter2.Take(30).ToArray();

                return result;
            }
        }

        public async Task<GetInfomationById> GetInfomationByIdAsync(Guid Id)
        {
           
             if(Id != null)
             {
                 var hotel = await _hotelRepository.FirstOrDefaultAsync(p => p.Id == Id);
                 if (hotel != null)
                 {
                    return hotel.MapTo<GetInfomationById>();
                 }

                var package = await _packageRepository.FirstOrDefaultAsync(p => p.Id == Id);
                if (package != null)
                {
                    return package.MapTo<GetInfomationById>();
                }

                var place = await _placeRepository.FirstOrDefaultAsync(p => p.Id == Id);
                if (place != null)
                {
                    return place.MapTo<GetInfomationById>();
                }

                var restaurant = await _restaurantRepository.FirstOrDefaultAsync(p => p.Id == Id);
                if (restaurant != null)
                {
                    return restaurant.MapTo<GetInfomationById>();
                }
                var transport = await _transportRepository.FirstOrDefaultAsync(p => p.Id == Id);
                if (transport != null)
                {
                    return transport.MapTo<GetInfomationById>();
                }
            }

                return null;
        }

        public async Task DeleteHotelPartnerInHotel(Guid Id)
        {
            await _hotelPartnerRepository.DeleteAsync(Id);
        }

        public async Task<GetHotelById> GetHotelPartnerByIdAsync(EntityDto<Guid> input)
        {
            var hotel = _hotelPartnerRepository.GetAllIncluding(p=>p.BankInformations ,a=>a.Contacts , c =>c.ServiceLinkeds).Where(e =>e.Id==input.Id).ToList().First();
            var output =  hotel.MapTo<GetHotelById>();
            foreach (var linked in output.ServiceLinkeds)
            {
                if (linked.RestaurantId == null)
                {
                    var check = _placeRepository.FirstOrDefault(p => p.Id == linked.PlaceId);
                    if (check != null)
                    {
                        linked.Name = check.Name;
                        linked.Address = check.Address;
                        linked.Facility = check.PlaceDecriptionV;

                    }


                }
                else if (linked.PlaceId == null)
                {
                    var check = _restaurantRepository.FirstOrDefault(p => p.Id == linked.RestaurantId);
                    if (check != null)
                    {
                        linked.Name = check.Name;
                        linked.Address = check.Address;
                        linked.Facility = check.Facility;

                    }

                }
            }
            return output;

            
        }

        public object GetAllServerSidePartner(ServerSideDatatableInput input)
        {
            //get parameter
            if (input.orderColumnName.IsNullOrEmpty() && input.dir.IsNullOrEmpty() && input.search.IsNullOrEmpty())
            {
                input.search = HttpContext.Current.Request.Params.GetValues("search[value]")[0].Trim().ToLower();
                var orderColumnIndex = HttpContext.Current.Request.Params.GetValues("order[0][column]")[0];
                input.orderColumnName = HttpContext.Current.Request.Params.GetValues("columns[" + orderColumnIndex + "][name]")[0];
                input.dir = HttpContext.Current.Request.Params.GetValues("order[0][dir]")[0];
            }
            var statusPurS = HttpContext.Current.Request.Params.GetValues("StatusPurS");
            var statusPur = 0;
            if (ParaRequestIsNullOrEmpty(statusPurS)) statusPur = Convert.ToInt16(statusPurS[0].ToLower());

            var id = HttpContext.Current.Request.Params.GetValues("id")[0];
            var guid = new Guid();
            if (id != "") guid = new Guid(id);
            //get all 
            var listAll = _hotelPartnerRepository.GetAll().Where(p => p.HotelId == guid).OrderByDescending(p => p.CreationTime)
                .Select((p) => new
                {
                    p.NotePartner,
                    p.Name,
                    Star = (p.Star != null) ? p.Star.Name : "",
                    p.Address,
                    Country = (p.Country != null) ? p.Country.Name : "",
                    Province = (p.Province != null) ? p.Province.Name : "",
                    District = (p.District != null) ? p.District.Name : "",
                    p.Status,
                    p.CapacityRoom,
                    p.Id,
                    p.StatusPurchasing,
                    CreatorName = (p.CreatorUserId != null) ? _userManager.Users.FirstOrDefault(c=>c.Id == p.CreatorUserId.Value).UserName.ToString() : "" ,
                    FullName = (p.CreatorUserId != null) ? _userManager.Users.FirstOrDefault(c => c.Id == p.CreatorUserId.Value).Surname.ToString() + " " + _userManager.Users.FirstOrDefault(c => c.Id == p.CreatorUserId.Value).Name.ToString() : "",
                    p.RequestDate,
                    p.DepartmentRequest
                })
                .ToList();
            //filter
            var listFilter = listAll
                .Where(p => VietToEngStr.RemoveSign4VietnameseString(p.RequestDate != null ? p.RequestDate.ToString() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
                 || VietToEngStr.RemoveSign4VietnameseString(p.DepartmentRequest != null ? p.DepartmentRequest.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
                  || VietToEngStr.RemoveSign4VietnameseString(p.FullName != null ? p.FullName.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
                  || VietToEngStr.RemoveSign4VietnameseString(p.CreatorName != null ? p.CreatorName.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
                 );
            if (ParaRequestIsNullOrEmpty(statusPurS))
                listFilter = listFilter.Where(p => p.StatusPurchasing == statusPur);
            //skip take
            var listSkipTake = listFilter.Skip(input.start).Take(input.length);
            var result = listSkipTake.ToArray();
            return new
            {
                draw = input.draw,
                recordsTotal = listAll.Count(),
                recordsFiltered = listFilter.Count(),
                data = result
            };
        }

        public async Task UpdateHotelPartnerAsync(UpdateHotelDto input)
        {
    
            var updateHotel = _hotelPartnerRepository.FirstOrDefault(p => p.Id == input.Id);
            updateHotel.StatusPurchasing = input.StatusPurchasing;
            updateHotel.UserId = input.UserId;
            DateTime Times = DateTime.Now;
            updateHotel.RequestTime = Times;
            updateHotel.DepartmentRequestPurchasing = input.DepartmentRequestPurchasing;
            await _hotelPartnerRepository.UpdateAsync(updateHotel);

        }
    }
}
