using Vibe.Core.Application.Models;
using Vibe.Core.Domain;

namespace Vibe.Core.Application.Services.PlayerServices
{
    public class PlayerQueryService(Player player)
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
