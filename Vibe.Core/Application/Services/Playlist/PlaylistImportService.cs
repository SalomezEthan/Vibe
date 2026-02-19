using System.Diagnostics;
using Vibe.Core.Application.Ports.Gateways;
using Vibe.Core.Application.Ports.Persistence;

// todo : Peut être ajouter un model de résultat d'importation.

namespace Vibe.Core.Application.Services.Playlist
{
    public sealed class PlaylistImportService(
        IPlaylistRepository playlistRepo,
        ISongRepository songRepo,
        IExternalSongCollectionService songCollectionService,
        ISongMetadataService songMetadataGateway
        )
    {
        public async Task ImportFoldersFromRoot(string rootReference)
        {
            var collections = await songCollectionService.GetCollectionReferencesFromRoot(rootReference);
            foreach (var collection in collections)
            {
                await ImportFolder(collection);
            }
        }
        public async Task ImportFolder(string reference)
        {
            var newPlaylist = await AddNewPlaylist(reference);
            var newSongs = await CreateSongsFromReference(reference);
            foreach (var song in newSongs)
            {
                try
                {
                    await songRepo.AddAsync(song);
                    newPlaylist.AddSong(song.Id);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                
            }

            await playlistRepo.UpdateAsync(newPlaylist);
        }


        public async Task<Domain.Persistence.Playlist> AddNewPlaylist(string reference)
        {
            var songCollectionName = await songCollectionService.GetExternalCollectionNameAsync(reference);
            var newPlaylist = new Domain.Persistence.Playlist(songCollectionName);
            await playlistRepo.AddAsync(newPlaylist);

            return newPlaylist;
        }

        public async Task<IEnumerable<Domain.Persistence.Song>> CreateSongsFromReference(string sourceReference)
        {
            var songReferences = await songCollectionService.GetSongReferencesAsync(sourceReference);
            var metadataTasks = songReferences.Select(songMetadataGateway.GetMetadataAsync);
            var metadata = await Task.WhenAll(metadataTasks);
            return metadata.Select(metadata => new Domain.Persistence.Song(
                title: metadata.Title,
                artist: metadata.Artist,
                duration: metadata.Duration,
                reference: metadata.Reference
                )
            );
        }
    }
}
