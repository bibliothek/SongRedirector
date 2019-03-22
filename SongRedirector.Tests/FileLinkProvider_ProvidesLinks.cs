using System;
using Xunit;
using SongRedirector.Services;

namespace SongRedirector.Tests
{
    public class FileLinkProvider_ProvidesLinks
    {

        [Fact]
        public void FileLinkProvider_FindsFile()
        {
            FileLinkProviderBase fileLinkProvider = new EmbeddedFileLinkProvider("nexoneers");
            var result = fileLinkProvider.GetLink();

            Assert.NotNull(result);
        }
    }
}