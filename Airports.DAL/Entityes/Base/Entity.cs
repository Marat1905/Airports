using Airports.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Airports.DAL.Entityes.Base
{
    public abstract class Entity:IEntity
    {
        /// <summary>
        /// Внутренний целочисленный идентификатор OurAirports для навигационного средства. Это останется постоянным, даже если идентификатор навигационного средства или частота изменятся.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Identificator { get; set; }

        /// <summary>
        /// Внутренний целочисленный идентификатор OurAirports для аэропорта.
        /// Это останется постоянным, даже если код аэропорта изменится.
        /// </summary>
        public int Id { get; set; }
    }
}
