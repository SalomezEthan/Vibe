using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Vibe.Core.Application.Services.Player;
using Vibe.Core.Application.Services.Playlist;
using Vibe.WinUI.Composants.Song;
using Vibe.WinUI.Composants.Song.ViewModels;

namespace Vibe.WinUI.Composants.Playlist.ViewModels
{
    internal sealed partial class PlaylistPageViewModel : ObservableObject
    {
        private readonly PlaylistViewModel _playlist;
        private readonly PlaylistQueryService _queryService;
        private readonly PlayerService _playerService;
        private readonly SongViewModelMap _songMap;
        private ObservableCollection<SongViewModel> _songs;

        public PlaylistPageViewModel(
            PlaylistViewModel playlist,
            PlaylistQueryService queryService, 
            PlayerService playerService,
            SongViewModelMap songMap
            )
        {
            _playlist = playlist;
            _queryService = queryService;
            _playerService = playerService;
            _songMap = songMap;
            _songs = [];
        }

        public PlaylistViewModel Playlist => _playlist;

        public ObservableCollection<SongViewModel> Songs
        {
            get => _songs;
            set => SetProperty(ref _songs, value);
        }

        [RelayCommand]
        public async Task LoadSongsAsync()
        {
            try
            {
                var songs = await _queryService.CollectSongsInPlaylist(_playlist.Id);
                var songViewModels = songs
                    .AsParallel()
                    .Select(_songMap.GetOrCreate);

                Songs = [.. songViewModels];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
