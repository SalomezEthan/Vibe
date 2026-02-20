using Vibe.Core.Application.Models;
using Vibe.Core.Application.Services.Player;
using Vibe.Core.Application.Services.Song;
using Vibe.WinUI.Composants.Song.ViewModels;

namespace Vibe.WinUI.Composants.Song
{
    internal sealed class SongViewModelFactory(
        SongEditService edit,
        PlayerService player
        )
    {
        public SongEditViewModel CreateEdit(SongModel model)
        {
            var songVM = Create(model);
            return new SongEditViewModel(songVM, edit);
        }

        public SongViewModel Create(SongModel model)
        {
            return new SongViewModel(model, player);
        }
    }
}
