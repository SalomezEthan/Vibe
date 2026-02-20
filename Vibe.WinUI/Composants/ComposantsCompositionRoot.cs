using Microsoft.Extensions.DependencyInjection;
using Vibe.WinUI.Composants.Player.ViewModels;
using Vibe.WinUI.Composants.Playlist;
using Vibe.WinUI.Composants.PlaylistLibrary.ViewModels;
using Vibe.WinUI.Composants.Song;

namespace Vibe.WinUI.Composants
{
    internal static class ComposantsCompositionRoot
    {
        public static IServiceCollection AddComposants(this IServiceCollection services)
        {
            return services
                .AddSingleton<PlayerViewModel>()
                .AddSingleton<SongViewModelFactory>()
                .AddSingleton<SongViewModelMap>()
                .AddSingleton<PlaylistViewModelFactory>()
                .AddSingleton<PlaylistLibraryPageViewModel>()
                .AddSingleton<SongLibraryViewModel>();
        }
    }
}
