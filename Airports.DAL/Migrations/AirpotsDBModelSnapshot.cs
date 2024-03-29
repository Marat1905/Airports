﻿// <auto-generated />
using System;
using Airports.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Airports.DAL.Migrations
{
    [DbContext(typeof(AirpotsDB))]
    partial class AirpotsDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Airports.DAL.Entityes.AirportDBModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Continent")
                        .HasColumnType("int");

                    b.Property<int?>("ElevationFt")
                        .HasColumnType("int");

                    b.Property<string>("GpsCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IataCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ident")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Identificator")
                        .HasColumnType("int");

                    b.Property<string>("IsoCountry")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IsoRegion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Keywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("LatitudeDeg")
                        .HasPrecision(25, 16)
                        .HasColumnType("decimal(25,16)");

                    b.Property<string>("LocalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("LongitudeDeg")
                        .HasPrecision(25, 16)
                        .HasColumnType("decimal(25,16)");

                    b.Property<string>("Municipality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScheduledService")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("WikipediaLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Identificator")
                        .IsUnique();

                    b.HasIndex("IsoCountry");

                    b.HasIndex("IsoRegion");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.AirportFrequenceDBModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AirportIdent")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AirportRef")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("FrequencyMhz")
                        .HasColumnType("float");

                    b.Property<int>("Identificator")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AirportIdent");

                    b.HasIndex("Identificator")
                        .IsUnique();

                    b.ToTable("AirportFrequences");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.CountryDBModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Continent")
                        .HasColumnType("int");

                    b.Property<int>("Identificator")
                        .HasColumnType("int");

                    b.Property<string>("Keywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WikipediaLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Identificator")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.NavaidDBModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AssociatedAirport")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DmeChannel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DmeElevationFt")
                        .HasColumnType("int");

                    b.Property<int?>("DmeFrequencyKhz")
                        .HasColumnType("int");

                    b.Property<double?>("DmeLatitudeDeg")
                        .HasColumnType("float");

                    b.Property<double?>("DmeLongitudeDeg")
                        .HasColumnType("float");

                    b.Property<int?>("ElevationFt")
                        .HasColumnType("int");

                    b.Property<string>("Filename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FrequencyKhz")
                        .HasColumnType("int");

                    b.Property<string>("Ident")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Identificator")
                        .HasColumnType("int");

                    b.Property<string>("IsoCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("LatitudeDeg")
                        .HasColumnType("float");

                    b.Property<double?>("LongitudeDeg")
                        .HasColumnType("float");

                    b.Property<double?>("MagneticVariationDeg")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Power")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("SlavedVariationDeg")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UsageType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssociatedAirport");

                    b.HasIndex("Identificator")
                        .IsUnique();

                    b.ToTable("Navaids");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.RegionDBModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Continent")
                        .HasColumnType("int");

                    b.Property<int>("Identificator")
                        .HasColumnType("int");

                    b.Property<string>("IsoCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WikipediaLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Identificator")
                        .IsUnique();

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.RunwayDBModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AirportIdent")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AirportRef")
                        .HasColumnType("int");

                    b.Property<int?>("Closed")
                        .HasColumnType("int");

                    b.Property<int?>("HeDisplacedThresholdFt")
                        .HasColumnType("int");

                    b.Property<int?>("HeElevationFt")
                        .HasColumnType("int");

                    b.Property<double?>("HeHeadingDegT")
                        .HasColumnType("float");

                    b.Property<string>("HeIdent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("HeLatitudeDeg")
                        .HasColumnType("float");

                    b.Property<decimal?>("HeLongitudeDeg")
                        .HasPrecision(25, 16)
                        .HasColumnType("decimal(25,16)");

                    b.Property<int>("Identificator")
                        .HasColumnType("int");

                    b.Property<int?>("LeDisplacedThresholdFt")
                        .HasColumnType("int");

                    b.Property<int?>("LeElevationFt")
                        .HasColumnType("int");

                    b.Property<double?>("LeHeadingDegT")
                        .HasColumnType("float");

                    b.Property<string>("LeIdent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("LeLatitudeDeg")
                        .HasColumnType("float");

                    b.Property<double?>("LeLongitudeDeg")
                        .HasColumnType("float");

                    b.Property<int?>("LengthFt")
                        .HasColumnType("int");

                    b.Property<int?>("Lighted")
                        .HasColumnType("int");

                    b.Property<string>("Surface")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WidthFt")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirportIdent");

                    b.HasIndex("Identificator")
                        .IsUnique();

                    b.ToTable("Runways");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.AirportDBModel", b =>
                {
                    b.HasOne("Airports.DAL.Entityes.CountryDBModel", "CountryDB")
                        .WithMany()
                        .HasForeignKey("IsoCountry")
                        .HasPrincipalKey("Code");

                    b.HasOne("Airports.DAL.Entityes.RegionDBModel", "RegionDB")
                        .WithMany()
                        .HasForeignKey("IsoRegion")
                        .HasPrincipalKey("Code");

                    b.Navigation("CountryDB");

                    b.Navigation("RegionDB");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.AirportFrequenceDBModel", b =>
                {
                    b.HasOne("Airports.DAL.Entityes.AirportDBModel", null)
                        .WithMany("AirportFrequencesDB")
                        .HasForeignKey("AirportIdent")
                        .HasPrincipalKey("Ident");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.NavaidDBModel", b =>
                {
                    b.HasOne("Airports.DAL.Entityes.AirportDBModel", null)
                        .WithMany("NavaidsDB")
                        .HasForeignKey("AssociatedAirport")
                        .HasPrincipalKey("Ident");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.RunwayDBModel", b =>
                {
                    b.HasOne("Airports.DAL.Entityes.AirportDBModel", null)
                        .WithMany("RunwaysDB")
                        .HasForeignKey("AirportIdent")
                        .HasPrincipalKey("Ident");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.AirportDBModel", b =>
                {
                    b.Navigation("AirportFrequencesDB");

                    b.Navigation("NavaidsDB");

                    b.Navigation("RunwaysDB");
                });
#pragma warning restore 612, 618
        }
    }
}
