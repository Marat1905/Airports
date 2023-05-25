using Airports.Data.Infrastructure.Attributes;
using Airports.Data.Infrastructure.Helper;
using Airports.Data.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Airports.Data.Infrastructure.Extensions
{
    public static class ToCsvFieldsExtension
    {
        public static string ToCsvFields<T>(this IReadAirportsCsvService readAirportsCsv, T fields, string separator = ",") where T : class, new()
        {
            StringBuilder line = new StringBuilder();
            PropertyInfo[] propertyInfo = fields.GetType().GetProperties();

            foreach (var p in propertyInfo)
            {
                if (line.Length > 0)
                    line.Append(separator);
                var x = p.GetValue(fields);
                // Получаем атрибуты
                CsvAttribute attribute =
                                   Attribute.GetCustomAttribute(p, typeof(CsvAttribute)) as CsvAttribute;

                if (p.PropertyType.IsEnum)
                {
                    line.Append($"{EnumHelper.GetDescription(p.PropertyType, x)}");
                }
                else if (p.PropertyType.IsValueType)
                {
                    Type t = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
                    object safeValue = string.IsNullOrEmpty(x?.ToString()) ? null : Convert.ChangeType(x, t, CultureInfo.InvariantCulture);
                    line.Append($"{safeValue?.ToString().Replace(",", ".").ToString()}");
                }
                else if (x != null)
                {
                    line.Append($"{x.ToString()}");
                }

            }
            return line.ToString();
        }
    }
}
