using Airports.DAL.Entityes.Base;
using Airports.Lib.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airports.DAL.Entityes
{
    /// <summary>Страна </summary>
    [Table("Countries")]
    public class CountryDBModel : Entity
    {
        /// <summary>
        /// Двух символьный код страны по стандарту ISO 3166:1-alpha2 . Также используется несколько неофициальных кодов, не относящихся к ISO, например «XK» для Косово .
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Распространенное англоязычное название страны.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Код континента, на котором (в основном) расположена страна.
        /// </summary>
        public ContinentCode Continent { get; set; }

        /// <summary>
        /// Ссылка на статью в Википедии о стране.
        /// </summary>
        public string? WikipediaLink { get; set; }

        /// <summary>
        /// Разделенный запятыми список ключевых слов/фраз для поиска, относящихся к стране.
        /// </summary>
        public string? Keywords { get; set; }
    }
}
