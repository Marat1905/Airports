using Airports.Data.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports.Data.Models
{
    /// <summary>Взлетно посадочная полоса </summary>
    public class Runway
    {
        /// <summary>
        /// целочисленный идентификатор взлетно-посадочной полосы в OurAirports. Это останется постоянным, даже если нумерация взлетно-посадочных полос изменится.
        /// </summary>
        [Csv("id")]
        public int Id { get; set; }

        /// <summary>
        /// Внутренний целочисленный внешний ключ, соответствующий столбцу id для связанного аэропорта в airports.csv . ( airport_ident является лучшей альтернативой.)
        /// </summary>
        [Csv("airport_ref")]
        public int AirportRef { get; set; }

        /// <summary>
        /// Видимая извне строка внешнего ключа, соответствующая столбцу ident для связанного аэропорта в airports.csv 
        /// </summary>
        [Csv("airport_ident")]
        public string? AirportIdent { get; set; }

        /// <summary>
        /// Длина всей поверхности взлетно-посадочной полосы (включая смещенные пороги, зоны выбега и т. д.) в футах.
        /// </summary>
        [Csv("length_ft")]
        public int? LengthFt { get; set; }

        /// <summary>
        /// Ширина поверхности взлетно-посадочной полосы в футах.
        /// </summary>
        [Csv("width_ft")]
        public int? WidthFt { get; set; }

        /// <summary>
        /// Код типа покрытия взлетно-посадочной полосы. Это еще не контролируемый словарь, но, вероятно, скоро будет. Некоторые общие значения включают «ASP» (асфальт), «TURF» (дерн), «CON» (бетон), «GRS» (трава), «GRE» (гравий), «WATER» (вода) и «UNK». (неизвестный).
        /// </summary>
        [Csv("surface")]
        public string? Surface { get; set; }

        /// <summary>
        /// 1, если поверхность освещена ночью, 0 в противном случае. (Обратите внимание, что это не соответствует файлу airports.csv, в котором вместо 1 и 0 используются «да» и «нет».)
        /// </summary>
        [Csv("lighted")]
        public int? Lighted { get; set; }

        /// <summary>
        ///1, если поверхность взлетно-посадочной полосы в настоящее время закрыта, 0 в противном случае.
        /// </summary>
        [Csv("closed")]
        public int? Closed { get; set; }

        /// <summary>
        /// Идентификатор конца взлетно-посадочной полосы с меньшим номером.
        /// </summary>
        [Csv("le_ident")]
        public string? LeIdent { get; set; }

        /// <summary>
        /// Широта центра конца взлетно-посадочной полосы с низким номером в десятичных градусах (положительное значение означает север), если доступно.
        /// </summary>
        [Csv("le_latitude_deg")]
        public double? LeLatitudeDeg { get; set; }

        /// <summary>
        /// Долгота центра конца взлетно-посадочной полосы с низким номером в десятичных градусах (положительное значение означает восток), если доступно.
        /// </summary>
        [Csv("le_longitude_deg")]
        public double? LeLongitudeDeg { get; set; }

        /// <summary>
        /// Высота над уровнем моря конца взлетно-посадочной полосы с низким номером в футах.
        /// </summary>
        [Csv("le_elevation_ft")]
        public int? LeElevationFt { get; set; }

        /// <summary>
        /// Курс конца взлетно-посадочной полосы с меньшим номером в градусах истинного ( не магнитного).
        /// </summary>
        [Csv("le_heading_degT")]
        public double? LeHeadingDegT { get; set; }

        /// <summary>
        /// Длина смещенного порога (если есть) конца взлетно-посадочной полосы с меньшим номером в футах.
        /// </summary>
        [Csv("le_displaced_threshold_ft")]
        public int? LeDisplacedThresholdFt { get; set; }

        /// <summary>
        /// Идентификатор конца взлетно-посадочной полосы с большим номером.
        /// </summary>
        [Csv("he_ident")]
        public string? HeIdent { get; set; }

        /// <summary>
        /// Широта центра конца взлетно-посадочной полосы с высоким номером в десятичных градусах (положительное значение означает север), если доступно.
        /// </summary>
        [Csv("he_latitude_deg")]
        public double? HeLatitudeDeg { get; set; }

        /// <summary>
        /// Долгота центра конца взлетно-посадочной полосы с высоким номером в десятичных градусах (положительное значение означает восток), если доступно.
        /// </summary>
        [Csv("he_longitude_deg")]
        public double? HeLongitudeDeg { get; set; }

        /// <summary>
        /// Высота над уровнем моря конца взлетно-посадочной полосы с большим номером в футах.
        /// </summary>
        [Csv("he_elevation_ft")]
        public int? HeElevationFt { get; set; }

        /// <summary>
        /// Курс конца взлетно-посадочной полосы с большим номером в градусах истинного ( не магнитного).
        /// </summary>
        [Csv("he_heading_degT")]
        public double? HeHeadingDegT { get; set; }

        /// <summary>
        /// Длина смещенного порога (если есть) конца взлетно-посадочной полосы с большим номером в футах.
        /// </summary>
        [Csv("he_displaced_threshold_ft")]
        public int? HeDisplacedThresholdFt { get; set; }

        public override string ToString()
        {
            return $"{Id} ; {AirportRef} ; {AirportIdent} ; {LengthFt} ; {WidthFt} ; {Surface} ; {Lighted} ; {Closed} ; {LeIdent} ; {LeLatitudeDeg} ; " +
                $"{LeLongitudeDeg} ; {LeElevationFt} ; {LeHeadingDegT} ; {LeDisplacedThresholdFt} ; {HeIdent} ; {HeLatitudeDeg} ; {HeLongitudeDeg} ; " +
                $"{HeElevationFt} ; {HeHeadingDegT} ; {HeDisplacedThresholdFt}";
        }


    }
}
