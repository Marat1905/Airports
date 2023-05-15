using Airports.DAL.Entityes.Base;

namespace Airports.DAL.Entityes
{
    /// <summary>Радионавигационные средства и частоты. </summary>
    public class AirportFrequence : Entity
    {
        /// <summary>
        /// Внутренний целочисленный внешний ключ, 
        /// соответствующий столбцу id для связанного аэропорта в airports.csv . 
        /// ( airport_ident является лучшей альтернативой.)
        /// </summary>
        public int AirportRef { get; set; }

        /// <summary>
        /// Видимая извне строка внешнего ключа, соответствующая столбцу ident для связанного аэропорта в airports.csv .
        /// </summary>
        public string AirportIdent { get; set; }

        /// <summary>
        /// Код типа частоты. Это не (в настоящее время) контролируемый словарь, но, вероятно, скоро будет. 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Описание частоты, как правило, так, как пилот открывает на ней вызов.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Частота радиоголоса в мегагерцах. Обратите внимание, что одна и та же частота может появляться несколько раз для аэропорта, выполняя разные функции.
        /// </summary>
        public double? FrequencyMhz { get; set; }
    }
}
