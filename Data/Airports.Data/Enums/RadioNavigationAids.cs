using System.ComponentModel;

namespace Airports.Data.Enums
{
    public enum RadioNavigationAids
    {
        /// <summary>Гражданский VOR без совмещенного DME.</summary>
        [Description("VOR")]
        VOR,

        /// <summary>Гражданский VOR с совмещенным DME.</summary>
        [Description("VOR-DME")]
        VOR_DME,

        /// <summary>Гражданский VOR совмещен с военным TACAN (также может использоваться как DME).</summary>
        [Description("VORTAC")]
        VORTAC,

        /// <summary>Военный TACAN без гражданского VOR, который может использоваться гражданскими лицами в качестве DME.</summary>
        [Description("TACAN")]
        TACAN,

        /// <summary>Ненаправленный маяк без совместно расположенного DME.</summary>
        [Description("NDB")]
        NDB,

        /// <summary>Маяк ненаправленного действия с совместно расположенным DME.</summary>
        [Description("NDB-DME")]
        NDB_DME,

        /// <summary>Автономное дальномерное оборудование.</summary>
        [Description("DME")]
        DME
    }
}
