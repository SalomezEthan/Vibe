namespace Vibe.Core.SongCollection.Models
{
    /// <summary>
    /// Le model représentant un son.
    /// </summary>
    /// <param name="Id">L'identifiant du son.</param>
    /// <param name="Name">Le nom du son.</param>
    /// <param name="PerformerIds">Les interprètes du son.</param>
    /// <param name="Duration">La durée du son.</param>
    public sealed record SongModel(
        Guid Id, 
        string Name, 
        IEnumerable<PerformerModel> PerformerIds, 
        TimeSpan Duration
        );
}
