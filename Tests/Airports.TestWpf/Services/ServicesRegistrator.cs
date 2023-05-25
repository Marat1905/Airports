using Airports.Data.Service;
using Airports.Data.Service.Interfaces;
using Airports.TestWpf.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Airports.TestWpf.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IFindAirportsService,FindAirportsService>()
           ;
    }
}
