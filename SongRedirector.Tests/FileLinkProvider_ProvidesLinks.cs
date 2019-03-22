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
            FileLinkProvider fileLinkProvider = new FileLinkProvider("Nexoneers.songs");
            var result = fileLinkProvider.GetLink();

            Assert.NotNull(result);
        }
    }
}