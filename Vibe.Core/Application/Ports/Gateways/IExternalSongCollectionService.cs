using Vibe.Core.Application.Models;

namespace Vibe.Core.Application.Ports.Gateways
{
    public interface IExternalSongCollectionService
    {
        Task<string> GetExternalCollectionNameAsync(string reference);
        Task<IEnumerable<string>> GetSongReferencesAsync(string sourceReference);
        Task<IEnumerable<string>> GetCollectionReferencesFromRoot(string rootReference);
    }
}
