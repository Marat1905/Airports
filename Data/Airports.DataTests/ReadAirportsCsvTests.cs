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
        string zipPath = @"C:\Users\Marat\Downloads\Airports.zip";

        [TestMethod()]
        public void ReadAirportsCsvTest()
        {
            //Arrange

            string fileAirports = "airports.csv"; ;
            List<Airport> Actuals = new List<Airport>();
            List<string> Expecteds = new List<string>();
            ReadAirportsCsv readAirports = new ReadAirportsCsv(zipPath);
            // Act
            foreach (var item in ReadCsv(zipPath, fileAirports))
            {
                Expecteds.Add(item);
            }
            foreach (var item in readAirports.GetCsv<Airport>(fileAirports))
            {
                Actuals.Add(item);
            }
            //Assert

            Assert.AreEqual(Expecteds.Count, Actuals.Count);

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = ReadAirportsCsv.ToCsvFields<Airport>(Actuals[i]);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void ReadAirportFrequenciesCsvTest()
        {
            //Arrange

            string fileAirportFrequencies = "airport-frequencies.csv";
            List<AirportFrequence> Actuals = new List<AirportFrequence>();
            List<string> Expecteds = new List<string>();
            ReadAirportsCsv readAirportFrequencies = new ReadAirportsCsv(zipPath);
            // Act
            foreach (var item in ReadCsv(zipPath, fileAirportFrequencies))
            {
                Expecteds.Add(item);
            }
            foreach (var item in readAirportFrequencies.GetCsv<AirportFrequence>(fileAirportFrequencies))
            {
                Actuals.Add(item);
            }
            //Assert

            Assert.AreEqual(Expecteds.Count, Actuals.Count);

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = ReadAirportsCsv.ToCsvFields<AirportFrequence>(Actuals[i]);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void ReadCountriesCsvTest()
        {
            //Arrange

            string fileCountries = "countries.csv";
            List<Country> Actuals = new List<Country>();
            List<string> Expecteds = new List<string>();
            ReadAirportsCsv readCountries = new ReadAirportsCsv(zipPath);
            // Act
            foreach (var item in ReadCsv(zipPath, fileCountries))
            {
                Expecteds.Add(item);
            }
            foreach (var item in readCountries.GetCsv<Country>(fileCountries))
            {
                Actuals.Add(item);
            }
            //Assert

            Assert.AreEqual(Expecteds.Count, Actuals.Count);

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = ReadAirportsCsv.ToCsvFields<Country>(Actuals[i]);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void ReadNavaidsCsvTest()
        {
            //Arrange

            string fileNavaids = "navaids.csv";
            List<Navaid> Actuals = new List<Navaid>();
            List<string> Expecteds = new List<string>();
            ReadAirportsCsv readNavaids = new ReadAirportsCsv(zipPath);
            // Act
            foreach (var item in ReadCsv(zipPath, fileNavaids))
            {
                Expecteds.Add(item);
            }
            foreach (var item in readNavaids.GetCsv<Navaid>(fileNavaids))
            {
                Actuals.Add(item);
            }
            //Assert

            Assert.AreEqual(Expecteds.Count, Actuals.Count);

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = ReadAirportsCsv.ToCsvFields<Navaid>(Actuals[i]);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void ReadRegionsCsvTest()
        {
            //Arrange

            string fileRegions = "regions.csv";
            List<Region> Actuals = new List<Region>();
            List<string> Expecteds = new List<string>();
            ReadAirportsCsv readRegions = new ReadAirportsCsv(zipPath);
            // Act
            foreach (var item in ReadCsv(zipPath, fileRegions))
            {
                Expecteds.Add(item);
            }
            foreach (var item in readRegions.GetCsv<Region>(fileRegions))
            {
                Actuals.Add(item);
            }
            //Assert

            Assert.AreEqual(Expecteds.Count, Actuals.Count);

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = ReadAirportsCsv.ToCsvFields<Region>(Actuals[i]);
               Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void ReadRunwaysCsvTest()
        {
            //Arrange

            string fileRunways = "runways.csv";
            List<Runway> Actuals = new List<Runway>();
            List<string> Expecteds = new List<string>();
            ReadAirportsCsv readRunways = new ReadAirportsCsv(zipPath);
            // Act
            foreach (var item in ReadCsv(zipPath, fileRunways))
            {
                Expecteds.Add(item);
            }
            foreach (var item in readRunways.GetCsv<Runway>(fileRunways))
            {
                Actuals.Add(item);
            }
            //Assert

            Assert.AreEqual(Expecteds.Count, Actuals.Count);

            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = ReadAirportsCsv.ToCsvFields<Runway>(Actuals[i]);
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