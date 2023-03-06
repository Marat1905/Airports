using Airports.Data.Infrastructure.Attributes;

namespace Airports.Data.Models
{
    /// <summary>Радионавигационные средства и частоты. </summary>
    public class AirportFrequence
    {
        /// <summary>
        /// Внутренний целочисленный идентификатор OurAirports для частоты. Это останется постоянным, даже если изменится радиочастота или описание.
        /// </summary>
        [Csv("id")]
        public int Id { get; set; }

        /// <summary>
        /// Внутренний целочисленный внешний ключ, 
        /// соответствующий столбцу id для связанного аэропорта в airports.csv . 
        /// ( airport_ident является лучшей альтернативой.)
        /// </summary>
        [Csv("airport_ref")]
        public int AirportRef { get; set; }

        /// <summary>
        /// Видимая извне строка внешнего ключа, соответствующая столбцу ident для связанного аэропорта в airports.csv .
        /// </summary>
        [Csv("airport_ident")]
        public string AirportIdent { get; set; }

        /// <summary>
        /// Код типа частоты. Это не (в настоящее время) контролируемый словарь, но, вероятно, скоро будет. 
        /// </summary>
        [Csv("type")]
        public string Type { get; set; }

        /// <summary>
        /// Описание частоты, как правило, так, как пилот открывает на ней вызов.
        /// </summary>
        [Csv("description")]
        public string Description { get; set; }

        /// <summary>
        /// Частота радиоголоса в мегагерцах. Обратите внимание, что одна и та же частота может появляться несколько раз для аэропорта, выполняя разные функции.
        /// </summary>
        [Csv("frequency_mhz")]
        public double? FrequencyMhz { get; set; }

        public override string ToString()
        {
            return $"{Id} ; {AirportRef} ; {AirportIdent} ; {Type} ; {Description} ;  {FrequencyMhz}";
        }
    }
}
