using Airports.DAL.Entityes;
using Airports.Interfaces;
using Airports.TestWpf.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airports.TestWpf.Services
{
    internal class FindAirportsService:IFindAirportsService
    {
        //2:27
        private readonly IRepository<AirportDBModel> _Airports;

        public IEnumerable<AirportDBModel> Airports => _Airports.Items;
        public FindAirportsService(IRepository<AirportDBModel> Airports)
        {
            _Airports = Airports;
        }

        public AirportDBModel FindAirports()
        {
            return new AirportDBModel();
        }
        //public async Task<AirportDBModel> FindAirportsRadius()
        //{
            
        //}
    }
}
