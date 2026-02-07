namespace Vibe.Core.SongCollection.Models
{
    /// <summary>
    /// Le model représentant un interprète.
    /// </summary>
    /// <param name="Id">L'identifiant de l'artiste.</param>
    /// <param name="Name">Le nom de l'artiste.</param>
    public sealed record PerformerModel(Guid Id, string Name);
}
