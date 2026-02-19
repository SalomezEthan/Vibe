using System.Collections.Generic;
using System.Threading.Tasks;
using Vibe.Core.Application.Ports.Gateways;
using Windows.Storage;
using System;
using Windows.Storage.Search;
using System.Linq;

namespace Vibe.WinUI.Infrastructure.Gateways
{
    public sealed class WinRTFolderGateway : IExternalSongCollectionService
    {
        public async Task<IEnumerable<string>> GetCollectionReferencesFromRoot(string rootReference)
        {
            var rootFolder = await StorageFolder.GetFolderFromPathAsync(rootReference);
            var folderQueryOption = new QueryOptions()
            {
                FolderDepth = FolderDepth.Deep
            };

            var folders = await rootFolder
                .CreateFolderQueryWithOptions(folderQueryOption)
                .GetFoldersAsync();

            return folders.Select(folder => folder.Path);
        }

        public async Task<string> GetExternalCollectionNameAsync(string reference)
        {
            var folder = await StorageFolder.GetFolderFromPathAsync(reference);
            return folder.Name;
        }

        public async Task<IEnumerable<string>> GetSongReferencesAsync(string sourceReference)
        {
            var folder = await StorageFolder.GetFolderFromPathAsync(sourceReference);
            var songs = await folder
                .CreateFileQueryWithOptions(new QueryOptions(CommonFileQuery.DefaultQuery, [".mp3"]))
                .GetFilesAsync();

            return songs.Select(song => song.Path);
        }
    }
}
