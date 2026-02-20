using Microsoft.Extensions.DependencyInjection;
using Vibe.Core.Application.Services.Player;
using Vibe.Core.Application.Services.Playlist;
using Vibe.Core.Application.Services.Song;

namespace Vibe.Core.Application.Services
{
    internal static class ServicesCompositionRoot
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddPlayerServices()
                .AddPlaylistServices()
                .AddSongServices();
        }
    }
}
