using Microsoft.Extensions.DependencyInjection;
using Vibe.Core.Application.Services;

namespace Vibe.Core.Application
{
    internal static class ApplicationCompositionRoot
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services.AddServices();
        }
    }
}
