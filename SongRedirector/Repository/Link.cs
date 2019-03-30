namespace SongRedirector.Repository
{
    public class Link
    {
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
    }
}