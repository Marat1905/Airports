using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airports.Data.Models;
using System.IO.Compression;
using System.Reflection;
using Airports.Data.Service;
using Airports.Data.Infrastructure.Extensions;

namespace Airports.Data.Tests
{
    [TestClass()]
    public class ReadAirportsCsvTests
    {
        string zipPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Tests\\TestConsole\\Airports.zip");
        //string zipPath = @"C:\Users\Marat\Downloads\Airports.zip";

        [TestMethod()]
        public void ReadAirportsCsvTest()
        {
            //Arrange
            string fileAirports = "airports.csv"; ;
            List<AirportInfo> Actuals = new List<AirportInfo>();
            List<string> Expecteds = new List<string>();
            ReadAirportsCsvService readAirports = new ReadAirportsCsvService(zipPath);
            // Act
            foreach (var item in ReadCsv(zipPath, fileAirports))
            {
                Expecteds.Add(item);
            }
            foreach (var item in readAirports.GetCsv<AirportInfo>(fileAirports))
            {
                Actuals.Add(item);
            }
            //Assert
            Assert.AreEqual(Expecteds.Count, Actuals.Count);

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = readAirports.ToCsvFields<AirportInfo>(Actuals[i]);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void ReadAirportFrequenciesCsvTest()
        {
            //Arrange
            string fileAirportFrequencies = "airport-frequencies.csv";
            List<AirportFrequenceInfo> Actuals = new List<AirportFrequenceInfo>();
            List<string> Expecteds = new List<string>();
            ReadAirportsCsvService readAirportFrequencies = new ReadAirportsCsvService(zipPath);
            // Act
            foreach (var item in ReadCsv(zipPath, fileAirportFrequencies))
            {
                Expecteds.Add(item);
            }
            foreach (var item in readAirportFrequencies.GetCsv<AirportFrequenceInfo>(fileAirportFrequencies))
            {
                Actuals.Add(item);
            }
            //Assert
            //Проверка количество записей
            Assert.AreEqual(Expecteds.Count, Actuals.Count);

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = readAirportFrequencies.ToCsvFields<AirportFrequenceInfo>(Actuals[i]);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void ReadCountriesCsvTest()
        {
            //Arrange
            string fileCountries = "countries.csv";
            List<CountryInfo> Actuals = new List<CountryInfo>();
            List<string> Expecteds = new List<string>();
            ReadAirportsCsvService readCountries = new ReadAirportsCsvService(zipPath);
            // Act
            foreach (var item in ReadCsv(zipPath, fileCountries))
            {
                Expecteds.Add(item);
            }
            foreach (var item in readCountries.GetCsv<CountryInfo>(fileCountries))
            {
                Actuals.Add(item);
            }
            //Assert
            //Проверка количество записей
            Assert.AreEqual(Expecteds.Count, Actuals.Count);

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = readCountries.ToCsvFields<CountryInfo>(Actuals[i]);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void ReadNavaidsCsvTest()
        {
            //Arrange
            string fileNavaids = "navaids.csv";
            List<NavaidInfo> Actuals = new List<NavaidInfo>();
            List<string> Expecteds = new List<string>();
            ReadAirportsCsvService readNavaids = new ReadAirportsCsvService(zipPath);
            // Act
            foreach (var item in ReadCsv(zipPath, fileNavaids))
            {
                Expecteds.Add(item);
            }
            foreach (var item in readNavaids.GetCsv<NavaidInfo>(fileNavaids))
            {
                Actuals.Add(item);
            }
            //Assert
            //Проверка количество записей
            Assert.AreEqual(Expecteds.Count, Actuals.Count);

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = readNavaids.ToCsvFields<NavaidInfo>(Actuals[i]);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void ReadRegionsCsvTest()
        {
            //Arrange
            string fileRegions = "regions.csv";
            List<RegionInfo> Actuals = new List<RegionInfo>();
            List<string> Expecteds = new List<string>();
            ReadAirportsCsvService readRegions = new ReadAirportsCsvService(zipPath);
            // Act
            foreach (var item in ReadCsv(zipPath, fileRegions))
            {
                Expecteds.Add(item);
            }
            foreach (var item in readRegions.GetCsv<RegionInfo>(fileRegions))
            {
                Actuals.Add(item);
            }
            //Assert
            //Проверка количество записей
            Assert.AreEqual(Expecteds.Count, Actuals.Count);

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = readRegions.ToCsvFields<RegionInfo>(Actuals[i]);
               Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void ReadRunwaysCsvTest()
        {
            //Arrange
            string fileRunways = "runways.csv";
            List<RunwayInfo> Actuals = new List<RunwayInfo>();
            List<string> Expecteds = new List<string>();
            ReadAirportsCsvService readRunways = new ReadAirportsCsvService(zipPath);
            // Act
            foreach (var item in ReadCsv(zipPath, fileRunways))
            {
                Expecteds.Add(item);
            }
            foreach (var item in readRunways.GetCsv<RunwayInfo>(fileRunways))
            {
                Actuals.Add(item);
            }
            //Assert
            //Проверка количество записей
            Assert.AreEqual(Expecteds.Count, Actuals.Count);

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = readRunways.ToCsvFields<RunwayInfo>(Actuals[i]);
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
    }
}