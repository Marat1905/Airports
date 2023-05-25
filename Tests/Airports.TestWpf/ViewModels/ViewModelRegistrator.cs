using Microsoft.Extensions.DependencyInjection;

namespace Airports.TestWpf.ViewModels
{
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<AirportsViewModel>()
            ;
    }
}
