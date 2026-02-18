using Vibe.Core.Domain.Persistence;

namespace Vibe.Core.Application.Ports.Persistence
{
    public interface IPlaylistRepository
    {
        Task<Playlist> GetById(Guid id);
        Task<IEnumerable<Playlist>> GetAllAsync();

        Task<IEnumerable<Song>> GetSongsInPlaylistAsync(Guid playlistId);

        Task AddAsync(Playlist playlist);
        Task UpdateAsync(Playlist playlist);
        Task DeleteAsync(Guid id);
    }
}
