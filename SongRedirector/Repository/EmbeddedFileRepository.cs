using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SongRedirector.Repository
{
    public class EmbeddedFileRepository : FileRepositoryBase
    {
        public override IList<string> GetConfigNames()
        {
            var assembly = typeof(EmbeddedFileRepository).Assembly;
            var files = assembly.GetManifestResourceNames();
            const string configNameRegex = @"^SongRedirector\.songs\.(.+)\.songs$";
            var names = files.Select(x => Regex.Match(x, configNameRegex).Groups[1].Value).ToList();
            return names;
        }

        protected override void DeleteInternal(string config, int id)
        {
            // do nothing
        }

        protected override Stream GetFileStream(string configName)
        {
            var assembly = typeof(EmbeddedFileRepository).Assembly;
            string filePath = "SongRedirector.songs." + configName + ".songs";
            return assembly.GetManifestResourceStream(filePath);
        }

        internal override void SaveInternal(string configName, ILinkConfig link)
        {
            // do nothing
        }
    }
}
