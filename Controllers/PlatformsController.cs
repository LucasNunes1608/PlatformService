using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
    {
        Console.WriteLine("--> Getting Platforms...");
        var platforms = _repository.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platforms));
    }

    [HttpGet("{id}", Name = "GetPlatformById")]
    public ActionResult<PlatformReadDTO> GetPlatformById(int id)
    {
        var platform = _repository.GetPlatformById(id);
        if (platform != null)
            return Ok(_mapper.Map<PlatformReadDTO>(platform));
        else
            return NotFound();
    }

    [HttpPost]
    public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTO platformCreateDTO)
    {
        var platformModel = _mapper.Map<Platform>(platformCreateDTO);
        _repository.CreatePlatform(platformModel);
        _repository.SaveChanges();

        var platformReadDTO = _mapper.Map<PlatformReadDTO>(platformModel);
        return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDTO.Id }, platformReadDTO);
    }
}
