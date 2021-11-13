using AutoMapper;

public class PlatformsProfile : Profile
{
    public PlatformsProfile()
    {
        // Source -> Target
        CreateMap<Platform, PlatformReadDTO>();
        CreateMap<PlatformCreateDTO, Platform>();
    }
}