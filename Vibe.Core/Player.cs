namespace Vibe.Core
{
    public enum PlaybackState
    {
        Playing,
        Paused,
        Stop
    }

    public sealed class Player
    {
        public Player()
        {
            PlaybackState = PlaybackState.Stop;
        }

        public PlaybackState PlaybackState { get; private set; }
        public Song? CurrentSong { get; private set; }

        public void LoadSong(Song song)
        {
            CurrentSong = song;
        }

        public void Play()
        {
            EnsureIsNotEmpty();
            PlaybackState = PlaybackState.Playing;
        }

        public void Pause()
        {
            EnsureIsNotEmpty();
            PlaybackState = PlaybackState.Paused;
        }

        public void EnsureIsNotEmpty()
        {
            if (CurrentSong is null)
            {
                throw new InvalidOperationException("Le lecteur ne peut changer de sons");
            }
        }
    }
}
