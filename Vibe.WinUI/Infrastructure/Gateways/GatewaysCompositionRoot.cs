using Microsoft.Extensions.DependencyInjection;
using Vibe.Core.Application.Ports.Gateways;

namespace Vibe.WinUI.Infrastructure.Gateways
{
    internal static class GatewaysCompositionRoot
    {
        public static IServiceCollection AddGateways(this IServiceCollection services)
        {
            return services
                .AddSingleton<IExternalSongCollectionService, WinRTFolderGateway>()
                .AddSingleton<ISongMetadataService, WinRTSongMetadataGateway>();
        }
    }
}
