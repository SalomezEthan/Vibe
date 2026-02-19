using Vibe.Core.Domain;
using Vibe.Core.Domain.Persistence;

namespace Vibe.Core.Tests.Domain
{
    [TestClass]
    public sealed class PlayerTests
    {
        [TestMethod]
        public void UpdateSongQueue_ShouldThrow_WhenNewSongQueueIsEmpty()
        {
            PlayerShouldThrow<ArgumentException>(player => player.UpdateSongQueue([]));
        }

        [TestMethod]
        public void UpdatePlaybackState_ShouldThrow_WhenSongQueueIsEmpty()
        {
            PlayerShouldThrow<InvalidOperationException>(player => player.UpdatePlaybackState(PlaybackState.Playing));
        }

        [TestMethod]
        public void Next_ShouldThrow_WhenSongQueueIsEmpty()
        {
            PlayerShouldThrow<InvalidOperationException>(player => player.Next());
        }

        [TestMethod]
        public void Next_ShouldThrow_WhenIsLastSongWithoutRepeatMode()
        {
            PlayerShouldThrow<InvalidOperationException>(player =>
            {
                var song = CreateTemplateSong();
                player.UpdateSongQueue([song]);
                player.Next();
            });
        }

        [TestMethod]
        public void Next_ShouldPushInHistory()
        {
            PlayerWithSongsShould(player =>
            {
                var songA = player.Songs[0];

                player.Next();
                Assert.Contains(songA, player.History);
            });
            
        }

        [TestMethod]
        public void Previous_ShouldThrow_WhenSongQueueIsEmpty()
        {
            PlayerShouldThrow<InvalidOperationException>(player => player.Previous());
        }

        [TestMethod]
        public void Previous_ShouldThrow_WhenPlayerHasNotHistory()
        {
            PlayerShouldThrow<InvalidOperationException>(player =>
            {
                var song = CreateTemplateSong();
                player.UpdateSongQueue([song]);
                player.Previous();
            });
        }

        [TestMethod]
        public void MoveToSongById_ShouldThrow_WhenSongQueueIsEmpty()
        {
            PlayerShouldThrow<InvalidOperationException>(player => player.MoveToSongById(Guid.NewGuid()));
        }

        [TestMethod]
        public void MoveToSongById_ShouldThrow_WhenPlayerHasNotSong()
        {
            PlayerShouldThrow<ArgumentException>(player =>
            {
                var song = CreateTemplateSong();
                player.UpdateSongQueue([song]);
                player.MoveToSongById(Guid.NewGuid());
            });
        }

        [TestMethod]
        public void MoveToSongById_ShouldPushInHistory()
        {
            PlayerWithSongsShould(player =>
            {
                var songA = player.Songs[0];
                var songB = player.Songs[1];

                player.MoveToSongById(songB.Id);
                Assert.Contains(songA, player.History);
            });
        }

        [TestMethod]
        public void UpdateVolume_ShouldThrow_WhenVolumeIsNotBetween0And1()
        {
            PlayerShouldThrow<ArgumentOutOfRangeException>(player => player.UpdateVolume(100));
        }

        [TestMethod]
        public void ClearPlayer_ShouldClearQueueAndHistory()
        {
            PlayerWithSongsShould(player =>
            {
                var song = player.Songs[0];

                player.Next();
                Assert.Contains(song, player.Songs);
                Assert.Contains(song, player.History);

                player.ClearPlayer();
                Assert.DoesNotContain(song, player.Songs);
                Assert.DoesNotContain(song, player.History);
            });

            
        }

        private void PlayerShouldThrow<T>(Action<Player> when)
        where T : Exception
        {
            var player = new Player();
            Assert.ThrowsExactly<T>(() => when.Invoke(player));
        }

        private void PlayerWithSongsShould(Action<Player> action)
        {
            var player = new Player();
            var songA = CreateTemplateSong();
            var songB = CreateTemplateSong();
            player.UpdateSongQueue([songA, songB]);

            action.Invoke(player);
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
