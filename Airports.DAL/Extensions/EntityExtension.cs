using Airports.DAL.Entityes;
using Airports.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Airports.DAL.Extensions
{
    public static class EntityExtension
    {
        /// <summary>Маппинг данных из БД в модель CSV </summary>
        /// <typeparam name="TSource"> Источник модель БД</typeparam>
        /// <typeparam name="TTarget">Целевая модель CSV</typeparam>
        /// <param name="Source">Источник модель БД</param>
        /// <returns>Возвращаем модель CSV</returns>
        public static TTarget ModelMapInfo<TSource, TTarget>(this TSource Source) where TTarget : class, new()
                                                                              where TSource : class, IEntity, new()
        {
            // Cоздаем объект
            var target = new TTarget();
            // Получает свойства объекта цель
            PropertyInfo[] propertiesTarget = target.GetType().GetProperties();
            // Получает свойства объекта источник
            PropertyInfo[] propertiesSource = Source.GetType().GetProperties();
            foreach (PropertyInfo propertyTarget in propertiesTarget)
            {
                foreach (var propertySource in propertiesSource)
                {
                    if (propertyTarget.PropertyType == propertySource.PropertyType)
                    {
                        if (propertyTarget.Name == propertySource.Name)
                        {
                            SetPropertyValue(target, Source, propertySource, propertyTarget);
                            break;
                        }
                    }

                }

            }
            return target;
        }
        /// <summary>Маппинг данных из модели CSV в модель БД</summary>
        /// <typeparam name="TSource"> Модель CSV</typeparam>
        /// <typeparam name="TTarget">Целевая модель БД</typeparam>
        /// <param name="Source">Модель CSV</param>
        /// <returns>Возвращаем модель БД</returns>
        public static TTarget ModelMap<TSource, TTarget>(this TSource Source) where TSource : class, new()
                                                                             where TTarget : class, IEntity, new()
        {
            // Cоздаем объект
            var target = new TTarget();
            // Получает свойства объекта цель
            PropertyInfo[] propertiesTarget = target.GetType().GetProperties();
            // Получает свойства объекта источник
            PropertyInfo[] propertiesSource = Source.GetType().GetProperties();
            foreach (PropertyInfo propertyTarget in propertiesTarget)
            {
                foreach (var propertySource in propertiesSource)
                {
                    if (propertyTarget.PropertyType == propertySource.PropertyType)
                    {
                        if (propertyTarget.Name == propertySource.Name)
                        {
                            SetPropertyValue(target, Source, propertySource, propertyTarget);
                            break;
                        }
                    }
                }
            }

            return target;
        }
        private static void SetPropertyValue<TSource, TTarget>(TTarget Result, TSource Source, PropertyInfo SourceInfo, PropertyInfo Target)
        {
            if (Target.PropertyType.IsEnum)
            {
                Type enumType = SourceInfo.PropertyType;
                var en = enumType.GetFields();
                object underlyingValue = Convert.ChangeType(SourceInfo.GetValue(Source), Enum.GetUnderlyingType(SourceInfo.GetValue(Source).GetType()));
                Target.SetValue(Result, underlyingValue,null);
            }
            else
            {
                Type t = Nullable.GetUnderlyingType(SourceInfo.PropertyType) ?? SourceInfo.PropertyType;
               // object safeValue = string.IsNullOrEmpty((string)SourceInfo.GetValue(Source)) ? null : Convert.ChangeType(SourceInfo.GetValue(Source), t, CultureInfo.InvariantCulture);
                Target.SetValue(Result, SourceInfo.GetValue(Source), null);
            }
        }


    }
}
