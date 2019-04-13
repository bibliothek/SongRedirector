using SongRedirector.Models;

namespace SongRedirector.Repository
{
    public interface ILinkRepository
    {
        ILinkConfig GetConfig(string configName);

        Link GetLink(string configName, int id);
        void Delete(string config, int id);
        void Save(string configName, Link link);
        void ChangeProbability(string config, int id, int delta);

    }
}
