using Microsoft.Extensions.DependencyInjection;

namespace Vibe.Core.Application.Services.Player
{
    internal static class PlayerServicesCompositionRoot
    {
        public static IServiceCollection AddPlayerServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<PlayerControlsService>()
                .AddSingleton<PlayerQueryService>()
                .AddSingleton<PlayerService>();
        }
    }
}
