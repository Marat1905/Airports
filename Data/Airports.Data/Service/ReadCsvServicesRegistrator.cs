using Airports.Data.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports.Data.Service
{
    public static class ReadCsvServicesRegistrator
    {
        public static IServiceCollection AddReadCsvServices(this IServiceCollection services, string zipPath) => services
           .AddTransient<IReadAirportsCsvService, ReadAirportsCsvService>(sp =>
           {
               return new ReadAirportsCsvService(zipPath);
           })
          ;
    }
}
