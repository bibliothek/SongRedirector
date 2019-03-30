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

        public void Delete(string config, int id)
        {
            DeleteInternal(config, id);
            cachedConfigs.Remove(config);
        }

        public ILinkConfig GetConfig(string configName)
        {
            string configKey = string.IsNullOrEmpty(configName) ? "default" : configName;

            ILinkConfig config;

            if (cachedConfigs.TryGetValue(configKey, out config))
            {
                return config;
            }

            using (Stream resource = GetFileStream(configKey))
            {
                config = GetConfig(resource, configKey);
                cachedConfigs[configKey] = config;
                return config;
            }
        }

        protected abstract void DeleteInternal(string config, int id);

        public Link GetLink(string configName, int id)
        {
            var config = GetConfig(configName);
            return config.Links.FirstOrDefault(x => x.Id == id);
        }

        protected abstract Stream GetFileStream(string configName);

        private ILinkConfig GetConfig(Stream stream, string configName)
        {
            if (stream == null)
            {
                throw new ArgumentNullException();
            }
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.Delimiter = ";";
                return new LinkConfig(csv.GetRecords<Link>().ToArray(), configName);
            }
        }

        public void Save(string configName, Link link)
        {
            var config = GetConfig(configName);
            if (link.Id == 0)
            {
                link.Id = config.GetNewId();
            }
            var newLinks = config.Links.Where(x => x.Id != link.Id).Append(link).ToArray();
            var newConfig = new LinkConfig(newLinks, configName);
            SaveInternal(configName, newConfig);
            cachedConfigs.Remove(configName);
        }

        internal abstract void SaveInternal(string configName, ILinkConfig config);
    }
}
