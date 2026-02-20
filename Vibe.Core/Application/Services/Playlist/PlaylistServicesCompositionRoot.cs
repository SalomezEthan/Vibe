using Microsoft.Extensions.DependencyInjection;

namespace Vibe.Core.Application.Services.Playlist
{
    internal static class PlaylistServicesCompositionRoot
    {
        public static IServiceCollection AddPlaylistServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<PlaylistEditService>()
                .AddSingleton<PlaylistQueryService>()
                .AddSingleton<PlaylistImportService>();
           
        }
    }
}
