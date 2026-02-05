using System;
using System.Collections.Generic;
using System.Text;

namespace Vibe.Core.Song.ValueObjects
{
    /// <summary>
    /// La durée d'un son.
    /// </summary>
    public sealed class SongDuration
    {
        readonly TimeSpan _duration;

        /// <summary>
        /// Crée la durée du son par sa durée <see cref="TimeSpan"/>
        /// </summary>
        /// <param name="duration">Sa durée</param>
        /// <exception cref="ArgumentException">La durée d'un son ne peut pas être de 0 seconde.</exception>
        public SongDuration(TimeSpan duration)
        {
            if (duration == TimeSpan.Zero)
            {
                throw new ArgumentException("La durée d'un son ne peut pas être de 0 seconde");
            }

            _duration = duration;
        }

        /// <summary>
        /// Récupère la durée du son en <see cref="TimeSpan"/>
        /// </summary>
        /// <returns>La durée du son en <see cref="TimeSpan"/></returns>
        public TimeSpan ToTimeSpan()
        {
            return _duration;
        }
    }
}
