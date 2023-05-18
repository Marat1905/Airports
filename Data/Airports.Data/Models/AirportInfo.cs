using Airports.Data.Infrastructure.Attributes;
using Airports.Data.Infrastructure.Helper;
using Airports.Lib.Enums;

namespace Airports.Data.Models
{
    /// <summary>Аэропорт. </summary>
    public class AirportInfo
    {
        /// <summary>
        /// Внутренний целочисленный идентификатор OurAirports для аэропорта.
        /// Это останется постоянным, даже если код аэропорта изменится.
        /// </summary>
        [Csv("id")]
        public int Identificator { get; set; }

        /// <summary>Текстовый идентификатор, используемый в URL-адресе OurAirports.
        /// Это будет код ИКАО, если таковой имеется. 
        /// В противном случае это будет местный код аэропорта (если нет конфликта) 
        /// или, если ничего другого не доступно, внутренне с генерированный код, 
        /// начинающийся с кода страны ISO2, за которым следует тире и четырехзначное 
        /// число. </summary>
        [Csv("ident")]
        public string Ident { get; set; }

        /// <summary>
        /// Тип аэропорта. Допустимые значения: «closed_airport», «heliport»,
        /// «large_airport», «medium_airport», «seeaplane_base» и «small_airport».
        /// См. легенду карты для определения каждого типа.
        /// </summary>
        [Csv("type")]
        public TypeAirport Type { get; set; }

        /// <summary>
        /// Официальное название аэропорта, включая «Аэропорт», «Взлетно-посадочная полоса» и т. д.
        /// </summary>
        [Csv("name")]
        public string Name { get; set; }

        /// <summary>
        /// Широта аэропорта в градусах (положительное значение для севера).
        /// </summary>
        [Csv("latitude_deg")]
        public double? LatitudeDeg { get; set; }

        /// <summary>
        /// Долгота аэропорта в градусах (положительная для востока).
        /// </summary>
        [Csv("longitude_deg")]
        public double? LongitudeDeg { get; set; }

        /// <summary>
        /// Высота аэропорта над уровнем моря в футах ( не в метрах).
        /// </summary>
        [Csv("elevation_ft")]
        public int? ElevationFt { get; set; }

        /// <summary>
        /// Код континента, на котором (в основном) расположен аэропорт.
        /// </summary>
        [Csv("continent")]
        public ContinentCode Continent { get; set; }

        //TODO: Изменить код страны.
        /// <summary>
        /// Двухсимвольный код ISO 3166:1-alpha2 для страны, в которой (в основном) 
        /// расположен аэропорт. Также используется несколько неофициальных кодов,
        /// не относящихся к ISO, например «XK» для Косово . 
        /// Указывает на столбец кода в country.csv .
        /// </summary>
        [Csv("iso_country")]
        public string IsoCountry { get; set; }

        //TODO: Изменить код региона.
        /// <summary>
        /// Буквенно-цифровой код административной единицы высокого уровня страны,
        /// в которой в основном расположен аэропорт (например, провинция, мухафаза),
        /// с префиксом кода страны ISO2 и дефисом.
        /// Наши аэропорты по возможности используют коды ISO 3166:2 , 
        /// отдавая предпочтение более высоким административным уровням,
        /// но также включают некоторые пользовательские коды. См. документацию по region.csv .
        /// </summary>   
        [Csv("iso_region")]
        public string IsoRegion { get; set; }

        /// <summary>
        /// Основной муниципалитет, который обслуживает аэропорт (при наличии). 
        /// Обратите внимание, что это не обязательно муниципалитет, 
        /// в котором физически расположен аэропорт.
        /// </summary>
        [Csv("municipality")]
        public string Municipality { get; set; }

        //TODO: Можно попробовать Enum.
        /// <summary>
        /// «да», если аэропорт в настоящее время обслуживает регулярные авиалинии; "нет" иначе.
        /// </summary>
        [Csv("scheduled_service")]
        public string ScheduledService { get; set; }

        /// <summary>
        /// Код, который авиационная база данных GPS (например, Jeppesen или Garmin)
        /// обычно использует для аэропорта. Это всегда будет код ИКАО , 
        /// если он существует. Обратите внимание, что, в отличие от столбца ident ,
        /// глобально уникальность этого столбца не гарантируется.
        /// </summary>
        [Csv("gps_code")]
        public string GpsCode { get; set; }

        //TODO: Проверить. код IATA
        /// <summary>
        /// Трех буквенный код IATA аэропорта (если он есть).
        /// </summary>
        [Csv("iata_code")]
        public string IataCode { get; set; }

        /// <summary>
        /// Местный код страны для аэропорта, если он отличается от полей gps_code и iata_code (используется в основном для аэропортов США).
        /// </summary>
        [Csv("local_code")]
        public string LocalCode { get; set; }

        /// <summary>
        /// URL-адрес официальной домашней страницы аэропорта в Интернете, если таковая существует.
        /// </summary>
        [Csv("home_link")]
        public string HomeLink { get; set; }

        /// <summary>
        /// URL-адрес страницы аэропорта в Википедии, если таковая существует.
        /// </summary>
        [Csv("wikipedia_link")]
        public string WikipediaLink { get; set; }

        /// <summary>
        /// Дополнительные ключевые слова/фразы для облегчения поиска, 
        /// разделенные запятыми. Может включать прежние названия аэропорта,
        /// альтернативные коды, названия на других языках, 
        /// близлежащие туристические направления и т. д.
        /// </summary>
        [Csv("keywords")]
        public string Keywords { get; set; }


        public override string ToString()
        {
            return $"{Identificator} ; {Ident} ; {Type.ToName()} ; {Name} ;" +
                $" {LatitudeDeg} ; {LongitudeDeg} ; {ElevationFt} ; {Continent} ; " +
                $"{IsoCountry} ; {IsoRegion} ; {Municipality} ; {ScheduledService} ; " +
                $"{GpsCode} ; {IataCode} ; {LocalCode} ; {HomeLink} ; {WikipediaLink} ; {Keywords}";
        }
    }
}
