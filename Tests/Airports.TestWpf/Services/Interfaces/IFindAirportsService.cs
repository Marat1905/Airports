using Airports.DAL.Entityes;
using Airports.TestWpf.Models;
using System.Collections.Generic;

namespace Airports.TestWpf.Services.Interfaces
{
    public interface IFindAirportsService
    {
        /// <summary>Перечисление Аэропортов</summary>
        IEnumerable<AirportDBModel> Airports { get; }

        /// <summary>
        /// Поиск ближайшего аэропорта
        /// </summary>
        /// <param name="point">Координаты</param>
        /// <returns>Возвращаем Аэропорт</returns>
        AirportDBModel FindТearestAirport(GeoPoint point);
        /// <summary>Поиск аэропортов в заданном радиусе </summary>
        /// <param name="point">Координаты центра поиска</param>
        /// <param name="radius">Радиус поиска(км)</param>
        /// <returns></returns>
        IEnumerable<AirportDBModel> FindAirportsRadius(GeoPoint point, int radius);


    }
}
