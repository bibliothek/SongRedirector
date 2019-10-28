using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongRedirector.Models
{
    public class SharedLayoutModel
    {
        public SharedLayoutModel(IList<string> configNames)
        {
            ConfigNames = configNames;
        }

        public SharedLayoutModel() {}

        public IList<string> ConfigNames { get; set; }
    }
}
