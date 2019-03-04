using System;
using System.Collections.Generic;

public class StaticLinkProvider : ILinkProvider
{
    private static readonly Random rnd = new Random();

    private static readonly Link[] links =
    {
        new Link("Spongebob", "https://www.youtube.com/watch?v=r9L4AseD-aA", 10),
        new Link("Eskalation", "https://www.youtube.com/watch?v=J10LaIqHj2s", 10),
        new Link("My Little Pony", "https://www.youtube.com/watch?v=GHy0xktlsSI", 10),
        new Link("Eternity Frog", "https://soundcloud.com/eternityfrog/her-face-1/s-kGyZs", 10),
        new Link("Bob Marley", "https://www.youtube.com/watch?v=X2W3aG8uizA", 10),
        new Link("Tool Time", "https://www.youtube.com/watch?v=Ejz_1qoE7hc", 10),
        new Link("Urlaub fürs Gehirn", "https://www.youtube.com/watch?v=HforN-mMMsE", 10),
        new Link("Cocain", "https://www.youtube.com/watch?v=zVOuRQPPdoo", 10),
        new Link("In Hell I'll Be In Good Company", "https://www.youtube.com/watch?v=B9FzVhw8_bY", 10),
        new Link("The Tropper", "https://www.youtube.com/watch?v=Li58voy6xXM", 10),
        new Link("Rick Rolled", "https://www.youtube.com/watch?v=dQw4w9WgXcQ", 1),
        new Link("Whisky in the Jar", "https://www.youtube.com/watch?v=wsrvmNtWU4E", 10),
        new Link("Mama Lauda", "https://www.youtube.com/watch?v=vloUhu7QxmU", 10),
        new Link("Castle on the hill", "https://www.youtube.com/watch?v=Ytb7J0ciBcE", 10),
        new Link("Shake it off", "https://www.youtube.com/watch?v=8XFBUM8dMqw", 10)
    };

    private static List<Link> OrderedLinks { get; } = GenerateWeightedLinks();

    public string GetLink()
    {
        var idx = rnd.Next(OrderedLinks.Count);
        return links[idx].Uri;
    }

    private static List<Link> GenerateWeightedLinks()
    {
        var weightedLinks = new List<Link>();

        foreach (var link in links)
            for (var i = 0; i < link.Probability; i++)
                weightedLinks.Add(link);

        return weightedLinks;
    }
}