using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using triluatsoft.tls.Domain.Common;
using triluatsoft.tls.Domain.FilesSub;
using triluatsoft.tls.Services.Contracts.Dto;

namespace triluatsoft.tls.Services.Contracts
{
    using triluatsoft.tls.Domain.Hotels;
    using triluatsoft.tls.Domain.Restaurants;
    using triluatsoft.tls.Domain.Packages;
    using triluatsoft.tls.Domain.Transports;
    using triluatsoft.tls.Domain.Places;
    using Abp.Application.Services.Dto;
    using triluatsoft.tls.Helpers;
    using System.IO;
    using Abp.IO;
    using Abp.Domain.Uow;
    using triluatsoft.tls.Dto;
    using System.Web;
    using Abp.Extensions;
    using System.Linq;
    using Authorization.Users.Exporting;
    using System.Web.Hosting;

    public class ContractAppService :  ApplicationService, IContractAppService
    {
        private readonly IRepository<Contract, Guid> _contractRepository;
        private readonly IRepository<FileSub, Guid> _filesubRepository;
        private readonly IRepository<FileContract, Guid> _filecontractRepository; 
        private readonly IRepository<Restaurant, Guid> _restaurantRepository;
        private readonly IRepository<Package, Guid> _packageRepository;
        private readonly IRepository<Transport, Guid> _transportRepository;
        private readonly IRepository<Place, Guid> _placeRepository;
        private readonly IRepository<Hotel, Guid> _hotelRepository;
        private readonly IAppFolders _appFolders;
        private readonly IUserListExcelExporter _userListExcelExporter;


        public ContractAppService(
         IRepository<Contract, Guid> contractRepository,
         IRepository<FileSub, Guid> filesubRepository,
         IRepository<Restaurant, Guid> restaurantRepository,
         IRepository<Package, Guid> packageRepository,
         IRepository<Transport,Guid> transportRepository,
         IRepository<Place, Guid> placeRepository,
         IRepository<Hotel, Guid> hotelRepository,
         IRepository<FileContract, Guid> filecontractRepository,
         IAppFolders appFolders,
         IUserListExcelExporter userListExcelExporter
         )
        {
            _contractRepository = contractRepository;
            _filesubRepository = filesubRepository;
            _restaurantRepository = restaurantRepository;
            _packageRepository = packageRepository;
            _transportRepository = transportRepository;
            _placeRepository = placeRepository;
            _hotelRepository = hotelRepository;
            _filecontractRepository = filecontractRepository;
            _appFolders = appFolders;
            _userListExcelExporter = userListExcelExporter;
        }
   
        private async Task<FtpResult> GetService(string Id)
        {
           var temp = await _contractRepository.GetAsync(new Guid(Id));

            if(temp.HotelId!=null)
            {
                return new FtpResult {
                    ServiceId = temp.HotelId,
                    prefix = Constants.p_Hotel
                };
            }else if(temp.RestaurantId !=  null)
            {
                return new FtpResult
                {
                    ServiceId = temp.RestaurantId,
                    prefix = Constants.p_Restaurant
                };
            }else if(temp.PlaceId != null)
            {
                return new FtpResult
                {
                    ServiceId = temp.PlaceId,
                    prefix = Constants.p_Place
                };
            }else if(temp.TransportId != null)
            {
                return new FtpResult
                {
                    ServiceId = temp.TransportId,
                    prefix = Constants.p_Transport
                };
            }
            else if (temp.PackageId != null)
            {
                return new FtpResult
                {
                    ServiceId = temp.PackageId,
                    prefix = Constants.p_Package
                };
            }
            return null;
        }

        private FtpResult GetService(Contract model)
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
            else if (model.PackageId != null)
            {
                return new FtpResult
                {
                    ServiceId = model.PackageId,
                    prefix = Constants.p_Package
                };
            }
            return null;
        }

