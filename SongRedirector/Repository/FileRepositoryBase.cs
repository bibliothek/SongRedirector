using CsvHelper;
using SongRedirector.Models;
using SongRedirector.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SongRedirector.Repository
{
    public abstract class FileRepositoryBase : ILinkRepository
    {

        private Dictionary<string, ILinkConfig> cachedConfigs = new Dictionary<string, ILinkConfig>();

        public ILinkConfig GetConfig(string configName)
        {
            string configKey = string.IsNullOrEmpty(configName) ? "default" : configName;

            ILinkConfig config;

            if(cachedConfigs.TryGetValue(configKey, out config))
            {
                return config;
            }
            
            using (Stream resource = GetFileStream(configKey))
            {
                config = GetConfig(resource);
                cachedConfigs[configKey] = config;
                return config;
            }
        }

        protected abstract Stream GetFileStream(string configName);

        private ILinkConfig GetConfig(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException();
            }
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.Delimiter = ";";
                return new LinkConfig(csv.GetRecords<Link>().ToArray());
            }
        }

    }
}
