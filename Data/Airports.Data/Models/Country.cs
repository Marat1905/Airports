using Airports.Data.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports.Data.Models
{
    /// <summary>Страна </summary>
    public class Country
    {
        /// <summary>
        /// Внутренний целочисленный идентификатор OurAirports для страны.
        /// </summary>
        [Csv("id")]
        public int Id { get; set; }

        /// <summary>
        /// Двух символьный код страны по стандарту ISO 3166:1-alpha2 . Также используется несколько неофициальных кодов, не относящихся к ISO, например «XK» для Косово .
        /// </summary>
        [Csv("code")]
        public string? Code { get; set; }

        /// <summary>
        /// Распространенное англоязычное название страны.
        /// </summary>
        [Csv("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Код континента, на котором (в основном) расположена страна.
        /// </summary>
        [Csv("continent")]
        public string? Continent { get; set; }

        /// <summary>
        /// Ссылка на статью в Википедии о стране.
        /// </summary>
        [Csv("wikipedia_link")]
        public string? WikipediaLink { get; set; }

        /// <summary>
        /// Разделенный запятыми список ключевых слов/фраз для поиска, относящихся к стране.
        /// </summary>
        [Csv("keywords")]
        public string? Keywords { get; set; }



        public override string ToString()
        {
            return $"{Id} ; {Code} ; {Name} ; {Continent} ; {WikipediaLink} ; {Keywords} ";
        }

       
    }
}
