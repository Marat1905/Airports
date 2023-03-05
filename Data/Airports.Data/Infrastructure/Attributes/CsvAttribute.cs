using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports.Data.Infrastructure.Attributes
{
    // <summary>
    /// Представляет атрибут для сериализации полей и свойств экземпляра объекта CSV.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class CsvAttribute : Attribute
    {
        /// <summary>
        /// Имя свойства или поля.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CsvAttribute"/>.
        /// </summary>
        /// <param name="name">Имя свойства или поля.</param>
        public CsvAttribute(string name) => Name = name;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CsvAttribute"/>.
        /// </summary>
        public CsvAttribute() : this(null) { }
    }
}
