namespace Vibe.Core.Ports
{
    public interface IAudioEngine
    {
        void PlaySong(string reference);
        void Play();
        void Pause();
        void Stop();
    }
}
