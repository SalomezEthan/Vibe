namespace Vibe.Core.Song.Ports
{
    public interface ISongRepository
    {
        /// <summary>
        /// Récupère une entité <see cref="SongEntity"/> par son identifiant.
        /// </summary>
        /// <param name="songId">L'identifiant du son recherché.</param>
        Task<SongEntity> GetSongById(Guid songId);

        /// <summary>
        /// Ajoute un nouveau son au stockage persistant avec son entité et sa référence.
        /// </summary>
        /// <param name="song">L'entité du nouveau son.</param>
        /// <param name="reference">La référence externe du nouveau son.</param>
        Task AddSong(SongEntity song, string reference);

        /// <summary>
        /// Met à jour un son dans le stockage persistant.
        /// </summary>
        /// <param name="song">L'entité du son modifié.</param>
        Task UpdateSong(SongEntity song);

        /// <summary>
        /// Supprime un son du stockage persistant par son identifiant.
        /// </summary>
        /// <param name="songId">L'identifiant du son à supprimer.</param>
        Task DeleteSongById(Guid songId);
    }
}
