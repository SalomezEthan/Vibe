using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Diagnostics;
using Vibe.Core.Application.Services.Player;
using Vibe.WinUI.Composants.Common.Messages;
using Vibe.WinUI.Composants.Song;
using Vibe.WinUI.Composants.Song.ViewModels;

// Todo : réparer l'oublie de la remise en été d'une liste shuffle
// Todo : créer des messages et recipients plus propres.

namespace Vibe.WinUI.Composants.Player.ViewModels
{
    internal sealed partial class PlayerViewModel 
    : ObservableObject, 
      IRecipient<PlaybackStateChangedMessage>,
      IRecipient<PlaybackChangedMessage>
    {
        private bool _isPlaying = false;
        private bool _isShuffled = false;
        private bool _isInRepatMode = false;
        private SongViewModel? _currentSong;
        private float _volume = 1f;

        private readonly PlayerControlsService _controls;
        private readonly PlayerQueryService _query;
        private readonly SongViewModelMap _songMap;

        public PlayerViewModel(
            PlayerControlsService controls,
            PlayerQueryService query,
            SongViewModelMap songMap
            )
        {
            _controls = controls;
            _query = query;
            _songMap = songMap;

            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        public bool IsPlaying
        {
            get => _isPlaying;
            set => SetProperty(ref _isPlaying, value);
        }

        public bool IsShuffled
        {
            get => _isShuffled;
            set => SetProperty(ref _isShuffled, value);
        }

        public bool IsInRepeatMode
        {
            get => _isInRepatMode;
            set => SetProperty(ref _isInRepatMode, value);
        }

        public SongViewModel? CurrentSong
        {
            get => _currentSong;
            set => SetProperty(ref _currentSong, value);
        }

        public float Volume
        {
            get => _volume;
            set
            {
                SetProperty(ref _volume, value);
                ChangeVolume(value);
            }
        }

        [RelayCommand]
        public void TogglePlayPause()
        {
            try
            {
                if (IsPlaying)
                {
                    _controls.Pause();
                }
                else
                {
                    _controls.Play();
                }

                IsPlaying = !IsPlaying;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        [RelayCommand]
        public void PlayNext()
        {
            try
            {
                _controls.PlayNextSong();
                UpdateCurrentSong();
                IsPlaying = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        [RelayCommand]
        public void PlayPrevious()
        {
            try
            {
                _controls.PlayPreviousSong();
                UpdateCurrentSong();
                IsPlaying = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void UpdateCurrentSong()
        {
            var song = _query.GetCurrentSong();
            CurrentSong = _songMap.GetOrCreate(song);
        }

        [RelayCommand]
        public void ChangeVolume(float value)
        {
            try
            {
                _controls.ChangeVolume(value);
                Volume = value;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void Receive(PlaybackStateChangedMessage message)
        {
            IsPlaying = message.Value;
        }

        public void Receive(PlaybackChangedMessage message)
        {
            UpdateCurrentSong();
        }
    }
}
