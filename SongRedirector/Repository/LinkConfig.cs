using SongRedirector.Models;
using SongRedirector.Services;
using System.Collections.Generic;
using System.Linq;

namespace SongRedirector.Repository
{
    public class LinkConfig : ILinkConfig
    {

        public LinkConfig(LinkEntity[] links, string name)
        {
            Links = links;
            Name = name;
            WeightedLinks = GenerateWeightedLinks(links).ToArray();
        }

        public LinkEntity[] Links { get; private set; }
        public string Name { get; }
        public LinkEntity[] WeightedLinks { get; private set; }

        public int GetNewId()
        {
            return Links.Max(x=>x.Id) + 1;
        }

        private List<LinkEntity> GenerateWeightedLinks(LinkEntity[] links)
        {
            var weightedLinks = new List<LinkEntity>();

            foreach (var link in links)
                for (var i = 0; i < link.Probability; i++)
                    weightedLinks.Add(link);

            return weightedLinks;
        }
    }
}
