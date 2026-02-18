using Vibe.Core.Application.Ports.Persistence;

namespace Vibe.Core.Application.Services.Song
{
    public class SongEditService(ISongRepository songRepository)
    {
        public async Task RenameSongAsync(Guid songId, string newTitle)
        {
            var song = await songRepository.GetByIdAsync(songId);
            song.UpdateTitle(newTitle);
            await songRepository.UpdateAsync(song);
        }
    }
}
