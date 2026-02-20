using Microsoft.Extensions.DependencyInjection;
using Vibe.Core.Application.Ports.Persistence;

namespace Vibe.WinUI.Infrastructure.Persistence
{
    internal static class PersistenceCompositionRoot
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            return services
                .AddSingleton<LiteDbDatabaseService>()
                .AddSingleton<IPlaylistRepository, LiteDbPlaylistRepository>()
                .AddSingleton<ISongRepository, LiteDbSongRepository>();
        }
    }
}
