using SoftwareApp.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoftwareApp.IBusinessLogic
{
    public interface ISoftwareBI
    {
        Task<IList<SoftwareDTO>> GetAllSoftwares(string name, int typeId);

        Task<IList<SoftwareDTO>> GetAllSoftwares(string name);

        Task<SoftwareDTO> GetSoftwaresById(int id);

        Task<bool> DeleteSoftwareById(int id);
        Task<bool> DeleteLocationById(int id);

        Task<bool> DeletePlatformById(int id);

        Task<bool> SaveSoftware(SoftwareDTO softwareDTO);

        Task<IList<PlatformDTO>> GetAllPlatforms();
        Task<PlatformDTO> GetPlatformsById(int id);
        Task<bool> SavePlatform(PlatformDTO platformDTO);


        Task<IList<LocationDTO>> GetAllLocations();
        Task<LocationDTO> GetLocationById(int id);
        Task<bool> SaveLocation(LocationDTO locationsDTO);


        Task<IList<SoftwareTypeDTO>> GetAllSoftwareTypes();
        Task<SoftwareTypeDTO> GetSoftwareTypeById(int id);
        Task<bool> SaveSoftwareType(SoftwareTypeDTO softwareTypeDTO);

        Task<bool> DeleteSoftwareTypeById(int id);

    }
}
