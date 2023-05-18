using Airports.Data.Infrastructure.Attributes;
using Airports.Data.Infrastructure.Helper;
using Airports.Lib.Enums;

namespace Airports.Data.Models
{
    /// <summary>Страна </summary>
    public class CountryInfo
    {
        /// <summary>
        /// Внутренний целочисленный идентификатор OurAirports для страны.
        /// </summary>
        [Csv("id")]
        public int Identificator { get; set; }

        /// <summary>
        /// Двух символьный код страны по стандарту ISO 3166:1-alpha2 . Также используется несколько неофициальных кодов, не относящихся к ISO, например «XK» для Косово .
        /// </summary>
        [Csv("code")]
        public string Code { get; set; }

        /// <summary>
        /// Распространенное англоязычное название страны.
        /// </summary>
        [Csv("name")]
        public string Name { get; set; }

        /// <summary>
        /// Код континента, на котором (в основном) расположена страна.
        /// </summary>
        [Csv("continent")]
        public ContinentCode Continent { get; set; }

        /// <summary>
        /// Ссылка на статью в Википедии о стране.
        /// </summary>
        [Csv("wikipedia_link")]
        public string WikipediaLink { get; set; }

        /// <summary>
        /// Разделенный запятыми список ключевых слов/фраз для поиска, относящихся к стране.
        /// </summary>
        [Csv("keywords")]
        public string Keywords { get; set; }



        public override string ToString()
        {
            return $"{Identificator} ; {Code} ; {Name} ; {Continent.ToName()} ; {WikipediaLink} ; {Keywords} ";
        }


    }
}
