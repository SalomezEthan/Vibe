namespace Vibe.Core.Song.Models
{
    public sealed record SongMetadataModel(string Title, IEnumerable<string> PerformerNames, TimeSpan Duration);
}
