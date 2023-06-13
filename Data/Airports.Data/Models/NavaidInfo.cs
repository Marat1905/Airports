using Airports.Data.Infrastructure.Attributes;
using Airports.Data.Infrastructure.Helper;
using Airports.Lib.Enums;

namespace Airports.Data.Models
{
    /// <summary>Навигационное средство. </summary>
    public class NavaidInfo
    {
        /// <summary>
        /// Внутренний целочисленный идентификатор OurAirports для навигационного средства. Это останется постоянным, даже если идентификатор навигационного средства или частота изменятся.
        /// </summary>
        [Csv("id")]
        public int Identificator { get; set; }

        /// <summary>
        /// Это уникальный строковый идентификатор, составленный из названия навигационного средства и страны и используемый в URL-адресе OurAirports.
        /// </summary>
        [Csv("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// Идентификатор из 1-3 символов, который передает навигационное средство.
        /// </summary>
        [Csv("ident")]
        public string Ident { get; set; }

        /// <summary>
        /// Название навигационного средства, исключая его тип.
        /// </summary>
        [Csv("name")]
        public string Name { get; set; }

        /// <summary>
        /// Тип навигационного средства. 
        /// </summary>
        [Csv("type")]
        public RadioNavigationAids Type { get; set; }

        /// <summary>
        /// Частота навигационного средства в килогерцах . Если навигационное средство работает в диапазоне УКВ (VOR, VOR-DME) или работает в диапазоне УВЧ с парной частотой УКВ (DME, TACAN, VORTAC), то вам нужно разделить это число на 1000, чтобы получить частоту в мегагерцах ( 115,3 МГц в этом примере). Для NDB или NDB-DME вы можете использовать эту частоту напрямую.
        /// </summary>
        [Csv("frequency_khz")]
        public int? FrequencyKhz { get; set; }

        /// <summary>
        /// Широта навигационного средства в десятичных градусах (отрицательная для юга).
        /// </summary>
        [Csv("latitude_deg")]
        public double? LatitudeDeg { get; set; }

        /// <summary>
        /// Долгота навигационного средства в десятичных градусах (отрицательная для запада).
        /// </summary>
        [Csv("longitude_deg")]
        public double? LongitudeDeg { get; set; }

        /// <summary>
        /// Высота навигационного средства над уровнем моря в футах (не в метрах).
        /// </summary>
        [Csv("elevation_ft")]
        public int? ElevationFt { get; set; }

        /// <summary>
        /// Двухсимвольный код ISO 3166:1-alpha2 для страны, в которой эксплуатируется навигационное средство. Также используется несколько неофициальных кодов, не относящихся к ISO, например «XK» для Косово .
        /// </summary>
        [Csv("iso_country")]
        public string IsoCountry { get; set; }

        /// <summary>
        /// Парная частота VHF для DME (или TACAN) в килогерцах. Разделите на 1000, чтобы получить парную частоту VHF в мегагерцах (например, 115,3 МГц).
        /// </summary>
        [Csv("dme_frequency_khz")]
        public int? DmeFrequencyKhz { get; set; }

        /// <summary>
        /// Канал DME (альтернативный способ настройки дальномерной аппаратуры).
        /// </summary>
        [Csv("dme_channel")]
        public string DmeChannel { get; set; }

        /// <summary>
        /// Широта соответствующего DME в десятичных градусах (отрицательное значение для юга). Если отсутствует, предположим, что значение такое же, как latitude_deg .
        /// </summary>
        [Csv("dme_latitude_deg")]
        public double? DmeLatitudeDeg { get; set; }

        /// <summary>
        /// Долгота соответствующего DME в десятичных градусах (отрицательная для запада). Если отсутствует, предположим, что значение совпадает с longitude_deg .
        /// </summary>
        [Csv("dme_longitude_deg")]
        public double? DmeLongitudeDeg { get; set; }

        /// <summary>
        /// Высота над уровнем моря соответствующих передатчиков DME в футах. Если отсутствует, предположим, что это то же значение, что и высота_фута .
        /// </summary>
        [Csv("dme_elevation_ft")]
        public int? DmeElevationFt { get; set; }

        /// <summary>
        /// Регулировка магнитного склонения, встроенная в радиалы VOR, VOR-DME или TACAN. Положительное значение означает восток (прибавленное к истинному направлению), а отрицательное значение означает запад (вычтенное из истинного направления). Обычно это не то же самое, что магнитная вариация , потому что магнитный полюс постоянно находится в движении.
        /// </summary>
        [Csv("slaved_variation_deg")]
        public double? SlavedVariationDeg { get; set; }

        /// <summary>
        /// Фактическое магнитное склонение в месте расположения навигационного средства. Положительное значение означает восток (прибавленное к истинному направлению), а отрицательное значение означает запад (вычтенное из истинного направления).
        /// </summary>
        [Csv("magnetic_variation_deg")]
        public double? MagneticVariationDeg { get; set; }

        /// <summary>
        /// Основная функция навигационных средств в системе воздушного пространства. Варианты включают «HI» (высотные воздушные трассы, на эшелоне полета 180 или выше), «LO» (низковысотные воздушные трассы), «BOTH» (высотные и малые воздушные трассы), «TERM» (терминальная навигация). только) и "RNAV" (зональная навигация без GPS).
        /// </summary>
        [Csv("usageType")]
        public string UsageType { get; set; }

        /// <summary>
        /// Уровень выходной мощности навигационного средства. Варианты включают «ВЫСОКИЙ», «СРЕДНИЙ», «НИЗКИЙ» и «НЕИЗВЕСТНО».
        /// </summary>
        [Csv("power")]
        public string Power { get; set; }

        /// <summary>
        /// Текстовый идентификатор OurAirports (обычно код ИКАО) для аэропорта, связанного с навигационным средством. Ссылки на столбец ident в airports.csv .
        /// </summary>
        [Csv("associated_airport")]
        public string AssociatedAirport { get; set; }

        public override string ToString()
        {
            return $"{Identificator} ; {Filename} ; {Ident} ; {Name} ; {Type.ToName()} ; {FrequencyKhz} ; {LatitudeDeg} ; {LongitudeDeg} ; {ElevationFt} ; {IsoCountry} ; " +
                $"{DmeFrequencyKhz} ; {DmeChannel} ; {DmeLatitudeDeg} ; {DmeLongitudeDeg} ; {DmeElevationFt} ; {SlavedVariationDeg} ; {MagneticVariationDeg} ; " +
                $"{UsageType} ; {Power} ; {AssociatedAirport}";
        }
    }
}
