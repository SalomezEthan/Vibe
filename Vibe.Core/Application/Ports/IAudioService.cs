namespace Vibe.Core.Application.Ports
{
    public interface IAudioService
    {
        void PlaySong(string reference);
        void Play();
        void Pause();

        void ChangeVolume(float volume);
    }
}
