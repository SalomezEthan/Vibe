using System.Diagnostics.CodeAnalysis;
using Vibe.Core.Domain.Common;

namespace Vibe.Core.Domain.Persistence
{
    public sealed class Song : IEntity
    {
        public const int MAX_TITLE_LENGTH = 128;
        public const int MAX_ARTIST_NAME_LENGTH = 64;

        public Song(Guid id, string title, string artist, TimeSpan duration, string reference)
        {
            Id = id;
            UpdateTitle(title);
            UpdateArtist(artist);
            UpdateDuration(duration);
            UpdateReference(reference);
        }

        public Song(string title, string artist, TimeSpan duration, string reference)
        : this(Guid.NewGuid(), title, artist, duration, reference) { }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Artist { get; private set; }
        public TimeSpan Duration { get; private set; }
        public string Reference { get; private set; }

        [MemberNotNull(nameof(Title))]
        public void UpdateTitle(string newTitle)
        {
            newTitle = newTitle.Trim();

            if (newTitle.Length == 0)
            {
                throw new ArgumentException("Le tite d'un son ne peut être vide.");
            }

            if (newTitle.Length > MAX_TITLE_LENGTH)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(newTitle),
                    newTitle.Length,
                    $"Le titre ne peut pas dépasser {MAX_TITLE_LENGTH} caractères."
                    );
            }

            Title = newTitle;
        }

        [MemberNotNull(nameof(Artist))]
        void UpdateArtist(string artist)
        {
            artist = artist.Trim();
            
            if (artist.Length > MAX_ARTIST_NAME_LENGTH)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(artist),
                    artist.Length,
                    $"Le nom d'un artiste ne peut pas excéder {MAX_ARTIST_NAME_LENGTH} caractères.");
            }

            Artist = artist;
        }

        [MemberNotNull(nameof(Duration))]
        void UpdateDuration(TimeSpan newDuration)
        {
            if (newDuration == TimeSpan.Zero)
            {
                throw new ArgumentException("La durée d'un son ne peut pas être de 0.");
            }

            Duration = newDuration;
        }

        [MemberNotNull(nameof(Reference))]
        public void UpdateReference(string reference)
        {
            reference = reference.Trim();

            if (reference.Length == 0)
            {
                throw new ArgumentException("La référence d'un son ne peut pas être vide.");
            }

            Reference = reference;
        }
    }
}
