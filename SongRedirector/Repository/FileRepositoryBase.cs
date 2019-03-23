using CsvHelper;
using SongRedirector.Models;
using SongRedirector.Services;
using System;
using System.IO;
using System.Linq;

namespace SongRedirector.Repository
{
    public abstract class FileRepositoryBase : ILinkRepository
    {
        public ILinkConfig GetConfig(string configName)
        {
            string configToUse = string.IsNullOrEmpty(configName) ? "default" : configName;
            
            using (Stream resource = GetFileStream(configToUse))
            {
                return GetLinks(resource);
            }
        }

        protected abstract Stream GetFileStream(string configName);

        private ILinkConfig GetLinks(Stream stream)
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
