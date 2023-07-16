using Microsoft.Extensions.DependencyInjection;
using YandexAPI.Mаps;
using YandexAPI.Mаps.Interfaces;

namespace YandexAPI.Service
{
    public static class MapsYandexServicesRegistrator
    {
        public static IServiceCollection AddMapYandexServices(this IServiceCollection services) => services
          .AddTransient<IStaticMaps, StaticMaps>()
         ;
    }
}
