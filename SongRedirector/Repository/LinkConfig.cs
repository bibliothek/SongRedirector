using SongRedirector.Services;
using System.Collections.Generic;

namespace SongRedirector.Repository
{
    public class LinkConfig : ILinkConfig
    {

        public LinkConfig(Link[] links, string name)
        {
            Links = links;
            Name = name;
            WeightedLinks = GenerateWeightedLinks(links).ToArray();
        }

        public Link[] Links { get; private set; }
        public string Name { get; }
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
