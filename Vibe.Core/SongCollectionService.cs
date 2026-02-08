using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Vibe.Core
{
    public sealed class SongCollectionService(ISongRepository songRepository, SongCollection collection)
    {
        public async Task AddSongAsync(Guid SongId)
        {
            var song = await songRepository.GetSongByIdAsync(SongId);
            collection.AddSong(song);
        }

        public async Task RemoveSongAsync(Guid SongId)
        {
            var song = await songRepository.GetSongByIdAsync(SongId);
            collection.AddSong(song);
        }
    }
}
