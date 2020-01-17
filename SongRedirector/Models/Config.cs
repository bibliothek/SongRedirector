using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongRedirector.Models
{
    public class Config
    {
        public string Name { get; set; }

        public IList<Link> Links { get; set; }
    }
}
