using System;
using System.Collections.Generic;

public abstract class RandomLinkProvider : ILinkProvider
{

    protected abstract IEnumerable<Link> GetLinkList();

    private static List<Link> OrderedLinks { get; set; }

    public RandomLinkProvider()
    {
        OrderedLinks = GenerateWeightedLinks();
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