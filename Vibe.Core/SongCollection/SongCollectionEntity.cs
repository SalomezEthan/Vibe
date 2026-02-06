using Vibe.Core.SongCollection.ValueObjects;

namespace Vibe.Core.SongCollection
{
    /// <summary>
    /// Entité métier représentant la collection de sons.
    /// </summary>
    /// <param name="songCollectionId">L'identifiant de la collection de sons.</param>
    /// <param name="name">Le nom de la collection.</param>
    /// <param name="songIds">L'identifiants de sons.</param>
    public sealed class SongCollectionEntity(
        Guid songCollectionId, 
        SongCollectionName name, 
        IEnumerable<Guid> songIds
        )
    {
        readonly List<Guid> _songIds = [.. songIds];

        public Guid Id { get; } = songCollectionId;
        public SongCollectionName Name { get; private set; } = name;
        public IReadOnlyList<Guid> SongIds => _songIds;

        /// <summary>
        /// Renomme la collection.
        /// </summary>
        /// <param name="newName">Le nouveau nom proposé.</param>
        public void Rename(SongCollectionName newName)
        {
            Name = newName;
        }

        /// <summary>
        /// Ajoute un son par son identifiant.
        /// </summary>
        /// <param name="songId">L'identifiant du son.</param>
        /// <exception cref="ArgumentException">Une collection de sons ne peut pas contenir 2 fois le même son</exception>
        public void AddSong(Guid songId)
        {
            if ( _songIds.Contains( songId ))
            {
                throw new ArgumentException("Une collection de sons ne peut pas contenir 2 fois le même son");
            }

            _songIds.Add( songId );
        }

        /// <summary>
        /// Retire un son par son identifiant.
        /// </summary>
        /// <param name="songId">L'id du son.</param>
        /// <exception cref="ArgumentException">Une collection de sons ne peut pas enlever un son qu'il ne contient pas.</exception>
        public void RemoveSong(Guid songId)
        {
            if (!_songIds.Remove(songId))
            {
                throw new ArgumentException("Une collection de sons ne peut pas enlever un son qu'il ne contient pas.");
            }
        }
    }
}
