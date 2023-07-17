using Airports.DAL.Entityes;
using Airports.Interfaces;
using Airports.TestWpf.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using YandexAPI.Mаps;

namespace Airports.TestWpf.Services
{
    internal class FindAirportsService:IFindAirportsService
    {
        private readonly IRepository<AirportDBModel> _Airports;

        public IQueryable<AirportDBModel> Airports => _Airports.Items;
        public FindAirportsService(IRepository<AirportDBModel> Airports)
        {
            _Airports = Airports;
        }

        public AirportDBModel FindТearestAirport(GeoPoint point)
        {
            double minDist=100000.0;
            AirportDBModel result=new AirportDBModel();
            foreach (var Air in Airports)
            {
                var dist = Distance(point, Air.LatitudeDeg, Air.LongitudeDeg);
                if (dist < minDist)
                {
                    result=Air;
                    minDist= dist;
                }
            }
            return result;
        }
       

        public IEnumerable<AirportDBModel>? FindAirportsRadius(GeoPoint point,int radius)
        {
            List<AirportDBModel>? result=null;
            foreach (var Air in Airports)
            {
                var dist = Distance(point, Air.LatitudeDeg, Air.LongitudeDeg);
                if (dist < radius)
                {
                    result ??= new List<AirportDBModel>();
                    result.Add(Air);
                }
            }
            return result;
        }

        public IEnumerable<AirportDBModel>? FindAirportsRadiusSql(GeoPoint point, int distance)
        {
            IEnumerable<AirportDBModel>? result = null;
            result = _Airports.SqlRawQuery($"SELECT * FROM (SELECT * ," +
                $"(6371.0 * 2.0 * ASIN(" +
                $" SQRT(" +
                $" POWER(" +
                $"SIN(([LatitudeDeg] - ABS({point.Latitude})) * PI() / 180 / 2), 2 ) +" +
                $"COS([LatitudeDeg] * PI() / 180) *" +
                $"COS(ABS({point.Latitude}) * PI() / 180) *" +
                $" POWER(SIN(([LongitudeDeg] - {point.Longitude}) * PI() / 180 / 2),2)))) as distance" +
                $" FROM[dbo].[Airports] ) p where distance < {distance}").ToList();
            return result;
        }

        /// <summary>Расчет расстояния до точки по формуле гаверсинусов </summary>
        /// <param name="Latitude"> Наш центр широты</param>
        /// <param name="Longitude">Наш центр долготы</param>
        /// <param name="LatitudeDeg">Широта точки</param>
        /// <param name="LongitudeDeg">Долгота точки</param>
        /// <returns> расстояние до точки (Км)</returns>
        private double Distance(GeoPoint point, decimal? LatitudeDeg, decimal? LongitudeDeg)
        {
            const double EarthRadius = 6371.0;
            const double pi180 = Math.PI / 180.0;
            
            if (LongitudeDeg == null || LatitudeDeg == null)
                throw new ArgumentNullException("Долгота и широта не может быть null");

            var dist = 2.0 * EarthRadius * Math.Asin(
                Math.Sqrt(
                           Math.Pow(Math.Sin(((double)LatitudeDeg - Math.Abs((double)point.Latitude)) * pi180 / 2.0), 2.0) +
                Math.Cos((double)LatitudeDeg * pi180) *
                Math.Cos(Math.Abs((double)point.Latitude) * pi180) *
                Math.Pow(Math.Sin(((double)LongitudeDeg - (double)point.Longitude) * pi180 / 2.0), 2.0)));
            return dist;        
        }

      
    }
}
