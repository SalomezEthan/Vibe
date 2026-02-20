using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Vibe.Core.Application.Models;
using Vibe.Core.Application.Services.Player;
using Vibe.WinUI.Composants.Common.Messages;

namespace Vibe.WinUI.Composants.Playlist.ViewModels
{
    internal sealed partial class PlaylistViewModel : ObservableObject
    {

        private string _name;
        private int _count;
        private readonly PlayerService _player;

        public PlaylistViewModel(
            PlaylistModel model,
            PlayerService playService
            )
        {
            _name = model.Name;
            _count = model.Count;
            _player = playService;

            Id = model.Id;
        }

        public Guid Id { get; }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }

        [RelayCommand]
        public async Task PlayPlaylistAsync()
        {
            try
            {
                await _player.PlayPlaylistAsync(Id);
                WeakReferenceMessenger.Default.Send(new PlaybackStateChangedMessage(true));
                WeakReferenceMessenger.Default.Send(new PlaybackChangedMessage());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
