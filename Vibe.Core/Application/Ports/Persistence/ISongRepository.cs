using Vibe.Core.Domain.Persistence;

namespace Vibe.Core.Application.Ports.Persistence
{
    public interface ISongRepository
    {
        Task<Song> GetByIdAsync(Guid id);
        Task<IEnumerable<Song>> GetFromArtistAsync(string artist);
        Task<IEnumerable<Song>> GetFromCharsInTitle(string chars);
        Task<IEnumerable<Song>> GetAllAsync();

        Task AddAsync(Song song);
        Task UpdateAsync(Song song);
        Task DeleteAsync(Guid id);
    }
}
