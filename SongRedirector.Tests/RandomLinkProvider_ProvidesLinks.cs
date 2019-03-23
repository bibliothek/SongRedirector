using System;
using Xunit;
using SongRedirector.Services;
using SongRedirector.Repository;

namespace SongRedirector.Tests
{
    public class RandomLinkProvider_ProvidesLinks
    {

        [Fact]
        public void RandomLinkProvider_WithConfig_FindsFile()
        {
            
            RandomLinkProvider fileLinkProvider = new RandomLinkProvider(new EmbeddedFileRepository());
            var result = fileLinkProvider.GetLink("nexoneers");

            Assert.NotNull(result);
        }
    }
}