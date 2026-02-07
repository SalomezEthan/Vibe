namespace Vibe.Core.User
{
    /// <summary>
    /// L'entité métier représentant l'utilisateur.
    /// </summary>
    /// <param name="favoriteSongIds">Les sons favoris de l'utilisateur.</param>
    public sealed class UserEntity(IEnumerable<Guid> favoriteSongIds)
    {
        readonly List<Guid> _favoriteSongIds = [.. favoriteSongIds];

        public IReadOnlyList<Guid> FavoriteSongIds => _favoriteSongIds;

        /// <summary>
        /// Ajoute un nouveau favoris à la liste des sons favoris.
        /// </summary>
        /// <param name="songId">L'identifiant du son à ajouter.</param>
        /// <exception cref="ArgumentException">Un utilisateur ne peut pas rajouter un son qu'il contient déjà.</exception>
        public void AddFavoriteSong(Guid songId)
        {
            if (_favoriteSongIds.Contains(songId))
            {
                throw new ArgumentException("Un utilisateur ne peut pas rajouter un son qu'il contient déjà.");
            }

            _favoriteSongIds.Add(songId);
        }

        /// <summary>
        /// Enlève un favoris de la liste des sons favoris.
        /// </summary>
        /// <param name="songId">L'identifiant du son à supprimer.</param>
        /// <exception cref="ArgumentException">Un utilisateur ne peut enlever un son qu'il ne contient pas.</exception>
        public void RemoveFavoriteSong(Guid songId)
        {
            if (!_favoriteSongIds.Remove(songId))
            {
                throw new ArgumentException("Un utilisateur ne peut enlever un son qu'il ne contient pas.");
            }
        }
    }
}
