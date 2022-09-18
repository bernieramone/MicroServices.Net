using AutoMapper;
using PlatformService.API.Models;
using PlatformService.API.Dtos;

namespace PlatformService.API.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            //source - > target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();

        }
    }
}
