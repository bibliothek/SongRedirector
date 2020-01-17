using SongRedirector.Models;
using SongRedirector.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SongRedirector.Repository
{
    public interface ILinkConfig
    {
        Link[] Links { get; }

        string Name { get; }

        Link[] WeightedLinks { get; }

        int GetNewId();
    }
}
