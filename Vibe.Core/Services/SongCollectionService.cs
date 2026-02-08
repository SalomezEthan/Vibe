using Vibe.Core.Entities;
using Vibe.Core.Ports;

namespace Vibe.Core.Services
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
