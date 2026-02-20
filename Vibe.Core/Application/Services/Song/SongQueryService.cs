using Vibe.Core.Application.Models;
using Vibe.Core.Application.Ports.Persistence;

namespace Vibe.Core.Application.Services.Song
{
    public class SongQueryService(ISongRepository songRepository)
    {
        public async Task<IEnumerable<SongModel>> CollectAllSongsAsync()
        {
            var songs = await songRepository.GetAllAsync();
            return songs.Select(SongModel.FromEntity);
        }

        public async Task<IEnumerable<SongModel>> CollectSongsByArtistAsync(string artist)
        {
            var songs = await songRepository.GetFromArtistAsync(artist);
            return songs.Select(SongModel.FromEntity);
        }

        public async Task<IEnumerable<SongModel>> CollectSongsWithCharsInTitleAsync(string chars)
        {
            var songs = await songRepository.GetFromCharsInTitle(chars);
            return songs.Select(SongModel.FromEntity);
        }
    }
}
