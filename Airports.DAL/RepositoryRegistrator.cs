using Airports.DAL.Entityes;
using Airports.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Airports.DAL
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<AirportDBModel>, AirportRepository>()
             .AddTransient<IRepository<AirportFrequenceDBModel>, DBRepository<AirportFrequenceDBModel>>()
             .AddTransient<IRepository<CountryDBModel>, DBRepository<CountryDBModel>>()
             .AddTransient<IRepository<NavaidDBModel>, DBRepository<NavaidDBModel>>()
             .AddTransient<IRepository<RegionDBModel>, DBRepository<RegionDBModel>>()
            .AddTransient<IRepository<RunwayDBModel>, DBRepository<RunwayDBModel>>()
            ;

    }
}
