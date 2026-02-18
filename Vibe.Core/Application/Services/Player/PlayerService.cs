using Vibe.Core.Application.Ports;
using Vibe.Core.Application.Ports.Persistence;
using Vibe.Core.Domain;

namespace Vibe.Core.Application.Services.Player
{
    public sealed class PlayerService(
        Domain.Player player, 
        IPlaylistRepository playlistRepo, 
        ISongRepository songRepo, 
        IAudioService audioService
        )
    {
        public async Task PlaySongAsync(Guid songId)
        {
            var song = await songRepo.GetByIdAsync(songId);
            player.UpdateSongQueue([song]);
            audioService.PlaySong(song.Reference);
        }

        public async Task PlayPlaylistAsync(Guid playlistId)
        {
            var songs = await playlistRepo.GetSongsInPlaylistAsync(playlistId);
            player.UpdateSongQueue(songs);
            audioService.PlaySong(player.CurrentSong.Reference);
        }

        public async Task PlayAllSongAsync()
        {
            var songs = await songRepo.GetAllAsync();
            player.UpdateSongQueue(songs);
            audioService.PlaySong(player.CurrentSong.Reference);
        }
    }
}
