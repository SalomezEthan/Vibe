namespace Vibe.Core
{
    public interface ISongRepository
    {
        Task<Song> GetSongByIdAsync(Guid id);
        Task<Song> UpdateAsync(Song song);
    }
}
