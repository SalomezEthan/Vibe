using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Vibe.Core.Application.Services.Playlist;
using Vibe.WinUI.Composants.Playlist;
using Vibe.WinUI.Composants.Playlist.ViewModels;

namespace Vibe.WinUI.Composants.PlaylistLibrary.ViewModels
{
    internal sealed partial class PlaylistLibraryPageViewModel : ObservableObject
    {
        private ObservableCollection<PlaylistViewModel> _playlists = [];
        private PlaylistQueryService _queryService;
        private PlaylistImportService _importService;
        private PlaylistViewModelFactory _factory;

        public PlaylistLibraryPageViewModel(
            PlaylistQueryService queryService,
            PlaylistImportService importService,
            PlaylistViewModelFactory factory
            )
        {
            _queryService = queryService;
            _importService = importService;
            _factory = factory;
        }

        public ObservableCollection<PlaylistViewModel> Playlists
        {
            get => _playlists;
            set => SetProperty(ref _playlists, value);
        }

        [RelayCommand]
        public async Task CollectPlaylistsAsync()
        {
            var playlists = await _queryService.CollectAllAsync();
            var viewModels = playlists
                .AsParallel()
                .Select(_factory.Create);
        }

        [RelayCommand]
        public async Task ImportFoldersFromRootAsync(string reference)
        {
            await _importService.ImportFoldersFromRoot(reference);
            await CollectPlaylistsAsync();
        }

        [RelayCommand]
        public async Task ImportFolder(string folderReference)
        {
            await _importService.ImportFolder(folderReference);
            await CollectPlaylistsAsync();
        }
    }
}
