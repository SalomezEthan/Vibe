using Vibe.Core.Application.Models;
using Vibe.Core.Domain;

namespace Vibe.Core.Application.Services.Player
{
    public class PlayerQueryService(Domain.Player player)
    {
        public SongModel GetCurrentSong()
        {
            return SongModel.FromEntity(player.CurrentSong);
        }

        public IEnumerable<SongModel> GetSongQueue()
        {
            return player.Songs.Select(SongModel.FromEntity);
        }
    }
}
