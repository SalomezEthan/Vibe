using Vibe.Core.Application.Ports;
using Vibe.Core.Domain;

namespace Vibe.Core.Application.Services.PlayerServices
{
    public sealed class PlayerControlsService(Player player, IAudioService audio, IShuffleService shuffle)
    {
        public void Play() 
        {
            player.UpdatePlaybackState(PlaybackState.Playing);
            audio.Play();
        }

        public void Pause()
        {
            player.UpdatePlaybackState(PlaybackState.InPause);
            audio.Pause();
        }

        public void PlayNextSong()
        {
            player.Next();
            PlayCurrentSong();
        }

        public void PlayPreviousSong()
        {
            player.Previous();
            PlayCurrentSong();
        }

        public void ShufflePlaylist()
        {
            var shuffledSongs = shuffle.ShuffleSongs(player.Songs);
            player.UpdateSongQueue(shuffledSongs);
            PlayCurrentSong();
        }

        private void PlayCurrentSong()
        {
            player.UpdatePlaybackState(PlaybackState.Playing);
            audio.PlaySong(player.CurrentSong.Reference);
        }

        public void ChangeVolume(float volume)
        {
            player.UpdateVolume(volume);
            audio.ChangeVolume(volume);
        }

        public void ChangeRepeatModeState(PlaybackMode mode)
        {
            player.UpdateRepeatMode(mode);
        }
    }
}
