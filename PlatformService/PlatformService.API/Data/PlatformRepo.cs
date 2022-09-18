using PlatformService.API.Models;

namespace PlatformService.API.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;

        }

        public void CreatePlatform(Platform platform)
        {
            if (platform is null) throw new ArgumentNullException(nameof(platform));
            _context.Platforms.Add(platform);
        }

        public Platform GetPlatformById(int id)
        {
            var response = _context.Platforms.FirstOrDefault(p => p.Id == id);

            if (response is null) throw new ArgumentNullException(nameof(response));
            
            return response;
        }

        public IEnumerable<Platform> GetPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public bool SaveChanges()
        {
            var responseNumberOfStatesWritenInTheData = _context.SaveChanges();

            return responseNumberOfStatesWritenInTheData >= 0;
        }
    }
}
