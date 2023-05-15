using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Airports.Lib.Enums
{
    /// <summary>
    /// Тип аэропорта.
    /// </summary>
    public enum TypeAirport
    {
        /// <summary>
        /// Сухопутный аэропорт с регулярным обслуживанием крупных авиалиний
        /// с миллионами пассажиров в год или с крупной военной базой). 
        /// </summary>
        [Description("large_airport")]
        LargeAirport,
        /// <summary>
        /// Наземный аэропорт с регулярными региональными авиалиниями, 
        /// регулярными авиалиниями общего назначения или военными
        /// </summary>
        [Description("medium_airport")]
        MediumAirport,
        /// <summary>
        /// Наземный аэропорт с небольшим количеством регулярных рейсов или без них,
        /// легким движением авиации общего назначения.
        /// </summary>
        [Description("small_airport")]
        SmallAirport,
        /// <summary>
        /// Вертолетная площадка без взлетно-посадочных полос для самолетов.
        /// </summary>
        [Description("heliport")]
        Heliport,
        /// <summary>
        /// Зона стыковки/заправки гидросамолетов, без помещений для наземных самолетов.
        /// </summary>
        [Description("seaplane_base")]
        SeaplaneBase,
        /// <summary>
        /// Площадка для запуска воздушных шаров.
        /// </summary>
        [Description("balloonport")]
        Balloonport,
        /// <summary>
        /// Любой тип аэропорта, который больше не работает.
        /// </summary>
        [Description("closed")]
        Closed
    }
}
