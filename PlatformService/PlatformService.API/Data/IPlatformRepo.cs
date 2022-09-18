using PlatformService.API.Models;

namespace PlatformService.API.Data
{
    public interface IPlatformRepo
    {
        bool SaveChnages();
        IEnumerable<Platform> GetPlatforms();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform platform);
    }
}