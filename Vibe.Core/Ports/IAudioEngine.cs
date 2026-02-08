namespace Vibe.Core.Ports
{
    public interface IAudioEngine
    {
        void LoadSong(string reference);
        void Play();
        void Pause();
    }
}
