using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace SongRedirector.Repository
{
    public class Link
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string Uri { get; set; }

        public int Probability { get; set; }

        public Link()
        {

        }
        public Link(int id, string displayName, string uri, int probability = 1)
        {
            Id = id;
            DisplayName = displayName;
            Uri = uri;
            Probability = probability;
        }

        private Match youtubeLinkMatches = null;
        private Match YoutubeLinkMatches {
            get {
                if (youtubeLinkMatches == null) {
                    var regex = @".*(youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=|\&v=)([^#\&\?]*)(?:(\?t|&start)=(\d+))?.*";
                    youtubeLinkMatches = Regex.Match(Uri, regex);
                }
                return youtubeLinkMatches;
            }
        }

        private string GetMatchGroup(int groupIndex) {
            var group = YoutubeLinkMatches.Groups[groupIndex];
            return group.Success ? group.Value : null;
        }

        public string GetYouTubeEmbedCode() {
            return GetMatchGroup(2);
        }

        public string GetYouTubeStartTime() {
            return "start=" + GetMatchGroup(4);
        }
    }
}