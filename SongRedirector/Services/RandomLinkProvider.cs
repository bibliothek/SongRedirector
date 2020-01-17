using SongRedirector.Models;
using SongRedirector.Repository;
using System;
namespace SongRedirector.Services
{
    public class RandomLinkProvider : ILinkProvider
    {
        private ILinkRepository linkRepository;

        private static readonly Random rnd = new Random(Guid.NewGuid().GetHashCode());

        public RandomLinkProvider(ILinkRepository linkRepository)
        {
            this.linkRepository = linkRepository;
        }

        public Link GetLink(string configName)
        {
            var config = linkRepository.GetConfig(configName);
            var idx = rnd.Next(config.WeightedLinks.Length);
            return config.WeightedLinks[idx];
        }

    }
}