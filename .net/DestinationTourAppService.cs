using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triluatsoft.tls.Services.DestinationTour
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;
    using Abp.Collections.Extensions;
    using Abp.Extensions;
    using Domain.DestinationTour;
    using Dto;
    using Helpers;
    using System.Linq.Dynamic.Core;
    using System.Web;
    using tls.Dto;

    public class DestinationTourAppService: ApplicationService, IDestinationTourAppService
    {
        private readonly IRepository<DestinationTour, Guid> _destinationTourRepository;
        private readonly IRepository<DestinationHotel, Guid> _destinationHotelRepository;
        private readonly IRepository<DestinationPlace, Guid> _destinationPlaceRepository;
        private readonly IRepository<DestinationRestaurant, Guid> _destinationRestaurantRepository;
        public DestinationTourAppService(
             IRepository<DestinationTour, Guid> destinationTourRepository,
             IRepository<DestinationHotel, Guid> destinationHotelRepository,
             IRepository<DestinationPlace, Guid> destinationPlaceRepository,
             IRepository<DestinationRestaurant, Guid> destinationRestaurantRepository
           )
        {

            _destinationTourRepository = destinationTourRepository;
            _destinationHotelRepository = destinationHotelRepository;
            _destinationPlaceRepository = destinationPlaceRepository;
            _destinationRestaurantRepository = destinationRestaurantRepository;
        }

        public IdDestinationTour CreateDestinationTourAsync(CreateDestinationTourInputDto input)
        {
            
            var create = input.MapTo<DestinationTour>();
            _destinationTourRepository.Insert(create);
            

            int day1 = 0;
            if (create.NumberDay >= create.NumberNight)
            {
                
                 day1 = create.NumberDay;
            }
            else
            {
                 day1 = create.NumberNight;
            }
            for (int count = 1; count <= day1; count++)
            {
                //nha hang
                var sag = new DestinationRestaurant();
                sag.day = count;
                sag.MealEnum = Domain.Enums.MealEnum.Breakfast;
                sag.DestinationTourId = create.Id;
                _destinationRestaurantRepository.Insert(sag);

                var tr = new DestinationRestaurant();
                tr.day = count;
                tr.MealEnum = Domain.Enums.MealEnum.Lunch;
                tr.DestinationTourId = create.Id;
                _destinationRestaurantRepository.Insert(tr);

                var ch = new DestinationRestaurant();
                ch.day = count;
                ch.MealEnum = Domain.Enums.MealEnum.Dinner;
                ch.DestinationTourId = create.Id;
                _destinationRestaurantRepository.Insert(ch);

                var toi = new DestinationRestaurant();
                toi.day = count;
                toi.MealEnum = Domain.Enums.MealEnum.Night;
                toi.DestinationTourId = create.Id;
                _destinationRestaurantRepository.Insert(toi);

                //diem tham quan
                var sag1 = new DestinationPlace();
                sag1.day = count;
                sag1.MealEnum = Domain.Enums.MealEnum.Breakfast;
                sag1.DestinationTourId = create.Id;
                _destinationPlaceRepository.Insert(sag1);

                var tr1 = new DestinationPlace();
                tr1.day = count;
                tr1.MealEnum = Domain.Enums.MealEnum.Lunch;
                tr1.DestinationTourId = create.Id;
                _destinationPlaceRepository.Insert(tr1);

                var ch1 = new DestinationPlace();
                ch1.day = count;
                ch1.MealEnum = Domain.Enums.MealEnum.Dinner;
                ch1.DestinationTourId = create.Id;
                _destinationPlaceRepository.Insert(ch1);

                var toi1 = new DestinationPlace();
                toi1.day = count;
                toi1.MealEnum = Domain.Enums.MealEnum.Night;
                toi1.DestinationTourId = create.Id;
                _destinationPlaceRepository.Insert(toi1);

                //khach san
                var sag2 = new DestinationHotel();
                sag2.day = count;
                sag2.MealEnum = Domain.Enums.MealEnum.Breakfast;
                sag2.DestinationTourId = create.Id;
                _destinationHotelRepository.Insert(sag2);

                var tr2 = new DestinationHotel();
                tr2.day = count;
                tr2.MealEnum = Domain.Enums.MealEnum.Lunch;
                tr2.DestinationTourId = create.Id;
                _destinationHotelRepository.Insert(tr2);

                var ch2 = new DestinationHotel();
                ch2.day = count;
                ch2.MealEnum = Domain.Enums.MealEnum.Dinner;
                ch2.DestinationTourId = create.Id;
                _destinationHotelRepository.Insert(ch2);

                var toi2 = new DestinationHotel();
                toi2.day = count;
                toi2.MealEnum = Domain.Enums.MealEnum.Night;
                toi2.DestinationTourId = create.Id;
                _destinationHotelRepository.Insert(toi2);

            }
            return new IdDestinationTour { Id = create.Id };

        }

        public async Task DeleteDestinationTourAsync(Guid Id)
        {
            await _destinationTourRepository.DeleteAsync(Id);
        }

        public async Task DeleteDestinationHotelAsync(Guid Id)
        {
            await _destinationHotelRepository.DeleteAsync(Id);
        }

        public async Task DeleteDestinationRestaurantAsync(Guid Id)
        {
            await _destinationRestaurantRepository.DeleteAsync(Id);
        }

        public async Task DeleteDestinationPlaceAsync(Guid Id)
        {
            await _destinationPlaceRepository.DeleteAsync(Id);
        }

        public async Task<ListResultDto<GetDestinationTourByIdInputDto>> GetListDestinationTourIdAsync(EntityDto<Guid> input)
        {
            var tour = await _destinationTourRepository.GetAsync(input.Id);
            if ( tour != null)
            {
                var hotel =  await _destinationHotelRepository.GetAllListAsync(p => p.DestinationTourId == tour.Id);
                if (hotel != null)
                {
                    foreach (var list in hotel)
                    {
                        tour.DestinationHotels.Add(list);
                    }
                }
                var place = await _destinationPlaceRepository.GetAllListAsync(p => p.DestinationTourId == tour.Id);
                if (place != null)
                {
                    foreach (var list in place)
                    {
                        tour.DestinationPlaces.Add(list);
                    }
                }
                var restaurant = await _destinationRestaurantRepository.GetAllListAsync(p => p.DestinationTourId == tour.Id);
                if (restaurant != null)
                {
                    foreach (var list in restaurant)
                    {
                        tour.DestinationRestaurants.Add(list);
                    }
                    
                }
                return new ListResultDto<GetDestinationTourByIdInputDto>(tour.MapTo<List<GetDestinationTourByIdInputDto>>());
            }
            return null;
        }
        
        public async Task UpdateDestinationTourAsync(UpdateDestinationTourInputDto input)
        {
            int day = 0;
            //var tour = await _destinationTourRepository.GetAsync(input.Id);
            var update = input.MapTo<DestinationTour>();
            await _destinationTourRepository.UpdateAsync(update);

            if (update.NumberDay >= update.NumberNight)
            {
                day = update.NumberDay;
            }
            else
            {
                day = update.NumberNight;
            }

            for (int count = 1; count <= day; count++)
            {
                var hotel = await _destinationHotelRepository.FirstOrDefaultAsync(p => p.DestinationTourId == update.Id && p.day == count);
                if(hotel == null)
                {
                    //sang
                    var sag1 = new DestinationHotel();
                    sag1.day = count;
                    sag1.MealEnum = Domain.Enums.MealEnum.Breakfast;
                    sag1.DestinationTourId = update.Id;
                    await _destinationHotelRepository.InsertAsync(sag1);

                    //trua
                    var tr1 = new DestinationHotel();
                    tr1.day = count;
                    tr1.MealEnum = Domain.Enums.MealEnum.Dinner;
                    tr1.DestinationTourId = update.Id;
                    await _destinationHotelRepository.InsertAsync(tr1);

                    //chieu
                    var c1 = new DestinationHotel();
                    c1.day = count;
                    c1.MealEnum = Domain.Enums.MealEnum.Lunch;
                    c1.DestinationTourId = update.Id;
                    await _destinationHotelRepository.InsertAsync(c1);

                    //toi
                    var t1 = new DestinationHotel();
                    t1.day = count;
                    t1.MealEnum = Domain.Enums.MealEnum.Night;
                    t1.DestinationTourId = update.Id;
                    await _destinationHotelRepository.InsertAsync(t1);
                }
                var restaurant = await _destinationRestaurantRepository.FirstOrDefaultAsync(p => p.DestinationTourId == update.Id && p.day == count);
                if (restaurant == null)
                {
                    //sang
                    var sag1 = new DestinationRestaurant();
                    sag1.day = count;
                    sag1.MealEnum = Domain.Enums.MealEnum.Breakfast;
                    sag1.DestinationTourId = update.Id;
                    await _destinationRestaurantRepository.InsertAsync(sag1);

                    //trua
                    var tr1 = new DestinationRestaurant();
                    tr1.day = count;
                    tr1.MealEnum = Domain.Enums.MealEnum.Dinner;
                    tr1.DestinationTourId = update.Id;
                    await _destinationRestaurantRepository.InsertAsync(tr1);

                    //chieu
                    var c1 = new DestinationRestaurant();
                    c1.day = count;
                    c1.MealEnum = Domain.Enums.MealEnum.Lunch;
                    c1.DestinationTourId = update.Id;
                    await _destinationRestaurantRepository.InsertAsync(c1);

                    //toi
                    var t1 = new DestinationRestaurant();
                    t1.day = count;
                    t1.MealEnum = Domain.Enums.MealEnum.Night;
                    t1.DestinationTourId = update.Id;
                    await _destinationRestaurantRepository.InsertAsync(t1);
                }
                var place = await _destinationPlaceRepository.FirstOrDefaultAsync(p => p.DestinationTourId == update.Id && p.day == count);
                if (place == null)
                {
                    //sang
                    var sag1 = new DestinationPlace();
                    sag1.day = count;
                    sag1.MealEnum = Domain.Enums.MealEnum.Breakfast;
                    sag1.DestinationTourId = update.Id;
                    await _destinationPlaceRepository.InsertAsync(sag1);

                    //trua
                    var tr1 = new DestinationPlace();
                    tr1.day = count;
                    tr1.MealEnum = Domain.Enums.MealEnum.Dinner;
                    tr1.DestinationTourId = update.Id;
                    await _destinationPlaceRepository.InsertAsync(tr1);

                    //chieu
                    var c1 = new DestinationPlace();
                    c1.day = count;
                    c1.MealEnum = Domain.Enums.MealEnum.Lunch;
                    c1.DestinationTourId = update.Id;
                    await _destinationPlaceRepository.InsertAsync(c1);

                    //toi
                    var t1 = new DestinationPlace();
                    t1.day = count;
                    t1.MealEnum = Domain.Enums.MealEnum.Night;
                    t1.DestinationTourId = update.Id;
                    await _destinationPlaceRepository.InsertAsync(t1);
                }

            }
            //await CurrentUnitOfWork.SaveChangesAsync();
            
            //foreach (var hotel in update.DestinationHotels)
            //{
            //    await _destinationHotelRepository.UpdateAsync(hotel);
            //}
            //foreach (var place in update.DestinationPlaces)
            //{
            //    await _destinationPlaceRepository.UpdateAsync(place);
            //}
            //foreach (var restaurant in update.DestinationRestaurants)
            //{
            //    await _destinationRestaurantRepository.UpdateAsync(restaurant);
            //}
        }

        public async Task<GetDestinationTourByIdInputDto> GetDestinationTourByIdAsync(EntityDto<Guid> input)
        {
            var tour = await _destinationTourRepository.GetAsync(input.Id);
            if (tour != null)
            {
                var hotel = await _destinationHotelRepository.GetAllListAsync(p => p.DestinationTourId == tour.Id);
                if (hotel != null)
                {
                    foreach (var list in hotel)
                    {
                        tour.DestinationHotels.Add(list);
                    }
                }
                var place = await _destinationPlaceRepository.GetAllListAsync(p => p.DestinationTourId == tour.Id);
                if (place != null)
                {
                    foreach (var list in place)
                    {
                        tour.DestinationPlaces.Add(list);
                    }
                }
                var restaurant = await _destinationRestaurantRepository.GetAllListAsync(p => p.DestinationTourId == tour.Id);
                if (restaurant != null)
                {
                    foreach (var list in restaurant)
                    {
                        tour.DestinationRestaurants.Add(list);
                    }

                }
                return tour.MapTo<GetDestinationTourByIdInputDto>();
            }
            return null;
        }

        public object GetDestinationTourByIdSS(ServerSideDatatableInput input)
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
            //var id = HttpContext.Current.Request.Params.GetValues("id")[0];
            //var guid = new Guid(id);
            var listAll = _destinationTourRepository.GetAll().OrderByDescending(p => p.CreationTime)
                .Select(p => new
                {
                    p.Id,
                    p.CreationTime,
                    p.CodeDestination,
                    p.NameDestination,
                    KindOfServiceName = p.KindService != null ? p.KindService.Name : "",
                    p.StartPlace,
                    p.EndPlace,
                    p.Highlight,
                    SeasonName = p.Season != null ? p.Season.Name : "",
                    p.Visa,
                    p.NumberDay,
                    p.NumberNight,

                    //SpeccialtiesS = (p.specialties == true) ? "Có" : "Không",
                    //SubPrioritys = (p.SubPriority == true) ? "Có" : "Không",
                })
                .ToList();
            var listFilter = listAll
                .Where(p => VietToEngStr.RemoveSign4VietnameseString(p.NameDestination != null ? p.NameDestination.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
                || VietToEngStr.RemoveSign4VietnameseString(p.CodeDestination != null ? p.CodeDestination.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
                || VietToEngStr.RemoveSign4VietnameseString(p.StartPlace != null ? p.StartPlace.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
                || VietToEngStr.RemoveSign4VietnameseString(p.EndPlace != null ? p.EndPlace.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
                || VietToEngStr.RemoveSign4VietnameseString(p.Highlight != null ? p.Highlight.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
                || VietToEngStr.RemoveSign4VietnameseString(p.Visa != null ? p.Visa.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
                || p.NumberDay.ToString().Contains(input.search)
                || p.NumberNight.ToString().Contains(input.search)
                //|| p.SubPrice.ToString().Contains(input.search)
                //|| p.EffectiveDate.Value.ToShortDateString().Contains(input.search)
                //|| p.ExpiartionDate.Value.ToShortDateString().Contains(input.search)
                || VietToEngStr.RemoveSign4VietnameseString(p.KindOfServiceName != null ? p.KindOfServiceName.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
                || VietToEngStr.RemoveSign4VietnameseString(p.SeasonName != null ? p.SeasonName.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
                
                );
            var listSkipTake = listFilter.Skip(input.start).Take(input.length);
            //var result = listSkipTake.MapTo<List<GetListPriceMenu>>();
            var result = listSkipTake.ToArray();
            return new
            {
                draw = input.draw,
                recordsTotal = listAll.Count(),
                recordsFiltered = listAll.Count(),
                data = result
            };
        }
        bool ParaRequestIsNullOrEmpty(string[] param)
        {
            if (param == null) return false;
            else if (param[0] == "") return false;
            return true;
        }

        public async Task UpdateDestinationPlaceAsync(UpdateDestinationPlaceDto input)
        {

            var place = input.MapTo<DestinationPlace>();
            await _destinationPlaceRepository.UpdateAsync(place);
        }

        public async Task UpdateDestinationRestaurantAsync(UpdateDestinationRestaurantDto input)
        {
            var resraurant = input.MapTo<DestinationRestaurant>();
            await _destinationRestaurantRepository.UpdateAsync(resraurant);
        }

        public async Task UpdateDestinationHotelAsync(UpdateDestinationHotelDto input)
        {
            var hotel = input.MapTo<DestinationHotel>();
            await _destinationHotelRepository.UpdateAsync(hotel);
        }

        public object GetDestinationTourOneDayInTour(GetDestinationTourInputDay input)
        {
            var IdS = HttpContext.Current.Request.Params.GetValues("Id");
            if (ParaRequestIsNullOrEmpty(IdS)) input.Id = new Guid(IdS[0]);
            var DayPosS = HttpContext.Current.Request.Params.GetValues("DayPos");
            if (ParaRequestIsNullOrEmpty(DayPosS)) input.DayPos = int.Parse(DayPosS[0]);

            //var MealEnumS = HttpContext.Current.Request.Params.GetValues("MealEnum");
            //if (ParaRequestIsNullOrEmpty(MealEnumS)) input.MealEnum = (Domain.Enums.MealEnum)(int.Parse(MealEnumS[0]));
            var hotel = _destinationHotelRepository.GetAll().Where(p => p.DestinationTourId == input.Id && p.day == input.DayPos /*|| p.MealEnum == input.MealEnum*/).ToList().OrderBy(p => p.MealEnum);
            var restaurant =  _destinationRestaurantRepository.GetAll().Where(p => p.DestinationTourId == input.Id && p.day == input.DayPos /*|| p.MealEnum == input.MealEnum*/).ToList().OrderBy(p => p.MealEnum);
            var place =  _destinationPlaceRepository.GetAll().Where(p => p.DestinationTourId == input.Id && p.day == input.DayPos /*|| p.MealEnum == input.MealEnum*/).ToList().OrderBy(p => p.MealEnum);

            var all = new
            {
                hotel,
                restaurant,
                place
            };
            return all;
        }

        public bool UpdateOneDayInDestinationTour(UpdateDestinationTourInputDay input)
        {
            //diem tham quan
            var places=_destinationPlaceRepository.GetAll()
                .Where(p => p.DestinationTourId == input.Id && p.day==input.DayPos)
                .OrderBy(p=>p.MealEnum).ToList();
            var indexP = 0;
            foreach(var place in places)
            {
                var item = input.UpdateDestinationTourOneDays.ElementAt(indexP);
                place.MealEnum = item.MealEnum;
                place.PlaceName = item.PlaceName;
                if (item.LanguagePlaceId == Guid.Empty)
                {
                    place.LanguagePlaceId = null;
                }
                else {
                    place.LanguagePlaceId = item.LanguagePlaceId;
                }
                place.CityDestination = item.CityDestination;
                place.ProvinceId = item.ProvinceId;
                place.day = input.DayPos;
                _destinationPlaceRepository.Update(place);
                indexP = indexP + 1;
            }

            //nha hang
            var restaurantS = _destinationRestaurantRepository.GetAll()
                .Where(p => p.DestinationTourId == input.Id && p.day == input.DayPos)
                .OrderBy(p => p.MealEnum).ToList();
            var indexR = 0;
            foreach (var resraurant in restaurantS)
            {
                var item = input.UpdateDestinationTourOneDays.ElementAt(indexR);
                resraurant.MealEnum = item.MealEnum;
                resraurant.RestaurantName = item.RestaurantName;
                resraurant.CityDestination = item.CityDestination;
                resraurant.day = input.DayPos;
                _destinationRestaurantRepository.Update(resraurant);
                indexR = indexR + 1;
            }

            //khach san
            var hotels = _destinationHotelRepository.GetAll()
                .Where(p => p.DestinationTourId == input.Id && p.day == input.DayPos)
                .OrderBy(p => p.MealEnum).ToList();
            var indexH = 0;
            foreach (var hotel in hotels)
            {
                var item = input.UpdateDestinationTourOneDays.ElementAt(indexH);
                hotel.MealEnum = item.MealEnum;
                hotel.HotelName = item.HotelName;
                hotel.CityDestination = item.CityDestination;
                hotel.day = input.DayPos;
                _destinationHotelRepository.Update(hotel);
                indexH = indexH + 1;
            }
            return true;
        }


        public object GetTourByIdSS(ServerSideDatatableInput input)
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
         
            var id = HttpContext.Current.Request.Params.GetValues("id")[0];
            var guid = new Guid();
            if (id != "") guid = new Guid(id);


            var hotel = _destinationHotelRepository.GetAll().Where(p => p.DestinationTourId == guid).ToList().OrderBy(p => p.day).OrderBy(p => p.MealEnum);
            var list1 = hotel.Select(p => new
            {
                p.day,
                MealEnumH = (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Breakfast) ? "Buổi Sáng" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Lunch) ? "Buổi Trưa" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Dinner) ? "Buổi Chiều" : "Buổi Tối",
                p.MealEnum,
                p.HotelName,
                p.DestinationTourId,
                p.CityDestination,
                p.Id
            });
            var restaurant = _destinationRestaurantRepository.GetAll().Where(p => p.DestinationTourId == guid).ToList().OrderBy(p => p.day).OrderBy(p => p.MealEnum);
            var list2 = restaurant.Select(p => new
            {
                p.day,
                MealEnumR = (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Breakfast) ? "Buổi Sáng" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Lunch) ? "Buổi Trưa" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Dinner) ? "Buổi Chiều" : "Buổi Tối",
                p.RestaurantName,
                p.MealEnum,
                p.DestinationTourId,
                p.CityDestination,
                p.Id
            });
            var place = _destinationPlaceRepository.GetAll().Where(p => p.DestinationTourId == guid).ToList().OrderBy(p => p.day).OrderBy(p => p.MealEnum);
            var list3 = place.Select(p => new
            {
                p.day,
                MealEnumP = (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Breakfast) ? "Buổi Sáng" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Lunch) ? "Buổi Trưa" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Dinner) ? "Buổi Chiều" : "Buổi Tối",
                p.PlaceName,
                p.MealEnum,
                Language = (p.LanguagePlace != null) ? p.LanguagePlace.Name : "",
                p.CityDestination,
                p.DestinationTourId,
                p.Id
            });

            //var tour = _destinationTourRepository.GetAll().OrderByDescending(p => p.CreationTime)
            //    .Where(a => a.Id == guid).ToList();

            //var list = tour.Select(p => new {
            //    p.Id,
            //    HotelDay = p.DestinationHotels.Select(hd => hd.day),
            //    HotelMeal = p.DestinationHotels.Select(hm => hm.MealEnum),
            //    HotelName = p.DestinationHotels.Select(hn => hn.HotelName),

            //    RestaurantDay = p.DestinationRestaurants.Select(hm => hm.day),
            //    RestaurantMeal = p.DestinationRestaurants.Select(hm => hm.MealEnum),
            //    RestaurantName = p.DestinationRestaurants.Select(hn => hn.RestaurantName),

            //    PlaceCountry = p.DestinationPlaces.Select(hm => hm.CityDestination),
            //    PlaceDay = p.DestinationPlaces.Select(hm => hm.day),
            //    PlaceMeal = p.DestinationPlaces.Select(hn => hn.MealEnum),
            //    PlaceLanguage = p.DestinationPlaces.Select(hm => hm.LanguagePlace.Name),
            //    PlaceName = p.DestinationPlaces.Select(hn => hn.PlaceName)


            //});
            //var list1 = list.Select(a => new
            //{
            //    a.Id,
            //    HotelDay = a.HN.Select(hd => hd.day),
            //    HotelMeal = a.HN.Select(hm =>hm.MealEnum),
            //    HotelName = a.HN.Select(hn => hn.HotelName),

            //    RestaurantDay = a.RN.Select(hd => hd.day),
            //    RestaurantMeal = a.RN.Select(hm => hm.MealEnum),
            //    RestaurantName = a.RN.Select(rn => rn.RestaurantName),

            //    PlaceCountry = a.PN.Select(pc => pc.PlaceName),
            //    PlaceDay = a.PN.Select(pd =>pd.day),
            //    PlaceMeal = a.PN.Select(pm => pm.MealEnum),
            //    PlaceLanguage = a.PN.Select(pl =>pl.LanguagePlace.Name),
            //    PlaceName = a.PN.Select(pn => pn.PlaceName)
            //});
            //.WhereIf(DestinationHotels.Any(te => te.))
            //.Join(_destinationHotelRepository.GetAll().OrderByDescending(p => p.CreationTime).Where(a => a.DestinationTourId == guid))
            //.Join _destinationRestaurantRepository.GetAll().OrderByDescending(p => p.CreationTime).Where(a => a.DestinationTourId == guid)
            //.Join(_destinationPlaceRepository.GetAll().OrderByDescending(p => p.CreationTime).Where(a => a.DestinationTourId == guid)).ToList();


            //IEnumerable<HPromotion> listAll = _hPromotionRepository.GetAll()
            //    .Include(p => p.HotelRoom.Roomtype)
            //    .Include(p => p.Customer)
            //    .Include(p => p.TypeCustomer)
            //    .OrderByDescending(p => p.CreationTime)
            //    .Where(a => a.HotelId == guid).ToList();
            //var list = listAll.Select(p => new
            //{
            //    p.TypeCustomerId,
            //    TypeCustomerName = (p.TypeCustomer != null) ? p.TypeCustomer.Name : "",
            //    p.HotelRoomId,
            //    RoomType = p.HotelRoom != null ? p.HotelRoom.Roomtype : null,
            //    p.RoomtypeId,
            //    RoomtypeName = (p.Roomtype != null) ? p.Roomtype.Name : "",
            //    p.CustomerId,
            //    CustomerName = (p.Customer != null) ? p.Customer.Name : "",
            //    p.Name,
            //    p.HotelId,
            //    p.Id
            //});



            list1.ToArray();
            list2.ToArray();
            list3.ToArray();
            //var list4 = new
            //{
            //    list1,
            //    list2,
            //    list3
            //};
            var listfinal = new List<GetDbDto>();
            foreach(var temp in list1)
            {
                var db = new GetDbDto();
                db.day = temp.day;
                db.cityDestination = temp.CityDestination;
                db.MealEnum = temp.MealEnum;
                db.Name = temp.HotelName;
                listfinal.Add(db);
            }

            foreach (var temp1 in list2)
            {
                var tempxxx = listfinal.FirstOrDefault(p => p.day == temp1.day && p.cityDestination == temp1.CityDestination && p.MealEnum == temp1.MealEnum);
                if (tempxxx != null)
                {
                    tempxxx.NameRestaurant = temp1.RestaurantName;
                }
            }

            foreach (var temp2 in list3)
            {
                var tempxxx = listfinal.FirstOrDefault(p => p.day == temp2.day && p.cityDestination == temp2.CityDestination && p.MealEnum == temp2.MealEnum);
                if (tempxxx != null)
                {
                    tempxxx.NamePlace = temp2.PlaceName;
                }
            }


            var listt =  listfinal.OrderBy(a => a.day).ThenBy(e => e.MealEnum).ToList();

            //var listSkipTake = listt.Skip(input.start).Take(input.length);
            ////var result = listSkipTake.MapTo<List<GetListPriceMenu>>();
            //var result = listSkipTake.ToArray();
            //return new
            //{
            //    draw = input.draw,
            //    recordsTotal = listt.Count(),
            //    recordsFiltered = listt.Count(),
            //    data = result
            //};
            var listSkipTake = listt.Skip(input.start);
            if (input.length != -1)
                listSkipTake = listSkipTake.Take(input.length);
            var result = listSkipTake.ToArray();
            return new
            {
                draw = input.draw,
                recordsTotal = listt.Count(),
                recordsFiltered = listt.Count(),
                data = result
            };
            ////filter
            //var listFilter = list
            //    .Where(p => VietToEngStr.RemoveSign4VietnameseString(p.RoomtypeName.ToLower()).Contains(VietToEngStr.RemoveSign4VietnameseString(input.search)));
            //if (input.orderColumnName == "RoomtypeName")
            //{
            //    if (input.dir == "asc") listFilter = listFilter.OrderBy(p => p.RoomtypeName);
            //    else listFilter = listFilter.OrderByDescending(p => p.RoomtypeName);
            //}


            //return new
            //{
            //    draw = input.draw,
            //    recordsTotal = list.Count(),
            //    recordsFiltered = listFilter.Count(),
            //    data = result
            //};
            //if (input.orderColumnName.IsNullOrEmpty() && input.dir.IsNullOrEmpty() && input.search.IsNullOrEmpty())
            //{
            //    input.search = HttpContext.Current.Request.Params.GetValues("search[value]") != null ?
            //        HttpContext.Current.Request.Params.GetValues("search[value]")[0].Trim().ToLower() : "";
            //    var orderColumnIndex = HttpContext.Current.Request.Params.GetValues("order[0][column]") != null ?
            //        HttpContext.Current.Request.Params.GetValues("order[0][column]")[0] : "";
            //    input.orderColumnName = HttpContext.Current.Request.Params.GetValues("columns[" + orderColumnIndex + "][name]") != null ?
            //        HttpContext.Current.Request.Params.GetValues("columns[" + orderColumnIndex + "][name]")[0] : "";
            //    input.dir = HttpContext.Current.Request.Params.GetValues("order[0][dir]") != null ?
            //        HttpContext.Current.Request.Params.GetValues("order[0][dir]")[0] : "";
            //}
            ////var id = HttpContext.Current.Request.Params.GetValues("id")[0];
            ////var guid = new Guid(id);
            ////if (id != "") guid = new Guid(id);
            ////var MealEnumS = HttpContext.Current.Request.Params.GetValues("MealEnum");
            ////if (ParaRequestIsNullOrEmpty(MealEnumS)) input.MealEnum = (Domain.Enums.MealEnum)(int.Parse(MealEnumS[0]));
            //var hotel = _destinationHotelRepository.GetAll()./*Where(p => p.DestinationTourId == guid).*/ToList().OrderBy(p => p.day).OrderBy(p => p.MealEnum);
            //var list1 = hotel.Select(p => new
            //{
            //    p.day,
            //    MealEnumH = (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Breakfast) ? "Buổi Sáng" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Lunch) ? "Buổi Trưa" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Dinner) ? "Buổi Chiều" : "Buổi Tối",
            //    p.HotelName,
            //    p.DestinationTourId,
            //    p.Id
            //});
            //var restaurant = _destinationRestaurantRepository.GetAll()./*Where(p => p.DestinationTourId == guid).*/ToList().OrderBy(p => p.day).OrderBy(p => p.MealEnum);
            //var list2 = restaurant.Select(p => new
            //{
            //    p.day,
            //    MealEnumR = (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Breakfast) ? "Buổi Sáng" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Lunch) ? "Buổi Trưa" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Dinner) ? "Buổi Chiều" : "Buổi Tối",
            //    p.RestaurantName,
            //    p.DestinationTourId,
            //    p.Id
            //});
            //var place = _destinationPlaceRepository.GetAll()./*Where(p => p.DestinationTourId == guid).*/ToList().OrderBy(p => p.day).OrderBy(p => p.MealEnum);
            //var list3 = place.Select(p => new
            //{
            //    p.day,
            //    MealEnumP = (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Breakfast) ? "Buổi Sáng" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Lunch) ? "Buổi Trưa" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Dinner) ? "Buổi Chiều" : "Buổi Tối",
            //    p.PlaceName,
            //    Language = (p.LanguagePlace != null) ? p.LanguagePlace.Name : "",
            //    p.CityDestination,
            //    p.DestinationTourId,
            //    p.Id
            //});


            //var listFilter1 = list1
            //    .Where(p => p.day.ToString().Contains(input.search)
            //    || VietToEngStr.RemoveSign4VietnameseString(p.MealEnumH != null ? p.MealEnumH.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
            //    || VietToEngStr.RemoveSign4VietnameseString(p.HotelName != null ? p.HotelName.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
            //    //|| p.NumberDay.ToString().Contains(input.search)
            //    //|| p.NumberNight.ToString().Contains(input.search)
            //    //|| p.SubPrice.ToString().Contains(input.search)
            //    //|| p.EffectiveDate.Value.ToShortDateString().Contains(input.search)
            //    //|| p.ExpiartionDate.Value.ToShortDateString().Contains(input.search)
            //    //|| VietToEngStr.RemoveSign4VietnameseString(p.KindOfServiceName != null ? p.KindOfServiceName.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
            //    //|| VietToEngStr.RemoveSign4VietnameseString(p.SeasonName != null ? p.SeasonName.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))

            //    );
            //var listFilter2 = list2
            //    .Where(p => p.day.ToString().Contains(input.search)
            //    || VietToEngStr.RemoveSign4VietnameseString(p.MealEnumR != null ? p.MealEnumR.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
            //    || VietToEngStr.RemoveSign4VietnameseString(p.RestaurantName != null ? p.RestaurantName.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
            //    //|| p.NumberDay.ToString().Contains(input.search)
            //    //|| p.NumberNight.ToString().Contains(input.search)
            //    //|| p.SubPrice.ToString().Contains(input.search)
            //    //|| p.EffectiveDate.Value.ToShortDateString().Contains(input.search)
            //    //|| p.ExpiartionDate.Value.ToShortDateString().Contains(input.search)
            //    //|| VietToEngStr.RemoveSign4VietnameseString(p.KindOfServiceName != null ? p.KindOfServiceName.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
            //    //|| VietToEngStr.RemoveSign4VietnameseString(p.SeasonName != null ? p.SeasonName.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))

            //    );
            //var listFilter3 = list3
            //    .Where(p => p.day.ToString().Contains(input.search)
            //    || VietToEngStr.RemoveSign4VietnameseString(p.MealEnumP != null ? p.MealEnumP.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
            //    || VietToEngStr.RemoveSign4VietnameseString(p.PlaceName != null ? p.PlaceName.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
            //    || VietToEngStr.RemoveSign4VietnameseString(p.CityDestination != null ? p.CityDestination.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
            //    || VietToEngStr.RemoveSign4VietnameseString(p.Language != null ? p.Language.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
            //    //|| p.NumberDay.ToString().Contains(input.search)
            //    //|| p.NumberNight.ToString().Contains(input.search)
            //    //|| p.SubPrice.ToString().Contains(input.search)
            //    //|| p.EffectiveDate.Value.ToShortDateString().Contains(input.search)
            //    //|| p.ExpiartionDate.Value.ToShortDateString().Contains(input.search)
            //    //|| VietToEngStr.RemoveSign4VietnameseString(p.KindOfServiceName != null ? p.KindOfServiceName.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
            //    //|| VietToEngStr.RemoveSign4VietnameseString(p.SeasonName != null ? p.SeasonName.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))

            //    );
            //var Total = new
            //{
            //    listFilter1,
            //    listFilter2,
            //    listFilter3
            //};

            //return Total;
        }

        public object GetHotelById(ServerSideDatatableInput input)
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
           
            var id = HttpContext.Current.Request.Params.GetValues("id")[0];
            var guid = new Guid();
            if (id != "") guid = new Guid(id);
            //get 
            IEnumerable<DestinationHotel> listAll = _destinationHotelRepository.GetAll()
                .Where(a => a.DestinationTourId == guid).OrderBy(a => a.day).ThenBy(e => e.MealEnum).ToList();
            
            var list = listAll.Select(p => new
            {
                p.day,
                p.HotelName,
                MealEnumH = (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Breakfast) ? "Buổi Sáng" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Lunch) ? "Buổi Trưa" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Dinner) ? "Buổi Chiều" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Night) ? "Buổi Tối" : "",
                p.CityDestination,
                p.Id
            });
            var listSkipTake = list.Skip(input.start).Take(input.length);
            var result = listSkipTake.ToArray();
            return new
            {
                draw = input.draw,
                recordsTotal = list.Count(),
                recordsFiltered = list.Count(),
                data = result
            };
        }

        public object GetRestaurantById(ServerSideDatatableInput input)
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

            var id = HttpContext.Current.Request.Params.GetValues("id")[0];
            var guid = new Guid();
            if (id != "") guid = new Guid(id);
            //get 
            IEnumerable<DestinationRestaurant> listAll = _destinationRestaurantRepository.GetAll()
                .Where(a => a.DestinationTourId == guid).OrderBy(a => a.day).ThenBy(e => e.MealEnum).ToList();
            var list = listAll.Select(p => new
            {
                p.day,
                p.RestaurantName,
                MealEnumR = (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Breakfast) ? "Buổi Sáng" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Lunch) ? "Buổi Trưa" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Dinner) ? "Buổi Chiều" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Night) ? "Buổi Tối" : "",
                p.CityDestination,
                p.Id
            });
            var listSkipTake = list.Skip(input.start).Take(input.length);
            var result = listSkipTake.ToArray();
            return new
            {
                draw = input.draw,
                recordsTotal = list.Count(),
                recordsFiltered = list.Count(),
                data = result
            };
        }

        public object GetPlaceById(ServerSideDatatableInput input)
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

            var id = HttpContext.Current.Request.Params.GetValues("id")[0];
            var guid = new Guid();
            if (id != "") guid = new Guid(id);
            //get 
            IEnumerable<DestinationPlace> listAll = _destinationPlaceRepository.GetAll()
                .Where(a => a.DestinationTourId == guid).OrderBy(a => a.day).ThenBy(e => e.MealEnum).ToList();
            var list = listAll.Select(p => new
            {
                p.day,
                p.PlaceName,
                p.CityDestination,
                Language = p.LanguagePlace != null ? p.LanguagePlace.Name : "",
                MealEnumP = (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Breakfast) ? "Buổi Sáng" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Lunch) ? "Buổi Trưa" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Dinner) ? "Buổi Chiều" : (p.MealEnum == triluatsoft.tls.Domain.Enums.MealEnum.Night) ? "Buổi Tối" :"",
                p.Id
            });
            var listSkipTake = list.Skip(input.start).Take(input.length);
            var result = listSkipTake.ToArray();
            return new
            {
                draw = input.draw,
                recordsTotal = list.Count(),
                recordsFiltered = list.Count(),
                data = result
            };
        }
    }
}
