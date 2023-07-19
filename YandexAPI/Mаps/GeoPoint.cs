using System;

namespace YandexAPI.Mаps
{
    /// <summary> Географические координаты </summary>
    public class GeoPoint
    {
        #region Поля
        private double _Latitude;
        private double _Longitude;
        #endregion

        /// <summary>Широта</summary>
        public double Latitude 
        {
            get => _Latitude;
             set 
            {
                if (value > 90.0 || value < -90.0)
                    throw new ArgumentOutOfRangeException("Широта может задаваться в диапазоне от -90 до +90");
                _Latitude = value;
            } 
        }
        /// <summary>Долгота</summary>
        public double Longitude
        {
            get => _Longitude;
             set
            {
                if (value > 180.0 || value < -180.0)
                    throw new ArgumentOutOfRangeException("Долгота может задаваться в диапазоне от -180 до +180");
                _Longitude = value;
            }
        }

        /// <summary> Географические координаты </summary>
        /// <param name="latitude">Широта</param>
        /// <param name="longitude">Долгота</param>
        public GeoPoint(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()=> FormattableString.Invariant($"{Longitude},{Latitude}");

        public static bool operator == (GeoPoint point1, GeoPoint point2)
        {
           if(point1.Longitude==point2.Longitude && point1.Latitude == point2.Latitude)
                return true;
            else
                return false;          
        }
        public static bool operator !=(GeoPoint point1, GeoPoint point2)
        {
            if (point1.Longitude == point2.Longitude && point1.Latitude == point2.Latitude)
                return false;
            else
                return true;
        }
    }
}
