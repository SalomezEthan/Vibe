using Vibe.Core.Song.ValueObjects;

namespace Vibe.Core.Song
{
    /// <summary>
    /// L'entité métier représentant un son.
    /// </summary>
    /// <param name="songId">L'identidiant du son.</param>
    /// <param name="title">Le titre du son.</param>
    /// <param name="performers">Les interprètes du son.</param>
    /// <param name="duration">La durée du son.</param>
    public sealed class SongEntity(Guid songId, SongName title, IEnumerable<Guid> performers, SongDuration duration)
    {
        readonly List<Guid> _performers = [.. performers];

        public Guid Id { get; } = songId;
        public SongName Title { get; private set; } = title;
        public SongDuration Duration { get; private set; } = duration;
        public IReadOnlyList<Guid> Performers => _performers;

        /// <summary>
        /// Renomme le titre du son.
        /// </summary>
        /// <param name="newTitle">Le nouveau titre.</param>
        public void RenameTitle(SongName newTitle)
        {
            Title = newTitle;
        }

        /// <summary>
        /// Ajoute un interprète à la chanson.
        /// </summary>
        /// <param name="performerId"></param>
        /// <exception cref="ArgumentException">Un son ne peut contenir un interprète en double.</exception>
        public void AddPerformer(Guid performerId)
        {
            if (_performers.Contains(performerId))
            {
                throw new ArgumentException("Un son ne peut contenir un interprète en double.");
            }

            _performers.Add(performerId);
        }

        /// <summary>
        /// Retire l'identifiant d'un interprète du son.
        /// </summary>
        /// <param name="performerId">L'identifiant de l'interprète.</param>
        /// <exception cref="ArgumentException">Un son ne peut supprimer l'id d'un interprète inexistant.</exception>
        public void RemovePerformer(Guid performerId)
        {
            if (!_performers.Remove(performerId))
            {
                throw new ArgumentException("Un son ne peut supprimer l'id d'un interprète inexistant.");
            }
        }
    }
}
