using System.Threading.Tasks;
using Vibe.Core.Application.Models;
using Windows.Storage;
using System;
using Vibe.Core.Application.Ports.Gateways;

namespace Vibe.WinUI.Infrastructure.Gateways
{
    internal sealed class WinRTSongMetadataGateway : ISongMetadataService
    {
        public async Task<SongMetadataModel> GetMetadataAsync(string reference)
        {
            var file = await StorageFile.GetFileFromPathAsync(reference);
            var properties = await file.Properties.GetMusicPropertiesAsync();
            return new SongMetadataModel(
                Title: properties.Title ?? file.DisplayName,
                Artist: properties.Artist ?? string.Empty,
                Duration: properties.Duration,
                Reference: file.Path
                );
        }
    }
}
