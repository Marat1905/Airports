using Airports.DAL.Entityes;
using Airports.Interfaces;
using Airports.TestWpf.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
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

            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@latitude",

                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 25,
                            Scale = 16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = (decimal)point.Latitude
                        },
                        new SqlParameter() {
                            ParameterName = "@longitude",
                            SqlDbType =  System.Data.SqlDbType.Decimal,
                            Precision = 25,
                            Scale = 16,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = (decimal)point.Longitude
                        },
                        new SqlParameter() {
                            ParameterName = "@distance",
                            SqlDbType =  System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = distance
                        }};

            result = _Airports.SqlRawQuery("SELECT * FROM(SELECT* ," +
                "(6371.0 * 2.0 * ASIN(" +
                "SQRT(" +
                "POWER(" +
                "SIN(([LatitudeDeg] - ABS(@latitude)) * PI() / 180 / 2), 2) +" +
                "COS([LatitudeDeg] * PI() / 180) *" +
                "COS(ABS(@latitude) * PI() / 180) *" +
                "POWER(SIN(([LongitudeDeg] - @longitude) * PI() / 180 / 2), 2)))) as distance" +
                " FROM[dbo].[Airports] ) p where distance < @distance ORDER BY abs(distance), distance desc", param).ToList();
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
