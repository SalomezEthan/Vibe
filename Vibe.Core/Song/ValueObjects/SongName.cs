namespace Vibe.Core.Song.ValueObjects
{
    /// <summary>
    /// Le nom d'un son.
    /// </summary>
    public sealed class SongName
    {
        readonly string _name;

        /// <summary>
        /// Crée un nouveau nom de son par une chaîne de caractères.
        /// </summary>
        /// <param name="name">Le nom proposé du son.</param>
        /// <exception cref="ArgumentException">Le nom ne peut être vide.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Le nom ne peut dépasser la limite de caractères autorisés.</exception>
        public SongName(string name)
        {
            name = name.Trim();

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Un nom ne peut pas être vide.");
            }

            if (name.Length > 255)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(name),
                    name.Length,
                    "Un nom de son ne peut excéder 255 caractères.");
            }

            _name = name;
        }

        /// <summary>
        /// Récupère le nom sous forme d'une chaîne de caractères.
        /// </summary>
        /// <returns>Le nom sous forme d'une chaîne de caractères.</returns>
        public override string ToString()
        {
            return _name;
        }
    }
}
