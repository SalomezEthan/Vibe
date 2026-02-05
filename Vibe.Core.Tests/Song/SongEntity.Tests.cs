using Vibe.Core.Song;
using Vibe.Core.Song.ValueObjects;

namespace Vibe.Core.Tests.Song
{
    [TestClass]
    public sealed class SongEntityTests
    {
        private SongEntity CreateTemplateEntity()
        {
            return new SongEntity(
                new Guid(),
                new SongName("Hello World :"),
                [Guid.NewGuid()],
                new SongDuration(TimeSpan.FromSeconds(30))
                );
        }

        [TestMethod]
        public void AddPerformer_ShouldThrow_WhenSongPerformersAlreadyContainsPerformer()
        {
            var song = CreateTemplateEntity();
            Guid duplicatedId = song.Performers[0];
            Assert.ThrowsExactly<ArgumentException>(() => song.AddPerformer(duplicatedId));
        }

        [TestMethod]
        public void RemovePerformer_ShouldThrow_WhenSongPerformersHasNotPerformer()
        {
            var song = CreateTemplateEntity();
            Guid randomId = Guid.NewGuid();
            Assert.ThrowsExactly<ArgumentException>(() => song.RemovePerformer(randomId));
        }
    }
}
