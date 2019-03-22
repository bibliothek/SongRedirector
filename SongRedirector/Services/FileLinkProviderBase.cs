using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
namespace SongRedirector.Services
{
    public abstract class FileLinkProviderBase : RandomLinkProvider
    {
        public string FileName { get; private set; }
        protected FileLinkProviderBase(string configName)
        {
            FileName = configName + ".songs";
        }
        protected override IEnumerable<Link> GetLinkList()
        {
            using (Stream resource = GetFileStream())
            {
                return GetLinks(resource);
            }

        }

        protected abstract Stream GetFileStream();

        private IEnumerable<Link> GetLinks(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException();
            }
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.Delimiter = ";";
                return csv.GetRecords<Link>().ToArray();
            }
        }

    }
}