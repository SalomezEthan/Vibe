namespace Vibe.Core.Entities
{
    public sealed class SongCollection
    {
        readonly List<Song> _songs;

        public SongCollection(Guid id, IEnumerable<Song> songs)
        {
            _songs = [.. songs];
            Id = id;
        }

        public Guid Id { get; } 
        public IReadOnlyCollection<Song> Songs => _songs;

        public void AddSong(Song song)
        {
            if (_songs.Contains(song))
            {
                throw new ArgumentException("Le son est déjà dans la collection.");
            }

            _songs.Add(song); 
        }

        public void RemoveSong(Song song)
        {
            if (!_songs.Remove(song))
            {
                throw new ArgumentException("La collection ne contient pas le morceau.");
            }
        }
    }
}
