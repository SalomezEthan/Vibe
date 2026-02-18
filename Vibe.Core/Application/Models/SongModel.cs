using Vibe.Core.Domain.Persistence;

namespace Vibe.Core.Application.Models
{
    public sealed record SongModel(
        Guid Id,
        string Title,
        string Artist,
        TimeSpan Duration
        )
    {
        public static SongModel FromEntity(Song song)
        {
            return new SongModel(
                song.Id,
                song.Title,
                song.Artist,
                song.Duration
                );
        }
    }
}
