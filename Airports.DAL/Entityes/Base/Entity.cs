using Airports.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Airports.DAL.Entityes.Base
{
    [Index(nameof(Identificator), IsUnique = true)]
    public abstract class Entity:IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Внутренний целочисленный идентификатор OurAirports для аэропорта.
        /// Это останется постоянным, даже если код аэропорта изменится.
        /// </summary>
        public int Identificator { get; set; }
    }
}
