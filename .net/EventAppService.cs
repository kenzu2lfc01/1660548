using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Domain.BeEvents;
using triluatsoft.tls.Domain.FilesSub;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.IO;
using triluatsoft.tls.Helpers;
using Abp.IO;
using Abp.Domain.Uow;
using triluatsoft.tls.Services.Events;
using triluatsoft.tls.Services.Events.Dto;
using triluatsoft.tls.Services.Contracts.Dto;
using triluatsoft.tls.Dto;
using Abp.Extensions;
using System.Web;
using System.Web.Hosting;
using System.Globalization;

namespace triluatsoft.tls.Services.BeEvents
{
    public class EventAppService : ApplicationService, IEventAppService
    {
        private readonly IRepository<BeEvent, Guid> _beEventRepository;
        private readonly IRepository<FileSub, Guid> _filesubRepository;
        private readonly IRepository<FilePicSub, Guid> _filepicsubRepository;


        public EventAppService(
        IRepository<BeEvent, Guid> beeventRepository,
        IRepository<FileSub, Guid> filesubRepository,
        IRepository<FilePicSub, Guid> filepicsubRepository)
        {
            _beEventRepository = beeventRepository;
            _filesubRepository = filesubRepository;
            _filepicsubRepository = filepicsubRepository;
        }

        public async Task CreateBeEventAsync(CreateEventModelDto input)
        {
            var BeEvents = input.MapTo<BeEvent>();
            await _beEventRepository.InsertAsync(BeEvents);
            foreach (var file in BeEvents.FilePicSubs)
            {
                var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"), file.FileName);
                FluentFtp.SendFilePic(
                    file.FileName,
                    tempFilePath,
                    Constants.p_BeEvent,
                    BeEvents.Id.ToString(),
                    Constants.p_FilePicSub,
                    file.Id.ToString()
                    );
                FileHelper.DeleteIfExists(tempFilePath);
            }
            foreach (var file in BeEvents.FileSubs)
            {
                var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"), file.FileName);
                FluentFtp.SendFilePic(
                    file.FileName,
                    tempFilePath,
                    Constants.p_BeEvent,
                    BeEvents.Id.ToString(),
                    Constants.p_FileSub,
                    file.Id.ToString()
                    );
                FileHelper.DeleteIfExists(tempFilePath);
            }

        }

        public async Task DeleteFilePicSub(EntityDto<Guid> input)
        {
            var file = _filepicsubRepository.FirstOrDefault(p => p.Id == input.Id);
            FluentFtp.DeleteSubServiceDirectory(Constants.p_BeEvent, file.BeEventId.ToString(), Constants.p_FilePicSub, input.Id.ToString());
            await _filepicsubRepository.DeleteAsync(input.Id);
        }

        public async Task DeleteFileSub(EntityDto<Guid> input)
        {

            var file = _filesubRepository.FirstOrDefault(p => p.Id == input.Id);
            FluentFtp.DeleteSubServiceDirectory(Constants.p_BeEvent, file.BeEventId.ToString(), Constants.p_FileSub, input.Id.ToString());
            await _filesubRepository.DeleteAsync(input.Id);
        }

        ////public Task<ListResultDto<GetBeEventById>> GetListBeEventByIdAsync()
        ////{
        ////    throw new NotImplementedException();
        ////}
        public Array GetEventIndex()
        {
               var listAll = _beEventRepository.GetAll().OrderByDescending(p=>p.CreationTime)
                .Select((p) => new
            {
                CurrencyName = p.Currency.Name,
                p.Name,
                TotalQuantity=p.Quantity,
                p.Price,
                p.EffectiveDate,
                p.ExpiartionDate,
                p.Id
            }).ToList();
            return listAll.ToArray();
        }
        public async Task<GetBeEventModelById> GetBeEventByIdAsync(EntityDto<Guid> input)
        {
            var BeEvent = await _beEventRepository.FirstOrDefaultAsync(p => p.Id == input.Id);
            var filesubList = await _filesubRepository.GetAllListAsync(p => p.BeEventId == BeEvent.Id);
            foreach (var file in filesubList)
            {
                BeEvent.FileSubs.Add(file);
            }
            var filepicsubs = await _filepicsubRepository.GetAllListAsync(p => p.BeEventId == BeEvent.Id);
            foreach (var file in filepicsubs)
            {
                BeEvent.FilePicSubs.Add(file);
            }
            return BeEvent.MapTo<GetBeEventModelById>();
        }

        public async Task UpdateBeEventByIdAsync(UpdateBeEventModelDto input)
        {
            var update = input.MapTo<BeEvent>();
            foreach (var file in update.FilePicSubs)
            {
                file.BeEventId = update.Id;
                if (file.Id == Guid.Empty)
                {
                    await _filepicsubRepository.InsertAsync(file);
                    var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"), file.FileName);
                    FluentFtp.SendFilePic(
                        file.FileName,
                        tempFilePath,
                        Constants.p_BeEvent,
                        update.Id.ToString(),
                        Constants.p_FilePicSub,
                        file.Id.ToString()
                        );
                    FileHelper.DeleteIfExists(tempFilePath);

                }
            }
            foreach (var file in update.FileSubs)
            {
                file.BeEventId = update.Id;
                if (file.Id == Guid.Empty)
                {

                    await _filesubRepository.InsertAsync(file);
                    var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"), file.FileName);
                    FluentFtp.SendFilePic(
                        file.FileName,
                        tempFilePath,
                        Constants.p_BeEvent,
                        update.Id.ToString(),
                        Constants.p_FileSub,
                        file.Id.ToString()
                        );
                    FileHelper.DeleteIfExists(tempFilePath);

                }
            }
            await CurrentUnitOfWork.SaveChangesAsync();
            await _beEventRepository.UpdateAsync(update);
        }

