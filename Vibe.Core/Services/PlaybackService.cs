using Vibe.Core.Entities;
using Vibe.Core.Ports;

namespace Vibe.Core.Services
{
    public sealed class PlaybackService(Player player, IAudioEngine audio, ISongCollectionRepository repo)
    {
        PlaybackQueue queue = new();

        public void Play()
        {
            player.Play();
            audio.Play();
        }

        public void Pause()
        {
            player.Pause();
            audio.Pause();
        }

        public async Task PlaySongCollection(Guid songCollectionId)
        {
            player.Stop();
            audio.Stop();

            var songCollection = await repo.GetById(songCollectionId);
            queue = new PlaybackQueue(songCollection.Songs);

            player.LoadSong(queue.CurrentSong);
            player.Play();

            audio.PlaySong(queue.CurrentSong.Reference);
        }

        public void NextSong()
        {
            queue.Next();
            player.LoadSong(queue.CurrentSong);
            player.Play();

            audio.PlaySong(queue.CurrentSong.Reference);
        }
    }
}
