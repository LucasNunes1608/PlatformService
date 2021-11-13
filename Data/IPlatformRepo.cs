public interface IPlatformRepo
{
    bool SaveChanges();
    IEnumerable<Platform> GetAllPlatforms();
    Platform GetPlatformById(int platformId);
    void CreatePlatform(Platform platform);
}
