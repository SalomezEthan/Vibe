using Vibe.Core.Application.Models;
using Vibe.Core.Application.Services.Player;
using Vibe.Core.Application.Services.Playlist;
using Vibe.WinUI.Composants.Playlist.ViewModels;
using Vibe.WinUI.Composants.Song;

namespace Vibe.WinUI.Composants.Playlist
{
    internal sealed class PlaylistViewModelFactory(
         PlaylistQueryService queryService,
         PlayerService playerService,
         SongViewModelMap songMap
        )
    {
        public PlaylistPageViewModel CreatePage(PlaylistModel model)
        {
            var playlistVM = Create(model);
            return new PlaylistPageViewModel(playlistVM, queryService, playerService, songMap);
        }

        public PlaylistViewModel Create(PlaylistModel model)
        {
            return new PlaylistViewModel(model, playerService);
        }
    }
}
