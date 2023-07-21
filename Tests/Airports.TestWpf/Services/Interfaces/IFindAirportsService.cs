using Airports.DAL.Entityes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using YandexAPI.Mаps;

namespace Airports.TestWpf.Services.Interfaces
{
    public interface IFindAirportsService
    {
        /// <summary>Перечисление Аэропортов</summary>
        IQueryable<AirportDBModel> Airports { get; }

        /// <summary>
        /// Поиск ближайшего аэропорта
        /// </summary>
        /// <param name="point">Координаты</param>
        /// <returns>Возвращаем Аэропорт</returns>
        AirportDBModel FindТearestAirport(GeoPoint point);
        /// <summary>Поиск аэропортов в заданном радиусе </summary>
        /// <param name="point">Координаты центра поиска</param>
        /// <param name="radius">Радиус поиска(км)</param>
        /// <returns>Возврат списков аэропортов</returns>
        IEnumerable<AirportDBModel> FindAirportsRadius(GeoPoint point, int radius);

        /// <summary>Поиск аэропортов в заданном радиусе прямой запрос к БД </summary>
        /// <param name="point">Координаты центра поиска</param>
        /// <param name="radius">Радиус поиска(км)</param>
        /// <returns>Возврат списков аэропортов</returns>
        IEnumerable<AirportDBModel>? FindAirportsRadiusSql(GeoPoint point, int radius);

        /// <summary>Поиск аэропортов в заданном радиусе прямой запрос к БД асинхронно</summary>
        /// <param name="point">Координаты центра поиска</param>
        /// <param name="radius">Радиус поиска(км)</param>
        /// <param name="Cancel">Токен отмены операции</param>
        /// <returns>Возврат списков аэропортов</returns>
        Task<IEnumerable<AirportDBModel>?> FindAirportsRadiusSqlAsync(GeoPoint point, int distance, CancellationToken Cancel = default);
    }
}
