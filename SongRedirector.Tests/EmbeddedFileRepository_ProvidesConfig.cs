using SongRedirector.Repository;
using SongRedirector.Services;
using System;
using Xunit;

namespace SongRedirector.Tests
{
    public class EmbeddedFileRepository_ProvidesConfig
    {

        [Fact]
        public void EmbeddedFileRepository_WithConfigName_ProvidesConfig()
        {
            EmbeddedFileRepository repo = new EmbeddedFileRepository();

            var config = repo.GetConfig("nexoneers");

            Assert.NotNull(config);
        }

        [Fact]
        public void EmbeddedFileRepository_WithoutConfigName_ProvidesConfig()
        {
            EmbeddedFileRepository repo = new EmbeddedFileRepository();

            Assert.Throws<ArgumentNullException>(() => repo.GetConfig(""));

        }
    }
}