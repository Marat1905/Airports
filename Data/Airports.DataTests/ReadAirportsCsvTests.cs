using Microsoft.VisualStudio.TestTools.UnitTesting;
using Airports.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airports.Data.Models;
using System.IO.Compression;
using System.Reflection;

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
            ReadAirportsCsv readAirports = new ReadAirportsCsv(zipPath);
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
                var actual = ReadAirportsCsv.ToCsvFields<AirportInfo>(Actuals[i]);
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
            ReadAirportsCsv readAirportFrequencies = new ReadAirportsCsv(zipPath);
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
                var actual = ReadAirportsCsv.ToCsvFields<AirportFrequenceInfo>(Actuals[i]);
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
            ReadAirportsCsv readCountries = new ReadAirportsCsv(zipPath);
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
                var actual = ReadAirportsCsv.ToCsvFields<CountryInfo>(Actuals[i]);
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
            ReadAirportsCsv readNavaids = new ReadAirportsCsv(zipPath);
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
                var actual = ReadAirportsCsv.ToCsvFields<NavaidInfo>(Actuals[i]);
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
            ReadAirportsCsv readRegions = new ReadAirportsCsv(zipPath);
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
                var actual = ReadAirportsCsv.ToCsvFields<RegionInfo>(Actuals[i]);
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
            ReadAirportsCsv readRunways = new ReadAirportsCsv(zipPath);
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
                var actual = ReadAirportsCsv.ToCsvFields<RunwayInfo>(Actuals[i]);
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