using System;
using System.Collections.Generic;
namespace SongRedirector.Services
{
    public abstract class RandomLinkProvider : ILinkProvider
    {

        protected abstract IEnumerable<Link> GetLinkList();

        private List<Link> orderedLinks;

        private List<Link> OrderedLinks
        {
            get
            {
                if (orderedLinks == null)
                {
                    orderedLinks = GenerateWeightedLinks();
                }
                return orderedLinks;
            }
        }

        private static readonly Random rnd = new Random(Guid.NewGuid().GetHashCode());

        public string GetLink()
        {
            var idx = rnd.Next(OrderedLinks.Count);
            return OrderedLinks[idx].Uri;
        }

        private List<Link> GenerateWeightedLinks()
        {
            var weightedLinks = new List<Link>();

            foreach (var link in GetLinkList())
                for (var i = 0; i < link.Probability; i++)
                    weightedLinks.Add(link);

            return weightedLinks;
        }
    }
}