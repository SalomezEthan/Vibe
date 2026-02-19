using System.Diagnostics.CodeAnalysis;
using Vibe.Core.Domain.Common;

namespace Vibe.Core.Domain.Persistence
{
    public sealed class Playlist : IEntity
    {
        public const int MAX_NAME_LENGTH = 64;

        private readonly List<Guid> _songIds;

        public Playlist(Guid id, string name, IEnumerable<Guid> songIds)
        {
            _songIds = [..songIds];

            Id = id;
            UpdateName(name);
        }

        public Playlist(string name) : this(Guid.NewGuid(), name, [])
        {
        }

        public Guid Id { get; }
        public string Name { get; private set; }
        public IReadOnlyList<Guid> SongIds => _songIds;

        [MemberNotNull(nameof(Name))]
        public void UpdateName(string name)
        {
            name = name.Trim();

            if (name.Length == 0)
            {
                throw new ArgumentException("La nom d'une playlist ne peut pas être vide.");
            }

            if (name.Length > MAX_NAME_LENGTH)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(name),
                    name.Length,
                    $"Le nom d'une playlist ne peut pas dépasser {MAX_NAME_LENGTH} caractères."
                    );
            }

            Name = name;
        }

        public void AddSong(Guid songId)
        {
            if (_songIds.Contains(songId))
            {
                throw new ArgumentException("La playlist a déjà ce son.");
            }

            _songIds.Add(songId);
        }

        public void RemoveSong(Guid songId)
        {
            if (!_songIds.Remove(songId))
            {
                throw new ArgumentException("La playlist ne contient pas ce son.");
            }
        }
    }
}
