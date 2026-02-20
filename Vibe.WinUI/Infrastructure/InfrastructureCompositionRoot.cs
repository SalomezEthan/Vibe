using Microsoft.Extensions.DependencyInjection;
using Vibe.Core.Application.Ports;
using Vibe.WinUI.Infrastructure.Gateways;
using Vibe.WinUI.Infrastructure.Persistence;

namespace Vibe.WinUI.Infrastructure
{
    public static class InfrastructureCompositionRoot
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services
                .AddGateways()
                .AddPersistence()
                .AddSingleton<IShuffleService, SystemShuffleService>()
                .AddSingleton<IAudioService, WinRTAudioService>();
        }
    }
}
