namespace Vibe.Core.Application.Models
{
    public sealed record SongMetadataModel(
        string Title,
        string Artist,
        TimeSpan Duration,
        string Reference
        );
}
