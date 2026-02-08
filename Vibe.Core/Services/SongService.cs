using Vibe.Core.Ports;

namespace Vibe.Core.Services
{
    public sealed class SongService(ISongRepository repo)
    {
        public async Task Rename(Guid songId, string newTitle)
        {
            var song = await repo.GetSongByIdAsync(songId);
            song.Rename(newTitle);
            await repo.UpdateAsync(song);
        }
    }
}
