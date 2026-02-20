using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Vibe.Core.Application.Services.Song;
using Vibe.WinUI.Composants.Song;
using Vibe.WinUI.Composants.Song.ViewModels;

namespace Vibe.WinUI.Composants
{
    internal sealed partial class SongLibraryViewModel : ObservableObject
    {
        private ObservableCollection<SongViewModel> _songs = [];
        private readonly SongQueryService _query;
        private readonly SongViewModelMap _songMap;

        public SongLibraryViewModel(SongQueryService query, SongViewModelMap map)
        {
            _query = query;
            _songMap = map;
        }

        public ObservableCollection<SongViewModel> Songs
        {
            get => _songs;
            set => SetProperty(ref _songs, value);
        }

        [RelayCommand]
        public async Task LoadSongsAsync()
        {
            var songs = await _query.CollectAllSongsAsync();
            var songViewModels = songs
                .AsParallel()
                .Select(_songMap.GetOrCreate);

            Songs = [.. songViewModels];
        }
    }
}
