using SongRedirector.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongRedirector.Models
{
    public class LinkModel : SharedLayoutModel
    {
        public LinkModel(string configName, Link link)
        {
            ConfigName = configName;
            Link = link;
        }

        public LinkModel() { }

        public string ConfigName { get; set; }

        public Link Link { get; set; }
    }
}
