using Vibe.Core.SongCollection.Models;

namespace Vibe.Core.SongCollection.Ports
{
    /// <summary>
    /// Permet de récupérer les sons d'une collection.
    /// </summary>
    public interface ISongGateway
    {
        /// <summary>
        /// Récupère les sons d'une collection.
        /// </summary>
        /// <param name="songIds">La collections d'identidiants des sons.</param>
        /// <returns>La collection.</returns>
        Task<IReadOnlyList<SongModel>> GetSongsAsync(IEnumerable<Guid> songIds);

        /// <summary>
        /// Récupère tous les sons.
        /// </summary>
        /// <returns>Tous les sons.</returns>
        Task<IReadOnlyList<SongModel>> GetAllSongsAsync();

        /// <summary>
        /// Récupère les sons favoris d'un utilisateur.
        /// </summary>
        /// <param name="userId">L'identifiant de l'utilisateur.</param>
        /// <returns>Les sons favoris de l'utilisateur.</returns>
        Task<IReadOnlyList<SongModel>> GetUserFavoriteSongsAsync(Guid userId);
    }
}
