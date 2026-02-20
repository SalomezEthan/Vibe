using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Threading.Tasks;
using Vibe.Core.Application.Models;
using Vibe.Core.Application.Services.Player;
using Vibe.WinUI.Composants.Common.Messages;

namespace Vibe.WinUI.Composants.Song.ViewModels
{
    internal sealed partial class SongViewModel : ObservableObject
    {
        private string _title;
        private string _artist;
        private TimeSpan _duration;
        private readonly PlayerService _player;
        
        public SongViewModel(SongModel model, PlayerService player)
        {
            _title = model.Title;
            _artist = model.Artist;
            _duration = model.Duration;
            _player = player;

            Id = model.Id;
        }

        public Guid Id { get; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Artist
        {
            get => _artist;
            set => SetProperty(ref _artist, value);
        }

        public TimeSpan Duration
        {
            get => _duration;
            set => SetProperty(ref _duration, value);
        }

        [RelayCommand]
        public async Task PlaySongAsync()
        {
            try
            {
                await _player.PlaySongAsync(Id);
                WeakReferenceMessenger.Default.Send(new PlaybackStateChangedMessage(true));
                WeakReferenceMessenger.Default.Send(new PlaybackChangedMessage());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
