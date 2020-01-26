using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SongRedirector.Models
{
    public class Link : LinkEntity
    {
        public Link(int id, string displayName, string uri, int probability = 1) : base(id, displayName, uri, probability)
        {
        }

        public Link(LinkEntity link) : base(link.Id, link.DisplayName, link.Uri, link.Probability) { }

        private Match youtubeLinkMatches = null;
        private Match YoutubeLinkMatches
        {
            get
            {
                if (youtubeLinkMatches == null)
                {
                    var regex = @".*(youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=|\&v=)([^#\&\?]*)(?:(\?t|&start)=(\d+))?.*";
                    youtubeLinkMatches = Regex.Match(Uri, regex);
                }
                return youtubeLinkMatches;
            }
        }

        private string GetMatchGroup(int groupIndex)
        {
            var group = YoutubeLinkMatches.Groups[groupIndex];
            return group.Success ? group.Value : null;
        }

        public string YouTubeEmbedCode => GetMatchGroup(2);

        public string YouTubeStartTime => "start=" + GetMatchGroup(4);
    }
}
