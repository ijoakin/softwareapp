using AutoMapper;
using SoftwareApp.DataTransferObjects;
using SoftwareApp.Entities;
using SoftwareApp.IBusinessLogic;
using SoftwareApp.IDataAccess;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoftwareApp.BusinessLogic
{
    public class SoftwareBI : ISoftwareBI
    {
        private readonly IRepository<Software> repositorySoftware;
        private readonly IRepository<Platform> repositoryPlatform;
        private readonly IRepository<Location> repositoryLocation;
        private readonly IRepository<SoftwareType> repositorySoftwareType;


        public SoftwareBI(IRepository<Software> _repositorySoftware,
            IRepository<Platform> _repositoryPlatform,
            IRepository<Location> _repositoryLocation,
            IRepository<SoftwareType> _repositorySoftwareType)
        {
            repositorySoftware = _repositorySoftware ?? throw new ArgumentNullException(nameof(_repositorySoftware));
            repositoryPlatform = _repositoryPlatform ?? throw new ArgumentNullException(nameof(_repositoryPlatform));
            repositoryLocation = _repositoryLocation ?? throw new ArgumentNullException(nameof(_repositoryLocation));
            repositorySoftwareType = _repositorySoftwareType ?? throw new ArgumentNullException(nameof(_repositorySoftwareType));
        }

        public async Task<IList<SoftwareDTO>> GetAllSoftwares(string name, int typeId)
        {

            var listSoftware = from s in this.repositorySoftware.GetQuery()
                               join p in repositoryPlatform.GetQuery() on s.platformid equals p.id
                               join l in repositoryLocation.GetQuery() on s.locationid equals l.id
                               join st in repositorySoftwareType.GetQuery() on s.typeid equals st.id
                               select new SoftwareDTO
                               {
                                   id = s.id,
                                   locationid = s.locationid,
                                   platformid = s.platformid,
                                   softwareDescription = s.softwareDescription,
                                   softwareName = s.softwareName,
                                   typeid = s.typeid,
                                   unc = s.unc,
                                   locationDescription = l.Description,
                                   platformDescription = p.Description,
                                   typeDescription = st.Description
                               };

            if (name != null)
            {
                listSoftware = listSoftware.Where(x => x.softwareName.Contains(name));
            }

            if (typeId != 0)
            {
                listSoftware = listSoftware.Where(x => x.typeid == typeId);
            }

            return listSoftware.OrderBy(x=>x.softwareName).ToList();
        }   
        public async Task<IList<SoftwareDTO>> GetAllSoftwares(string name)
        {
            var listSoftware = await this.repositorySoftware.GetQueryAsync();

            listSoftware.Where(x => x.softwareName.Contains(name));

            var listSoftwareDTO = new List<SoftwareDTO>();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Software, SoftwareDTO>();
            });
            IMapper iMapper = config.CreateMapper();

            foreach (var software in listSoftware.ToList())
            {
                listSoftwareDTO.Add(iMapper.Map<Software, SoftwareDTO>(software));
            }
            return listSoftwareDTO;
        }

        public async Task<SoftwareDTO> GetSoftwaresById(int id)
        {
            var software = await this.repositorySoftware.GetByIdAsync(id);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Software, SoftwareDTO>();
            });
            IMapper iMapper = config.CreateMapper();

            if (software != null)
                return iMapper.Map<Software, SoftwareDTO>(software);
            return null;
        }

        public async Task<bool> DeleteSoftwareById(int id)
        {
            return await this.repositorySoftware.DeleteAsync(id);
        }

        public async Task<bool> DeleteLocationById(int id)
        {
            return await this.repositoryLocation.DeleteAsync(id);
        }

        public async Task<bool> DeletePlatformById(int id)
        {
            return await this.repositoryPlatform.DeleteAsync(id);
        }


        public async Task<bool> SaveSoftware(SoftwareDTO softwareDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SoftwareDTO, Software>();
            });
            IMapper iMapper = config.CreateMapper();

            var software = iMapper.Map<SoftwareDTO, Software>(softwareDTO);

            return await this.repositorySoftware.SaveAsync(software);
        }
        #region "Platform"
        public async Task<IList<PlatformDTO>> GetAllPlatforms()
        {
            var listPlatform = await this.repositoryPlatform.GetAllAsync();
            var listPlatformDTO = new List<PlatformDTO>();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Platform, PlatformDTO>();
            });
            IMapper iMapper = config.CreateMapper();

            foreach (var platform in listPlatform)
            {
                listPlatformDTO.Add(iMapper.Map<Platform, PlatformDTO>(platform));
            }
            return listPlatformDTO;
        }
        public async Task<PlatformDTO> GetPlatformsById(int id)
        {
            var listPlatform = await this.repositoryPlatform.GetByIdAsync(id);
            
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Platform, PlatformDTO>();
            });
            IMapper iMapper = config.CreateMapper();

            var platformDTO = iMapper.Map<Platform, PlatformDTO>(listPlatform);
            
            return platformDTO;
        }
        

        public async Task<bool> SavePlatform(PlatformDTO platformDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PlatformDTO, Platform>();
            });
            IMapper iMapper = config.CreateMapper();

            var platform = iMapper.Map<PlatformDTO, Platform>(platformDTO);

            return await this.repositoryPlatform.SaveAsync(platform);
        }
        #endregion

        #region "Location"
        public async Task<IList<LocationDTO>> GetAllLocations()
        {
            var listLocation = await this.repositoryLocation.GetAllAsync();
            var listLocationDTO = new List<LocationDTO>();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Location, LocationDTO>();
            });
            IMapper iMapper = config.CreateMapper();

            foreach (var location in listLocation)
            {
                listLocationDTO.Add(iMapper.Map<Location, LocationDTO>(location));
            }
            return listLocationDTO;
        }

        public async Task<LocationDTO> GetLocationById(int id)
        {
            var location = await this.repositoryLocation.GetByIdAsync(id);
            

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Location, LocationDTO>();
            });
            IMapper iMapper = config.CreateMapper();

            var locationDTO = iMapper.Map<Location, LocationDTO>(location);
            
            return locationDTO;
        }

        public async Task<bool> SaveLocation(LocationDTO locationsDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LocationDTO, Location>();
            });
            IMapper iMapper = config.CreateMapper();

            var location = iMapper.Map<LocationDTO, Location>(locationsDTO);
            var result = await this.repositoryLocation.SaveAsync(location);

            return result;
        }
        #endregion

        #region "Software Type"

        public async Task<bool> DeleteSoftwareTypeById(int id)
        {
            return await this.repositorySoftwareType.DeleteAsync(id);
        }

        public async Task<IList<SoftwareTypeDTO>> GetAllSoftwareTypes()
        {
            var list = await this.repositorySoftwareType.GetAllAsync();
            var listDTO = new List<SoftwareTypeDTO>();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SoftwareType, SoftwareTypeDTO>();
            });
            IMapper iMapper = config.CreateMapper();

            foreach (var softwareType in list)
            {
                listDTO.Add(iMapper.Map<SoftwareType, SoftwareTypeDTO>(softwareType));
            }
            return listDTO;
        }

        public async Task<SoftwareTypeDTO> GetSoftwareTypeById(int id)
        {
            var item = await this.repositorySoftwareType.GetByIdAsync(id);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SoftwareType, SoftwareTypeDTO>();
            });
            IMapper iMapper = config.CreateMapper();

            var itemDTO = iMapper.Map<SoftwareType, SoftwareTypeDTO>(item);

            return itemDTO;
        }

        public async Task<bool> SaveSoftwareType(SoftwareTypeDTO softwareTypeDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SoftwareTypeDTO, SoftwareType>();
            });
            IMapper iMapper = config.CreateMapper();

            var item = iMapper.Map<SoftwareTypeDTO, SoftwareType>(softwareTypeDTO);

            return await this.repositorySoftwareType.SaveAsync(item);
        }
        #endregion
    }
}