        private async Task DeleteFileFtp(Guid Id,string subPrefix)
        {
            if (subPrefix == Constants.p_FileContract)
            {
                var temp2 = await _filecontractRepository.FirstOrDefaultAsync(Id) ;
                var result2 = await GetService(temp2.Contract.ToString());
                FluentFtp.DeleteFileDirectory(result2.prefix,
                    result2.ServiceId.ToString(),
                    Constants.p_Contract,
                    temp2.Contract.ToString(),
                    subPrefix,
                    Id.ToString());
            }   
            else {
                var temp = await _filesubRepository.FirstOrDefaultAsync(Id);
                var result = await GetService(temp.ContractId.ToString());
                FluentFtp.DeleteFileDirectory(result.prefix
                    , result.ServiceId.ToString(),
                    Constants.p_Contract,
                    temp.ContractId.ToString(),
                    subPrefix,
                    Id.ToString());
            }
        }

        public async Task DeleteFileContract(EntityDto<Guid> input)
        {
            try
            {
                await DeleteFileFtp(input.Id, Constants.p_FileContract);
            }
            catch
            {

            }
            await _filecontractRepository.DeleteAsync(input.Id);
        }

        public async Task DeleteFileSub(EntityDto<Guid> input)
        {
            try
            {
                await DeleteFileFtp(input.Id, Constants.p_FileSub);
            }
            catch
            {

            }
            await _filesubRepository.DeleteAsync(input.Id);

        }

        public async Task CreateContractAsync(CreateContractDto input)
        {
            var createContract = input.MapTo<Contract>();
            await _contractRepository.InsertAsync(createContract);
            var result = GetService(createContract);
            try
            {
                FluentFtp.CreateSubServiceDirectory(result.prefix,
                result.ServiceId.ToString(),
                Constants.p_Contract,
                createContract.Id.ToString());
                foreach (var file in createContract.FileSubs)
                {
                    var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"), file.FileName);
                    FluentFtp.SendFile(
                        file.FileName,
                        tempFilePath,
                        result.prefix,
                        result.ServiceId.ToString(),
                        Constants.p_Contract,
                        createContract.Id.ToString(),
                        Constants.p_FileSub,
                        file.Id.ToString()
                        );
                    FileHelper.DeleteIfExists(tempFilePath);

                }
                foreach (var file in createContract.FileContracts)
                {
                    var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"), file.ContractFileName);
                    FluentFtp.SendFile(
                        file.ContractFileName,
                        tempFilePath,
                        result.prefix,
                        result.ServiceId.ToString(),
                        Constants.p_Contract,
                        createContract.Id.ToString(),
                        Constants.p_FileContract,
                        file.Id.ToString());
                    FileHelper.DeleteIfExists(tempFilePath);
                }
            }
            catch
            {

            }
            
        }

        public async Task DeleteContractAsync(Guid Id)
        {
            var result = await GetService(Id.ToString());
            try
            {
                FluentFtp.DeleteSubServiceDirectory(result.prefix, result.ServiceId.ToString(), Constants.p_Contract, Id.ToString());
            }
            catch
            {

            }
            await _contractRepository.DeleteAsync(Id);
        }


        public async Task<ListResultDto<GetContractRestaurantById>> GetContractRestaurantByIdAsync(EntityDto<Guid> input)
        {
            //restaurant
            var contractList = await _contractRepository.GetAllListAsync(p => p.RestaurantId == input.Id);
            foreach (var contract in contractList)
            {
                var filesubList = await _filesubRepository.GetAllListAsync(p => p.ContractId == contract.Id);
                foreach (var file in filesubList)
                {
                    contract.FileSubs.Add(file);
                }
                var filecontractList = await _filecontractRepository.GetAllListAsync(p => p.ContractId == contract.Id);
                foreach(var file in filecontractList)
                {
                    contract.FileContracts.Add(file);
                }
            }
            return new ListResultDto<GetContractRestaurantById>(contractList.MapTo<List<GetContractRestaurantById>>());
        }