        bool ParaRequestIsNullOrEmpty(string[] param)
        {
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
            #endregion
            //get all 
            var listAll = _beEventRepository.GetAll().OrderByDescending(p=>p.CreationTime)
                .Select((p) => new
            {
                p.Name,
                TotalQuantity=p.Quantity,
                p.Price,
                p.EffectiveDate,
                p.ExpiartionDate,
                p.Id
            }).ToList();
            //filter
            var listFilter = listAll.Where(p => VietToEngStr.RemoveSign4VietnameseString(p.Name.ToLower()).Contains(VietToEngStr.RemoveSign4VietnameseString(input.search)));
            //if (ParaRequestIsNullOrEmpty(roomNumberS))
            //    listFilter = listFilter.Where(p => p.CapacityRoom == roomNumberString);
            ////filter price chua biet
            //if (ParaRequestIsNullOrEmpty(countryS))
            //    listFilter = listFilter.Where(p => p.CountryId == countryGuidId);
            //if (ParaRequestIsNullOrEmpty(provinceS))
            //    listFilter = listFilter.Where(p => p.ProvinceId == provinceGuidId);
            //if (ParaRequestIsNullOrEmpty(starS))
            //    listFilter = listFilter.Where(p => p.StarId != null && p.StarId == starGuidId);
            if (input.orderColumnName == "Name")
            {
                if (input.dir == "asc") listFilter = listFilter.OrderBy(p => p.Name);
                else listFilter = listFilter.OrderByDescending(p => p.Name);
            }
            //else if (input.orderColumnName == "Star")
            //{
            //    if (input.dir == "asc") listFilter = listFilter.OrderBy(p => p.Star);
            //    else listFilter = listFilter.OrderByDescending(p => p.Star);
            //}
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

        public async Task DeleteEventASync(EntityDto<Guid> input)
        {
            FluentFtp.DeleteServiceDirectory(Constants.p_BeEvent, input.Id.ToString());
            await _beEventRepository.DeleteAsync(input.Id);
        }
        public object GetAllServerSideAsyncForTour(ServerSideDatatableInput input)
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

            var priceFromS = HttpContext.Current.Request.Params.GetValues("priceFrom");
            var priceFromString = "";
            if (ParaRequestIsNullOrEmpty(priceFromS)) priceFromString = priceFromS[0];

            var priceToS = HttpContext.Current.Request.Params.GetValues("priceTo");
            var priceToString = "";
            if (ParaRequestIsNullOrEmpty(provinceS)) priceToString = priceToS[0];

            var dateFromS = HttpContext.Current.Request.Params.GetValues("dateFrom");
            var dateFromString = new DateTime();
            if (dateFromS[0] != "Invalid Date") dateFromString = DateTime.ParseExact(dateFromS[0], "d/m/yyyy", CultureInfo.InvariantCulture);

            var dateToS = HttpContext.Current.Request.Params.GetValues("dateTo");
            var dateToString = new DateTime();
            if (dateToS[0] != "Invalid Date") dateToString = DateTime.ParseExact(dateToS[0], "d/m/yyyy", CultureInfo.InvariantCulture);
            #endregion
            //get all 
            var listAll = _beEventRepository.GetAll().OrderByDescending(p => p.CreationTime)
                .Select((p) => new
                {
                    p.Name,
                    TotalQuantity = p.Quantity,
                    p.Price,
                    Currency = (p.Currency != null) ? p.Currency.Name: "",
                    p.EffectiveDate,
                    p.ExpiartionDate,
                    p.Id
                }).ToList();
            //filter
            var listFilter = listAll.Where(p => VietToEngStr.RemoveSign4VietnameseString(p.Name.ToLower()).Contains(VietToEngStr.RemoveSign4VietnameseString(input.search)));

            if (ParaRequestIsNullOrEmpty(priceFromS))
                listFilter = listFilter.Where(p => p.Price >= int.Parse(priceFromString));
            if (ParaRequestIsNullOrEmpty(priceToS))
                listFilter = listFilter.Where(p => p.Price <= int.Parse(priceToString));
            if (dateFromS[0] != "Invalid Date" && dateFromS[0] != "1/1/1970")
                listFilter = listFilter.Where(p => p.EffectiveDate <= dateFromString && p.ExpiartionDate >= dateFromString);
            if (dateToS[0] != "Invalid Date" && dateToS[0] != "1/1/1970")
                listFilter = listFilter.Where(p => p.EffectiveDate <= dateToString && p.ExpiartionDate >= dateToString);
            if (input.orderColumnName == "Name")
            {
                if (input.dir == "asc") listFilter = listFilter.OrderBy(p => p.Name);
                else listFilter = listFilter.OrderByDescending(p => p.Name);
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

        public string TestConnection()
        {
            return "success";
        }
    }
}
