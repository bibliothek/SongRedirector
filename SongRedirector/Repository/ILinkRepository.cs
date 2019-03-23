using SongRedirector.Models;

namespace SongRedirector.Repository
{
    public interface ILinkRepository
    {
        ILinkConfig GetConfig(string configName);
    }
}