        public async Task UpdateContractAsync(UpdateContractDto input)
        {
            var updateContract = input.MapTo<Contract>();
            var result = GetService(updateContract);
            foreach (var file in updateContract.FileContracts)
            {
                file.ContractId = updateContract.Id;
                if (file.Id == Guid.Empty)
                {
                  
                    await _filecontractRepository.InsertAsync(file);
                    var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"), file.ContractFileName);
                    FluentFtp.SendFile(
                        file.ContractFileName,
                        tempFilePath,
                        result.prefix,
                        result.ServiceId.ToString(),
                        Constants.p_Contract,
                        file.ContractId.ToString(),
                        Constants.p_FileContract,
                        file.Id.ToString()
                        );
                    FileHelper.DeleteIfExists(tempFilePath);

                }
            }
            foreach (var file in updateContract.FileSubs)
            {
                file.ContractId = updateContract.Id;
                if (file.Id == Guid.Empty)
                {
           
                    await _filesubRepository.InsertAsync(file);
                    var tempFilePath = Path.Combine(HostingEnvironment.MapPath("~/Temp/Downloads/"), file.FileName);
                    FluentFtp.SendFile(
                        file.FileName,
                        tempFilePath,
                        result.prefix,
                        result.ServiceId.ToString(),
                        Constants.p_Contract,
                        file.ContractId.ToString(),
                        Constants.p_FileSub,
                        file.Id.ToString()
                        );
                    FileHelper.DeleteIfExists(tempFilePath);

                }
            }
            await CurrentUnitOfWork.SaveChangesAsync();
            await _contractRepository.UpdateAsync(updateContract);
            foreach (var file in updateContract.FileSubs)
            {
                await _filesubRepository.UpdateAsync(file);
            }
            foreach (var file in updateContract.FileContracts)
            {
                await _filecontractRepository.UpdateAsync(file);
            }
        }

        public async Task<ListResultDto<GetContractPackageById>> GetContractPackageById(EntityDto<Guid> input)
        {
            //Package
            var contractListPa = await _contractRepository.GetAllListAsync(p => p.PackageId == input.Id);
            foreach (var contract in contractListPa)
            {
                var filesubList = await _filesubRepository.GetAllListAsync(p => p.ContractId == contract.Id);
                foreach (var file in filesubList)
                {
                    contract.FileSubs.Add(file);
                }
                var filecontractList = await _filecontractRepository.GetAllListAsync(p => p.ContractId == contract.Id);
                foreach (var file in filecontractList)
                {
                    contract.FileContracts.Add(file);
                }
            }
            return new ListResultDto<GetContractPackageById>(contractListPa.MapTo<List<GetContractPackageById>>());
        }

        public async Task<ListResultDto<GetContractPlaceById>> GetContractPlaceById(EntityDto<Guid> input)
        {
            //Place
            var contractListPl = await _contractRepository.GetAllListAsync(p => p.PlaceId == input.Id);
            foreach (var contract in contractListPl)
            {
                var filesubList = await _filesubRepository.GetAllListAsync(p => p.ContractId == contract.Id);
                foreach (var file in filesubList)
                {
                    contract.FileSubs.Add(file);
                }
                var filecontractList = await _filecontractRepository.GetAllListAsync(p => p.ContractId == contract.Id);
                foreach (var file in filecontractList)
                {
                    contract.FileContracts.Add(file);
                }
            }
            return new ListResultDto<GetContractPlaceById>(contractListPl.MapTo<List<GetContractPlaceById>>());
        }

        public async Task<ListResultDto<GetContractHotelById>> GetContractHotelById(EntityDto<Guid> input)
        {
            //Hotel
            var contractListH = await _contractRepository.GetAllListAsync(p => p.HotelId == input.Id);
            foreach (var contract in contractListH)
            {
                var filesubList = await _filesubRepository.GetAllListAsync(p => p.ContractId == contract.Id);
                foreach (var file in filesubList)
                {
                    contract.FileSubs.Add(file);
                }
                var filecontractList = await _filecontractRepository.GetAllListAsync(p => p.ContractId == contract.Id);
                foreach (var file in filecontractList)
                {
                    contract.FileContracts.Add(file);
                }
            }
            return new ListResultDto<GetContractHotelById>(contractListH.MapTo<List<GetContractHotelById>>());
        }

