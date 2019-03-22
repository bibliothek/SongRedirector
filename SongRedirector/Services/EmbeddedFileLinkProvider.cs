using System.IO;
namespace SongRedirector.Services
{
    public class EmbeddedFileLinkProvider : FileLinkProviderBase
    {
        public EmbeddedFileLinkProvider(string configName) : base(configName) { }

        protected override Stream GetFileStream()
        {
            var assembly = typeof(TenantConfigResolver).Assembly;
            string filePath = "SongRedirector.songs." + FileName;
            return assembly.GetManifestResourceStream(filePath);
        }
    }
}