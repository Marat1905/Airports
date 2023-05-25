using Airports.DAL.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports.TestWpf.Services.Interfaces
{
    public interface IFindAirportsService
    {
        IEnumerable<AirportDBModel> Airports { get; }

    }
}