        public async Task<ListResultDto<GetContractTransportById>> GetContractTransportById(EntityDto<Guid> input)
        {
            //Transport
            var contractListTr = await _contractRepository.GetAllListAsync(p => p.TransportId == input.Id);
            foreach (var contract in contractListTr)
            {
                var filesubList = await _filesubRepository.GetAllListAsync(p => p.ContractId == contract.Id);
                foreach (var file in filesubList)
                {
                    contract.FileSubs.Add(file);
                }
                var filecontractList = await _filecontractRepository.GetAllListAsync(p => p.ContractId == contract.Id);
                foreach (var file in filecontractList)
                {
                    contract.FileContracts.Add(file);
                }
            }
            return new ListResultDto<GetContractTransportById>(contractListTr.MapTo<List<GetContractTransportById>>());
        }
        public object GetContractTransportByIdSS(ServerSideDatatableInput input)
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
            var listAll = _contractRepository.GetAll().OrderByDescending(p=>p.CreationTime)
                .Where(p => (p.TransportId.Value == guid))
                .ToList();
            foreach(var item in listAll)
            {
                var filesubList = _filesubRepository.GetAll().Where(p => p.ContractId == item.Id);
                foreach (var file in filesubList)
                {
                    item.FileSubs.Add(file);
                }
                var filecontractList =  _filecontractRepository.GetAll().Where(p => p.ContractId == item.Id);
                foreach (var file in filecontractList)
                {
                    item.FileContracts.Add(file);
                }
            }
            var listSkipTake = listAll.Skip(input.start).Take(input.length);
            var result = listSkipTake.MapTo<List<GetContractTransportById>>();
            return new
            {
                draw = input.draw,
                recordsTotal = listAll.Count(),
                recordsFiltered = listAll.Count(),
                data = result
        };
        }
        public object GetContractHotelByIdSS(ServerSideDatatableInput input)
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
            var listAll = _contractRepository.GetAll().OrderByDescending(p => p.CreationTime)
                .Where(p => (p.HotelId.Value == guid))
                .ToList();
            foreach (var item in listAll)
            {
                var filesubList = _filesubRepository.GetAll().Where(p => p.ContractId == item.Id);
                foreach (var file in filesubList)
                {
                    item.FileSubs.Add(file);
                }
                var filecontractList = _filecontractRepository.GetAll().Where(p => p.ContractId == item.Id);
                foreach (var file in filecontractList)
                {
                    item.FileContracts.Add(file);
                }
            }
            var listSkipTake = listAll.Skip(input.start).Take(input.length);
            var result = listSkipTake.MapTo<List<GetContractHotelById>>();
            return new
            {
                draw = input.draw,
                recordsTotal = listAll.Count(),
                recordsFiltered = listAll.Count(),
                data = result
            };
        }
        public object GetContractPackageByIdSS(ServerSideDatatableInput input)
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
            var listAll = _contractRepository.GetAll().OrderByDescending(p => p.CreationTime)
                .Where(p => (p.PackageId.Value == guid))
                .ToList();
            foreach (var item in listAll)
            {
                var filesubList = _filesubRepository.GetAll().Where(p => p.ContractId == item.Id);
                foreach (var file in filesubList)
                {
                    item.FileSubs.Add(file);
                }
                var filecontractList = _filecontractRepository.GetAll().Where(p => p.ContractId == item.Id);
                foreach (var file in filecontractList)
                {
                    item.FileContracts.Add(file);
                }
            }
            var listSkipTake = listAll.Skip(input.start).Take(input.length);
            var result = listSkipTake.MapTo<List<GetContractPackageById>>();
            return new
            {
                draw = input.draw,
                recordsTotal = listAll.Count(),
                recordsFiltered = listAll.Count(),
                data = result
            };
        }
        public object GetContractRestaurantByIdSS(ServerSideDatatableInput input)
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
            var listAll = _contractRepository.GetAll().OrderByDescending(p => p.CreationTime)
                .Where(p => (p.RestaurantId.Value == guid))
                .ToList();
            foreach (var item in listAll)
            {
                var filesubList = _filesubRepository.GetAll().Where(p => p.ContractId == item.Id);
                foreach (var file in filesubList)
                {
                    item.FileSubs.Add(file);
                }
                var filecontractList = _filecontractRepository.GetAll().Where(p => p.ContractId == item.Id);
                foreach (var file in filecontractList)
                {
                    item.FileContracts.Add(file);
                }
            }
            var listSkipTake = listAll.Skip(input.start).Take(input.length);
            var result = listSkipTake.MapTo<List<GetContractPackageById>>();
            return new
            {
                draw = input.draw,
                recordsTotal = listAll.Count(),
                recordsFiltered = listAll.Count(),
                data = result
            };
        }
        public object GetContractPlaceByIdSS(ServerSideDatatableInput input)
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
            var listAll = _contractRepository.GetAll().OrderByDescending(p => p.CreationTime)
                .Where(p => (p.PlaceId.Value == guid))
                .ToList();
            foreach (var item in listAll)
            {
                var filesubList = _filesubRepository.GetAll().Where(p => p.ContractId == item.Id);
                foreach (var file in filesubList)
                {
                    item.FileSubs.Add(file);
                }
                var filecontractList = _filecontractRepository.GetAll().Where(p => p.ContractId == item.Id);
                foreach (var file in filecontractList)
                {
                    item.FileContracts.Add(file);
                }
            }
            var listSkipTake = listAll.Skip(input.start).Take(input.length);
            var result = listSkipTake.MapTo<List<GetContractPackageById>>();
            return new
            {
                draw = input.draw,
                recordsTotal = listAll.Count(),
                recordsFiltered = listAll.Count(),
                data = result
            };
        }
        public async Task<GetContractHotelById> GetContractForEdit(EntityDto<Guid> input)
        {
            var contract = await _contractRepository.FirstOrDefaultAsync(p => p.Id == input.Id);        
            var filesubList = await _filesubRepository.GetAllListAsync(p => p.ContractId == contract.Id);
            foreach (var file in filesubList)
            {
                contract.FileSubs.Add(file);
            }
            var filecontractList = await _filecontractRepository.GetAllListAsync(p => p.ContractId == contract.Id);
            foreach (var file in filecontractList)
            {
                contract.FileContracts.Add(file);
            }
            return contract.MapTo<GetContractHotelById>();
        }

      

        private bool ParaRequestIsNullOrEmpty(string[] param)
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
            var partnerContractCodeS = HttpContext.Current.Request.Params.GetValues("partnerContractCode");
            var partnerContractCodeSring = "";
            if (ParaRequestIsNullOrEmpty(partnerContractCodeS)) partnerContractCodeSring = partnerContractCodeS[0];

            var registerYearS = HttpContext.Current.Request.Params.GetValues("registerYear");
            var registerYearString = 0;
            if (ParaRequestIsNullOrEmpty(registerYearS)) registerYearString =int.Parse(registerYearS[0]);

            var contractNameS = HttpContext.Current.Request.Params.GetValues("contractName");
            var contractNameString = "";
            if (ParaRequestIsNullOrEmpty(contractNameS)) contractNameString = contractNameS[0];
            
            var effectiveDateS = HttpContext.Current.Request.Params.GetValues("effectiveDate");
            var effectiveDateString = "";
            if (ParaRequestIsNullOrEmpty(effectiveDateS)) effectiveDateString = effectiveDateS[0];

            var expiartionDateS = HttpContext.Current.Request.Params.GetValues("expiartionDate");
            var expiartionDateString = "";
            if (ParaRequestIsNullOrEmpty(expiartionDateS)) expiartionDateString = expiartionDateS[0]; 

            //var starS = HttpContext.Current.Request.Params.GetValues("star");
            //Guid starGuidId = new Guid();
            //if (ParaRequestIsNullOrEmpty(starS)) starGuidId = new Guid(starS[0]);
            //var priceFromS = HttpContext.Current.Request.Params.GetValues("priceFrom");
            //var priceFromString = "";
            //if (ParaRequestIsNullOrEmpty(priceFromS)) priceFromString = priceFromS[0];
            //var priceToS = HttpContext.Current.Request.Params.GetValues("priceTo");
            //var priceToString = "";
            //if (ParaRequestIsNullOrEmpty(provinceS)) priceToString = priceToS[0];
            #endregion
            //get all 
            var listAll = _contractRepository.GetAll().Select((p) => new
            {
                p.PartnerContractCode,
                p.RegisterYear,
                p.ContractName,
                p.EffectiveDate,
                p.ExpiartionDate,
                Service = (p.HotelId != null) ? "Khách sạn" :
                (p.TransportId != null) ? "Vận chuyển" :
                (p.RestaurantId != null) ? "Nhà hàng" :
                (p.PackageId != null) ? "Package" :
                (p.PlaceId != null) ? "Điểm tham quan" : "X",
                Hotel = (p.HotelId != null) ? p.Hotel.Name : "",
                p.HotelId,
                Transport = (p.TransportId != null) ? p.Transport.Name : "",
                p.TransportId,
                Restaurant = (p.RestaurantId != null) ? p.Restaurant.Name : "",
                p.RestaurantId,
                Package = (p.PackageId != null) ? p.Package.Name : "",
                p.PackageId,
                Place = (p.PlaceId != null) ? p.Place.Name : "",
                p.PlaceId,
                p.PayPolicy,
                p.FreePolicy,
                p.ChildPolicy,
                p.Cancellation,
                p.Deposit,
                p.Id
                //Star = (p.Star != null) ? p.Star.Name : "",
                //p.StarId,
                //p.Address,
                //Country = (p.Country != null) ? p.Country.Name : "",
                //p.CountryId,
                //Province = (p.Province != null) ? p.Province.Name : "",
                //p.ProvinceId,
                //District = (p.District != null) ? p.District.Name : "",
                //p.Status,
                //p.CapacityRoom,
                //p.Id,
                //price = (p.AddPackageContractPrices.FirstOrDefault() != null) ? p.AddPackageContractPrices.Min(x => x.Price) : 0,
                //Roomtype = (p.AddPackageContractPrices.FirstOrDefault() != null) ? p.AddPackageContractPrices.OrderBy(x => x.Price).FirstOrDefault().Roomtype.Name : "",
                //p.DirectorName,
                //p.PositionName,
                //p.EmailAdress,
                //p.PhoneNumber,
                //SeriesCheck = (p.SeriesBookingHotels.FirstOrDefault() != null) ? true : false,
                //p.Rate,




            }).ToList();
            //filter
            var listFilter = listAll.Where(p => VietToEngStr.RemoveSign4VietnameseString(p.ContractName.ToLower()).Contains(VietToEngStr.RemoveSign4VietnameseString(input.search)));
            if (ParaRequestIsNullOrEmpty(contractNameS))
                listFilter = listFilter.Where(p => p.ContractName == contractNameString);
            //if (ParaRequestIsNullOrEmpty(roomNumberS))
            //    listFilter = listFilter.Where(p => p.CapacityRoom == roomNumberString);registerYearS
            //if (ParaRequestIsNullOrEmpty(registerYearS))
            //    listFilter = listFilter.Where(p => p.RegisterYear == int.Parse(registerYearString));
            //filter price chua biet
            //if (ParaRequestIsNullOrEmpty(countryS))
            //    listFilter = listFilter.Where(p => p.CountryId == countryGuidId);
            //if (ParaRequestIsNullOrEmpty(provinceS))
            //    listFilter = listFilter.Where(p => p.ProvinceId == provinceGuidId);
            //if (ParaRequestIsNullOrEmpty(starS))
            //    listFilter = listFilter.Where(p => p.StarId != null && p.StarId == starGuidId);
            if (input.orderColumnName == "ContractName")
            {
                if (input.dir == "asc") listFilter = listFilter.OrderBy(p => p.ContractName);
                else listFilter = listFilter.OrderByDescending(p => p.ContractName);
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

        public FileDto GetContractsToExcel(List<ExcelContractInputDto> input)
        {
            return _userListExcelExporter.ExportToFile(input);
        }
    }
    
}
