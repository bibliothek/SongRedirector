using SongRedirector.Services;
using System.Collections.Generic;

namespace SongRedirector.Models
{
    public class LinkConfig : ILinkConfig
    {

        public LinkConfig(Link[] links)
        {
            Links = links;
            WeightedLinks = GenerateWeightedLinks(links).ToArray();
        }

        public Link[] Links { get; private set; }

        public Link[] WeightedLinks { get; private set; }

        private List<Link> GenerateWeightedLinks(Link[] links)
        {
            var weightedLinks = new List<Link>();

            foreach (var link in links)
                for (var i = 0; i < link.Probability; i++)
                    weightedLinks.Add(link);

            return weightedLinks;
        }
    }
}
