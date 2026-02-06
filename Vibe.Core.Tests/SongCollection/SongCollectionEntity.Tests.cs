using Vibe.Core.SongCollection;
using Vibe.Core.SongCollection.ValueObjects;

namespace Vibe.Core.Tests.SongCollection
{
    [TestClass]
    public sealed class SongCollectionEntityTests
    {
        private SongCollectionEntity CreateSongCollectionEntityTemplate()
        {
            return new SongCollectionEntity(
                new Guid(),
                new SongCollectionName("Ma collection"),
                [Guid.NewGuid()]
                );
        }

        [TestMethod]
        public void AddSong_ShouldThrow_WhenSongCollectionAlreadyContainsSong()
        {
            SongCollectionEntity songCollection = CreateSongCollectionEntityTemplate();
            Guid duplicatedSong = songCollection.SongIds[0];
            Assert.ThrowsExactly<ArgumentException>(() => songCollection.AddSong(duplicatedSong));
        }

        [TestMethod]
        public void RemoveSong_ShouldThrow_WhenSongCollectionNotContainsSong()
        {
            SongCollectionEntity songCollection = CreateSongCollectionEntityTemplate();
            Guid randomId = Guid.NewGuid();
            Assert.ThrowsExactly<ArgumentException>(() => songCollection.RemoveSong(randomId));
        }
    }
}
