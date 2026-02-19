using LiteDB.Async;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vibe.Core.Domain.Persistence;

namespace Vibe.WinUI.Infrastructure.Persistence
{
    internal sealed class LiteDbDatabaseService
    {
        private readonly LiteDatabaseAsync _db;

        public LiteDbDatabaseService()
        {
            _db = new LiteDatabaseAsync(Path.Combine(Environment.CurrentDirectory, "LiteDataBase.db"));

            Songs = _db.GetCollection<Song>();
            Playlists = _db.GetCollection<Playlist>();
        }

        public ILiteCollectionAsync<Song> Songs { get; }
        public ILiteCollectionAsync<Playlist> Playlists { get; }
    }
}
