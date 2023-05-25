using Airports.DAL.Entityes;
using Microsoft.EntityFrameworkCore;

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
            //Настраиваем точность и масштаб свойства LatitudeDeg
            modelBuilder.Entity<AirportDBModel>()
                        .Property(o => o.LatitudeDeg).HasPrecision(25, 16);
            //Настраиваем точность и масштаб свойства LongitudeDeg
            modelBuilder.Entity<AirportDBModel>()
                        .Property(o => o.LongitudeDeg).HasPrecision(25, 16);

            //Настраиваем точность и масштаб свойства HeLongitudeDeg
            modelBuilder.Entity<RunwayDBModel>()
                        .Property(o => o.HeLongitudeDeg).HasPrecision(25, 16);

            //Создаем внешний ключ для связи один ко многим между объектами 
            modelBuilder.Entity<AirportDBModel>()                      
                        .HasMany(e => e.AirportFrequencesDB)
                        .WithOne()
                        .HasForeignKey(e => e.AirportIdent)
                        .HasPrincipalKey(e => e.Ident)
                        ;
            //Создаем внешний ключ для связи один ко многим между объектами 
            modelBuilder.Entity<AirportDBModel>()
                        .HasMany(e => e.RunwaysDB)
                        .WithOne()
                        .HasForeignKey(e => e.AirportIdent)
                        .HasPrincipalKey(e => e.Ident)
                        ;
            //Создаем внешний ключ для связи один ко многим между объектами 
            modelBuilder.Entity<AirportDBModel>()
                        .HasMany(e => e.NavaidsDB)
                        .WithOne()
                        .HasForeignKey(e => e.AssociatedAirport)
                        .HasPrincipalKey(e => e.Ident)
                        ;

            //Создаем внешний ключ для связи один ко многим между объектами
            modelBuilder.Entity<AirportDBModel>()
                        .HasOne(e => e.RegionDB)
                        .WithMany()
                        .HasForeignKey(e => e.IsoRegion)
                        .HasPrincipalKey(e => e.Code)
                        ;


            ////Создаем внешний ключ для связи один ко многим между объектами
            modelBuilder.Entity<AirportDBModel>()
                        .HasOne(e => e.CountryDB)
                        .WithMany()
                        .HasForeignKey(e => e.IsoCountry)
                        .HasPrincipalKey(e => e.Code)
                        ;





            base.OnModelCreating(modelBuilder);
        }
    }
}
