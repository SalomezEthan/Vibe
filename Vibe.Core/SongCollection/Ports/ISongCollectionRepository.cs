namespace Vibe.Core.SongCollection.Ports
{
    public interface ISongCollectionRepository
    {
        /// <summary>
        /// Récupère l'entité <see cref="SongCollectionEntity"/> par son identifiant.
        /// </summary>
        /// <param name="songCollectionId"></param>
        /// <returns>L'entité.</returns>
        Task<SongCollectionEntity> GetByIdAsync(Guid songCollectionId);
        
        /// <summary>
        /// Ajoute une nouvelle collection de sons.
        /// </summary>
        /// <param name="songCollection">La collection à rajouter.</param>
        Task AddAsync(SongCollectionEntity songCollection);

        /// <summary>
        /// Sauvegarde les changements d'une collection.
        /// </summary>
        /// <param name="songCollection">La collection modifiée.</param>
        Task SaveAsync(SongCollectionEntity songCollection);

        /// <summary>
        /// Supprime la collection de sons.
        /// </summary>
        /// <param name="songCollectionId">L'identifiant de la collection à supprimer.</param>
        Task DeleteAsync(Guid songCollectionId);
    }
}
