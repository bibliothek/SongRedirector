using SongRedirector.Repository;
using System;
using Xunit;

namespace SongRedirector.Tests
{
    public class Link_YoutubeParts {

        [Fact]
        public void Link_FullLink_EmbedCodeCanBeExtracted() {
            Link l = new Link(1, "name", "https://www.youtube.com/watch?v=X2W3aG8uizA");
            var embedCode = l.GetYouTubeEmbedCode();

            Assert.Equal("X2W3aG8uizA", embedCode);
        }

        [Fact]
        public void Link_FullLinkWithStart_EmbedCodeCanBeExtracted() {
            Link l = new Link(1, "name", "https://www.youtube.com/watch?v=X2W3aG8uizA&start=20");
            var embedCode = l.GetYouTubeEmbedCode();

            Assert.Equal("X2W3aG8uizA", embedCode);
        }

        [Fact]
        public void Link_ShortLink_EmbedCodeCanBeExtracted() {
            Link l = new Link(1, "name", "https://youtu.be/Rbo9VslSGuU");
            var embedCode = l.GetYouTubeEmbedCode();

            Assert.Equal("Rbo9VslSGuU", embedCode);
        }

        [Fact]
        public void Link_ShortLinkWithStart_EmbedCodeCanBeExtracted() {
            Link l = new Link(1, "name", "https://youtu.be/uHFJ9qhR0VM?t=50");
            var embedCode = l.GetYouTubeEmbedCode();

            Assert.Equal("uHFJ9qhR0VM", embedCode);
        }

        [Fact]
        public void Link_FullLinkNoStart_StartCannotBeExtracted() {
            Link l = new Link(1, "name", "https://www.youtube.com/watch?v=X2W3aG8uizA");
            var start = l.GetYouTubeStartTime();

            Assert.Equal("start=", start);
        }

        [Fact]
        public void Link_FullLinkWithStart_StartCanBeExtracted() {
            Link l = new Link(1, "name", "https://www.youtube.com/watch?v=X2W3aG8uizA&start=20");
            var start = l.GetYouTubeStartTime();

            Assert.Equal("start=20", start);
        }

        [Fact]
        public void Link_ShortLinkNoStart_StartCannotBeExtracted() {
            Link l = new Link(1, "name", "https://youtu.be/Rbo9VslSGuU");
            var start = l.GetYouTubeStartTime();

            Assert.Equal("start=", start);
        }

        [Fact]
        public void Link_ShortLinkWithStart_StartCanBeExtracted() {
            Link l = new Link(1, "name", "https://youtu.be/uHFJ9qhR0VM?t=50");
            var start = l.GetYouTubeStartTime();

            Assert.Equal("start=50", start);
        }
    }
}