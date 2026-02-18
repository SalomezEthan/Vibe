using Vibe.Core.Domain.Persistence;

namespace Vibe.Core.Domain
{

    public enum PlaybackState
    {
        Playing,
        InPause
    }

    public enum PlaybackMode
    {
        Once,
        Repeat
    }

    public sealed class Player
    {
        private readonly List<Song> _songs = [];
        private readonly Stack<Song> _history = [];

        public Player()
        {
            PlaybackState = PlaybackState.InPause;
            PlaybackMode = PlaybackMode.Once;
            Position = 0;
            Volume = 1f;
        }

        public PlaybackState PlaybackState { get; private set; }
        public PlaybackMode PlaybackMode { get; private set; }
        public int Position { get; private set; }
        public float Volume { get; private set; }
        public IReadOnlyList<Song> Songs => _songs;
        public Song CurrentSong => _songs[Position];
        public bool IsEmpty => _songs.Count == 0;

        public void UpdateSongQueue(IEnumerable<Song> songs)
        {
            if (!songs.Any())
            {
                throw new ArgumentException("Le lecteur ne peut charger une liste de chansons vide.");
            }

            _history.Clear();
            _songs.Clear();
            _songs.AddRange(songs);
            Position = 0;
        }

        public void UpdatePlaybackState(PlaybackState newState)
        {
            EnsurePlayerIsNotEmpty("Impossible de changer l'état de lecture si la file est vide");
            PlaybackState = newState;
        }

        public void Next()
        {
            EnsurePlayerIsNotEmpty("Impossible de passer au son suivant si la file est vide.");
            int pos;

            if (PlaybackMode is PlaybackMode.Repeat)
            {
                pos = (Position + 1) % _songs.Count;
            }
            else
            {
                if (Position + 1 >= _songs.Count)
                {
                    throw new InvalidOperationException("Le lecteur est déjà à la fin de la liste de chansons.");
                }

                pos = Position + 1;
            }

            _history.Push(_songs[Position]);
            Position = pos;
        }

        public void Previous()
        {
            EnsurePlayerIsNotEmpty("Impossible de passer au son précédent si la liste est vide.");

            if (!_history.TryPop(out var song))
            {
                throw new InvalidOperationException("Cette file de son ne possède encore aucun historique.");
            }

            Position = _songs.IndexOf(song);
        }

        public void MoveToSongById(Guid songId)
        {
            EnsurePlayerIsNotEmpty("Impossible de se déplacer dans une file qui ne contient aucun élément.");
            Position = _songs.FindIndex(song => song.Id == songId);
        }

        void EnsurePlayerIsNotEmpty(string messageIfItIs)
        {
            if (IsEmpty)
                throw new InvalidOperationException(messageIfItIs);
        }

        public void UpdateVolume(float newVolume)
        {
            if (newVolume < 0 || newVolume > 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(newVolume), 
                    newVolume, 
                    "Le volume doit être compris entre 0 et 1."
                    );
            }

            Volume = newVolume;
        }

        public void UpdateRepeatMode(PlaybackMode mode)
        {
            PlaybackMode = mode;
        }

        public void ClearPlayer()
        {
            _songs.Clear();
            _history.Clear();
            Position = 0;

        }
    }
}
