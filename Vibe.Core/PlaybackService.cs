using System.Threading.Tasks;

namespace Vibe.Core
{
    public sealed class PlaybackService(Player player, IAudioEngine audio, ISongRepository repo)
    {
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

        public async Task PlaySongAsync(Guid songId)
        {
            var song = await repo.GetSongByIdAsync(songId);
            
            player.LoadSong(song);
            audio.LoadSong(song.Reference);
            
            player.Play();
            audio.Play();
        }
    }
}
