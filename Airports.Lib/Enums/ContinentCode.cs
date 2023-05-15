using System.ComponentModel;


namespace Airports.Lib.Enums
{
    /// <summary>Код континента. </summary>
    public enum ContinentCode
    {
        /// <summary>Африка.</summary>
        [Description("AF")]
        Africa,
        /// <summary>Антарктида.</summary>
        [Description("AN")]
        Antarctica,
        /// <summary>Азия.</summary>
        [Description("AS")]
        Asia,
        /// <summary>Европа.</summary>
        [Description("EU")]
        Europe,
        /// <summary>Северная Америка.</summary>
        [Description("NA")]
        NorthAmerica,
        /// <summary>Океания.</summary>
        [Description("OC")]
        Oceania,
        /// <summary>Южная Америка.</summary>
        [Description("SA")]
        SouthAmerica,
    }
}
