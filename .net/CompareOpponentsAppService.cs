using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Domain.CompareProducts;
using triluatsoft.tls.Services.CompareOpponents.Dto;
using Abp.Application.Services.Dto;
using triluatsoft.tls.Dto;
using Abp.Extensions;
using System.Web;
using System.Data.Entity;
using triluatsoft.tls.Helpers;

namespace triluatsoft.tls.CompareOpponents
{
    public class CompareOpponentsAppService: ApplicationService,ICompareOpponentsAppService
    {
        private readonly IRepository<CompareProduct, Guid> _compareProductRepository;
        private readonly IRepository<CompareProductDetail, Guid> _compareProductDetailRepository;
        private readonly IRepository<PlaceMini, Guid> _placeMiniRepository;
        public CompareOpponentsAppService(
            IRepository<CompareProduct, Guid> compareProductTourRepository,
            IRepository<CompareProductDetail, Guid> compareProductDetailRepository,
            IRepository<PlaceMini, Guid> placeMiniRepository
          )
        {

            _compareProductRepository = compareProductTourRepository;
            _compareProductDetailRepository = compareProductDetailRepository;
            _placeMiniRepository = placeMiniRepository;
        }

        public IdCompareOpponents CreateCompareOpponentsAsync(CreateCompareOpponentInputDto input)
        {
            var create = input.MapTo<CompareProduct>();
            _compareProductRepository.Insert(create);
           
            for (int count = 1; count <= create.Quantity; count++)
            {
                var detail = new CompareProductDetail();
                detail.IndeX = count;
                detail.CompareProductId = create.Id;
                _compareProductDetailRepository.InsertAsync(detail);


                var mini = new PlaceMini();
                mini.CompareProductDetailId = detail.Id;
                _placeMiniRepository.InsertAsync(mini);

            }
            

            return new IdCompareOpponents { Id = create.Id };
        }

        public async Task DeleteCompareOpponentsAsync(Guid Id)
        {
            await _compareProductRepository.DeleteAsync(Id);
        }

        public async Task DeleteCompareProductDetailAsync(Guid Id)
        {
            await _compareProductDetailRepository.DeleteAsync(Id);
        }

        public async Task DeletePlaceMiniAsync(Guid Id)
        {
            await _placeMiniRepository.DeleteAsync(Id);
        }

        public async Task UpdateCompareOpponentsAsync(UpdateCompareOpponentsInputDto input)
        {
            var update = input.MapTo<CompareProduct>();
            await _compareProductRepository.UpdateAsync(update);


            for (int count = 1; count <= update.Quantity; count++)
            {
                var hotel = await _compareProductDetailRepository.FirstOrDefaultAsync(p => p.CompareProductId == update.Id && p.IndeX == count);
                if (hotel == null)
                {
                    var detail = new CompareProductDetail();
                    detail.IndeX = count;
                    detail.CompareProductId = update.Id;
                    await _compareProductDetailRepository.InsertAsync(detail);


                    var mini = new PlaceMini();
                    mini.CompareProductDetailId = detail.Id;
                    await _placeMiniRepository.InsertAsync(mini);
                }
            }
        }
        public async Task<GetCompareOpponentByIdDto> GetCompareOpponentsByIdAsync(EntityDto<Guid> input)
        {
            var compare = await _compareProductRepository.GetAsync(input.Id);
            if (compare != null)
            {
                var compareDetail = await _compareProductDetailRepository.GetAllListAsync(p => p.CompareProductId == compare.Id);
                if (compareDetail != null)
                {
                    foreach (var detail in compareDetail)
                    {
                        var placeminiList = await _placeMiniRepository.GetAllListAsync(p => p.CompareProductDetailId == detail.Id);
                        foreach(var placemini in placeminiList)
                        {
                            detail.PlaceMinis.Add(placemini);
                        }
                    }

                }
                return compare.MapTo<GetCompareOpponentByIdDto>();
            }
            return null;
        }

        public object GetCompareOpponentsByIdSS(ServerSideDatatableInput input)
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
            //var listAll = _compareProductRepository.GetAll().Include(p => p.CompareProductDetails)
            var listAll = _compareProductRepository.GetAll().OrderByDescending(p => p.CreationTime)
                .Select(p => new
                {
                    p.Id,
                    p.CreationTime,
                    p.Name
                })
                .ToList();
            var listFilter = listAll
                .Where(p => VietToEngStr.RemoveSign4VietnameseString(p.Name != null ? p.Name.ToLower() : "").Contains(VietToEngStr.RemoveSign4VietnameseString(input.search))
                || p.CreationTime.ToString().Contains(input.search)

                );
            var listSkipTake = listFilter.Skip(input.start).Take(input.length);
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
        
        public IdCompareOpponents CreateCompareOpponentsAsync1(CreateCompareProductDetailDto input)
        {
            var create = input.MapTo<CompareProductDetail>();
            _compareProductDetailRepository.Insert(create);
            return new IdCompareOpponents { Id = create.Id };
        }

