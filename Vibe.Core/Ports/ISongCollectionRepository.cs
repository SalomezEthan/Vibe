using Vibe.Core.Entities;

namespace Vibe.Core.Ports
{
    public interface ISongCollectionRepository
    {
        Task<SongCollection> GetById(Guid id);
    }
}
