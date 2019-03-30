using System.IO;

namespace SongRedirector.Repository
{
    public class EmbeddedFileRepository : FileRepositoryBase
    {
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
