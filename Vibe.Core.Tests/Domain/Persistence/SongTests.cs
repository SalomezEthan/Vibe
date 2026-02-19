using Vibe.Core.Domain.Persistence;

namespace Vibe.Core.Tests.Domain.Persistence
{
    [TestClass]
    public sealed class SongTests
    {
        [TestMethod]
        public void UpdateTitle_ShouldThrow_WhenNewTitleIsEmpty()
        {
            SongShouldThrow<ArgumentException>(song => song.UpdateTitle(string.Empty));
        }

        [TestMethod]
        public void UpdateTitle_ShouldThrow_WhenNewTitleIsTooLong()
        {
            SongShouldThrow<ArgumentOutOfRangeException>(song => song.UpdateTitle(new string('z', Song.MAX_TITLE_LENGTH+1)));
        }

        [TestMethod]
        public void UpdateArtist_ShouldThrow_WhenArtistNameIsTooLong()
        {
            SongShouldThrow<ArgumentOutOfRangeException>(song => song.UpdateArtist(new string('a', Song.MAX_ARTIST_NAME_LENGTH + 1)));
        }

        [TestMethod]
        public void UpdateArtist_ShouldThrow_WhenNewDurationIsZero()
        {
            SongShouldThrow<ArgumentException>(song => song.UpdateDuration(TimeSpan.Zero));
        }

        [TestMethod]
        public void UpdateArtist_ShouldThrowWhenNewReferenceIsEmpty()
        {
            SongShouldThrow<ArgumentException>(song => song.UpdateReference(string.Empty));
        }

        private void SongShouldThrow<T>(Action<Song> when)
        where T : Exception
        {
            var song = CreateTemplateSong();
            Assert.ThrowsExactly<T>(() => when.Invoke(song));
        }

        private Song CreateTemplateSong()
        {
            return new Song(
                "Titre",
                "Artiste",
                TimeSpan.FromMinutes(2),
                "Reference"
                );
        }
    }
}
