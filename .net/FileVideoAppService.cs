using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using triluatsoft.tls.Services.FileVideos.Dto;
using triluatsoft.tls.Domain.FilesSub;
using Abp.Domain.Repositories;

namespace triluatsoft.tls.Services.Files
{
    using triluatsoft.tls.Domain.Hotels;
    using triluatsoft.tls.Domain.Restaurants;
    using triluatsoft.tls.Domain.Transports;
    using triluatsoft.tls.Domain.Places;
    using Abp.AutoMapper;
    using triluatsoft.tls.Services.Hotels.FilePicSubHotel.Dto;
    using triluatsoft.tls.Helpers;
    using triluatsoft.tls.Services.Contracts.Dto;
    using System.IO;
    using System.Web.Hosting;
    using Abp.IO;

    public class FileVideoAppService : ApplicationService, IFileVideoAppService
    {
        private readonly IRepository<FileVideo, Guid> _fileVideoRepository;
        private readonly IRepository<Restaurant, Guid> _restaurantRepository;
        private readonly IRepository<Transport, Guid> _transportRepository;
        private readonly IRepository<Place, Guid> _placeRepository;
        private readonly IRepository<Hotel, Guid> _hotelRepository;


        public FileVideoAppService(
         IRepository<FileVideo, Guid> fileVideoRepository,
         IRepository<Restaurant, Guid> restaurantRepository,
         IRepository<Transport, Guid> transportRepository,
         IRepository<Place, Guid> placeRepository,
         IRepository<Hotel, Guid> hotelRepository
         )
        {
            _fileVideoRepository = fileVideoRepository;
            _restaurantRepository = restaurantRepository;
            _transportRepository = transportRepository;
            _placeRepository = placeRepository;
            _hotelRepository = hotelRepository;
        }

        private async Task<FtpResult> GetService(string Id)
        {
            var temp = await _fileVideoRepository.GetAsync(new Guid(Id));

            if (temp.HotelId != null)
            {
                return new FtpResult
                {
                    ServiceId = temp.HotelId,
                    prefix = Constants.p_Hotel
                };
            }
            else if (temp.RestaurantId != null)
            {
                return new FtpResult
                {
                    ServiceId = temp.RestaurantId,
                    prefix = Constants.p_Restaurant
                };
            }
            else if (temp.PlaceId != null)
            {
                return new FtpResult
                {
                    ServiceId = temp.PlaceId,
                    prefix = Constants.p_Place
                };
            }
            else if (temp.TransportId != null)
            {
                return new FtpResult
                {
                    ServiceId = temp.TransportId,
                    prefix = Constants.p_Transport
                };
            }
            return null;
        }

        private FtpResult GetService(FileVideo model)
        {
            if (model.HotelId != null)
            {
                return new FtpResult
                {
                    ServiceId = model.HotelId,
                    prefix = Constants.p_Hotel
                };
            }
            else if (model.RestaurantId != null)
            {
                return new FtpResult
                {
                    ServiceId = model.RestaurantId,
                    prefix = Constants.p_Restaurant
                };
            }
            else if (model.PlaceId != null)
            {
                return new FtpResult
                {
                    ServiceId = model.PlaceId,
                    prefix = Constants.p_Place
                };
            }
            else if (model.TransportId != null)
            {
                return new FtpResult
                {
                    ServiceId = model.TransportId,
                    prefix = Constants.p_Transport
                };
            }
            return null;
        }
        public async Task CreateFileVideoAsync(List<CreateFileVideoDto> input)
        {
            foreach (var file in input)
            {
                var filevideo = file.MapTo<FileVideo>();
                await _fileVideoRepository.InsertAsync(filevideo);
                var result = GetService(filevideo);

                FluentFtp.CreateSubServiceDirectory(result.prefix,
                result.ServiceId.ToString(),
                Constants.p_FileVideo,
                filevideo.Id.ToString()
                );
                 var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"), filevideo.FileName);
                 FluentFtp.SendFilePic(
                 filevideo.FileName,
                 tempFilePath,
                 result.prefix,
                 result.ServiceId.ToString(),
                 Constants.p_FileVideo,
                 filevideo.Id.ToString()
                 );
                FileHelper.DeleteIfExists(tempFilePath);

            }
        }

        public async Task DeleteFileVideo(EntityDto<Guid> input)
        {
            var result = await GetService(input.Id.ToString());
            try
            {
                FluentFtp.DeleteSubServiceDirectory(result.prefix, result.ServiceId.ToString(), Constants.p_FileVideo, input.Id.ToString());
            }
            catch
            {

            }
            await _fileVideoRepository.DeleteAsync(input.Id);
        }

        public async Task<ListResultDto<GetFileVideoById>> GetFileVideoByHotelIdAsync(EntityDto<Guid> input)
        {
            var list = await _fileVideoRepository.GetAllListAsync(p => p.HotelId == input.Id);
            return new ListResultDto<GetFileVideoById>(list.MapTo<List<GetFileVideoById>>());
        }

        public async Task<ListResultDto<GetFileVideoById>> GetFileVideoByPlaceId(EntityDto<Guid> input)
        {
            var list = await _fileVideoRepository.GetAllListAsync(p => p.PlaceId == input.Id);
            return new ListResultDto<GetFileVideoById>(list.MapTo<List<GetFileVideoById>>());
        }

        public async Task<ListResultDto<GetFileVideoById>> GetFileVideoByRestaurantId(EntityDto<Guid> input)
        {
            var list = await _fileVideoRepository.GetAllListAsync(p => p.RestaurantId == input.Id);
            return new ListResultDto<GetFileVideoById>(list.MapTo<List<GetFileVideoById>>());
        }

        public async Task<ListResultDto<GetFileVideoById>> GetFileVideoByTransportId(EntityDto<Guid> input)
        {
            var list = await _fileVideoRepository.GetAllListAsync(p => p.TransportId == input.Id);
            return new ListResultDto<GetFileVideoById>(list.MapTo<List<GetFileVideoById>>());
        }
    }
}
