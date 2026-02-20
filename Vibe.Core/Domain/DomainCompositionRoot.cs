using Microsoft.Extensions.DependencyInjection;

namespace Vibe.Core.Domain
{
    internal static class DomainCompositionRoot
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services.AddSingleton<Player>();
        }
    }
}
