using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports.TestWpf.Models
{
    /// <summary> Географические координаты </summary>
    public class GeoPoint
    {
        #region Поля
        private decimal _Latitude;
        private decimal _Longitude;
        #endregion

        /// <summary>Широта</summary>
        public decimal Latitude 
        {
            get => _Latitude;
             set 
            {
                if (value > 90.0m || value < -90.0m)
                    throw new ArgumentOutOfRangeException("Широта может задаваться в диапазоне от -90 до +90");
                _Latitude = value;
            } 
        }
        /// <summary>Долгота</summary>
        public decimal Longitude
        {
            get => _Longitude;
             set
            {
                if (value > 180.0m || value < -180.0m)
                    throw new ArgumentOutOfRangeException("Долгота может задаваться в диапазоне от -180 до +180");
                _Longitude = value;
            }
        }

        /// <summary> Географические координаты </summary>
        /// <param name="latitude">Широта</param>
        /// <param name="longitude">Долгота</param>
        public GeoPoint(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
