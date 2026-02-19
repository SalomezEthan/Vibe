using Vibe.Core.Domain.Persistence;

namespace Vibe.Core.Tests.Domain.Persistence
{
    [TestClass]
    public sealed class PlaylistTests
    {
        [TestMethod]
        public void UpdateName_ShouldThrow_WhenNewNameIsEmpty()
        {
            PlaylistShouldThrow<ArgumentException>(playlist => playlist.UpdateName(string.Empty));
        }

        [TestMethod]
        public void UpdateName_ShouldThrow_WhenNewNameIsTooLong()
        {
            PlaylistShouldThrow<ArgumentOutOfRangeException>(playlist => playlist.UpdateName(new string('z', Playlist.MAX_NAME_LENGTH + 1)));
        }

        [TestMethod]
        public void AddSong_ShouldThrow_WhenNewSongIsAlreadyInPlaylist()
        {
            PlaylistShouldThrow<ArgumentException>(playlist =>
            {
                var songId = playlist.SongIds[0];
                playlist.AddSong(songId);
            });
        }

        [TestMethod]
        public void RemoveSong_ShouldThrow_WhenPlaylistDoesNotContainsSong()
        {
            PlaylistShouldThrow<ArgumentException>(playlist =>
            {
                var songId = Guid.NewGuid();
                playlist.RemoveSong(songId);
            });
        }

        private void PlaylistShouldThrow<T>(Action<Playlist> when)
        where T : Exception
        {
            var playlist = CreateTemplatePlaylist();
            Assert.ThrowsExactly<T>(() => when.Invoke(playlist));
        }

        private Playlist CreateTemplatePlaylist()
        {
            return new Playlist(
                new Guid(), 
                "Nom de la playlist",
                [Guid.NewGuid()]
                );
        }
    }
}
