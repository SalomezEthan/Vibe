namespace Vibe.Core.SongCollection.ValueObjects
{
    public sealed class SongCollectionName
    {
        readonly string _name;

        /// <summary>
        /// Crée le nom d'une collection de sons à partir d'un <see cref="string"/>.
        /// </summary>
        /// <param name="name">Le nom de la colletion.</param>
        /// <exception cref="ArgumentException">Un nom de collection de sons ne peut pas être vide.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Un nom de collection de sons ne peut dépasser 128 caractères.</exception>
        public SongCollectionName(string name)
        {
            name = name.Trim();

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Un nom de collection de sons ne peut pas être vide.");
            }

            if (name.Length > 128)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(name),
                    name.Length,
                    "Un nom de collection de sons ne peut dépasser 128 caractères."
                    );
            }

            _name = name;
        }

        /// <summary>
        /// Récupère le nom de la collection de sons sous forme de <see cref="string"/>
        /// </summary>
        /// <returns>Le nom de la collection de sons sous forme de <see cref="string"/></returns>
        public override string ToString()
        {
            return _name;
        }
    }
}
