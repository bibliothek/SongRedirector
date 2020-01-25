using SongRedirector.Models;
using SongRedirector.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SongRedirector.Repository
{
    public interface ILinkConfig
    {
        LinkEntity[] Links { get; }

        string Name { get; }

        LinkEntity[] WeightedLinks { get; }

        int GetNewId();
    }
}
