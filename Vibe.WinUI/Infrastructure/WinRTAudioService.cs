using Vibe.Core.Application.Ports;
using Windows.Media.Playback;
using Windows.Media.Core;
using System;

namespace Vibe.WinUI.Infrastructure
{
    internal sealed class WinRTAudioService : IAudioService
    {
        private readonly MediaPlayer _audio = new();

        public void ChangeVolume(float volume)
        {
            _audio.Volume = volume;
        }

        public void Pause()
        {
            _audio.Pause();
        }

        public void Play()
        {
            _audio.Play();
        }

        public void PlaySong(string reference)
        {
            var uri = new Uri(reference);
            _audio.SetUriSource(uri);
            _audio.Play();
        }
    }
}
