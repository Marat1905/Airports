using Airports.DAL.Entityes.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airports.DAL.Entityes
{
    /// <summary>Взлетно посадочная полоса </summary>
    [Table("Runways")]
    public class RunwayDBModel : Entity
    {
        /// <summary>
        /// Внутренний целочисленный внешний ключ, соответствующий столбцу id для связанного аэропорта в airports.csv . ( airport_ident является лучшей альтернативой.)
        /// </summary>
        public int AirportRef { get; set; }

        /// <summary>
        /// Видимая извне строка внешнего ключа, соответствующая столбцу ident для связанного аэропорта в airports.csv 
        /// </summary>
        public string AirportIdent { get; set; }

        /// <summary>
        /// Длина всей поверхности взлетно-посадочной полосы (включая смещенные пороги, зоны выбега и т. д.) в футах.
        /// </summary>
        public int? LengthFt { get; set; }

        /// <summary>
        /// Ширина поверхности взлетно-посадочной полосы в футах.
        /// </summary>
        public int? WidthFt { get; set; }

        /// <summary>
        /// Код типа покрытия взлетно-посадочной полосы. Это еще не контролируемый словарь, но, вероятно, скоро будет. Некоторые общие значения включают «ASP» (асфальт), «TURF» (дерн), «CON» (бетон), «GRS» (трава), «GRE» (гравий), «WATER» (вода) и «UNK». (неизвестный).
        /// </summary>
        public string Surface { get; set; }

        /// <summary>
        /// 1, если поверхность освещена ночью, 0 в противном случае. (Обратите внимание, что это не соответствует файлу airports.csv, в котором вместо 1 и 0 используются «да» и «нет».)
        /// </summary>
        public int? Lighted { get; set; }

        /// <summary>
        ///1, если поверхность взлетно-посадочной полосы в настоящее время закрыта, 0 в противном случае.
        /// </summary>
        public int? Closed { get; set; }

        /// <summary>
        /// Идентификатор конца взлетно-посадочной полосы с меньшим номером.
        /// </summary>
        public string LeIdent { get; set; }

        /// <summary>
        /// Широта центра конца взлетно-посадочной полосы с низким номером в десятичных градусах (положительное значение означает север), если доступно.
        /// </summary>
        public double? LeLatitudeDeg { get; set; }

        /// <summary>
        /// Долгота центра конца взлетно-посадочной полосы с низким номером в десятичных градусах (положительное значение означает восток), если доступно.
        /// </summary>
        public double? LeLongitudeDeg { get; set; }

        /// <summary>
        /// Высота над уровнем моря конца взлетно-посадочной полосы с низким номером в футах.
        /// </summary>
        public int? LeElevationFt { get; set; }

        /// <summary>
        /// Курс конца взлетно-посадочной полосы с меньшим номером в градусах истинного ( не магнитного).
        /// </summary>
        public double? LeHeadingDegT { get; set; }

        /// <summary>
        /// Длина смещенного порога (если есть) конца взлетно-посадочной полосы с меньшим номером в футах.
        /// </summary>
        public int? LeDisplacedThresholdFt { get; set; }

        /// <summary>
        /// Идентификатор конца взлетно-посадочной полосы с большим номером.
        /// </summary>
        public string HeIdent { get; set; }

        /// <summary>
        /// Широта центра конца взлетно-посадочной полосы с высоким номером в десятичных градусах (положительное значение означает север), если доступно.
        /// </summary>
        public double? HeLatitudeDeg { get; set; }

        /// <summary>
        /// Долгота центра конца взлетно-посадочной полосы с высоким номером в десятичных градусах (положительное значение означает восток), если доступно.
        /// </summary>
        [Column(TypeName = "float")]
        public decimal? HeLongitudeDeg { get; set; }

        /// <summary>
        /// Высота над уровнем моря конца взлетно-посадочной полосы с большим номером в футах.
        /// </summary>
        public int? HeElevationFt { get; set; }

        /// <summary>
        /// Курс конца взлетно-посадочной полосы с большим номером в градусах истинного ( не магнитного).
        /// </summary>
        public double? HeHeadingDegT { get; set; }

        /// <summary>
        /// Длина смещенного порога (если есть) конца взлетно-посадочной полосы с большим номером в футах.
        /// </summary>
        public int? HeDisplacedThresholdFt { get; set; }
    }
}
