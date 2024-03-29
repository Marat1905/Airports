﻿using Airports.DAL.Entityes;
using Airports.DAL.Extensions;
using Airports.Data.Infrastructure.Extensions;
using Airports.Data.Models;
using Airports.Data.Service;
using Airports.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO.Compression;
using System.Text;
using TestConsole;
using TestConsole.Data;

namespace Airports.DataTests
{
    [TestClass()]
    public class EntityAirportsTest
    {
        static string  zipPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Tests\\TestConsole\\Airports.zip");
        //string zipPath = @"C:\Users\Marat\Downloads\Airports.zip";
        private static IHost __Host;
        private static IServiceProvider Services;

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            // _services = Program.CreateHostBuilder(new string[] { }).Build().Services; // one line
            IHost Host = __Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
            Services = Host.Services;
            using (var scope = Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync().Wait();
            }
        }

        [TestMethod()]
        public void T01_RegionsEntity()
        {
            //Arrange
            IRepository<RegionDBModel>? repository = Services.CreateScope().ServiceProvider.GetService<IRepository<RegionDBModel>>();
            string file = "regions.csv"; ;
            List<string> Expecteds = new List<string>();
            ReadAirportsCsvService readAirports = new ReadAirportsCsvService(zipPath);

            // Act
            foreach (var item in ReadCsv(zipPath, file))
            {
                Expecteds.Add(item);
            }
            repository!.AutoSaveChanges = false;
            foreach (var item in readAirports.GetCsv<RegionInfo>(file))
            {
                repository?.Add(item.ModelMap<RegionInfo, RegionDBModel>());
            }
            repository.SaveAs();
            //Assert

            Assert.AreEqual(Expecteds.Count, repository?.Items.Count());

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = readAirports.ToCsvFields<RegionInfo>(repository!.Get(i + 1).ModelMapInfo<RegionDBModel, RegionInfo>());
                //var actual = ReadAirportsCsvService.ToCsvFields<RegionInfo>(repository!.Get(i + 1).ModelMapInfo<RegionDBModel, RegionInfo>());
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void T02_CountriesEntity()
        {
            //Arrange
            IRepository<CountryDBModel>? repository = Services.CreateScope().ServiceProvider.GetService<IRepository<CountryDBModel>>();
            string file = "countries.csv"; ;
            List<string> Expecteds = new List<string>();
            ReadAirportsCsvService readAirports = new ReadAirportsCsvService(zipPath);

            // Act
            foreach (var item in ReadCsv(zipPath, file))
            {
                Expecteds.Add(item);
            }
            repository!.AutoSaveChanges = false;
            foreach (var item in readAirports.GetCsv<CountryInfo>(file))
            {
                repository?.Add(item.ModelMap<CountryInfo, CountryDBModel>());
            }
            repository.SaveAs();
            //Assert

            Assert.AreEqual(Expecteds.Count, repository?.Items.Count());

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = readAirports.ToCsvFields<CountryInfo>(repository!.Get(i + 1).ModelMapInfo<CountryDBModel, CountryInfo>());
                //var actual = ReadAirportsCsvService.ToCsvFields<CountryInfo>(repository!.Get(i + 1).ModelMapInfo<CountryDBModel, CountryInfo>());
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void T03_AirportsEntity()
        {
            //Arrange
            IRepository<AirportDBModel>? repositoryAirport = Services.CreateScope().ServiceProvider.GetService<IRepository<AirportDBModel>>();
            string fileAirports = "airports.csv"; ;
            List<string> Expecteds = new List<string>();
            ReadAirportsCsvService readAirports = new ReadAirportsCsvService(zipPath);

            // Act
            foreach (var item in ReadCsv(zipPath, fileAirports))
            {
                Expecteds.Add(item);
            }
            repositoryAirport!.AutoSaveChanges = false;
            foreach (var item in readAirports.GetCsv<AirportInfo>(fileAirports))
            {
                repositoryAirport?.Add(item.ModelMap<AirportInfo, AirportDBModel>());
            }
            repositoryAirport.SaveAs();
            //Assert

            Assert.AreEqual(Expecteds.Count, repositoryAirport?.Items.Count());

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = readAirports.ToCsvFields<AirportInfo>(repositoryAirport!.Get(i + 1).ModelMapInfo<AirportDBModel, AirportInfo>());
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void T04_AirportFrequencesEntity()
        {
            //Arrange
            IRepository<AirportFrequenceDBModel>? repository = Services.CreateScope().ServiceProvider.GetService<IRepository<AirportFrequenceDBModel>>();
            string file = "airport-frequencies.csv"; ;
            List<string> Expecteds = new List<string>();
            ReadAirportsCsvService readAirports = new ReadAirportsCsvService(zipPath);

            // Act
            foreach (var item in ReadCsv(zipPath, file))
            {
                Expecteds.Add(item);
            }
            repository!.AutoSaveChanges = false;
            foreach (var item in readAirports.GetCsv<AirportFrequenceInfo>(file))
            {
                repository?.Add(item.ModelMap<AirportFrequenceInfo, AirportFrequenceDBModel>());
            }
            repository.SaveAs();
            //Assert

            Assert.AreEqual(Expecteds.Count, repository?.Items.Count());

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = readAirports.ToCsvFields<AirportFrequenceInfo>(repository!.Get(i + 1).ModelMapInfo<AirportFrequenceDBModel, AirportFrequenceInfo>());
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void T05_NavaidsEntity()
        {
            //Arrange
            IRepository<NavaidDBModel>? repository = Services.CreateScope().ServiceProvider.GetService<IRepository<NavaidDBModel>>();
            string file = "navaids.csv"; ;
            List<string> Expecteds = new List<string>();
            ReadAirportsCsvService readAirports = new ReadAirportsCsvService(zipPath);

            // Act
            foreach (var item in ReadCsv(zipPath, file))
            {
                Expecteds.Add(item);
            }
            repository!.AutoSaveChanges = false;
            foreach (var item in readAirports.GetCsv<NavaidInfo>(file))
            {
                repository?.Add(item.ModelMap<NavaidInfo, NavaidDBModel>());
            }
            repository.SaveAs();
            //Assert

            Assert.AreEqual(Expecteds.Count, repository?.Items.Count());

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = readAirports.ToCsvFields<NavaidInfo>(repository!.Get(i + 1).ModelMapInfo<NavaidDBModel, NavaidInfo>());
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void T06_RunwaysEntity()
        {
            //Arrange
            IRepository<RunwayDBModel>? repository = Services.CreateScope().ServiceProvider.GetService<IRepository<RunwayDBModel>>();
            string file = "runways.csv"; ;
            List<string> Expecteds = new List<string>();
            ReadAirportsCsvService readAirports = new ReadAirportsCsvService(zipPath);

            // Act
            foreach (var item in ReadCsv(zipPath, file))
            {
                Expecteds.Add(item);
            }
            repository!.AutoSaveChanges = false;
            foreach (var item in readAirports.GetCsv<RunwayInfo>(file))
            {
                repository?.Add(item.ModelMap<RunwayInfo, RunwayDBModel>());
            }
            repository.SaveAs();
            //Assert

            Assert.AreEqual(Expecteds.Count, repository?.Items.Count());

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = readAirports.ToCsvFields<RunwayInfo>(repository!.Get(i + 1).ModelMapInfo<RunwayDBModel, RunwayInfo>());
                Assert.AreEqual(expected, actual);
            }
        }

        public static IEnumerable<string> ReadCsv(string zipPath, string fileName, string separator = ",")
        {
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                var sample = archive.GetEntry(fileName);
                if (sample != null)
                {
                    using (var zipEntryStream = sample.Open())
                    {
                        using (StreamReader reader = new StreamReader(zipEntryStream, Encoding.Default))
                        {
                            var lines = reader.ReadLine();
                            while (!reader.EndOfStream)
                            {
                                yield return reader.ReadLine();
                            }

                        }
                    }
                }
            }
        }

        private static void ReadCsvToEntity<TDbModel, TInfo>(string zipPath, string fileAirports, IServiceProvider Services)
           where TInfo : class, new()
           where TDbModel : class, IEntity, new()
        {
            IRepository<TDbModel>? repository = Services.CreateScope().ServiceProvider.GetService<IRepository<TDbModel>>();
            ReadAirportsCsvService readAirports = new ReadAirportsCsvService(zipPath);
            List<TDbModel> DBModel = new List<TDbModel>();
            // не сохраняем каждую запись
            //repositoryAirport!.AutoSaveChanges = false;
            foreach (var item in readAirports.GetCsv<TInfo>(fileAirports))
            {
                DBModel.Add(item.ModelMap<TInfo, TDbModel>());
                //repositoryAirport?.Add(item.ModelMap<AirportInfo, AirportDBModel>());
                Console.WriteLine(item);
            }
            repository?.AddRange(DBModel);
            //repositoryAirport.SaveAs();
        }
    }
}
