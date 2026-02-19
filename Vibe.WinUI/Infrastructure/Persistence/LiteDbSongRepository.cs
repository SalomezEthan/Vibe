using LiteDB.Async;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vibe.Core.Application.Ports.Persistence;
using Vibe.Core.Domain.Persistence;

namespace Vibe.WinUI.Infrastructure.Persistence
{
    internal sealed class LiteDbSongRepository(LiteDbDatabaseService db) : ISongRepository
    {
        private readonly ILiteCollectionAsync<Song> _songs = db.Songs;

        public async Task AddAsync(Song song)
        {
            await _songs.InsertAsync(song);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _songs.DeleteAsync(id);
        }

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return [..await _songs.FindAllAsync()];
        }

        public async Task<Song> GetByIdAsync(Guid id)
        {
            return await _songs.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Song>> GetFromArtistAsync(string artist)
        {
            return [..await _songs.FindAsync(song => song.Artist == artist)];
        }

        public async Task<IEnumerable<Song>> GetFromCharsInTitle(string chars)
        {
            return [.. await _songs.FindAsync(song => song.Title.Contains(chars, StringComparison.CurrentCultureIgnoreCase))];
        }

        public async Task UpdateAsync(Song song)
        {
            await _songs.UpdateAsync(song);
        }
    }
}