        public async Task<GetCompareProductDetailDto> GetCompareOpponentsIndeXInProduct(GetCompareOpponentsInputIndex input)
        {
            var IdS = HttpContext.Current.Request.Params.GetValues("Id");
            if (ParaRequestIsNullOrEmpty(IdS)) input.Id = new Guid(IdS[0]);
            var IndexS = HttpContext.Current.Request.Params.GetValues("Index");
            if (ParaRequestIsNullOrEmpty(IndexS)) input.IndeX = int.Parse(IndexS[0]);

            var id1 = await _compareProductRepository.GetAsync(input.Id);
            var Detail1 = await _compareProductDetailRepository.FirstOrDefaultAsync(p => p.CompareProductId == input.Id && p.IndeX == input.IndeX);
            var Detail = await _compareProductDetailRepository.GetAllListAsync(p => p.CompareProductId == input.Id && p.IndeX == input.IndeX);
            var Detail2 = await _compareProductDetailRepository.GetAsync(Detail1.Id);

            if (Detail2 != null)
            {
                var contactList = await _placeMiniRepository.GetAllListAsync(p => p.CompareProductDetailId == Detail2.Id);
                if (contactList != null)
                {
                    foreach (var contact in contactList)
                    {
                        Detail2.PlaceMinis.Add(contact);
                    }
                }
                //var aa = _compareProductDetailRepository.GetAll().Where(p => p.CompareProductId == input.Id && p.IndeX == input.IndeX);
                //foreach (var list in aa)
                //{
                //    var de = _placeMiniRepository.GetAllListAsync(p => p.CompareProductDetailId == list.Id);
                //    if (de != null)
                //    {
                //        ListCompare.Add(new GetCompareProductDetailDto
                //        {
                //            Programme = list.Programme,
                //            PlaceMinis = list.PlaceMinis.ToList(),

                //        });
                //    }


                //}

                //return ListCompare;
                var result = Detail2.MapTo<GetCompareProductDetailDto>();

                return result;
            }
            return null;
        }

        public bool UpdateOneOpponent(UpdateCompareOpponentIdIndex input)
        {
            //diem tham quan
            var places = _compareProductDetailRepository.GetAll()
                .Where(p => p.CompareProductId == input.Id && p.IndeX == input.IndeX)
                .ToList();
            var indexP = 0;
            foreach (var place in places)
            {
                var item = input.UpdateCompareOpponentDetailIndex.ElementAt(indexP);
                place.CompareProductCompanyId = item.CompareProductCompanyId;
                place.Programme = item.Programme;
                place.Price = item.Price;
                place.ComparePrice = item.ComparePrice;
                place.CurrrentPrice = item.CurrrentPrice;
                place.Start = item.Start;
                place.NumberDay = item.NumberDay;
                place.SomeMeals = item.SomeMeals;
                place.HotelName = item.HotelName;
                place.Flight = item.Flight;
                place.MigrationRoute = item.MigrationRoute;
                place.PriceInclude = item.PriceInclude;
                place.PriceNotInclude = item.PriceNotInclude;
                place.Shopping = item.Shopping;
                place.Comment = item.Comment;
                place.Suggest = item.Suggest;
                _compareProductDetailRepository.Update(place);
                indexP = indexP + 1;
            }
            return true;
        }

        public async Task UpdateCompareDetailAsnc(UpdateCompareOpponentDetailIndex input)
        {
            var update = input.MapTo<CompareProductDetail>();
            foreach (var place in update.PlaceMinis)
            {
                place.CompareProductDetailId = update.Id;
                if (place.Id == Guid.Empty)
                    await _placeMiniRepository.InsertAsync(place);
            }
            await CurrentUnitOfWork.SaveChangesAsync();
            await _compareProductDetailRepository.UpdateAsync(update);
            foreach (var mini in update.PlaceMinis)
            {
                await _placeMiniRepository.UpdateAsync(mini);
            }


        }

        public object GetCompareOpponentsDetailByIdSS(ServerSideDatatableInput input)
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
            var guid = new Guid(id);
            var listAll = _compareProductDetailRepository.GetAll().OrderByDescending(p => p.IndeX)
                .Where(p => (p.CompareProductId.Value == guid))
                .ToList();
            foreach (var item in listAll)
            {
                var filesubList = _placeMiniRepository.GetAll().Where(p => p.CompareProductDetailId == item.Id);
                foreach (var file in filesubList)
                {
                    item.PlaceMinis.Add(file);
                }
            }
            var listSkipTake = listAll.Skip(input.start).Take(input.length);
            var result = listSkipTake.MapTo<List<GetCompareProductDetailDto>>();
            return new
            {
                draw = input.draw,
                recordsTotal = listAll.Count(),
                recordsFiltered = listAll.Count(),
                data = result
            };
        }
    }
}
