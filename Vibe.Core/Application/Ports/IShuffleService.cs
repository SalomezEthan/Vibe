using Vibe.Core.Domain.Persistence;

namespace Vibe.Core.Application.Ports
{
    public interface IShuffleService
    {
        IEnumerable<Song> ShuffleSongs(IEnumerable<Song> songs);
    }
}
