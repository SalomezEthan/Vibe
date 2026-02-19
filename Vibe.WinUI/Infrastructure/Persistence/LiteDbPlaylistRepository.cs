using LiteDB;
using LiteDB.Async;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vibe.Core.Application.Ports.Persistence;
using Vibe.Core.Domain.Persistence;

namespace Vibe.WinUI.Infrastructure.Persistence
{
    internal class LiteDbPlaylistRepository(LiteDbDatabaseService db) : IPlaylistRepository
    {
        private readonly ILiteCollectionAsync<Playlist> _playlists = db.Playlists;
        private readonly ILiteCollectionAsync<Song> _songs = db.Songs;

        public async Task AddAsync(Playlist playlist)
        {
            await _playlists.InsertAsync(playlist);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _playlists.DeleteAsync(id);
        }

        public async Task<IEnumerable<Playlist>> GetAllAsync()
        {
            return [.. await _playlists.FindAllAsync()];
        }

        public async Task<Playlist> GetById(Guid id)
        {
            return await _playlists.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Song>> GetSongsInPlaylistAsync(Guid playlistId)
        {
            var playlist = await _playlists.FindByIdAsync(playlistId);

            List<Song> songs = [];
            foreach(var songId in playlist.SongIds)
            {
                var song = await _songs.FindByIdAsync(songId);
                songs.Add(song);
            }

            return songs;
        }

        public async Task UpdateAsync(Playlist playlist)
        {
            await _playlists.UpdateAsync(playlist);
        }
    }
}
