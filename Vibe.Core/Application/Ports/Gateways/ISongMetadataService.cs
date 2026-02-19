using Vibe.Core.Application.Models;

namespace Vibe.Core.Application.Ports.Gateways
{
    public interface ISongMetadataService
    {
        Task<SongMetadataModel> GetMetadataAsync(string reference);
    }
}
