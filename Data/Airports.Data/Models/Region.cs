using Airports.Data.Enums;
using Airports.Data.Infrastructure.Attributes;
using Airports.Data.Infrastructure.Helper;

namespace Airports.Data.Models
{
    /// <summary>Регион.</summary>
    public class Region
    {
        /// <summary>
        /// Внутренний целочисленный идентификатор OurAirports для региона. 
        /// Это останется постоянным, даже если код региона изменится.
        /// </summary>
        [Csv("id")]
        public int Id { get; set; }

        /// <summary>
        /// local_code с префиксом кода страны для создания глобального уникального идентификатора
        /// </summary>
        [Csv("code")]
        public string Code { get; set; }

        /// <summary>
        /// Местный код административной единицы. Когда это возможно, это официальные стандарты ISO 3166:2 самого высокого доступного уровня, 
        /// но в некоторых случаях нашим аэропортам приходится использовать неофициальные коды. 
        /// </summary>
        [Csv("local_code")]
        public string LocalCode { get; set; }

        /// <summary>
        /// Распространенное англоязычное название административной единицы. В некоторых случаях имя на местном языке будет отображаться в поле ключевых слов для облегчения поиска.
        /// </summary>
        [Csv("name")]
        public string Name { get; set; }

        /// <summary>
        /// Код континента, к которому относится регион. См. поле континента в airports.csv для списка кодов
        /// </summary>
        [Csv("continent")]
        public ContinentCode Continent { get; set; }

        /// <summary>
        /// Двух символьный код ISO 3166:1-alpha2 для страны, содержащей административное подразделение.
        /// </summary>
        [Csv("iso_country")]
        public string IsoCountry { get; set; }

        /// <summary>
        /// Ссылка на статью в Википедии с описанием подразделения.
        /// </summary>
        [Csv("wikipedia_link")]
        public string WikipediaLink { get; set; }

        /// <summary>
        /// Список ключевых слов, разделенных запятыми, для облегчения поиска. Может включать прежние названия региона и/или название региона на других языках.
        /// </summary>
        [Csv("keywords")]
        public string Keywords { get; set; }

        public override string ToString()
        {
            return $"{Id} ; {Code} ; {LocalCode} ; {Name} ; {Continent.ToName()} ; {IsoCountry} ; {WikipediaLink} ; {Keywords} ";
        }
    }
}
