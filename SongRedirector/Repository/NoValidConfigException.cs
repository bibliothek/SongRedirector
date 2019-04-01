using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongRedirector.Repository
{
    public class NoValidConfigException : Exception
    {
        public NoValidConfigException(string configName)
        {
            ConfigName = configName;
        }
        public string ConfigName { get; }

        public override string ToString()
        {
            return $"No valid config found with name: {ConfigName}";
        }
    }
}
