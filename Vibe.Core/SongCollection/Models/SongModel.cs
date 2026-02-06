namespace Vibe.Core.SongCollection.Models
{
    public sealed record SongModel(
        Guid Id, 
        string Name, 
        IEnumerable<ArtistModel> ArtistIds, 
        TimeSpan Duration
        );
}
