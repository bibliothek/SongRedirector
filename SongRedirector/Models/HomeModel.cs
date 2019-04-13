using SongRedirector.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongRedirector.Models
{
    public class HomeModel
    {
        public Link Link { get; set; }

        public string ConfigName { get; set; }

        public string GetTitle()
        {
            return Link.DisplayName;
        }

        public string GetEmbedLink()
        {
            return $"https://www.youtube.com/embed/{Link.GetYouTubeEmbedCode()}?rel=0&autoplay=1";
        }
        
    }
}
