
using System.Globalization;
using System;
using System.Windows.Data;
using System.Windows.Markup;
using YandexAPI.Mаps;

namespace Airports.TestWpf.Infrastructure.Converters
{
    [ValueConversion(typeof(GeoPoint), typeof(string))]
    [MarkupExtensionReturnType(typeof(LocationPointToStr))]
    internal class LocationPointToStr:Converter
    {
        public override object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (!(value is GeoPoint point)) return null;

            return $"{point.Latitude},{point.Longitude}";
        }

        public override object ConvertBack(object value, Type y, object p, CultureInfo c)
        {
            if (!(value is string str)) return null;

            var components = str.Split(',');
            var lat_str = components[0].Split(':')[0];
            var lon_str = components[1].Split(':')[0];

            var lat = double.Parse(lat_str, CultureInfo.InvariantCulture.NumberFormat);
            var lon = double.Parse(lon_str, CultureInfo.InvariantCulture.NumberFormat);

            return new GeoPoint(lat, lon);
        }
    }
}
