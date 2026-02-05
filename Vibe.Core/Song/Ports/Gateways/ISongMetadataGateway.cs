using Vibe.Core.Song.Models;

namespace Vibe.Core.Song.Ports.Gateways
{
    public interface ISongMetadataGateway
    {
        /// <summary>
        /// Récupère les métadonnées d'un son à partir de sa reference.
        /// </summary>
        /// <param name="reference">La référence vers le son externe.</param>
        /// <returns>Les métadonnées du son.</returns>
        Task<SongMetadataModel> GetSongMetadataFromReference(string reference);
    }
}
