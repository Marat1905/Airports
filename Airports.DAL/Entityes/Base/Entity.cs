using System;
using System.Collections.Generic;
using System.Text;

namespace Airports.DAL.Entityes.Base
{
    public abstract class Entity
    {
        /// <summary>
        /// Внутренний целочисленный идентификатор OurAirports для навигационного средства. Это останется постоянным, даже если идентификатор навигационного средства или частота изменятся.
        /// </summary>
        public int Id { get; set; }     
    }
}
