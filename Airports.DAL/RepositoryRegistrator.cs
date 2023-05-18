using Airports.DAL.Entityes;
using Airports.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports.DAL
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<Airport>, DBRepository<Airport>>()
             .AddTransient<IRepository<AirportFrequence>, DBRepository<AirportFrequence>>()
             .AddTransient<IRepository<Country>, DBRepository<Country>>()
             .AddTransient<IRepository<Navaid>, DBRepository<Navaid>>()
             .AddTransient<IRepository<Region>, DBRepository<Region>>()
            .AddTransient<IRepository<Runway>, DBRepository<Runway>>()
            ;

    }
}
