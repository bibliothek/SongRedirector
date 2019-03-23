namespace SongRedirector.Services
{
    public class Link
    {
        public string DisplayName { get; set; }

        public string Uri { get; set; }

        public int Probability { get; set; }

        public Link()
        {

        }
        public Link(string displayName, string uri, int probability = 1)
        {
            DisplayName = displayName;
            Uri = uri;
            Probability = probability;
        }
    }
}