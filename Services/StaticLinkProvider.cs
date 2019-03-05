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
        new Link("Shake it off", "https://www.youtube.com/watch?v=8XFBUM8dMqw", 10),
        new Link("Best song in the world","https://www.youtube.com/watch?v=_lK4cX5xGiQ",10),
        new Link("Killing in the name of","https://www.youtube.com/watch?v=B5NoXaSajq0",10),
        new Link("Rockstar","https://www.youtube.com/watch?v=DmeUuoxyt_E",10),
        new Link("Grilfirend","https://www.youtube.com/watch?v=Bg59q4puhmg",10),
        new Link("4 chord song","https://youtu.be/5pidokakU4I?t=58",10),
        new Link("Whats my age again","https://www.youtube.com/watch?v=JZioV5d3osg",10),
        new Link("Green Day Holiday","https://www.youtube.com/watch?v=A1OqtIqzScI",10),
        new Link("Ollas Leiwand","https://www.youtube.com/watch?v=hRilPLU-9-0&list=OLAK5uy_mR4JTyNcvSBqxf8TiGAbofn97bJjfZx4M&index=14",10),
        new Link("Wanabe","https://www.youtube.com/watch?v=gJLIiF15wjQ",10),
        new Link("Clap clap", "https://www.youtube.com/watch?v=NsWj6_AaNNE", 4)
    };

    private static List<Link> OrderedLinks { get; } = GenerateWeightedLinks();

    public string GetLink()
    {
        var idx = rnd.Next(OrderedLinks.Count);
        return OrderedLinks[idx].Uri;
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