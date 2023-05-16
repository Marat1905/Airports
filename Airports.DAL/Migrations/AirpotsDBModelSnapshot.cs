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

            modelBuilder.Entity("Airports.DAL.Entityes.Airport", b =>
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IataCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ident")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsoCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsoRegion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keywords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("LatitudeDeg")
                        .HasColumnType("float");

                    b.Property<string>("LocalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("LongitudeDeg")
                        .HasColumnType("float");

                    b.Property<string>("Municipality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScheduledService")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("WikipediaLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.AirportFrequence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AirportIdent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AirportRef")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("FrequencyMhz")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AirportFrequences");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Continent")
                        .HasColumnType("int");

                    b.Property<string>("Keywords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WikipediaLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.Navaid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AssociatedAirport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DmeChannel")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FrequencyKhz")
                        .HasColumnType("int");

                    b.Property<string>("Ident")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsoCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("LatitudeDeg")
                        .HasColumnType("float");

                    b.Property<double?>("LongitudeDeg")
                        .HasColumnType("float");

                    b.Property<double?>("MagneticVariationDeg")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Power")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("SlavedVariationDeg")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UsageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Navaids");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Continent")
                        .HasColumnType("int");

                    b.Property<string>("IsoCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keywords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WikipediaLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Airports.DAL.Entityes.Runway", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AirportIdent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("HeLatitudeDeg")
                        .HasColumnType("float");

                    b.Property<double?>("HeLongitudeDeg")
                        .HasColumnType("float");

                    b.Property<int?>("LeDisplacedThresholdFt")
                        .HasColumnType("int");

                    b.Property<int?>("LeElevationFt")
                        .HasColumnType("int");

                    b.Property<double?>("LeHeadingDegT")
                        .HasColumnType("float");

                    b.Property<string>("LeIdent")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WidthFt")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Runways");
                });
#pragma warning restore 612, 618
        }
    }
}
