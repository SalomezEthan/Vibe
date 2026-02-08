namespace Vibe.Core.Entities
{
    public class PlaybackQueue
    {
        int _position;

        public PlaybackQueue()
        {
            Queue = [];
            _position = 0;
        }

        public PlaybackQueue(IEnumerable<Song> songs)
        {
            Queue = [..songs];
            _position = 0;
        }

        public List<Song> Queue { get; private set; }
        public Song CurrentSong
        {
            get
            {
                var song = Queue.ElementAtOrDefault(_position);
                return song ?? throw new InvalidOperationException("Il n'y a pas de son.");
            }
        }

        public void Next()
        {
            if (_position + 1 >= Queue.Count)
            {
                throw new InvalidOperationException("La file est déjà en fin de lecture.");
            }

            _position++;
        }
    }
}
