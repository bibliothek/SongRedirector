using SongRedirector.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SongRedirector.Models
{
    public interface ILinkConfig
    {
        Link[] Links { get; }

        Link[] WeightedLinks { get; }
    }
}
