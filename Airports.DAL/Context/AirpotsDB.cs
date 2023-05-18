using Airports.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Airports.DAL.Context
{
    public class AirpotsDB:DbContext
    {
        public DbSet<AirportDBModel> Airports { get; set; }

        public DbSet<AirportFrequenceDBModel> AirportFrequences { get; set; }

        public DbSet<CountryDBModel> Countries { get; set; }

        public DbSet<NavaidDBModel> Navaids { get; set; }

        public DbSet<RegionDBModel> Regions { get; set; }

        public DbSet<RunwayDBModel> Runways { get; set; }


        public AirpotsDB(DbContextOptions<AirpotsDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirportDBModel>().Property(o => o.LatitudeDeg).HasPrecision(25, 16);

            base.OnModelCreating(modelBuilder);
        }
    }
}
