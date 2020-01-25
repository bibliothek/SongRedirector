using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace SongRedirector.Models
{
    public class LinkEntity
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string Uri { get; set; }

        public int Probability { get; set; }

        public LinkEntity() { }

        public LinkEntity(int id, string displayName, string uri, int probability = 1)
        {
            Id = id;
            DisplayName = displayName;
            Uri = uri;
            Probability = probability;
        }

    }
}