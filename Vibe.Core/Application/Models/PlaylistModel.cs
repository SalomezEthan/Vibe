using Vibe.Core.Domain.Persistence;

namespace Vibe.Core.Application.Models
{
    public sealed record PlaylistModel(
        Guid Id,
        string Name,
        int Count
        ) 
    {
        public static PlaylistModel FromEntity(Playlist playlist)
        {
            return new PlaylistModel(
                playlist.Id,
                playlist.Name,
                playlist.SongIds.Count
                );
        }
    }
}
