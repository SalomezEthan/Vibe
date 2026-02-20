using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Vibe.Core.Application.Services.Song;

namespace Vibe.WinUI.Composants.Song.ViewModels
{
    internal sealed partial class SongEditViewModel : ObservableObject
    {
        private readonly SongViewModel _song;
        private readonly SongEditService _editService;

        public SongEditViewModel(SongViewModel song, SongEditService editService)
        {
            _song = song;
            _editService = editService;
        }

        [RelayCommand]
        public async Task Rename(string newName)
        {
            try
            {
                await _editService.RenameSongAsync(_song.Id, newName);
                _song.Title = newName;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
