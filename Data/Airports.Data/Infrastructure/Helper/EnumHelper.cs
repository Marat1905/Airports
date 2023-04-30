using System;
using System.ComponentModel;
using System.Reflection;

namespace Airports.Data.Infrastructure.Helper
{
    internal static class EnumHelper
    {      
        
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0
              ? (T)attributes[0]
              : null;
        }

        /// <summary>
        /// Из перечисления получаем его атрибут
        /// </summary>
        /// <param name="value">Перечисления</param>
        /// <returns> Атрибут </returns>
        public static string ToName(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }
  
        /// <summary>
        /// Получаем из атрибута именованную константу перечисления
        /// </summary>
        /// <param name="type">Тип перечисления</param>
        /// <param name="description">Атрибут именованной константы </param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static FieldInfo GetValueFromDescription(Type type, string description)
        {
            if (!type.IsEnum)
                throw new ArgumentException();
            FieldInfo[] fields = type.GetFields();
            var field = fields
                       .SelectMany(f => f.GetCustomAttributes(
                           typeof(DescriptionAttribute), false), (
                               f, a) => new { Field = f, Att = a })
                       .Where(a => ((DescriptionAttribute)a.Att)
                           .Description == description).SingleOrDefault();
            return field == null ? default : field.Field;
        }

        /// <summary>Получаем атрибут </summary>
        /// <param name="type"></param>
        /// <param name="value">Перечислитель</param>
        /// <returns>возвращаем атрибут</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GetDescription(Type type, object value)
        {
            if (!type.IsEnum)
                throw new ArgumentException();
            FieldInfo[] fields = type.GetFields();
            var field = fields
                       .SelectMany(f => f.GetCustomAttributes(
                           typeof(DescriptionAttribute), false), (
                               f, a) => new { Field = f, Att = a })
                       .Where(f => ((FieldInfo)f.Field)
                           .Name == value.ToString()).SingleOrDefault();
            if(field.Att is DescriptionAttribute attribute)
            return attribute.Description; 
           return null;
        }
    }
}
