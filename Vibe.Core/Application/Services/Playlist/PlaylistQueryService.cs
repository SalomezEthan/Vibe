using Vibe.Core.Application.Models;
using Vibe.Core.Application.Ports.Persistence;

namespace Vibe.Core.Application.Services.Playlist
{
    public sealed class PlaylistQueryService(IPlaylistRepository repo)
    {
        public async Task<IEnumerable<PlaylistModel>> CollectAllAsync()
        {
            var playlists = await repo.GetAllAsync();
            return playlists.Select(PlaylistModel.FromEntity);
        }

        public async Task<IEnumerable<SongModel>> CollectSongsInPlaylist(Guid playlistId)
        {
            var songs = await repo.GetSongsInPlaylistAsync(playlistId);
            return songs.Select(SongModel.FromEntity);
        }
    }
}
