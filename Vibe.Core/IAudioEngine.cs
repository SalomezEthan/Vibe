namespace Vibe.Core
{
    public interface IAudioEngine
    {
        void LoadSong(string reference);
        void Play();
        void Pause();
    }
}
