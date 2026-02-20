using Microsoft.Extensions.DependencyInjection;

namespace Vibe.Core.Application.Services.Song
{
    internal static class SongServicesCompositionRoot
    {
        public static IServiceCollection AddSongServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<SongQueryService>()
                .AddSingleton<SongEditService>();
        }
    }
}
