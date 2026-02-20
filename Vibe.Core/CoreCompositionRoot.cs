using Microsoft.Extensions.DependencyInjection;
using Vibe.Core.Application;
using Vibe.Core.Domain;

namespace Vibe.Core
{
    public static class CoreCompositionRoot
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            return services
                .AddApplication()
                .AddDomain();
        }
    }
}
