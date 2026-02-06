namespace Vibe.Core.SongCollection.Ports
{
    public interface ISongCollectionRepository
    {
        Task<SongCollectionEntity> GetByIdAsync(Guid songCollectionId);
        
        Task AddAsync(SongCollectionEntity songCollection);
        Task SaveAsync(SongCollectionEntity songCollection);
        Task DeleteAsync(Guid songCollectionId);
    }
}
