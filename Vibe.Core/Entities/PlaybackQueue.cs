namespace Vibe.Core.Entities
{
    public class PlaybackQueue
    {
        public PlaybackQueue(IEnumerable<Song> songs)
        {
            if (!songs.Any())
            {
                throw new ArgumentException("Une file de lecture ne peut pas être vide.");
            }

            Queue = [..songs];
            CurrentPosition = 0;
        }
        public List<Song> Queue { get; private set; }
        public int CurrentPosition { get; private set; }

        public void Next()
        {
            if (CurrentPosition + 1 >= Queue.Count)
            {
                throw new InvalidOperationException("La file est déjà en fin de lecture.");
            }

            CurrentPosition++;
        }
    }
}
