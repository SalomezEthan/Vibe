using Vibe.Core.Application.Ports.Persistence;

namespace Vibe.Core.Application.Services.PlaylistServices
{
    public sealed class PlaylistEditService(IPlaylistRepository repo)
    {
        public async Task RenameAsync(Guid playlistId, string newName)
        {
            var playlist = await repo.GetById(playlistId);
            playlist.UpdateName(newName);
            await repo.UpdateAsync(playlist);
        }

        public async Task AddSongAsync(Guid playlistId, Guid songId)
        {
            var playlist = await repo.GetById(playlistId);
            playlist.AddSong(songId);
            await repo.UpdateAsync(playlist);
        }

        public async Task RemoveSongAsync(Guid playlistId, Guid songId)
        {
            var playlist = await repo.GetById(playlistId);
            playlist.RemoveSong(songId);
            await repo.UpdateAsync(playlist);
        }
    }
}
