
using SongRedirector.Models;
using SongRedirector.Repository;

namespace SongRedirector.Services
{
    public interface ILinkProvider
    {
        Link GetLink(string configName);

    }
}