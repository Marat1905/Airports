using Airports.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airports.DAL.Context
{
    public class AirpotsDB:DbContext
    {
        public DbSet<Airport> Airports { get; set; }

        public DbSet<AirportFrequence> AirportFrequences { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Navaid> Navaids { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Runway> Runways { get; set; }


        public AirpotsDB(DbContextOptions<AirpotsDB> options) : base(options) { }
    }
}
