using Airports.DAL.Entityes.Base;
using Airports.Lib.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airports.DAL.Entityes
{
    /// <summary>Аэропорт. </summary>
    public class Airport:Entity
    {
        /// <summary>Текстовый идентификатор, используемый в URL-адресе OurAirports.
        /// Это будет код ИКАО, если таковой имеется. 
        /// В противном случае это будет местный код аэропорта (если нет конфликта) 
        /// или, если ничего другого не доступно, внутренне с генерированный код, 
        /// начинающийся с кода страны ISO2, за которым следует тире и четырехзначное 
        /// число. </summary>
        public string Ident { get; set; }

        /// <summary>
        /// Тип аэропорта. Допустимые значения: «closed_airport», «heliport»,
        /// «large_airport», «medium_airport», «seeaplane_base» и «small_airport».
        /// См. легенду карты для определения каждого типа.
        /// </summary>
        public TypeAirport Type { get; set; }

        /// <summary>
        /// Официальное название аэропорта, включая «Аэропорт», «Взлетно-посадочная полоса» и т. д.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Широта аэропорта в градусах (положительное значение для севера).
        /// </summary>
        [Column(TypeName ="float")]
        public decimal? LatitudeDeg { get; set; }

        /// <summary>
        /// Долгота аэропорта в градусах (положительная для востока).
        /// </summary>
        public double? LongitudeDeg { get; set; }

        /// <summary>
        /// Высота аэропорта над уровнем моря в футах ( не в метрах).
        /// </summary>
        public int? ElevationFt { get; set; }

        /// <summary>
        /// Код континента, на котором (в основном) расположен аэропорт.
        /// </summary>
        public ContinentCode Continent { get; set; }

        /// <summary>
        /// Двухсимвольный код ISO 3166:1-alpha2 для страны, в которой (в основном) 
        /// расположен аэропорт. Также используется несколько неофициальных кодов,
        /// не относящихся к ISO, например «XK» для Косово . 
        /// Указывает на столбец кода в country.csv .
        /// </summary>
        public string IsoCountry { get; set; }

        /// <summary>
        /// Буквенно-цифровой код административной единицы высокого уровня страны,
        /// в которой в основном расположен аэропорт (например, провинция, мухафаза),
        /// с префиксом кода страны ISO2 и дефисом.
        /// Наши аэропорты по возможности используют коды ISO 3166:2 , 
        /// отдавая предпочтение более высоким административным уровням,
        /// но также включают некоторые пользовательские коды. См. документацию по region.csv .
        /// </summary>   
        public string IsoRegion { get; set; }

        /// <summary>
        /// Основной муниципалитет, который обслуживает аэропорт (при наличии). 
        /// Обратите внимание, что это не обязательно муниципалитет, 
        /// в котором физически расположен аэропорт.
        /// </summary>
        public string Municipality { get; set; }

        /// <summary>
        /// «да», если аэропорт в настоящее время обслуживает регулярные авиалинии; "нет" иначе.
        /// </summary>
        public string ScheduledService { get; set; }

        /// <summary>
        /// Код, который авиационная база данных GPS (например, Jeppesen или Garmin)
        /// обычно использует для аэропорта. Это всегда будет код ИКАО , 
        /// если он существует. Обратите внимание, что, в отличие от столбца ident ,
        /// глобально уникальность этого столбца не гарантируется.
        /// </summary>
        public string GpsCode { get; set; }

        //TODO: Проверить. код IATA
        /// <summary>
        /// Трех буквенный код IATA аэропорта (если он есть).
        /// </summary>
        public string IataCode { get; set; }

        /// <summary>
        /// Местный код страны для аэропорта, если он отличается от полей gps_code и iata_code (используется в основном для аэропортов США).
        /// </summary>
        public string LocalCode { get; set; }

        /// <summary>
        /// URL-адрес официальной домашней страницы аэропорта в Интернете, если таковая существует.
        /// </summary>
        public string HomeLink { get; set; }

        /// <summary>
        /// URL-адрес страницы аэропорта в Википедии, если таковая существует.
        /// </summary>
        public string WikipediaLink { get; set; }

        /// <summary>
        /// Дополнительные ключевые слова/фразы для облегчения поиска, 
        /// разделенные запятыми. Может включать прежние названия аэропорта,
        /// альтернативные коды, названия на других языках, 
        /// близлежащие туристические направления и т. д.
        /// </summary>
        public string Keywords { get; set; }

    }
}
