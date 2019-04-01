using Microsoft.AspNetCore.Mvc;

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
    }
}