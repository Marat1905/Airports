using Airports.DAL.Entityes.Base;
using Airports.Lib.Enums;

namespace Airports.DAL.Entityes
{
    /// <summary>Регион.</summary>
    public class Region : Entity
    {
        /// <summary>
        /// local_code с префиксом кода страны для создания глобального уникального идентификатора
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Местный код административной единицы. Когда это возможно, это официальные стандарты ISO 3166:2 самого высокого доступного уровня, 
        /// но в некоторых случаях нашим аэропортам приходится использовать неофициальные коды. 
        /// </summary>
        public string LocalCode { get; set; }

        /// <summary>
        /// Распространенное англоязычное название административной единицы. В некоторых случаях имя на местном языке будет отображаться в поле ключевых слов для облегчения поиска.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код континента, к которому относится регион. См. поле континента в airports.csv для списка кодов
        /// </summary>
        public ContinentCode Continent { get; set; }

        /// <summary>
        /// Двух символьный код ISO 3166:1-alpha2 для страны, содержащей административное подразделение.
        /// </summary>
        public string IsoCountry { get; set; }

        /// <summary>
        /// Ссылка на статью в Википедии с описанием подразделения.
        /// </summary>
        public string WikipediaLink { get; set; }

        /// <summary>
        /// Список ключевых слов, разделенных запятыми, для облегчения поиска. Может включать прежние названия региона и/или название региона на других языках.
        /// </summary>
        public string Keywords { get; set; }
    }
}
