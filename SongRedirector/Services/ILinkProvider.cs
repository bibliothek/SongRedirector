
using SongRedirector.Models;
using SongRedirector.Repository;

namespace SongRedirector.Services
{
    public interface ILinkProvider
    {
        LinkEntity GetLink(string configName);

    }
}