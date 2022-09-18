using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.API.Data;
using PlatformService.API.Dtos;
using PlatformService.API.Models;

namespace PlatformService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting platforms...");

            var platformItem = _repository.GetPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platformItem = _repository.GetPlatformById(id);

            if (platformItem is null)
            {
                return NotFound();
            }

            var mapp = _mapper.Map<PlatformReadDto>(platformItem);
            return Ok(mapp);
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreate)
        {
            var platformModel = _mapper.Map<Platform>(platformCreate);
            _repository.CreatePlatform(platformModel);
            var response = _repository.SaveChanges();

            var platformResponse = _mapper.Map<PlatformReadDto>(platformModel);

            return CreatedAtRoute( nameof(GetPlatformById), new { Id = platformResponse.Id} , response);
        }
    }
}
